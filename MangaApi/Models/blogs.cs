using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaApi.Models
{
    public class blogs
    {
        public string BlogName { get; set; }
        public string BlogImg { get; set; }
        public string BlogContent { get; set; }
        public int UserID { get; set; }
    }
}