﻿using System.ComponentModel.DataAnnotations;

namespace NetSo.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [MaxLength(10)]
        [Display(Name = "Username", Description = "Username unique to you.")]
        public string UserName { get; set; }
    }
}
