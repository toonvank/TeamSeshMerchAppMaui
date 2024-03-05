using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BonesAlbumInfoApp.Model;

namespace BonesAlbumInfoApp.PassObjects
{
    public static class AlbumInfoObjectPass
    {
        public static Album passedAlbum { get; set; }
        public static ObservableCollection<Album> Albums { get; set; }
    }
}
