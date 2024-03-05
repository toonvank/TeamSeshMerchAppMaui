using BonesAlbumInfoApp.PassObjects;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonesAlbumInfoApp.Model
{
    public class rssChannelItem
    {
        private string priceField1;
        public int idField { get; set; }
        public string titleField { get; set; }
        public string descriptionField { get; set; }
        public string priceField
        {
            get => priceField1;
            set
            {
                string strVal = value.Remove(value.IndexOf("."));
                double dbVal = double.Parse(strVal);
                if (DataPass.currencyIndex == 0)
                {
                    dbVal = dbVal * DataPass.eurExchange;
                    strVal = $"{Math.Round(dbVal, 2)} EUR";
                }
                else if (DataPass.currencyIndex == 1)
                {
                    dbVal = dbVal * DataPass.gbpExchange;
                    strVal = $"{Math.Round(dbVal, 2)} GBP";
                }
                else if (DataPass.currencyIndex == 3)
                {
                    dbVal = dbVal * DataPass.rubExchange;
                    strVal = $"{Math.Round(dbVal, 2)} RUB";
                }
                else
                {
                    strVal = value;
                }
                priceField1 = strVal;
            }
        }
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
                if (availabilityField == "out of stock")
                {
                    c = Colors.DarkRed;
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
