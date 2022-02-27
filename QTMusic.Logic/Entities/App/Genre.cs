using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTMusic.Logic.Entities.App
{
    [Table("Genres", Schema = "App")]
    [Index(nameof(Name), IsUnique = true)]
    public class Genre : VersionEntity
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; } = String.Empty;

        // Navigation properties
        public List<Album> Albums { get; set; } = new();
    }
}
