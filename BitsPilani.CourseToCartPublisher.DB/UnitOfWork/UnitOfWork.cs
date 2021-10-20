using BitsPilani.CourseToCartPublisher.Common.Repositories;
using BitsPilani.CourseToCartPublisher.Common.UnitOfWork;
using BitsPilani.CourseToCartPublisher.DB.Repositories;
using BitsPilani.RabbitMQMessageBroker;
using StackExchange.Redis;

namespace BitsPilani.CourseToCartPublisher.DB.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDatabase redisDB)
        {
            this.RedisDB = redisDB;
        }

        public IDatabase RedisDB { get; }
        public RabbitMQProducer rabbitMQProducer { get; }
        public ICourseCartRepository Basket => new CourseCartRepository(RedisDB, rabbitMQProducer);
    }
}
