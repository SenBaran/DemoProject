using QTMusic.Logic.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTMusic.Logic.Controllers.App
{
    public sealed partial class ArtistsController : GenericController<Artist>
    {
        public ArtistsController() : base()
        {

        }

        public ArtistsController(ControllerObject other) : base(other)
        {

        }
    }
}
