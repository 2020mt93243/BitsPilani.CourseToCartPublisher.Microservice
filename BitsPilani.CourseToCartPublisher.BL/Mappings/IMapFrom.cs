using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitsPilani.CourseToCartPublisher.BL.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
    }
}
