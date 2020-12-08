using CartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Repository
{
    public interface ICartRepository
    {
        public IEnumerable<MenuItem> GetByUserId(int id);
        public IEnumerable<MenuItem> DeleteMenuItemFromCart(int userid, int itemId);
        public IEnumerable<MenuItem> AddItemToCart(int userid, MenuItem item);
    }
}
