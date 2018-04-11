using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetSo.Models
{
    public class Site
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }

        public string HostName { get; set; }

        public bool HasClients{ get; set; }

        public ICollection<Client> Clients { get; set; }

    }
}