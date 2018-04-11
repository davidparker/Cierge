using System.ComponentModel.DataAnnotations;

namespace NetSo.Models
{
    public interface IAdditionalUserInfo
    {
        string UserName { get; set; }
        string FullName { get; set; }

        string MobileNumber { get; set; } 
        
        bool SendCodesViaSms { get; set; }
    }

    public class AdditionalUserInfo : IAdditionalUserInfo
    {
        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Your username should be between 4 and 15 characters in length.")]
        [Display(Name = "Username", Prompt = "unique, short, no spaces")]
        public string UserName { get; set; }

        [Display(Name = "Name", Prompt = "optional full name")]
        [StringLength(20, ErrorMessage = "Your name can't be more than 20 characters.")]
        public string FullName { get; set; }

        [Display(Name = "Mobile Number", Prompt = "optional")]
        [MinLength(10)]
        public string MobileNumber { get; set; }

        [Display(Name = "Send login codes via sms")]
        public bool SendCodesViaSms { get; set; }

    }
}
