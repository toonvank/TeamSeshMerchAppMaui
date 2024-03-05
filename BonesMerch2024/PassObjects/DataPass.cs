using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BonesAlbumInfoApp.Model;

namespace BonesAlbumInfoApp.PassObjects
{
    public static class DataPass
    {
        public static List<rssChannelItem> rssChannel = new List<rssChannelItem>();
        public static List<rssChannelItem> passedAlbum = new List<rssChannelItem>();
        public static ObservableCollection<rssChannelItem> loadedMerch = new ObservableCollection<rssChannelItem>();
        public static List<int> whichOneRemove = new List<int>();
        public static int currencyIndex = 2;
        public static double eurExchange { get; set; }
        public static double gbpExchange { get; set; }
        public static double rubExchange { get; set; }
        public static List<int> favorItems = new List<int>();
        public static int minPrice { get; set; }
        public static int maxPrice { get; set; }
    }
}
