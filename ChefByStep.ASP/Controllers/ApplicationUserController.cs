namespace ChefByStep.ASP.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class ApplicationUserController : Controller
    {
        // GET: ApplicationUserController
        public ActionResult Index()
        {
            return this.View();
        }

        // GET: ApplicationUserController/Details/5
        public ActionResult Details(int id)
        {
            return this.View();
        }

        // GET: ApplicationUserController/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: ApplicationUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }

        // GET: ApplicationUserController/Edit/5
        public ActionResult Edit(int id)
        {
            return this.View();
        }

        // POST: ApplicationUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }

        // GET: ApplicationUserController/Delete/5
        public ActionResult Delete(int id)
        {
            return this.View();
        }

        // POST: ApplicationUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }
    }
}