using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBook.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public string FullName { get; set; }
        public List<string> BookTitle { get; set; }
    }
}
