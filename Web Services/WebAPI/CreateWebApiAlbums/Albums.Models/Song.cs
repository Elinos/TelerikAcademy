namespace Albums.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Title { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        public string Year { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Genre { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
