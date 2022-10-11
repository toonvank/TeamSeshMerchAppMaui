using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSeshMerchAppMaui
{
    public class rssChannelItem
    {
        public int idField { get; set; }
        public string titleField { get; set; }
        public string descriptionField { get; set; }
        public string priceField { get; set; }
        public string linkField { get; set; }
        public string image_linkField { get; set; }
        public string additional_image_linkField { get; set; }
        public int mpnField { get; set; }
        public string conditionField { get; set; }
        public string availabilityField { get; set; }
        public Color stockColor 
        {
            get
            {
                Color c = new Color();
                if (this.availabilityField == "out of stock")
                {
                    c =  Colors.DarkRed;
                }
                else
                {
                    c = Colors.Green;
                }
                return c;
            }
            set
            {
                stockColor = value;
            }
        }
    }
}
