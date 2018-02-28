using Addon365.WebSync.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addon365.WebSync
{
    public interface IUrls
    {
        IEnumerable<UrlMap> getUrls { get; }

    }
    public class Urls:IUrls
    {
        private IEnumerable<UrlMap> _Urls;
        private IEnumerable<UrlMap> _Urls1;

        public IEnumerable<UrlMap> getUrls
        { get
            {
                if (_Urls == null)
                {
                    _Urls = new List<UrlMap>();
                    


                    List<UrlMap> myUrls = (List<UrlMap>)_Urls;

                    myUrls.Add(new UrlMap("software", "software", 0.9, ChangeFrequency.Weekly, DateTime.UtcNow));
                    myUrls.Add(new UrlMap("software/pawnbroker", "PawnBroker", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow,"Pawn Broker Software","Pawn",UrlType.Main));
                    myUrls.Add(new UrlMap("software/pawnbroker", "Pawn-Broker", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));

                    myUrls.Add(new UrlMap("vellore/software", "software", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));
                    myUrls.Add(new UrlMap("vellore/pawnbroker", "PawnBroker", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));
                    myUrls.Add(new UrlMap("vellore/software/pawnbroker", "PawnBroker", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));
                    myUrls.Add(new UrlMap("vellore/pawnbroker-software", "PawnBroker", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));
                    myUrls.Add(new UrlMap("vellore/pawn-brokers-shop-billing", "PawnBroker", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));
                    myUrls.Add(new UrlMap("vellore/pawn-shop", "PawnBroker", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));

                    myUrls.Add(new UrlMap("madurai/software", "software", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow, "Madurai Software", "Pawn", UrlType.Main));
                    myUrls.Add(new UrlMap("madurai/pawnbroker", "PawnBroker", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));
                    myUrls.Add(new UrlMap("madurai/software/pawnbroker", "PawnBroker", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));
                    myUrls.Add(new UrlMap("madurai/pawnbroker-software", "PawnBroker", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));
                    myUrls.Add(new UrlMap("madurai/pawn-brokers-shop-billing", "PawnBroker", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));
                    myUrls.Add(new UrlMap("madurai/pawn-shop", "PawnBroker", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));

               
                    myUrls.Add(new UrlMap("software/jewellery", "Jewellery", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow, "Jewellery Software", "Jewel", UrlType.Main));

                
                    myUrls.Add(new UrlMap("software/supermarket", "SuperMarket", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow, "SuperMarket Software", "Supermarket", UrlType.Main));

                 
                    myUrls.Add(new UrlMap("software/generalstores", "GeneralStores", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow, "GeneralStore Software", "store", UrlType.Main));

                 
                    myUrls.Add(new UrlMap("software/shoemarts", "ShoeMarts", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow, "ShoeMarts Software", "marts", UrlType.Main));

                 
                    myUrls.Add(new UrlMap("software/autofinance", "AutoFinance", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow, "Auto-Finance Software", "Auto-finance", UrlType.Main));

                 
                    myUrls.Add(new UrlMap("software/schools", "Schools", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow, "Schools Software", "Schools", UrlType.Main));

                 
                    myUrls.Add(new UrlMap("software/pharmacy", "Pharmacy", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow, "Pharmacy Software", "Pharmacy", UrlType.Main));

                  
                    myUrls.Add(new UrlMap("software/textiles", "Textiles", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow, "Textiles Software", "Textiles", UrlType.Main));


                    myUrls.Add(new UrlMap("software/pos", "pos", 0.8, ChangeFrequency.Weekly, DateTime.UtcNow));




                }
                return _Urls;

            }
        }

    }

    public class UrlMap
    {
        public UrlMap(string Url, string PageName)
        {
            this.Url = Url;
            this.PageName = PageName;
            this.Priority = 0.8;
            this.Frequency = ChangeFrequency.Always;
            this.Published = DateTime.UtcNow;
            this.Type = UrlType.Seo;
        }
        public UrlMap(string Url, string PageName,Double Priority,ChangeFrequency Frequency,DateTime Published)
        {
            this.Url = Url;
            this.PageName = PageName;
            this.Priority = Priority;
            this.Frequency = Frequency;
            this.Published = Published;
            this.Type = UrlType.Seo;
        }
        public UrlMap(string Url, string PageName, Double Priority, ChangeFrequency Frequency, DateTime Published,string UrlShortName, string UrlDescription,UrlType Type)
        {
            this.Url = Url;
            this.PageName = PageName;
            this.Priority = Priority;
            this.Frequency = Frequency;
            this.Published = Published;
            this.UrlShortName = UrlShortName;
            this.UrlDescription = UrlDescription;
            this.Type = Type;
        }
        public UrlMap(string Url, string PageName, Double Priority, ChangeFrequency Frequency, DateTime Published, string UrlShortName, string UrlDescription, UrlType Type,string Author,string Keywords, string Description)
        {
            this.Url = Url;
            this.PageName = PageName;
            this.Priority = Priority;
            this.Frequency = Frequency;
            this.Published = Published;
            this.UrlShortName = UrlShortName;
            this.UrlDescription = UrlDescription;
            this.Type = Type;
            this.Author = Author;
            this.Keyword = Keyword;
            this.Description = Description;
        }
        public string Url { get; set; }
        public string PageName { get; set; }

        public Double Priority { get; set; }

        public ChangeFrequency Frequency { get; set; }

        public DateTime Published{get;set;}

        public string UrlShortName { get; set; }

        public string UrlDescription { get; set; }

        public UrlType Type { get; set; }

        public string Author { get; set; }

        public string Keyword { get; set; }

        public string Description { get; set; }
    }

    public enum UrlType
    {
        Main,
        Seo
       
    }
}
