using QTMusic.Logic.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTMusic.Logic.Controllers.App
{
    public sealed partial class GenresController : GenericController<Genre>
    {
        public GenresController() : base()
        {

        }

        public GenresController(ControllerObject other) : base(other)
        {

        }
    }
}
