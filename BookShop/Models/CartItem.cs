using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    [Serializable]//tuần tự hóa
    public class CartItem
    {
        
        public Book Book { set; get; }
        public int Quantity { set; get; }
    }
}