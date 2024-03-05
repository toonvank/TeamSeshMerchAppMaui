using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonesAlbumInfoApp.Model
{
    public class Album
    {
        public string Artist { get; set; }
        public string AlbumName { get; set; }
        public string ReleaseDate { get; set; }
        public string DownloadLink { get; set; }
        public string Image { get; set; }
    }
}
