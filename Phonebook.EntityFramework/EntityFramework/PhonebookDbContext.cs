using System.Data.Common;
using Abp.Zero.EntityFramework;
using Phonebook.Authorization.Roles;
using Phonebook.MultiTenancy;
using Phonebook.Users;

namespace Phonebook.EntityFramework
{
    public class PhonebookDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public PhonebookDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in PhonebookDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of PhonebookDbContext since ABP automatically handles it.
         */
        public PhonebookDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public PhonebookDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public PhonebookDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        public virtual IDbSet<Person> Persons { get; set; }

        //...other entities

        public PhoneBookDbContext()
            :base("Default")
        {

        }

        //...other codes
    }
}
