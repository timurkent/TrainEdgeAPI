using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainEdgeAPI.Models
{
    [Table("studentData")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("userId")]
        [Required]
        public string UserId { get; set; }
        [Column("username")]
        [Required]
        public string Username { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        [Required]
        public string Password { get; set; }

        [Column(name: "birthdate", TypeName = "date")]
        public DateTime Birthdate { get; set; }

        [Column("telegram")]
        [Required]
        public string Telegram { get; set; }

        [Column("isAdmin")]
        public bool IsAdmin { get; set; } = true;
    }
}
