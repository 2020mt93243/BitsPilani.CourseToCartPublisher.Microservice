using AutoMapper;
using BitsPilani.CourseToCartPublisher.BL.Mappings;
using BitsPilani.CourseToCartPublisher.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitsPilani.CourseToCartPublisher.BL.VM
{
    public class CourseToCartVM: IMapFrom<CourseCartEntity>
    {
        public string UserEmail { get; set; }
        public string Subjects { get; set; }
        public decimal TotalPrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CourseCartEntity, CourseToCartVM>()
                .ForMember(d => d.Subjects, e => e.MapFrom(s => string.Join(",", s.Items.Select(x => x.CourseName).ToArray())));
        }
    }
}
