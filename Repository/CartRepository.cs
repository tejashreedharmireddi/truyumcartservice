using CartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Repository
{
    public class CartRepository:ICartRepository
    {
        public static IDictionary<int, List<MenuItem>> dict = new Dictionary<int, List<MenuItem>>();
        public IEnumerable<MenuItem> AddItemToCart(int userid, MenuItem menuItem)
        {
            if (dict.ContainsKey(userid))
            {
                dict[userid].Add(menuItem);
            }
            else
            {
                dict.Add(userid, new List<MenuItem>());
                dict[userid].Add(menuItem);
            }
            // MenuItem item = dict[userid].Find(x => x.Id == menuItem.Id);

            return dict[userid].ToList();

        }

        public IEnumerable<MenuItem> DeleteMenuItemFromCart(int userid, int itemId)
        {
            if (dict.ContainsKey(userid))
            {
                var items = dict[userid];
                var itemToRemove = items.SingleOrDefault(x => x.Id == itemId);
                if (itemToRemove != null)
                {
                    //items.Remove(itemToRemove);
                    dict[userid].Remove(itemToRemove);
                    return dict[userid].ToList();
                }
            }
            return dict[userid].ToList();





        }

        public IEnumerable<MenuItem> GetByUserId(int userid)
        {
            /*if(dict.ContainsKey(userid))
            {
                return dict[userid].ToList();
            }
            return Enumerable.Empty<MenuItem>();*/

            return dict[userid].ToList();
        }
    }
}
