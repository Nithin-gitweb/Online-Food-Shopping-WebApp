using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TruYumCS_OrderFoodOnline.Models;

namespace TruYumCS_OrderFoodOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                ContextDefine contextDefine = new ContextDefine();
                List<Cart> carts = contextDefine.Carts.ToList();
                foreach (var item in carts)
                {
                    contextDefine.Carts.Remove(item);
                    contextDefine.SaveChanges();
                }
                return View();
            }
            catch(Exception e)
            {
                ViewBag.Exception = "Exception occured in " + this.GetType().Name + " Controller and in " + MethodBase.GetCurrentMethod().Name + " Action Name \n\n\n" + Convert.ToString(e);
                return View("ExceptionGen");
            }
        }
//-----------------------------------------------START OF ADMIN BLOCK------------------------------------------
        public ActionResult AdminIndex()
        {
            try
            {
                ContextDefine contextDefine = new ContextDefine();
                List<MenuItem> menuItems = contextDefine.MenuItems.ToList();
                return View(menuItems);
            }
            catch (Exception e)
            {
                ViewBag.Exception = "Exception occured in " + this.GetType().Name + " Controller and in " + MethodBase.GetCurrentMethod().Name + " Action Name \n\n\n" + Convert.ToString(e);
                return View("ExceptionGen");
            }
        }
        [HttpGet]
        public ActionResult AddNewItem()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Exception = "Exception occured in " + this.GetType().Name + " Controller and in " + MethodBase.GetCurrentMethod().Name + " Action Name \n\n\n" + Convert.ToString(e);
                return View("ExceptionGen");
            }
        }
        [HttpPost]
        public ActionResult AddNewItem(FormCollection formCollection)
        {
            try
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Name = formCollection["Name"];
                menuItem.Price = Convert.ToDouble(formCollection["Price"]);
                if (formCollection["Active"] == "true")
                    menuItem.Active = false;
                else
                    menuItem.Active = true;
                menuItem.DateOfLaunch = Convert.ToDateTime(formCollection["DateOfLaunch"]);
                if (formCollection["FreeDelivery"] == "true")
                    menuItem.FreeDelivery = true;
                else
                    menuItem.FreeDelivery = false;
                menuItem.Type = formCollection["Type"];
                ContextDefine contextDefine = new ContextDefine();
                contextDefine.MenuItems.Add(menuItem);
                contextDefine.SaveChanges();
                return View("AddNewItemConfirmation");
            }
            catch (Exception e)
            {
                ViewBag.Exception = "Exception occured in " + this.GetType().Name + " Controller and in " + MethodBase.GetCurrentMethod().Name + " Action Name \n\n\n" + Convert.ToString(e);
                return View("ExceptionGen");
            }
        }
        [HttpGet]
        public ActionResult EditItem(int id)
        {
            try
            {
                ContextDefine contextDefine = new ContextDefine();
                MenuItem menuItem = contextDefine.MenuItems.Single(menu => menu.Id == id);
                return View(menuItem);
            }
            catch (Exception e)
            {
                ViewBag.Exception = "Exception occured in " + this.GetType().Name + " Controller and in " + MethodBase.GetCurrentMethod().Name + " Action Name \n\n\n" + Convert.ToString(e);
                return View("ExceptionGen");
            }
        }
        [HttpPost]
        public ActionResult EditItem(MenuItem menuItem)
        {
            try
            {
                ContextDefine contextDefine = new ContextDefine();
                contextDefine.Entry(menuItem).State = EntityState.Modified;
                contextDefine.SaveChanges();
                return View("EditItemConfirmation");
            }
            catch (Exception e)
            {
                ViewBag.Exception = "Exception occured in " + this.GetType().Name + " Controller and in " + MethodBase.GetCurrentMethod().Name + " Action Name \n\n\n" + Convert.ToString(e);
                return View("ExceptionGen");
            }

        }
//------------------------------------------END OF ADMIN BLOCK-------------------------------------
        public ActionResult ConsumerIndex()
        {
            try
            {
                ContextDefine contextDefine = new ContextDefine();
                List<MenuItem> menuItems = contextDefine.MenuItems.ToList();
                return View(menuItems);
            }
            catch (Exception e)
            {
                ViewBag.Exception = "Exception occured in " + this.GetType().Name + " Controller and in " + MethodBase.GetCurrentMethod().Name + " Action Name \n\n\n" + Convert.ToString(e);
                return View("ExceptionGen");
            }
        }
        public ActionResult AddToCart(int id)
        {
            try
            {
                ContextDefine contextDefine = new ContextDefine();
                MenuItem menuItem = contextDefine.MenuItems.Where(item => item.Id == id).SingleOrDefault();
                Cart cart = new Cart { Name = menuItem.Name, Price = menuItem.Price, FreeDelivery = menuItem.FreeDelivery };
                bool check = false;
                List<Cart> carts = contextDefine.Carts.ToList();
                foreach (var item in carts)
                {
                    if (item.Name == cart.Name)
                    {
                        check = true;
                        break;
                    }
                    else
                    {
                        check = false;
                    }
                }
                if (check == false)
                {
                    contextDefine.Carts.Add(cart);
                    contextDefine.SaveChanges();
                }
                return View("AddToCart");
            }
            catch (Exception e)
            {
                ViewBag.Exception = "Exception occured in " + this.GetType().Name + " Controller and in " + MethodBase.GetCurrentMethod().Name + " Action Name \n\n\n" + Convert.ToString(e);
                return View("ExceptionGen");
            }
        }
        public ActionResult ViewCart()
        {
            try
            {
                ContextDefine contextDefine = new ContextDefine();
                List<Cart> cart = contextDefine.Carts.ToList();
                return View(cart);
            }
            catch (Exception e)
            {
                ViewBag.Exception = "Exception occured in " + this.GetType().Name + " Controller and in " + MethodBase.GetCurrentMethod().Name + " Action Name \n\n\n" + Convert.ToString(e);
                return View("ExceptionGen");
            }

        }
        public ActionResult DeleteItemFromCart(int id)
        {
            try
            {
                ContextDefine contextDefine = new ContextDefine();
                Cart cart = contextDefine.Carts.Where(item => item.Id == id).FirstOrDefault();
                contextDefine.Carts.Remove(cart);
                contextDefine.SaveChanges();
                return View("DeleteItemFromCart");
            }
            catch (Exception e)
            {
                ViewBag.Exception = "Exception occured in " + this.GetType().Name + " Controller and in " + MethodBase.GetCurrentMethod().Name + " Action Name \n\n\n" + Convert.ToString(e);
                return View("ExceptionGen");
            }
        }
        
    }
}