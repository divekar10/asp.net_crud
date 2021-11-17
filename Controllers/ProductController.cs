using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList.Mvc.Core;
using X.PagedList;
using X.PagedList.Mvc;

namespace MvcCrud.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _Db;

        public ProductController(ProductContext Db)
        {
            _Db = Db;
        }
        public IActionResult ProductList(int? page)
        {
            try
            {
                var prolist = from a in _Db.productMaster
                              join b in _Db.catMaster
                              on a.catID equals b.catID into productData
                              from b in productData.DefaultIfEmpty()

                              select new productMaster
                              {
                                  productID = a.productID,
                                  productName = a.productName,
                                  catID = a.catID,

                                  Category = b == null ? "" : b.catName
                              };
                  

                //const int pageSize = 10;
                //if(pg < 1)
                //   pg = 1;
                

                //int recsCount = prolist.Count();
                //var pager = new Pager(recsCount, pg, pageSize);

                //int recSkip = (pg - 1) * pageSize;

                //var data = prolist.Skip(recSkip).Take(pager.PageSize).ToList();

                //this.ViewBag.Pager = pager;


                // return View(data);
                return View(prolist.ToList().ToPagedList(page ?? 1, 10));
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        public IActionResult Create(productMaster obj)
        {
            loadDDL();
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(productMaster obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.productID == 0)
                    {
                        _Db.productMaster.Add(obj);
                        await _Db.SaveChangesAsync();
                    }else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("ProductList");
                }
                return View();
            }
            catch (Exception ex)
            {

                return RedirectToAction("ProductList");
            }
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var pro = await _Db.productMaster.FindAsync(id);
                if(pro!=null)
                {
                    _Db.productMaster.Remove(pro);
                    await _Db.SaveChangesAsync();
                }
                return RedirectToAction("ProductList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("ProductList");
            }
        }


        private void loadDDL()
        {
            try
            {
                List<catMaster> catList = new List<catMaster>();
                catList = _Db.catMaster.ToList();
                catList.Insert(0, new catMaster { catID = 0, catName = "--Select Category--" });

                ViewBag.CatList = catList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
