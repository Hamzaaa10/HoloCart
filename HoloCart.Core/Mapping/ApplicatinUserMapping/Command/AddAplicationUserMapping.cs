﻿using HoloCart.Core.Features.ApplicationUserFeatures.Commands.Requests;
using HoloCart.Data.Entities.Identity;

namespace HoloCart.Core.Mapping.ApplicatinUserMapping
{
    public partial class ApplicationAuthorizationProfile
    {
        public void AddAplicationUserMapping()
        {
            CreateMap<AddAplicationUserRequest, ApplicationUser>();
        }
    }
}
