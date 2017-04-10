using System.Threading.Tasks;
using Abp.Application.Services;
using Phonebook.Roles.Dto;

namespace Phonebook.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
