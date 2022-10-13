using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_node.Models;
using net_node.Repositories;

namespace net_node.Controllers
{
    public class SongController : Controller
    {
        private IAlbumCollection db = new AlbumCollection();
        public IActionResult Index()
        {
            return View();
        }

        // GET: SongController/Create
        public ActionResult Create(string id)
        {
            SongViewModel songVM = new SongViewModel() {AlbumId = id, Song = new Song() };
            return View(songVM);
        }

        // POST: SongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var album = db.GetAlbumId(collection["AlbumId"]);
                if (album.Songs == null)
                    album.Songs = new List<Song>();
                album.Songs.Add(new Song
                {
                    Name = collection["Song.Name"],
                    Duration = int.Parse(collection["Song.Duration"])
                });
                db.UpdateAlbum(album);
                return RedirectToAction("index","Album");
            }
            catch
            {
                return View();
            }
        }
    }
}
