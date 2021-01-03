using MarketApp.Business.Abstract;
using MarketApp.webUI.Identity;
using MarketApp.webUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Controllers
{   
    [Authorize]
    public class SepetController : Controller
    {
        private ISepetService _sepetService;
        private UserManager<UserIdentity> _userManager;
        public SepetController(ISepetService sepetService, UserManager<UserIdentity> userManager)
        {
            _sepetService = sepetService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var sepet = _sepetService.GetSepetByUserId(_userManager.GetUserId(User)); // User bilgisine göre userId getirilecek.
            return View(new SepetModel()
            { 
                SepetId = sepet.Id, 
                SepetItems = sepet.SepetItems.Select(i=> new SepetItemModel()
                {
                    SepetItemId =i.Id,
                    ProductId = i.Product.Id,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price,   //
                    ImageUrl = i.Product.ImgUrl,
                    Quantity = i.Quantity

                }).ToList()
            });
        }
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            _sepetService.AddToChart(_userManager.GetUserId(User), productId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            _sepetService.DeleteFromCart(_userManager.GetUserId(User), productId);
            return RedirectToAction("Index");
        }
    }
}
