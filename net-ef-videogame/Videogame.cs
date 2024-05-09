using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_ef_videogame
{
    [Table("videogame")]
    public class Videogame
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        [Column("release_date")]
        public string ReleaseDate { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        // Foreign key property
        [ForeignKey("SoftwareHouseId")]
        public int SoftwareHouseId { get; set; }

        // Navigation property
        public SoftwareHouse SoftwareHouse { get; set; }
        public Videogame() { }
        public Videogame(string name, string overview, string releaseDate, DateTime createdAt, DateTime updateAt)
        {
            this.Name = name;
            this.Overview = overview;
            this.ReleaseDate = releaseDate;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updateAt;
        }
    }
}
