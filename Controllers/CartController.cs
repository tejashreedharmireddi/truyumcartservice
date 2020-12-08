using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartService.Models;
using CartService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CartController));
        private ICartRepository repository;
        public CartController(ICartRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {

                _log4net.Info("Getting cart details for user id " + id);
                var menuitemlist = repository.GetByUserId(id);
                return Ok(menuitemlist);
            }
            catch
            {

                _log4net.Error("Failed to load the cart for user id " + id);
                return NotFound();
            }
        }
        [HttpDelete]
        public IActionResult RemoveItem(int id, int userid)
        {
            try
            {

                _log4net.Info("Removing menu item: " + id + "  from cart for user :" + userid);
                var result = repository.DeleteMenuItemFromCart(userid, id);
                return Ok(result);
            }
            catch
            {

                _log4net.Error("Failed to remove menu item: " + id + "  from cart for user :" + userid);
                return new BadRequestResult();
            }
        }
        [HttpPost]
        public IActionResult AddItemToCart([FromBody]MenuItem item, int userid)
        {
            try
            {

                _log4net.Info("Adding menu item : " + item.Id + " to cart for user id " + userid);
                var result = repository.AddItemToCart(userid, item);
                return Ok(result);

            }
            catch
            {

                _log4net.Error("Failed to Add menu item : " + item.Id + " to cart for user id " + userid);

                return new BadRequestResult();
            }
        }
    }
}