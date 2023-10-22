using Define.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postgres.Context.Entities
{
    public record AthletesEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AthletesId { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(16)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string FavoriteActivity { get; set; }
        public Roles Role { get; set; }
    }
}
