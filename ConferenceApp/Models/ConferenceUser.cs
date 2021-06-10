using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApp.Models
{

    public class CT
    {
        [EnumDataType(typeof(ConferenceTypes))]
        public ConferenceTypes ConferenceType { get; set; }
        [Key]
        public int IDConferenceType { get; set; }

    }
    
    public enum ConferenceTypes 
    {
        [Display(Name = "Warsztaty")]
        Workshop,
        [Display(Name = "Wykłady")]
        Lecture,
        [Display(Name = "Zdalne")]
        Remote
    }

    public class ConferenceUser 
    {
        [Key]
        public int IDConferenceuser { get; set; }
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Zdjęcie Profilowe")]
        [Required(ErrorMessage = "Prosze wybierz zdjecie")]
        [NotMapped]
        public IFormFile ProfilePicture { get; set; }          
        [Display(Name = "Typ konferencji")]
        public ConferenceTypes ? ConferenceType { get; set; }
        [Display(Name ="Zdjęcie profilowe")]
        public string ProfilePicturePath { get; set; }

    }
}
