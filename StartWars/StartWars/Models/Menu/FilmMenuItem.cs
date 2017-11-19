using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartWars.Models.Menu
{
    public class FilmMenuItem
    {
        public short Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public FilmMenuItem(short Id ,string Title, string Description)
        {
            this.Title = Title;
            this.Description = Description;
            this.Id = Id;
        }
    }
}
