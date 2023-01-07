using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaApi.Models
{
    public class manga
    {
        public int MangaID { get; set; }
        public string MangaName { get; set; }
        public string MangaImage { get; set; }
        public string Description { get; set; }
    }
}