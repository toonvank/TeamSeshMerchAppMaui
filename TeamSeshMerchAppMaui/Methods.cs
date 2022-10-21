using CodeHollow.FeedReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TeamSeshMerchAppMaui
{
    public class Methods
    {
        public async Task ReadXml(string link)
        {
            var feed = await FeedReader.ReadAsync(link);
            rssChannelItem r = new rssChannelItem();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(feed.OriginalDocument);
            for (int i = 0; i < doc.GetElementsByTagName("item").Count; i++)
            {
                rssChannelItem localItem = new rssChannelItem();
                XmlNodeList nl = doc.GetElementsByTagName("item")[i].ChildNodes;
                localItem.idField = int.Parse(nl[0].InnerText);
                localItem.titleField = nl[1].InnerText.ToUpper();
                localItem.descriptionField = nl[2].InnerText;
                localItem.priceField = nl[3].InnerText;
                localItem.linkField = nl[4].InnerText;
                localItem.image_linkField = nl[5].InnerText;
                localItem.additional_image_linkField = nl[6].InnerText;
                localItem.mpnField = int.Parse(nl[7].InnerText);
                localItem.conditionField = nl[8].InnerText;
                localItem.availabilityField = nl[9].InnerText;
                DataPass.rssChannel.Add(localItem);
            }
        }
        public async Task FillProductList()
        {
            DataPass.rssChannel.Clear();
            Sources s = new Sources();
            for (int i = 0; i < s.AddLinks().Count; i++)
            {
                try
                {
                    await ReadXml(s.AddLinks()[i]);
                }
                catch (Exception)
                {

                }
            }
        }
        public async Task FillProductListCustSource()
        {
            DataPass.rssChannel.Clear();
            Sources s = new Sources();
            foreach (var item in DataPass.whichOneRemove)
            {
                try
                {
                    await ReadXml(s.AddLinks()[item]);
                }
                catch (Exception)
                {

                }
            }
        }
        public List<string> availability()
        {
            var availability = new List<string>();
            availability.Add("out of stock");
            availability.Add("in stock");
            availability.Add("all");
            return availability;
        }
    }
}
