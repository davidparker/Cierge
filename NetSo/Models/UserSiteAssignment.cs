namespace NetSo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using NetSo.Data;

    public class UserSiteAssignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public Site Site { get; set; }

        public Client Client { get; set; }

        public ApplicationUser User { get; set; }
    }
}