using BookShop . data ;
using BookShop . Models ;
using Microsoft . AspNetCore . Mvc ;
using System . Net . WebSockets ;

namespace BookShop . Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db ;

        public CategoryController ( ApplicationDbContext db )
        { this . _db = db ; }

        public IActionResult Index ( )
        { IEnumerable < Category > objCategoryList = _db . Categories . ToList ( ) ;
          return View ( objCategoryList ) ; }
    }
}