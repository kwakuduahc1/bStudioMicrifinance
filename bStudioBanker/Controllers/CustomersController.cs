using BSSL;
using BSSL.ObjectModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bStudioBanker.Controllers
{
    public class CustomersController : Controller
    {
        readonly ITransactor<Customers> db;
        public CustomersController(ITransactor<Customers> accountsTransactor) => db = accountsTransactor;
        public async Task<IActionResult> Index()
        {
            var list =await db.List();
            return View(list);
        }
    }
}