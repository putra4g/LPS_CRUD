using LPS_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPS_CRUD.Controllers
{
	public class ProductController : Controller
	{
		ProdukDataAccessLayer objProdukDAL = new ProdukDataAccessLayer();

		// GET: ProductController
		public ActionResult Index()
		{
			List<Produk> produks = new List<Produk>();
			produks = objProdukDAL.GetAllProduk().ToList();
			return View(produks);
		}

		// GET: ProductController/Details/5
		public ActionResult Details(int id)
		{
			Produk produk = new Produk();
			produk = objProdukDAL.GetProdukData(id);
			return View(produk);
		}

		// GET: ProductController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ProductController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind] Produk objProduk)
		{
			if (ModelState.IsValid)
			{
				objProdukDAL.AddProduk(objProduk);
				return RedirectToAction("Index");
			}
			return View(objProduk);
		}

		// GET: ProductController/Edit/5
		public ActionResult Edit(int id)
		{
			Produk produk = new Produk();
			produk = objProdukDAL.GetProdukData(id);
			return View(produk);
		}

		// POST: ProductController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, [Bind] Produk objProduk)
		{
			if (id != objProduk.id)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				objProdukDAL.UpdateProduk(objProduk);
				return RedirectToAction("Index");
			}
			return View(objProdukDAL);
		}

		// GET: ProductController/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			Produk objproduk = objProdukDAL.GetProdukData(id);

			if (objproduk == null)
			{
				return NotFound();
			}
			return View(objproduk);
		}

		// POST: ProductController/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int ? id)
		{
			objProdukDAL.DeleteProduk(id);
			return RedirectToAction("Index");

		}
	}
}
