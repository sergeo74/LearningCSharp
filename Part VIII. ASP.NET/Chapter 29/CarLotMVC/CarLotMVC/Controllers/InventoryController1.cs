using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using System.Net;
using System.Web.Mvc;

namespace CarLotMVC.Controllers
{
    public class InventoryController1 : Controller
    {
        // private AutoLotEntities db = new AutoLotEntities(); //удалить!!!
        private readonly InventoryRepo _repo = new InventoryRepo();

        // GET: api/Inventory
        //public IQueryable<Inventory> GetInventory()
        //{
        //    return db.Inventory;
        //}

        // GET: api/Inventory/5
        //[ResponseType(typeof(Inventory))]
        //public IHttpActionResult GetInventory(int id)
        //{
        //    Inventory inventory = db.Inventory.Find(id);
        //    if (inventory == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(inventory);
        //}

        // PUT: api/Inventory/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutInventory(int id, Inventory inventory)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != inventory.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(inventory).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!InventoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Inventory
        //[ResponseType(typeof(Inventory))]
        //public IHttpActionResult PostInventory(Inventory inventory)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Inventory.Add(inventory);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = inventory.Id }, inventory);
        //}

        // DELETE: api/Inventory/5
        //[ResponseType(typeof(Inventory))]
        //public IHttpActionResult DeleteInventory(int id)
        //{
        //    Inventory inventory = db.Inventory.Find(id);
        //    if (inventory == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Inventory.Remove(inventory);
        //    db.SaveChanges();

        //    return Ok(inventory);
        //}
        //private bool InventoryExists(int id)
        //{
        //    return db.Inventory.Count(e => e.Id == id) > 0;
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = _repo.GetOne(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }
    }
}