using System;
using System.Collections.Generic;
using System.Text;

namespace BitsPilani.CourseToCartPublisher.Common.Entities
{
    public class CourseCartItem
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseShortName { get; set; }
        public decimal CreditHour { get; set; }
        public decimal Price { get; set; }
    }
}
