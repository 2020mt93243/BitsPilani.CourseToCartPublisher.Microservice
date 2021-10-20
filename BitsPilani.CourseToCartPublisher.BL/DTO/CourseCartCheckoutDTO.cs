using AutoMapper;
using BitsPilani.CourseToCartPublisher.BL.Mappings;
using BitsPilani.CourseToCartPublisher.Common.Entities;
using BitsPilani.RabbitMQMessageBroker;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitsPilani.CourseToCartPublisher.BL.DTO
{
    public class CourseCartCheckoutDTO : IMapFrom<CourseCartCheckout>, IMapFrom<CheckoutEvent>
    {
        public string Subjects { get; set; }
        public decimal TotalPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CourseCartCheckout, CourseCartCheckoutDTO>();
            profile.CreateMap<CourseCartCheckoutDTO, CourseCartCheckout>();

            profile.CreateMap<CheckoutEvent, CourseCartCheckoutDTO>();
            profile.CreateMap<CourseCartCheckoutDTO, CheckoutEvent>();
        }
    }
}
