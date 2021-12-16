using System.ComponentModel.DataAnnotations;

namespace Service
{
    public class AddressDTO
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public int HouseNumber { get; set; }

        public string? HouseNumberAddon { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }
    }
}