﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Crawl.Models
{
    public enum MenuItemType
    {
        Home,
        Items,
        Characters,
        About
    }
    class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
