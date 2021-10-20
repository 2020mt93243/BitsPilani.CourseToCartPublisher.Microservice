using AutoMapper;
using BitsPilani.CourseToCartPublisher.BL.BaseClass;
using BitsPilani.CourseToCartPublisher.BL.Interfaces;
using BitsPilani.CourseToCartPublisher.Common.Entities;
using BitsPilani.CourseToCartPublisher.Common.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BitsPilani.CourseToCartPublisher.BL.Commands
{
    public class UpdateCourseCartCommand : IRequest<bool>
    {
        public string UserEmail { get; set; }
        public List<CourseCartItem> Items { get; set; }

        public class UpdateCourseCardHandler : AppBaseClass, IRequestHandler<UpdateCourseCartCommand, bool>
        {
            private CourseCartEntity courseCartEntity;
            public UpdateCourseCardHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<bool> Handle(UpdateCourseCartCommand request, CancellationToken cancellationToken)
            {
                courseCartEntity = new CourseCartEntity { UserEmail = request.UserEmail, Items = request.Items.Distinct().ToList() };
                return await this.UnitOfWork.Basket.UpdateCourseCart(courseCartEntity);
            }
        }
    }
}
