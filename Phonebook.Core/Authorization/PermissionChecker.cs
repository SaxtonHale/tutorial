using Abp.Authorization;
using Phonebook.Authorization.Roles;
using Phonebook.MultiTenancy;
using Phonebook.Users;

namespace Phonebook.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
