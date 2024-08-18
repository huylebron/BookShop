using BookShop . data ;
using BookShop . Models ;
using Microsoft . AspNetCore . Mvc ;
using System . Net . WebSockets ;

namespace BookShop . Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db ;

        public CategoryController ( ApplicationDbContext db ) {
            this . _db = db ;
        }

        public IActionResult Index ( ) {
            IEnumerable < Category > objCategoryList = _db . Categories . ToList ( ) ;
            return View ( objCategoryList ) ;
        }

        public IActionResult Create ( ) {
            return View ( ) ;
        }

        //post
        [ HttpPost ] // counter faken ;
        [ ValidateAntiForgeryToken ] //  counter noob hacker :)))

        // auto post category 
        public IActionResult Create ( Category obj ) {
            if ( obj . Name == obj . DisplayOrder . ToString ( ) )
            {
                ModelState . AddModelError ( "CustomError" , "the Name must not same  " ) ;
            }

            if ( ModelState . IsValid )
            {
                _db . Categories . Add ( obj ) ;
                _db . SaveChanges ( ) ;
                return RedirectToAction ( "index" ) ;
            }

            return View ( obj ) ;
        }

        public IActionResult Edit ( int ? id ) {
            if ( id == null || id == 0 )
            {
                return NotFound ( ) ;
            }

            var categoryfromDb = _db . Categories . Find ( id ) ;
            var categoryfromDbfirst = _db . Categories . FirstOrDefault ( u => u . Id == id ) ;
            var categoryfromDbsingle = _db . Categories . SingleOrDefault ( u => u . Id == id ) ;

            if ( categoryfromDb == null )
            {
                return NotFound ( ) ;
            }


            return View ( categoryfromDb ) ;
        }

        //post
        [ HttpPost ] // counter faken ;
        [ ValidateAntiForgeryToken ] //  counter noob hacker :)))

        // auto post category 
        public IActionResult Edit ( Category obj ) {
            if ( obj . Name == obj . DisplayOrder . ToString ( ) )
            {
                ModelState . AddModelError ( "CustomError" , "the Name must not same  " ) ;
            }

            if ( ModelState . IsValid )
            {
                _db . Categories . Update ( obj ) ;
                _db . SaveChanges ( ) ;
                return RedirectToAction ( "index" ) ;
            }


            return View ( obj ) ;
        }


        public IActionResult Delete ( int ? id ) {
            if ( id == null || id == 0 )
            {
                return NotFound ( ) ;
            }

            var categoryfromDb = _db . Categories . Find ( id ) ;
            //var categoryfromDbfirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //  var categoryfromDbsingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if ( categoryfromDb == null )
            {
                return NotFound ( ) ;
            }


            return View ( categoryfromDb ) ;
        }

        //post
        [ HttpPost ] // counter faken ;
        [ ValidateAntiForgeryToken ] //  counter noob hacker :)))

        // auto post category 
        public IActionResult DeletePost ( int ? id ) {
            var obj = _db . Categories . Find ( id ) ;
            // var categoryfromDbfirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryfromDbsingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if ( obj == null )
            {
                return NotFound ( ) ;
            }
            else
            {
                _db . Categories . Remove ( obj ) ;
                _db . SaveChanges ( ) ;
                return RedirectToAction ( "index" ) ;
            }


            return View ( obj ) ;
        }
    }
}