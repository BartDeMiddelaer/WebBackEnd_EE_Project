using System;
using System.ComponentModel.DataAnnotations;


namespace Wba.EE.DeMiddelaerBart.Web.Models
{
    public class InputRegistration
    {
        // ------------------------------------------------------
        [Required]
        [Display(Name = "User Name")]  
        [MaxLength(15,ErrorMessage = "Max Length of username 15 chars")]        
        public string Username { get; set; }

        // Pass -------------------------------------------------

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MaxLength(30, ErrorMessage = "Max Length of Password 30 chars")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Repeat Password")]
        [DataType(DataType.Password)]
        [MaxLength(30, ErrorMessage = "Max Length of Password 30 chars")]
        [Compare(nameof(Password),ErrorMessage = "Passwords dont match")]
        public string PasswordRepeat { get; set; }
        // ------------------------------------------------------

        [Display(Name = "Your Gender")]
        public int GenderID { get; set; }

        // ------------------------------------------------------

        [Display(Name = "berth day")]     
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [MaxLength(20, ErrorMessage = "Max Length of Country 20 chars")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [MaxLength(50, ErrorMessage = "Max Length of E - Mail 50 chars")]
        [Display(Name = "E - Mail")]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(20, ErrorMessage = "Max Length of Phone Number 20 chars")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [MaxLength(255, ErrorMessage = "Max Length of Bio 255 chars")]
        [Display(Name = "About You")]
        public string Bio { get; set; }

        [Required]
        [Display(Name = "team")]
        public int? IndexOfTeamSelectit { get; set; }

        [Required]
        [Display(Name = "Avatar")]
        public int? IndexOfAvatarSelectit { get; set; }

        public int? HighScore { get; set; } = null;
    }
}
