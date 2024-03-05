using BonesAlbumInfoApp.Model;
using BonesAlbumInfoApp.PassObjects;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BonesAlbumInfoApp.ViewModel
{
    [QueryProperty("Album", "selectedAlbum")]
    public partial class AlbumInfoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string releaseDate;
        [ObservableProperty]
        private string image;
        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private string artist;

        private Album album;
        public Album Album
        {
            set
            {
                album = value;
                ReleaseDate = album.ReleaseDate;
                Image = album.Image;
                Title = album.AlbumName;
                Artist = album.Artist;
                AlbumInfoObjectPass.passedAlbum = album;
            }
        }
    }
}
