using QTMusic.Logic.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTMusic.Logic.Controllers.App
{
    public sealed partial class AlbumsController : GenericController<Album>
    {
        public AlbumsController() : base()
        {

        }
        public AlbumsController(ControllerObject other) : base(other)
        {

        }

        public override Task<Album[]> GetAllAsync()
        {
            return EntitySet.Include(a => a.Artist).Include(m => m.Genre).ToArrayAsync();
        }

        public override ValueTask<Album?> GetByIdAsync(int id)
        {
            return new ValueTask<Album?>(EntitySet.Include(a => a.Artist).Include(m => m.Genre).SingleOrDefaultAsync(f => f.Id == id));
        }
    }
}
