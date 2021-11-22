using AutoMapper;
using Entities.DTO.UserDTOs;
using Entities.DTO.WarehouseDTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<WarehouseCreateDTO, Warehouse>();
        }
    }
}
