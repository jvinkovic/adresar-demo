using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Date
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Mobile { get; set; }

        public Guid? AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual Address? Address { get; set; }
    }
}