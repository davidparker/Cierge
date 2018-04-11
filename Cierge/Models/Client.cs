using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Cierge.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string name { get; set; }

        public bool Enabled{ get; set; }
        
        public string SiteId { get; set; }
        public Site Site{ get; set; }
    }
}