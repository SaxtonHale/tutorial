using Phonebook.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Phonebook.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly PhonebookDbContext _context;

        public InitialHostDbBuilder(PhonebookDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
