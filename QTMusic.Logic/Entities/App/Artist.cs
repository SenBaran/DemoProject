using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTMusic.Logic.Entities.App
{
    [Table("Artists", Schema = "App")]
    [Index(nameof(Name), IsUnique = true)]
    public class Artist : VersionEntity
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; } = String.Empty;

        //navigation prop
        public List<Album> Albums { get; set; } = new List<Album>();
    }
}
