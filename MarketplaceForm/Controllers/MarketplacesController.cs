using System.Linq;
using System.Net;
using System.Web.Mvc;
using MarketplaceDB;

namespace MarketplaceForm.Controllers
{
    public class MarketplacesController : Controller
    {
        private MarketplaceDBEntities db = new MarketplaceDBEntities();

        // GET: Marketplaces
        public ActionResult Index()
        {
            return View(db.Marketplace.ToList());
        }

        // GET: Marketplaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var marketplace = db.Marketplace.Find(id);
            return marketplace == null ? (ActionResult) HttpNotFound() : View(marketplace);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
