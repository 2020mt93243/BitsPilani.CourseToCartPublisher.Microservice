using System;
using System.Collections.Generic;
using System.Text;

namespace BitsPilani.CourseToCartPublisher.Common.Entities
{
    public class CourseCartEntity
    {
        public string UserEmail { get; set; }
        public List<CourseCartItem> Items { get; set; } = new List<CourseCartItem>();
        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price;
                }
                return totalprice;
            }
        }
    }
}
