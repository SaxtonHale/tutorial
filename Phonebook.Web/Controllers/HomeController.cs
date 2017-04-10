using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Phonebook.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PhonebookControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}