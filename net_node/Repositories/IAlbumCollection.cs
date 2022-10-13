using net_node.Models;
namespace net_node.Repositories

{
    public interface IAlbumCollection
    {
        void InsertAlbum(Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(string album);
        List<Album> GetAllAlbum();
        Album GetAlbumId(string id);
            
    }
}
