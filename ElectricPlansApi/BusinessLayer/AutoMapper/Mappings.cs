using AutoMapper;
using BusinessLayer.Models;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.AutoMapper
{
    public class Mappings : Profile
    {

        public Mappings()
        {
            CreateMap<ProductsDTO, Product>();
        }

    }

}
