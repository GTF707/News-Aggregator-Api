using Domain.PersistentObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class News : PersistentObject
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; } 
        public DateTimeOffset PublishDate { get; set; }
        public NewsSite NewsSite { get; set; }
        public long NewsSiteId { get; set; }
        public News() { }
    }
}