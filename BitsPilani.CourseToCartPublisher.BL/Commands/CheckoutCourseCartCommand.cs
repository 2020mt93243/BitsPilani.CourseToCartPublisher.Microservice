using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BitsPilani.CourseToCartPublisher.BL.BaseClass;
using BitsPilani.CourseToCartPublisher.BL.DTO;
using BitsPilani.CourseToCartPublisher.BL.Interfaces;
using BitsPilani.CourseToCartPublisher.Common.UnitOfWork;
using BitsPilani.RabbitMQMessageBroker;
using MediatR;
namespace BitsPilani.CourseToCartPublisher.BL.Commands
{
    public class CheckoutCourseCartCommand : IRequest<bool>
    {
        public List<CourseCartCheckoutDTO> courseCartCheckoutDTOs { get; set; }
        public class CheckoutCourseCartHandler : AppBaseClass, IRequestHandler<CheckoutCourseCartCommand, bool>
        {
            private readonly RabbitMQProducer rabbitMQProducer;
            public CheckoutCourseCartHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork, RabbitMQProducer rabbitMQProducer)
                : base(constant, unitOfWork, mapper)
            {
                this.rabbitMQProducer = rabbitMQProducer;
            }

            public async Task<bool> Handle(CheckoutCourseCartCommand request, CancellationToken cancellationToken)
            {
                var eventMessage = Mapper.Map(request.courseCartCheckoutDTOs, new List<CheckoutEvent>());

                try
                {
                    this.rabbitMQProducer.PublishCoursesCheckout(Constants.RabbitMQCheckoutQueue, eventMessage);
                }
                catch (Exception)
                {
                    throw;
                }

                return await Task.Run(() => true);
            }
        }
    }
}
