using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace BookStoreApp
{
    public class Book
    {
        public Book()
        {
            objAuthor = new Author();
            objCategory = new Category();
            objPublisher = new Publisher();
        }
        public int BookID { get; set; }
        public Category objCategory { get; set; }
        public string Title { get; set; }
        public Author objAuthor { get; set; }
        public Publisher objPublisher { get; set; }
        public string BookDescription { get; set; }
        public string Price { get; set; }
        public string ISBN { get; set; }
        public string PublicationDate { get; set; }
    }
}
