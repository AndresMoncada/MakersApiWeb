using MakersApiWeb.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakersApiWeb.Controllers
{
    [Route("api/Loan")]
    [ApiController]
    public class LoanController : BaseController
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return null;
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return null;
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return null;
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return null;
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return null;
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }
    }
}
