using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSeshMerchAppMaui
{
    public class Sources
    {
        public List<string> AddLinks()
        {
            List<string> links = new List<string>();
            links.Add("https://teamsesh.bigcartel.com/products.xml");
            links.Add("https://teamseshmerchscraps.bigcartel.com/products.xml");
            links.Add("https://www.supporttrees.com/products.xml");
            links.Add("https://endorphinfitnesswear.bigcartel.com/products.xml");
            return links;
        }
    }
}
