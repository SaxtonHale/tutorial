using System.Linq;
using Phonebook.EntityFramework;
using Phonebook.MultiTenancy;

namespace Phonebook.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly PhonebookDbContext _context;

        public DefaultTenantCreator(PhonebookDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
