using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSeshMerchAppMaui
{
    public static class DataPass
    {
        public static List<rssChannelItem> rssChannel = new List<rssChannelItem>();
        public static List<rssChannelItem> passedAlbum = new List<rssChannelItem>();
        public static List<int> whichOneRemove = new List<int>();
        public static int currencyIndex = 2;
        public static double eurExchange { get; set; }
        public static double gbpExchange { get; set; }
    }
}
