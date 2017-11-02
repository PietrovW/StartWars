﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StartWars.Models.Menu
{
   public class NavigationMenuItem
    {
        public string Title { get; set; }
        public ImageSource IconSource { get; set; }
        public NavigationMenuItem(string Title, ImageSource IconSource)
        {
            this.Title = Title;
            this.IconSource = IconSource;
        }
    }
}

