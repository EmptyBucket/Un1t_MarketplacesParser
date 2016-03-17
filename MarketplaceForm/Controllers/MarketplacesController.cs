using System.Linq;
using System.Web.Mvc;
using MarketplaceLocalDB.Repository;

namespace MarketplaceForm.Controllers
{
    public class MarketplacesController : Controller
    {
        private readonly LotsRepository _lotsRepository;

        public MarketplacesController()
        {
            _lotsRepository = new LotsRepository();
        }

        public ActionResult Index(string site, string customer, string dateCreated, string cost, string description, string dateStart,
            string dateEnd, string code, int countRows = 30, int page = 1)
        {
            var marketplaces = _lotsRepository.Get(site, customer, dateCreated, cost, description,
                dateStart, dateEnd, code);
            ViewBag.TotalCount = marketplaces.Count();
            marketplaces = marketplaces.Skip((page - 1)*countRows).Take(countRows);
            return View(marketplaces);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _lotsRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}