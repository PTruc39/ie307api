﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaApi.Models
{
    public class chapter
    {
        public int ChapterID { get; set; }
        public string ChapterName { get; set; }
        public int MangaID { get; set; }
    }
}