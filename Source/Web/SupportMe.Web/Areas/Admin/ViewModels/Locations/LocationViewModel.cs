﻿namespace SupportMe.Web.Areas.Admin.ViewModels.Locations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using ViewModels.Contacts;

    public class LocationViewModel : IMapFrom<Location>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Company")]
        public string CompanyId { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Contact Id")]
        public int? ContactId { get; set; }

        public ContactViewModel Contact { get; set; }

        public IEnumerable<SelectListItem> Companies { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Location, LocationViewModel>()
                .ForMember(vm => vm.CompanyName, opt => opt.MapFrom(dbm => dbm.Company.Name))
                .ForMember(vm => vm.CompanyId, opt => opt.MapFrom(dbm => dbm.CompanyId.ToString()));
        }
    }
}
