﻿using SellingBookSolution.Data.Entities;
using SellingBookSolution.ViewModels.System.Users.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellingBookSolution.Application.System.Roles;

namespace SellingBookSolution.Application.Utilities.Slides
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleViewModel>> GetAll()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToListAsync();

            return roles;
        }
    }
}
