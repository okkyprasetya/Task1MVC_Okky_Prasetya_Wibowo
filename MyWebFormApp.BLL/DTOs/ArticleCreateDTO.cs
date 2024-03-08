﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebFormApp.BLL.DTOs
{
    public class ArticleCreateDTO
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsApproved { get; set; }
        public string Pic { get; set; }
        public string username { get; set; }
    }
}
