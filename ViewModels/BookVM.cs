using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBook.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public string Genre { get; set; }
        public DateTime DateAdded { get; set; }

        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
