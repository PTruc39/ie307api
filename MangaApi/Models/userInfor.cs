using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaApi.Models
{
    public class userInfor
    {
        public int userID { get; set; }
        public string userName { get;set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}