using System.ComponentModel.DataAnnotations;

namespace epitec;

public class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(250)]
        public string? LastName { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; }
         
        public DateTime BirthDate { get; set; }
    }