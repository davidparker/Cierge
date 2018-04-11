using Microsoft.AspNetCore.Identity;
using NetSo.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetSo.Models.ManageViewModels
{
    public class HistoryViewModel
    {
        public IList<AuthEvent> Events { get; set; }
    }
}
