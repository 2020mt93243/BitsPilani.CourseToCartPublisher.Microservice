using BitsPilani.CourseToCartPublisher.Common.Entities;
using BitsPilani.CourseToCartPublisher.Common.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BitsPilani.RabbitMQMessageBroker;
using Newtonsoft.Json;

namespace BitsPilani.CourseToCartPublisher.DB.Repositories
{
    public class CourseCartRepository : ICourseCartRepository
    {
        private readonly IDatabase redisConn;
        private readonly RabbitMQProducer rabbitMQProducer;
        public CourseCartRepository(IDatabase redisConn, RabbitMQProducer rabbitMQProducer)
        {
            this.redisConn = redisConn;
            this.rabbitMQProducer = rabbitMQProducer;
        }
      
        public Task<bool> CheckoutCourseCart(List<CheckoutEvent> coursesCheckoutEvent)
        {
            this.rabbitMQProducer.PublishCoursesCheckout(Constants.RabbitMQCheckoutQueue, coursesCheckoutEvent);
            return Task.Run(() => true);
        }

        public async Task<bool> DeleteCourseCart(string userName)
        {
            return await this.redisConn.KeyDeleteAsync(userName);
        }

        public async Task<List<CourseCartEntity>> GetAllItemInCart(List<string> userNames)
        {
            List<CourseCartEntity> baskets = new List<CourseCartEntity>();
            foreach (var userName in userNames)
            {
                var item = GetCourseCart(userName).Result;
                if (item != null)
                {
                    baskets.Add(GetCourseCart(userName).Result);
                }
            }
            return await Task.Run(() => baskets);
        }

        public async Task<CourseCartEntity> GetCourseCart(string userName)
        {
            var basket = await this.redisConn.StringGetAsync(userName);

            if (basket.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<CourseCartEntity>(basket);
        }

        public async Task<bool> UpdateCourseCart(CourseCartEntity basket)
        {
            var updated = await this.redisConn.StringSetAsync(basket.UserEmail, JsonConvert.SerializeObject(basket));

            if (!updated)
            {
                return false;
            }

            return await Task.Run(() => true);
        }
    }
}
