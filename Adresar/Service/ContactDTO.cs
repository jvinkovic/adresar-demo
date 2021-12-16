using System.ComponentModel.DataAnnotations;

namespace Service
{
    public class ContactDTO
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Mobile { get; set; }

        public Guid? AddressId { get; set; }
    }
}