using System;
using System.Collections.Generic;
using System.Text;

namespace BitsPilani.CourseToCartPublisher.Common.Entities
{
    public class CourseCartCheckout
    {
        public string Subjects { get; set; }
        public decimal TotalPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
