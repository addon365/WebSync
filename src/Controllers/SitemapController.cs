using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;


namespace Addon365.WebSync.Controllers
{
    public class SitemapController : Controller
    {
        private readonly IUrls _urls;
        public SitemapController(IUrls urls)
        {
            _urls = urls;
        }

        [Route("sitemap")]
        public ActionResult SitemapAsync()
        {
            string baseUrl = "http://addon.cc/";

            // get a list of published articles
            var urls = _urls.getUrls;

            // get last modified date of the home page
            var siteMapBuilder = new SitemapBuilder();

            // add the home page to the sitemap
            siteMapBuilder.AddUrl(baseUrl, modified: DateTime.UtcNow, changeFrequency: ChangeFrequency.Weekly, priority: 1.0);

            // add the blog posts to the sitemap
            foreach (var page in urls )
            {
                siteMapBuilder.AddUrl(baseUrl + page.Url, modified: page.Published, changeFrequency: page.Frequency, priority: page.Priority);
            }

            // generate the sitemap xml
            string xml = siteMapBuilder.ToString();
            return Content(xml, "text/xml");

        }
    }
    public enum ChangeFrequency
    {
        Always,
        Hourly,
        Daily,
        Weekly,
        Monthly,
        Yearly,
        Never
    }

    public class SitemapUrl
    {
        public string Url { get; set; }
        public DateTime? Modified { get; set; }
        public ChangeFrequency? ChangeFrequency { get; set; }
        public double? Priority { get; set; }
    }
    public class SitemapBuilder
    {
        private readonly XNamespace NS = "http://www.sitemaps.org/schemas/sitemap/0.9";

        private List<SitemapUrl> _urls;

        public SitemapBuilder()
        {
            _urls = new List<SitemapUrl>();
        }

        public void AddUrl(string url, DateTime? modified = null, ChangeFrequency? changeFrequency = null, double? priority = null)
        {
            _urls.Add(new SitemapUrl()
            {
                Url = url,
                Modified = modified,
                ChangeFrequency = changeFrequency,
                Priority = priority,
            });
        }

        public override string ToString()
        {
            var sitemap = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(NS + "urlset",
                    from item in _urls
                    select CreateItemElement(item)
                    ));

            return sitemap.ToString();
        }

        private XElement CreateItemElement(SitemapUrl url)
        {
            XElement itemElement = new XElement(NS + "url", new XElement(NS + "loc", url.Url.ToLower()));

            if (url.Modified.HasValue)
            {
                itemElement.Add(new XElement(NS + "lastmod", url.Modified.Value.ToString("yyyy-MM-ddTHH:mm:ss.f") + "+00:00"));
            }

            if (url.ChangeFrequency.HasValue)
            {
                itemElement.Add(new XElement(NS + "changefreq", url.ChangeFrequency.Value.ToString().ToLower()));
            }

            if (url.Priority.HasValue)
            {
                itemElement.Add(new XElement(NS + "priority", url.Priority.Value.ToString("N1")));
            }

            return itemElement;
        }
    }
}