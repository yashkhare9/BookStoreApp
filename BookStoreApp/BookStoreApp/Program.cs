using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace BookStoreApp
{
    class Program
    {

        static void Main(string[] args)
        {
            int Choice;
            BookStore bookstore = new BookStore();
            Book b = new Book();
        l:
            Console.Clear();
            Console.WriteLine("\t===================================================================");
            Console.WriteLine("\t\t\t\tMAIN MENU BOOK STORE");
            Console.WriteLine("\t===================================================================");
            Console.Write("\t1. Adding a new book\n\t2. Displaying all books \n\t3. Displaying a book by BookId \n\t4. Updating a book by BookId \n\t5. Deleting a book by BookId \n\t6. Put the Books in an XML File (Serialize) \n\t7. Read the Books from XML File (Deserialize) \n\t8. List of Authors, Categories & Publishers\n\t9. Exit \n\tEnter Your Choice (any number from 1 to 9): ");
            int BID;
            char subChoice;

            try
            {
                Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        Console.WriteLine();
                        bookstore.AddBook();
                        Console.Write("\n\tEnter c = Contitune or e = Exit.\n\tEnter the choice:");
                        subChoice = Convert.ToChar(Console.ReadLine());
                        if (subChoice == 'c' || subChoice == 'C')
                        {
                            goto l;
                        }
                        else
                            break;

                    case 2:
                        Console.WriteLine();
                        bookstore.DisplayAllBooks();
                        Console.Write("\n\tEnter c = Contitune or e = Exit.\n\tEnter the choice:");
                        subChoice = Convert.ToChar(Console.ReadLine());
                        if (subChoice == 'c' || subChoice == 'C')
                        {
                            goto l;
                        }
                        else
                            break;

                    case 3:
                        Console.Write("\n\tEnter the BookID to display the desired book: ");
                        BID = Convert.ToInt32(Console.ReadLine());
                        bookstore.DisplayBookByBookID(BID);
                        Console.Write("\n\tEnter c = Contitune or e = Exit.\n\tEnter the choice:");
                        subChoice = Convert.ToChar(Console.ReadLine());
                        if (subChoice == 'c' || subChoice == 'C')
                        {
                            goto l;
                        }
                        else
                            break;

                    case 4:
                        Console.Write("\n\tEnter the BookID to update the desired book: ");
                        BID = Convert.ToInt32(Console.ReadLine());
                        bookstore.UpdateBookByBookID(BID);
                        Console.Write("\n\tEnter c = Contitune or e = Exit.\n\tEnter the choice:");
                        subChoice = Convert.ToChar(Console.ReadLine());
                        if (subChoice == 'c' || subChoice == 'C')
                        {
                            goto l;
                        }
                        else
                            break;

                    case 5:
                        Console.Write("\n\tEnter the BookID to delete the desired book: ");
                        BID = Convert.ToInt32(Console.ReadLine());
                        bookstore.DeleteBookByBookID(BID);
                        Console.Write("\n\tEnter c = Contitune or e = Exit.\n\tEnter the choice:");
                        subChoice = Convert.ToChar(Console.ReadLine());
                        if (subChoice == 'c' || subChoice == 'C')
                        {
                            goto l;
                        }
                        else
                            break;

                    case 6:
                        Console.WriteLine("\n\tWriting the books to a XML File at the below location: \n\t" + @"C:\Users\yashkh\Documents\BookStoreApp");
                        bookstore.SerializeBook();
                        Console.Write("\n\tEnter c = Contitune or e = Exit.\n\tEnter the choice:");
                        subChoice = Convert.ToChar(Console.ReadLine());
                        if (subChoice == 'c' || subChoice == 'C')
                        {
                            goto l;
                        }
                        else
                            break;


                    case 7:
                        Console.WriteLine("\n\tReading the books from a XML File from the below location: \n\t" + @"C:\Users\yashkh\Documents\BookStoreApp");
                        bookstore.DeserializeBook();
                        Console.Write("\n\tEnter c = Contitune or e = Exit.\n\tEnter the choice:");
                        subChoice = Convert.ToChar(Console.ReadLine());
                        if (subChoice == 'c' || subChoice == 'C')
                        {
                            goto l;
                        }
                        else
                            break;

                    case 8:
                        Console.Clear();
                        bookstore.DisplayACP();
                        Console.Write("\n\tEnter c = Contitune or e = Exit.\n\tEnter the choice:");
                        subChoice = Convert.ToChar(Console.ReadLine());
                        if (subChoice == 'c' || subChoice == 'C')
                        {
                            goto l;
                        }
                        else
                            break;


                    case 9:
                        break;

                    default:
                        Console.WriteLine("\n\tPlease Choose a right option.\n\n\tDo you wish to continue?");
                        Console.Write("\n\tEnter c = Contitune or e = Exit.\n\tEnter the choice:");
                        subChoice = Convert.ToChar(Console.ReadLine());
                        if (subChoice == 'c' || subChoice == 'C')
                        {
                            goto l;
                        }
                        else
                            break;
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.Write("\n\tSomething Went Wrong. Sorry for the inconvenience.\n\tPress Enter to Restart the application...");
                Console.ReadLine();
                goto l;
            }

        }
    }
}
