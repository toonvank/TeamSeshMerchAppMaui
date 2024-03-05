//using BonesAlbumInfoApp.Class;
//using BonesAlbumInfoApp.Model;
//using BonesAlbumInfoApp.PassObjects;
//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using CsvHelper;
//using FireSharp.Config;
//using FireSharp.Interfaces;
//using Microsoft.VisualBasic;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Globalization;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using static Android.Gms.Common.Apis.Api;
//using static Java.Util.Jar.Attributes;

//namespace BonesAlbumInfoApp.ViewModel
//{
//    public partial class AlbumPageViewModel : INotifyPropertyChanged
//    {
//        IFirebaseConfig fcon = new FirebaseConfig()
//        {
//            AuthSecret = "O1itSeLoiYkjfMjzk3iv9q4wK99k70VkJ0COQPMZ",
//            BasePath = "https://bonesinfoapp-default-rtdb.europe-west1.firebasedatabase.app/"
//        };
        
//        private ObservableCollection<Album> albums1;
//        public ObservableCollection<Album> albumBackup = new ObservableCollection<Album>();

//        public event PropertyChangedEventHandler PropertyChanged;
//        public ObservableCollection<Album> albums { get => albums1; set 
//            { 
//                albums1 = value;
//                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(albums)));
//            } 
//        }
//        public AlbumPageViewModel()
//        {
//            IFirebaseClient client = new FireSharp.FirebaseClient(fcon);
//            ObservableCollection<Album> _albums = new ObservableCollection<Album>();
//            var result = client.Get($"Albums/");
//            string[] waarden = result.Body.ToString().Remove(0, "[null".Length + 2)
//                .Split('{');
//            foreach (var item in waarden)
//            {
//                string albumRaw = item.Remove(item.Length - 2);
//                string[] albumItems = albumRaw.Split(',');
//                Album album = new Album();//nieuw album object
//                string albumName = albumItems[0].Remove(0, albumItems[0].IndexOf(':') + 2);
//                album.AlbumName = albumName.Remove(albumName.Length - 1);
//                string artist = albumItems[1].Remove(0, albumItems[1].IndexOf(':') + 2);
//                album.Artist = artist.Remove(artist.Length - 1);
//                string releaseDate = albumItems[4].Remove(0, albumItems[4].IndexOf(':') + 2);
//                album.ReleaseDate = releaseDate.Remove(releaseDate.Length - 1);
//                string downloadLInk = albumItems[2].Remove(0, albumItems[2].IndexOf(':') + 2);
//                album.DownloadLink = downloadLInk.Remove(downloadLInk.Length - 1);// download link
//                string image = albumItems[3].Remove(0, albumItems[3].IndexOf(':') + 2);
//                album.Image = image.Remove(image.Length - 1);
//                _albums.Add(album);
//            }
//            albums = _albums;
//            albumBackup = _albums;
//            AlbumInfoObjectPass.Albums = _albums;
//        }
//        string text = string.Empty;
//        [RelayCommand]
//        public void Search(SearchBar search)
//        {
//            if (text.Length < search.Text.Length)
//            {
//                text = search.Text;
//                ObservableCollection<Album> _albums = new ObservableCollection<Album>();
//                for (int i = 0; i < albums.Count; i++)
//                {
//                    if (albums[i].AlbumName.StartsWith(search.Text.ToUpper()))
//                    {
//                        _albums.Add(albums[i]);
//                    }
//                }
//                albums = _albums;
//            }
//            else
//            {
//                text = search.Text;
//                ObservableCollection<Album> _albums = new ObservableCollection<Album>();
//                for (int i = 0; i < albumBackup.Count; i++)
//                {
//                    if (albumBackup[i].AlbumName.StartsWith(search.Text.ToUpper()))
//                    {
//                        _albums.Add(albumBackup[i]);
//                    }
//                }
//                albums = _albums;
//            }
//        }
//        [RelayCommand]
//        public void ReverseList()
//        {
//            albums = new ObservableCollection<Album>(albums.Reverse());
//        }
//        [RelayCommand]
//        public async void GoToDetail(Album clickedAlbum)
//        {
//            await Shell.Current.GoToAsync(nameof(AlbumInfo), true, new Dictionary<string, object>
//            {
//                {"selectedAlbum", clickedAlbum}
//            });
//        }
//    }
//}
