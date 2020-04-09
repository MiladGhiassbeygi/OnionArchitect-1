﻿using AutoMapper;
using Infra.Authentication.Identity.Models;
using OnionArchitect.Api.V1.Dtos.Roles;
using OnionArchitect.Api.V1.Forms.Roles;


namespace OnionArchitect.Api.V1.Mappings
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<Role,RoleDto>();
            CreateMap<CreateRoleForm,Role>();
            CreateMap<UpdateRoleForm,Role>();
           
        }
    }

}
