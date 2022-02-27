using QTMusic.Logic.Entities;
using QTMusic.Logic.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTMusic.Logic.DataContext
{
    partial class ProjectDbContext
    {
        public DbSet<Artist>? ArtistsSet { get; set; }
        public DbSet<Album>? AlbumsSet { get; set; }
        public DbSet<Genre>? GenresSet { get; set; }
        partial void GetDbSet<E>(ref DbSet<E>? dbSet, ref bool handled) where E : IdentityEntity
        {
            if(typeof(E) == typeof(Artist))
            {
                handled = true;
                dbSet = ArtistsSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(Album))
            {
                handled = true;
                dbSet = AlbumsSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(Genre))
            {
                handled = true;
                dbSet = GenresSet as DbSet<E>;
            }

        }
    }
}
