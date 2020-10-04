using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Wba.EE.DeMiddelaerBart.Domain.SiteProperties;


namespace Wba.EE.DeMiddelaerBart.Domain.Models
{
    public class User
    {     
        #region Done

        [MaxLength(15)]
        public string Name { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public int GenderId { get; set; }

        public DateTime DayOfBirth { get; set; }

        [MaxLength(20)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(999)]
        public string Bio { get; set; }

        public int? IndexOfTeamSelectit { get; set; }

        public int? IndexOfAvatarSelectit { get; set; }

        public int? HighScore { get; set; }
        public UserType TypeOfUser { get; set; }
        #endregion

        public long Id { get; set; }

        public List<Pokemon> PlayDeck { get; set; } = null;

    }
}
 