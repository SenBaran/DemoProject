using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTMusic.ConApp
{
    partial class Program
    {
        static partial void AfterRun()
        {
            var csvGenres = File.ReadAllLines("C:/Users/baran/Desktop/QTMusic/QTMusic.ConApp/CsvData/Genre.csv")
                             .Skip(1)
                             .Select(l => l.Split(";"))
                             .Select(d => new { id = d[0], Entity = new Logic.Entities.App.Genre { Name = d[1] } });
            var csvArtists = File.ReadAllLines("C:/Users/baran/Desktop/QTMusic/QTMusic.ConApp/CsvData/Artist.csv")
                             .Skip(1)
                             .Select(l => l.Split(";"))
                             .Select(d => new
                             {
                                 id = d[0],
                                 Entity = new Logic.Entities.App.Artist
                                 {
                                     Name = d[1],
                                 }
                             });
            var csvAlbums = File.ReadAllLines("C:/Users/baran/Desktop/QTMusic/QTMusic.ConApp/CsvData/AlbumWithGenre.csv")
                             .Skip(1)
                             .Select(l => l.Split(";"))
                             .Select(d => new
                             {
                                 id = d[0],
                                 ArtistId = d[2],
                                 GenreId = d[3],
                                 Entity = new Logic.Entities.App.Album
                                 {
                                     Title = d[1],
                                 }
                             });
            var artists = csvArtists.Select(e => e.Entity).ToArray();
            var genres = csvGenres.Select(e => e.Entity).ToArray();
            var albums = new List<Logic.Entities.App.Album>();

            foreach (var item in csvAlbums)
            {
                var genIdx = csvGenres.IndexOf(e => e.id == item.GenreId);
                var artIdx = csvArtists.IndexOf(e => e.id == item.ArtistId);

                item.Entity.Genre = genres[genIdx];
                item.Entity.Artist = artists[artIdx];
                albums.Add(item.Entity);
            }

            Task.Run(async () =>
            {
                using var albumsCtrl = new Logic.Controllers.App.AlbumsController();

                await albumsCtrl.InsertAsync(albums);
                await albumsCtrl.SaveChangesAsync();
            }).Wait();
        }
    }
}
