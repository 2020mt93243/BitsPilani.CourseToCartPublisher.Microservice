using BitsPilani.CourseToCartPublisher.BL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitsPilani.CourseToCartPublisher.DB.Constant
{
    public class ConfigConstants : IConfigConstants
    {
        public IConfiguration Configuration { get; }
        public ConfigConstants(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public string RedisConnection => this.Configuration.GetConnectionString("Redis");
    }
}
