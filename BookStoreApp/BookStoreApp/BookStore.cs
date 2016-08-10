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
    class BookStore
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
        public static int BookIDCount = 0, AuthorIDCount = 0, CategoryIDCount = 0, PublisherIDCount = 0;
        public static List<Book> storedBooks = new List<Book>();
        public static List<Author> authorList = new List<Author>();
        public static List<Category> categoryList = new List<Category>();
        public static List<Publisher> publisherList = new List<Publisher>();
        double numericvaluecheck;
        DateTime date;
        int authorFlag = 1, categoryFlag = 1, publisherFlag = 1;


        /// <summary>                                                                                   <summaey> ///
        /////////////////////      Populating All the Tables in the DATABASE        /////////////////////////////////
        /// </summary>                                                                                  <summaey> ///


        public BookStore()
        {
            //For BookS
            for (int j = 1; j <= 5; j++)
            {
                Book b = new Book();
                b.BookID = ++BookIDCount;
                b.objAuthor.AuthorName = "A" + j + 1;
                b.objCategory.CategoryName = "C" + j + 1;
                b.objPublisher.PublisherName = "P" + j + 1;
                b.Title = "Ti" + j + 1;
                b.Price = "1000" + (j * 10 - j);
                b.ISBN = "1000" + j;
                b.PublicationDate = DateTime.Now.ToShortDateString();
                b.BookDescription = "BD" + j + 1;
                storedBooks.Add(b);
            }

            //For Author
            for (int j = 1; j <= 5; j++)
            {
                Author a = new Author();
                a.AuthorID = ++AuthorIDCount;
                a.AuthorName = "A" + j + 1;
                a.DOB = DateTime.Now.ToShortDateString();
                a.State = "AS" + j + 1;
                a.City = "AC" + j + 1;
                a.Phone = "9854701234";
                authorList.Add(a);
            }

            //For Category
            for (int j = 1; j <= 5; j++)
            {
                Category c = new Category();
                c.CategoryID = ++CategoryIDCount;
                c.CategoryName = "C" + j + 1;
                c.CategoryDescription = "CD" + j + 1;
                categoryList.Add(c);
            }

            //For Publisher
            for (int j = 1; j <= 5; j++)
            {
                Publisher p = new Publisher();
                p.PublisherID = ++PublisherIDCount;
                p.PublisherName = "P" + j + 1;
                p.DOB = DateTime.Now.ToShortDateString();
                p.State = "PS" + j + 1;
                p.City = "PC" + j + 1;
                p.Phone = "9854701234";
                publisherList.Add(p);
            }

        }




        /// <summary>                                                                             <summaey> ///
        /////////////////////      Adding A Book to the database           ////////////////////////////////////
        /// </summary>                                                                            <summaey> ///

        public void AddBook()
        {
            Console.Clear();
            Author objA1 = new Author();
            Console.WriteLine("\n\t=================================================================");
            Console.WriteLine("\n\tEnter the details of the book:\n");
            Book b = new Book();
            BookIDCount++;
            b.BookID = BookIDCount;
            Console.WriteLine("\tBookID: {0}", b.BookID);
            Console.Write("\tEnter Title: ");
            b.Title = Console.ReadLine();
            Console.Write("\tEnter Author ID: ");
            b.objAuthor.AuthorID = Convert.ToInt32(Console.ReadLine());
            foreach (Author a3 in authorList)
            {
                if (a3.AuthorID == b.objAuthor.AuthorID)
                {
                    b.objAuthor.AuthorName = a3.AuthorName;
                    Console.WriteLine("\tAuthor Name: {0}", b.objAuthor.AuthorName);
                    authorFlag = 0;
                    break;
                }
            }
            if (authorFlag == 1)
            {
                Console.WriteLine("\tAuthor ID not available. Please Update Author details.");
                b.objAuthor.AuthorName = AddAuthor();
                Console.WriteLine("\tAuthor Name: {0}", b.objAuthor.AuthorName);
            }
            Console.Write("\tEnter Category ID: ");
            b.objCategory.CategoryID = Convert.ToInt32(Console.ReadLine());
            foreach (Category c3 in categoryList)
            {
                if (c3.CategoryID == b.objCategory.CategoryID)
                {
                    b.objCategory.CategoryName = c3.CategoryName;
                    Console.WriteLine("\tCategory Name: {0}", b.objCategory.CategoryName);
                    categoryFlag = 0;
                    break;
                }
            }
            if (categoryFlag == 1)
            {
                Console.WriteLine("\tCategory ID not available. Please Update Category details.");
                b.objCategory.CategoryName = AddCategory();
                Console.WriteLine("\tAuthor Name: {0}", b.objCategory.CategoryName);
            }
            Console.Write("\tEnter Book Description: ");
            b.BookDescription = Console.ReadLine();
            Console.Write("\tEnter ISBN: ");
            b.ISBN = (Console.ReadLine());
            while (double.TryParse(b.ISBN, out numericvaluecheck) == false || double.Parse(b.ISBN) < 0 || b.ISBN == null || b.ISBN.Length > 13)
            {

                Console.WriteLine("\n\tISBN should be a 13 digit unique no. ISBN Can't be less than 0.");
                Console.Write("\tEnter ISBN: ");
                b.ISBN = (Console.ReadLine());
            }
            Console.Write("\tEnter Price: $ ");
            b.Price = Console.ReadLine();
            while (double.TryParse(b.Price, out numericvaluecheck) == false || int.Parse(b.Price) < 0 || b.Price == null)
            {
                Console.WriteLine("\n\tEnter the right price of the book.");
                Console.Write("\tEnter Price: $ ");
                b.Price = Console.ReadLine();
            }
            Console.Write("\tEnter Publication Date(mm/dd/yyyy or mm/yyyy/dd or yyyy/mm/dd): ");
            b.PublicationDate = Console.ReadLine();
            while (DateTime.TryParse(b.PublicationDate, out date) == false || b.PublicationDate == null)// || DateTime.Parse(b.PublicationDate) > )
            {
                Console.WriteLine("\n\tPlease Enter a valid date.");
                Console.Write("\tEnter Publication Date(mm/dd/yyyy or mm/yyyy/dd or yyyy/mm/dd): ");
                b.PublicationDate = Console.ReadLine();
            }
            b.PublicationDate = date.ToShortDateString();
            Console.Write("\tEnter Publisher ID: ");
            b.objPublisher.PublisherID = Convert.ToInt32(Console.ReadLine());
            foreach (Publisher p3 in publisherList)
            {
                if (p3.PublisherID == b.objPublisher.PublisherID)
                {
                    b.objPublisher.PublisherName = p3.PublisherName; 
                    Console.WriteLine("\tPublisher Name: {0}", b.objPublisher.PublisherName);
                    publisherFlag = 0;
                    break;
                }
            }
            if (publisherFlag == 1)
            {
                Console.WriteLine("\tPublisher ID not available. Please Update Publisher details.");
                b.objPublisher.PublisherName = AddPublisher();
                Console.WriteLine("\tPublisher Name: {0}", b.objPublisher.PublisherName);
            }
            Console.WriteLine("\n\t\"New Book Added\"\n");
            storedBooks.Add(b);
            Console.WriteLine("\t=================================================================");
        }

        /// <summary>                                                                           <summaey> ///
        /////////////////////      Display Books from database           ////////////////////////////////////
        /// </summary>                                                                          <summaey> ///

        public void DisplayBook()
        {
            Console.Clear();
            Console.WriteLine("\n\t=================================================================");
            Console.WriteLine("\n\tThe Details of Books are: \n");
            if (storedBooks.Count == 0)
            {
                Console.WriteLine("\n\t\"No books in database.\"");
            }
            else
            {
                foreach (Book displaybook in storedBooks)
                {
                    Console.WriteLine("\tBookID: {0}", displaybook.BookID);
                    Console.WriteLine("\tAuthor Name: {0}", displaybook.objAuthor.AuthorName);
                    Console.WriteLine("\tCategory Name: {0}", displaybook.objCategory.CategoryName);
                    Console.WriteLine("\tTitle: {0}", displaybook.Title);
                    Console.WriteLine("\tPublisher Name: {0}", displaybook.objPublisher.PublisherName);
                    Console.WriteLine("\tPublication Date: {0}", displaybook.PublicationDate);
                    Console.WriteLine("\tPrice: $ {0}/-", displaybook.Price);
                    Console.WriteLine("\tISBN: {0}", displaybook.ISBN);
                    Console.WriteLine("\tAbout Book:{0}", displaybook.BookDescription);
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n\t================================================================="); Console.WriteLine("\tThe details of the book are:\n");
        }



        /// <summary>                                                                                   <summaey> ///
        /////////////////////      Display Book by BooKID from database           ///////////////////////////////////
        /// </summary>                                                                                  <summaey> ///

        public void DisplayBookByBookID(int BID)
        {
            Console.Clear();
            Console.WriteLine("\n\t=================================================================");
            foreach (Book book in storedBooks)
            {
                if (book.BookID == BID)
                {
                    Console.WriteLine("\n\tThe Details of the Book are: \n");
                    Console.WriteLine("\tBookID: {0}", book.BookID);
                    Console.WriteLine("\tAuthor Name: {0}", book.objAuthor.AuthorName);
                    Console.WriteLine("\tCategory Name: {0}", book.objCategory.CategoryName);
                    Console.WriteLine("\tTitle: {0}", book.Title);
                    Console.WriteLine("\tPublisher Name: {0}", book.objPublisher.PublisherName);
                    Console.WriteLine("\tPublication Date: {0}", book.PublicationDate);
                    Console.WriteLine("\tPrice: $ {0}/-", book.Price);
                    Console.WriteLine("\tISBN: {0}", book.ISBN);
                    Console.WriteLine("\tAbout Book:{0}", book.BookDescription);
                    Console.WriteLine();
                }
            }
            if (storedBooks.Count == 0 || BID > BookIDCount)
            {
                Console.WriteLine("\n\t\"BookID doesn't exist or deleted.\"");
            }
            Console.WriteLine("\n\t=================================================================");
        }

        /// <summary>                                                                                   <summaey> ///
        /////////////////////      Update Book by BooKID from database           ////////////////////////////////////
        /// </summary>                                                                                  <summaey> ///

        public void UpdateBookByBookID(int BID)
        {
            Console.Clear();
            Console.WriteLine("\n\t=================================================================");
            foreach (Book updatebook in storedBooks)
            {
                if (updatebook.BookID == BID)
                {
                    //Console.Clear();
                    Console.WriteLine("\n\tThe Details of the Book are: \n");
                    Console.WriteLine("\tBookID: {0}", updatebook.BookID);
                    Console.WriteLine("\tAuthor Name: {0}", updatebook.objAuthor.AuthorName);
                    Console.WriteLine("\tCategory Name: {0}", updatebook.objCategory.CategoryName);
                    Console.WriteLine("\tTitle: {0}", updatebook.Title);
                    Console.WriteLine("\tPublisher Name: {0}", updatebook.objPublisher.PublisherName);
                    Console.WriteLine("\tPublication Date: {0}", updatebook.PublicationDate);
                    Console.WriteLine("\tPrice: $ {0}/-", updatebook.Price);
                    Console.WriteLine("\tISBN: {0}", updatebook.ISBN);
                    Console.WriteLine("\tAbout Book:{0}", updatebook.BookDescription);
                    Console.WriteLine();
                    Console.WriteLine("\t=================================================================");
                    Console.WriteLine("\n\tEnter the updated details below: \n");
                    Console.WriteLine("\tBookID: {0}", updatebook.BookID);
                    Console.Write("\tEnter Title: ");
                    updatebook.Title = Console.ReadLine();
                    Console.Write("\tEnter Author ID: ");
                    updatebook.objAuthor.AuthorID = Convert.ToInt32(Console.ReadLine());
                    foreach (Author a3 in authorList)
                    {
                        if (a3.AuthorID == updatebook.objAuthor.AuthorID)
                        {
                            updatebook.objAuthor.AuthorName = a3.AuthorName;
                            Console.WriteLine("\tAuthor Name: {0}", updatebook.objAuthor.AuthorName);
                            authorFlag = 0;
                            break;
                        }
                    }
                    if (authorFlag == 1)
                    {
                        Console.WriteLine("\tAuthor ID not available. Please Update Author details.");
                        updatebook.objAuthor.AuthorName = AddAuthor();
                        Console.WriteLine("\tAuthor Name: {0}", updatebook.objAuthor.AuthorName);
                    }

                    Console.Write("\tEnter Category ID: ");
                    updatebook.objCategory.CategoryID = Convert.ToInt32(Console.ReadLine());
                    foreach (Category c3 in categoryList)
                    {
                        if (c3.CategoryID == updatebook.objCategory.CategoryID)
                        {
                            updatebook.objCategory.CategoryName = c3.CategoryName;
                            Console.WriteLine("\tCategory Name: {0}", updatebook.objCategory.CategoryName);
                            categoryFlag = 0;
                            break;
                        }
                    }
                    if (categoryFlag == 1)
                    {
                        Console.WriteLine("\tCategory ID not available. Please Update Category details.");
                        updatebook.objCategory.CategoryName = AddCategory();
                        Console.WriteLine("\tAuthor Name: {0}", updatebook.objCategory.CategoryName);
                    }
                    Console.Write("\tEnter Book Description: ");
                    updatebook.BookDescription = Console.ReadLine();
                    Console.Write("\tEnter ISBN: ");
                    updatebook.ISBN = (Console.ReadLine());
                    while (double.TryParse(updatebook.ISBN, out numericvaluecheck) == false || double.Parse(updatebook.ISBN) < 0 || updatebook.ISBN == null || updatebook.ISBN.Length > 13)
                    {

                        Console.WriteLine("\n\tISBN should be a 13 digit unique no. ISBN Can't be less than 0.");
                        Console.Write("\tEnter ISBN: ");
                        updatebook.ISBN = (Console.ReadLine());
                    }
                    Console.Write("\tEnter Price: $ ");
                    updatebook.Price = Console.ReadLine();
                    while (double.TryParse(updatebook.Price, out numericvaluecheck) == false || int.Parse(updatebook.Price) < 0 || updatebook.Price == null)
                    {
                        Console.WriteLine("\n\tEnter the right price of the book.");
                        Console.Write("\tEnter Price: $ ");
                        updatebook.Price = Console.ReadLine();
                    }
                    Console.Write("\tEnter Publication Date(mm/dd/yyyy or mm/yyyy/dd or yyyy/mm/dd): ");
                    updatebook.PublicationDate = Console.ReadLine();
                    while (DateTime.TryParse(updatebook.PublicationDate, out date) == false || updatebook.PublicationDate == null)// || DateTime.Parse(b.PublicationDate) > )
                    {
                        Console.WriteLine("\n\tPlease Enter a valid date.");
                        Console.Write("\tEnter Publication Date(mm/dd/yyyy or mm/yyyy/dd or yyyy/mm/dd): ");
                        updatebook.PublicationDate = Console.ReadLine();
                    }
                    updatebook.PublicationDate = date.ToShortDateString();
                    Console.Write("\tEnter Publisher ID: ");
                    updatebook.objPublisher.PublisherID = Convert.ToInt32(Console.ReadLine());
                    foreach (Publisher p3 in publisherList)
                    {
                        if (p3.PublisherID == updatebook.objPublisher.PublisherID)
                        {
                            updatebook.objPublisher.PublisherName = p3.PublisherName;
                            Console.WriteLine("\tPublisher Name: {0}", updatebook.objPublisher.PublisherName);
                            publisherFlag = 0;
                            break;
                        }
                    }
                    if (publisherFlag == 1)
                    {
                        Console.WriteLine("\tPublisher ID not available. Please Update Publisher details.");
                        updatebook.objPublisher.PublisherName = AddPublisher();
                        Console.WriteLine("\tPublisher Name: {0}", updatebook.objPublisher.PublisherName);
                    }
                    Console.WriteLine("\n\t\"Book updated\"\n\n");

                }
            }
            if (BookIDCount <= 0 || BID > BookIDCount || storedBooks.Count == 0)
            {
                Console.WriteLine("\n\t\"BookID doesn't exist or deleted.\"");
            }
            Console.WriteLine("\n\t=================================================================");
        }


        /// <summary>                                                                                   <summaey> ///
        /////////////////////      Delete Book by BooKID from database           ////////////////////////////////////
        /// </summary>                                                                                  <summaey> ///

        public void DeleteBookByBookID(int BID)
        {
            Console.Clear();
            Console.WriteLine("\n\t=================================================================");
            foreach (Book deletebook in storedBooks)
            {
                if (deletebook.BookID == BID)
                {
                    //Console.Clear();
                    Console.WriteLine("\n\tThe Details of the Book are: \n");
                    Console.WriteLine("\tBookID: {0}", deletebook.BookID);
                    Console.WriteLine("\tAuthor Name: {0}", deletebook.objAuthor.AuthorName);
                    Console.WriteLine("\tCategory Name: {0}", deletebook.objCategory.CategoryName);
                    Console.WriteLine("\tTitle: {0}", deletebook.Title);
                    Console.WriteLine("\tPublisher Name: {0}", deletebook.objPublisher.PublisherName);
                    Console.WriteLine("\tPublication Date: {0}", deletebook.PublicationDate);
                    Console.WriteLine("\tPrice: $ {0}/-", deletebook.Price);
                    Console.WriteLine("\tISBN: {0}", deletebook.ISBN);
                    Console.WriteLine("\tAbout Book:{0}", deletebook.BookDescription);
                    storedBooks.Remove(deletebook);
                    Console.WriteLine("\n\t\"This Book is deleted.\"");
                    break;
                }
            }
            if (BookIDCount <= 0 || BID > BookIDCount || storedBooks.Count == 0)
            {
                Console.WriteLine("\n\t\"BookID doesn't exist or deleted.\"");
            }
            Console.WriteLine("\n\t=================================================================");
        }

        /// <summary>                                                                                   <summaey> ///
        /////////////////////      Serialization of books into XML File           ///////////////////////////////////
        /// </summary>                                                                                  <summaey> ///

        public void SerializeBook()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Users\yashkh\Documents\BookStoreApp\BookStoreApp.xml"))
                {
                    serializer.Serialize(writer, storedBooks);
                    Console.WriteLine("\tBooks object serialized successfully");
                }
            }
            catch (SerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        /// <summary>                                                                                     <summaey> ///
        /////////////////////      DeSerialization of books from XML File           ///////////////////////////////////
        /// </summary>                                                                                    <summaey> ///


        public void DeserializeBook()
        {
            List<Book> books = new List<Book>();
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\yashkh\Documents\BookStoreApp\BookStoreApp.xml"))
                {
                    books = (List<Book>)serializer.Deserialize(reader);
                    Console.WriteLine("\tDeserializing Book object - Reading from xml file");
                    foreach (Book Db in books)
                    {
                        Console.WriteLine("\tBookID: {0}", Db.BookID);
                        Console.WriteLine("\tAuthor Name: {0}", Db.objAuthor.AuthorName);
                        Console.WriteLine("\tCategory Name: {0}", Db.objCategory.CategoryName);
                        Console.WriteLine("\tTitle: {0}", Db.Title);
                        Console.WriteLine("\tPublisher Name: {0}", Db.objPublisher.PublisherName);
                        Console.WriteLine("\tPublication Date: {0}", Db.PublicationDate);
                        Console.WriteLine("\tPrice: $ {0}/-", Db.Price);
                        Console.WriteLine("\tISBN: {0}", Db.ISBN);
                        Console.WriteLine("\tAbout Book:{0}", Db.BookDescription);
                        Console.WriteLine();
                    }
                }
            }
            catch (SerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>                                                                                         <summaey> ///
        /////////////////////      Add & Display Author / Category / Publisher          ///////////////////////////////////
        /// </summary>                                                                                        <summaey> ///


        public string AddAuthor()
        {
            Author a1 = new Author();
            Console.Clear();
            Console.WriteLine("\tEnter The New Authr Details:");
            a1.AuthorID = ++CategoryIDCount;
            Console.WriteLine("\tAuthor ID: {0}", a1.AuthorID);
            Console.Write("\tAuthor Name: ");
            a1.AuthorName = Console.ReadLine();
            Console.Write("\tAuthor DOB: ");
            a1.DOB = Console.ReadLine();
            while (DateTime.TryParse(a1.DOB, out date) == false || a1.DOB == null)// || DateTime.Parse(b.PublicationDate) > )
            {
                Console.WriteLine("\n\tPlease Enter a valid date.");
                Console.Write("\tEnter Author DOB (mm/dd/yyyy or mm/yyyy/dd or yyyy/mm/dd): ");
                a1.DOB = Console.ReadLine();
            }
            Console.Write("\tState: ");
            a1.State = Console.ReadLine();
            Console.Write("\tCity: ");
            a1.City = Console.ReadLine();
            Console.Write("\tPhone: ");
            a1.Phone = Console.ReadLine();
            while (double.TryParse(a1.Phone, out numericvaluecheck) == false || double.Parse(a1.Phone) < 0 || a1.Phone == null || a1.Phone.Length > 10)
            {
                Console.WriteLine("\tPlease Enter a valid Phone No.\n\tPhone:");
                a1.Phone = Console.ReadLine();
            }
            authorList.Add(a1);
            Console.WriteLine("\tNew Author Added Successfully.");
            Console.ReadLine();
            Console.Clear();
            return a1.AuthorName;
        }

        public string AddCategory()
        {
            Category c1 = new Category();
            Console.Clear();
            Console.WriteLine("\tEnter The New Category Details:");
            c1.CategoryID = ++CategoryIDCount;
            Console.WriteLine("\tCategory ID: {0}", c1.CategoryID);
            Console.Write("\tCategory Name: ");
            c1.CategoryName = Console.ReadLine();
            Console.Write("\tCategory Description: ");
            c1.CategoryDescription = Console.ReadLine();
            categoryList.Add(c1);
            Console.WriteLine("\tNew Category Added Successfully.");
            Console.ReadLine();
            Console.Clear();
            return c1.CategoryName;
        }

        public string AddPublisher()
        {
            Publisher p1 = new Publisher();
            Console.Clear();
            Console.WriteLine("\tEnter The New Publisher Details: ");
            p1.PublisherID = ++PublisherIDCount;
            Console.WriteLine("\tPublisher ID: {0}", p1.PublisherID);
            Console.Write("\tPublisher Name: ");
            p1.PublisherName = Console.ReadLine();
            while (DateTime.TryParse(p1.DOB, out date) == false || p1.DOB == null)// || DateTime.Parse(b.PublicationDate) > )
            {
                Console.WriteLine("\n\tPlease Enter a valid date.");
                Console.Write("\tEnter Publisher DOB (mm/dd/yyyy or mm/yyyy/dd or yyyy/mm/dd): ");
                p1.DOB = Console.ReadLine();
            }
            Console.Write("\tState: ");
            p1.State = Console.ReadLine();
            Console.Write("\tCity: ");
            p1.City = Console.ReadLine();
            Console.Write("\tPhone: ");
            p1.Phone = Console.ReadLine();
            p1.Phone = Console.ReadLine();
            while (double.TryParse(p1.Phone, out numericvaluecheck) == false || double.Parse(p1.Phone) < 0 || p1.Phone == null || p1.Phone.Length > 10)
            {
                Console.WriteLine("\tPlease Enter a valid Phone No.\n\tPhone:");
                p1.Phone = Console.ReadLine();
            }
            publisherList.Add(p1);
            Console.WriteLine("\tNew Publisher Added Successfully.");
            Console.ReadLine();
            Console.Clear();
            return p1.PublisherName;
        }

        public void DisplayACP()
        {
            int cho;
            x:
            Console.WriteLine("\tChoose a option:\n\t1. Author's List\n\t2. Publisher's List\n\t3. Category List\n\t4. Exit");
            Console.Write("\tEnter Choice: ");
            cho = Convert.ToInt32(Console.ReadLine());
            switch (cho)
            {
                case 1:
                        Console.Clear();
                        foreach (Author a2 in authorList)
                        {
                            Console.WriteLine("\tAuthorID: {0}", a2.AuthorID);
                            Console.WriteLine("\tAuthor Name: {0}", a2.AuthorName);
                            Console.WriteLine("\tAuthor DOB: {0}", a2.DOB);
                            Console.WriteLine("\tState: {0}", a2.State);
                            Console.WriteLine("\tCity: {0}", a2.City);
                            Console.WriteLine("\tPhone: {0}", a2.Phone);
                            Console.WriteLine();
                        }
                    break;

                case 2:
                        Console.Clear();
                        foreach (Publisher p2 in publisherList)
                        {
                            Console.WriteLine("\tPublisherID: {0}", p2.PublisherID);
                            Console.WriteLine("\tPublisher Name: {0}", p2.PublisherName);
                            Console.WriteLine("\tPublisher DOB: {0}", p2.DOB);
                            Console.WriteLine("\tState: {0}", p2.State);
                            Console.WriteLine("\tCity: {0}", p2.City);
                            Console.WriteLine("\tPhone: {0}", p2.Phone);
                            Console.WriteLine();
                    }
                        break;

                case 3:
                        Console.Clear();
                        foreach (Category c2 in categoryList)
                        {
                            Console.WriteLine("\tCategoryID: {0}", c2.CategoryID);
                            Console.WriteLine("\tCategory Name: {0}", c2.CategoryName);
                            Console.WriteLine("\tCategory Description: {0}", c2.CategoryDescription);
                            Console.WriteLine();
                    }
                        break;

                case 4:
                    break;

                default:
                    Console.WriteLine("\tCchoose a Correct Option.");
                    goto x;
            }
        }
    }
}

