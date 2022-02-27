using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTMusic.Logic.Entities.App
{
    [Table("Albums", Schema = "App")]
    [Index(nameof(Title), IsUnique = true)]
    public class Album : VersionEntity
    {
        public int ArtistId { get; set; }
        public int GenreId { get; set; }

        [Required]
        [MaxLength(256)]
        public string Title { get; set; } = String.Empty;

        //navigation props
        public Artist? Artist { get; set; }
        public Genre? Genre { get; set; }
    }
}
