using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace net_ef_videogame
{
    [Table("software_houses")]
    public class SoftwareHouse
    {
        public SoftwareHouse() { }

        public SoftwareHouse(string name, string pIva, string city, string country)
        {
            Name = name;
            PIva = pIva;
            City = city;
            Country = country;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PIva { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        public ICollection<Videogame> Videogames { get; set; }
    }
}
