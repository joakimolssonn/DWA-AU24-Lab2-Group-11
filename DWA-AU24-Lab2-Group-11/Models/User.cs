﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DWA_AU24_Lab2_Group_11.Models
{
    public class User : IdentityUser
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public string Fullname => $"{FirstName} {LastName}";
        public string Location { get; set; } // Selected location
        public double Latitude { get; set; } // Latitude of the location
        public double Longitude { get; set; } // Longitude of the location

    }
}
