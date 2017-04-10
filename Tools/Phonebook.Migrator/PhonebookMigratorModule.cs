using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Phonebook.EntityFramework;

namespace Phonebook.Migrator
{
    [DependsOn(typeof(PhonebookDataModule))]
    public class PhonebookMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<PhonebookDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}