using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UdemyCourseProject.Models
{
    public class Hobby
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public Guid HobbyId { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public int Rating { get; set; }

        [ForeignKey("AspNetUsers")]
        public ApplicationUser User { get; set; }

        public string AspNetUserId { get; set; }
    }
}
