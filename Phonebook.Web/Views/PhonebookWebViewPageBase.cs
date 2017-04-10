using Abp.Web.Mvc.Views;

namespace Phonebook.Web.Views
{
    public abstract class PhonebookWebViewPageBase : PhonebookWebViewPageBase<dynamic>
    {

    }

    public abstract class PhonebookWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected PhonebookWebViewPageBase()
        {
            LocalizationSourceName = PhonebookConsts.LocalizationSourceName;
        }
    }
}