using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public interface IPersonAppService : IApplicationService
    {
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);

        Task CreateOrUpdatePerson(CreatePersonInput input);

        Task DeletePerson(PeopleId input);

        Task<EditPersonDto> GetPersonForEdit(PeopleId input);

    }

    [AutoMapFrom(typeof(Person))]
    public class EditPersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }

    [AutoMapTo(typeof(Person))]
    public class CreatePersonInput
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(Person.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(Person.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(Person.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }

    public class PeopleId
    {
        public int Id { get; set; }
    }

    public class GetPeopleInput
    {
        public string Filter { get; set; }
    }

    [AutoMapFrom(typeof(Person))]
    public class PersonListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class PersonAppService : PhonebookAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public ListResultDto<PersonListDto> GetPeople(GetPeopleInput input)
        {
            var persons = _personRepository
                .GetAll()
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) ||
                        p.Surname.Contains(input.Filter) ||
                        p.EmailAddress.Contains(input.Filter)
                )
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Surname)
                .ToList();
            var result = persons.MapTo<List<PersonListDto>>();

            return new ListResultDto<PersonListDto>(result);
        }

        public async Task CreateOrUpdatePerson(CreatePersonInput input)
        {
            if (input.Id.HasValue)
            {
                await UpdatePerson(input);
            }
            else
            {
                await CreatePerson(input);
            }
        }


        private async Task UpdatePerson(CreatePersonInput input)
        {
            var person = input.MapTo<Person>();
            await _personRepository.UpdateAsync(person);
        }

        private async Task CreatePerson(CreatePersonInput input)
        {
            var person = input.MapTo<Person>();
            await _personRepository.InsertAsync(person);
        }

        public async Task DeletePerson(PeopleId input)
        {
           await _personRepository.DeleteAsync(input.Id);
        }

        public async Task<EditPersonDto> GetPersonForEdit(PeopleId input)
        {
            var person = await _personRepository.FirstOrDefaultAsync(x=>x.Id == input.Id);
            var result = person.MapTo<EditPersonDto>();

            return result;
        }
    }
}
