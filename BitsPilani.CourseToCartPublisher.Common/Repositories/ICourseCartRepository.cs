using BitsPilani.CourseToCartPublisher.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BitsPilani.RabbitMQMessageBroker;

namespace BitsPilani.CourseToCartPublisher.Common.Repositories
{
    public interface ICourseCartRepository
    {
        Task<List<CourseCartEntity>> GetAllItemInCart(List<string> userNames);
        Task<CourseCartEntity> GetCourseCart (string userName);
        Task<bool> UpdateCourseCart(CourseCartEntity basket);
        Task<bool> DeleteCourseCart(string userName);

        Task<bool> CheckoutCourseCart(List<CheckoutEvent> coursesCheckoutEvent);
    }
}
