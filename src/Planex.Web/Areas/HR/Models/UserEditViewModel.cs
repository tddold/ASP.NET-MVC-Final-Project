﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using AutoMapper;
using Planex.Data.Models;
using Planex.Web.Infrastructure.Mappings;
using AutoMapper;

namespace Planex.Web.Areas.HR.Models
{
    public class UserEditViewModel: IMapFrom<User>, IHaveCustomMappings
    {
        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required]
        [UIHint("Email")]

        public string Email { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public decimal PricePerHour { get; set; }
//
//        [Required]
//        public Image Avatar { get; set; }
//
        public List<string> Skills { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserEditViewModel>("")
                .ForMember(m => m.Skills, opt => opt.MapFrom(c => c.Skills.Select(s => s.Name)));            
        }
    }
}