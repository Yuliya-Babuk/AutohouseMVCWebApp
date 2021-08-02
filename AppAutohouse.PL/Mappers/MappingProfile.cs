using AppAutohouse.PL.Models;
using AutoMapper;
using MVCAppAutohouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAutohouse.PL.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarModel>().ReverseMap();
            CreateMap<Brand, BrandModel>().ReverseMap();
        }
    }
}
