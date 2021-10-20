using AutoMapper;
using BitsPilani.CourseToCartPublisher.BL.BaseClass;
using BitsPilani.CourseToCartPublisher.BL.Interfaces;
using BitsPilani.CourseToCartPublisher.Common.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BitsPilani.CourseToCartPublisher.BL.Commands
{
    public class DeleteCourseCartCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public class DeleteCourseCartHandler : AppBaseClass, IRequestHandler<DeleteCourseCartCommand, bool>
        {
            public DeleteCourseCartHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<bool> Handle(DeleteCourseCartCommand request, CancellationToken cancellationToken)
            {
                return await this.UnitOfWork.Basket.DeleteCourseCart(request.UserName);
            }
        }
    }
}
