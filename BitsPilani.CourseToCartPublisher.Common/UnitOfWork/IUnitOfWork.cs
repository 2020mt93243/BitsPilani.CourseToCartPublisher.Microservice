using BitsPilani.CourseToCartPublisher.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitsPilani.CourseToCartPublisher.Common.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICourseCartRepository Basket { get; }
    }
}
