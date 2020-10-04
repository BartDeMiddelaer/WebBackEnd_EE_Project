using System.ComponentModel.DataAnnotations;

namespace Wba.EE.DeMiddelaerBart.Web.Models
{
    public class InputLogInViewModel
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Display(Name = "Remamber me")]     
        public bool RemamberMe { get; set; }
    }
}
