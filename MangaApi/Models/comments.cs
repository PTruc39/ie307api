using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaApi.Models
{
    public class comments
    {
        public int userID { get; set; }
        public int commentID { get; set; }
        public int? mangaID { get; set; } = null;
        public int? blogID { get; set; } = null;
        public string comment { get; set; }
    }
}