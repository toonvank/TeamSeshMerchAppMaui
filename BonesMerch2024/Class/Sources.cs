using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonesAlbumInfoApp.Class
{
    public class Sources
    {
        public List<string> AddLinks()
        {
            List<string> links = new List<string>
            {
                "https://teamsesh.bigcartel.com/products.xml",
                "https://teamseshmerchscraps.bigcartel.com/products.xml",
                "https://www.supporttrees.com/products.xml",
                "https://endorphinfitnesswear.bigcartel.com/products.xml"
            };
            return links;
        }
    }
}
