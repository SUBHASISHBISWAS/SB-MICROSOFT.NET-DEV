using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo1
{

    class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Price { get; set; }
    }

    //static class MyExtensions
    //{
    //    public static int Sum(this IEnumerable<int> collection)
    //    {
    //        int s = 0;
    //        foreach (int item in collection)
    //        {
    //            s += item;
    //        }
    //        return s;
    //    }

    //    public static double Sum(this IEnumerable<double> collection)
    //    {
    //        double s = 0;
    //        foreach (double item in collection)
    //        {
    //            s += item;
    //        }
    //        return s;
    //    }

    //    public static int Sum<T>(this IEnumerable<T> collection,
    //                             Func<T, int> callback)
    //    {
    //        int s = 0;
    //        foreach (T item in collection)
    //        {
    //            s += callback(item);
    //        }
    //        return s;
    //    }

    //    public static double Sum<T>(this IEnumerable<T> collection,
    //                                Func<T, double> callback)
    //    {
    //        double s = 0;
    //        foreach (T item in collection)
    //        {
    //            s += callback(item);
    //        }
    //        return s;
    //    }

    //    public static IEnumerable<TReturn> Select<T,TReturn> ( this IEnumerable<T> collection,
    //                                                           Func<T,TReturn> callback)
    //    {
    //        foreach (T item in collection)
    //        {
    //           yield return callback(item);
    //        }
    //    }

    //    public static IEnumerable<T> Where<T>(this IEnumerable<T> collection,
    //                                          Func<T,bool> callback)
    //    {
    //        foreach (T item in collection)
    //        {
    //            if (callback(item))
    //                yield return item; 
    //        }
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>();
            numbers.Add(100);
            numbers.Add(200);
            numbers.Add(300);
            Console.WriteLine(numbers.Sum()); // MyExtensions.Sum ( numbers ) ;

            var price = new LinkedList<double>();
            price.AddLast(100.4);
            price.AddLast(200.4);
            price.AddLast(300.4);
            Console.WriteLine(price.Sum()); // MyExtensions.Sum ( numbers ) ;

            var books = new List<Book>();
            books.Add(new Book() {Title="T1", Author="A1", Price = 1000 });
            books.Add(new Book() {Title="T2", Author="A2", Price = 2000 });
            books.Add(new Book() {Title="T3", Author="A1", Price = 3000 });
            Console.WriteLine(books.Sum(b => b.Price));

            var query1 = (from b in books
                         where b.Author == "A1" 
                         select b.Title).Count();
            
            Console.WriteLine(query1);

            //var query1 = books
            //             .Where(b => b.Author == "A1" && b.Publisher == "P1")
            //             .Select(b => b.Title);

            //foreach (string title in query1)
            //{
            //    Console.WriteLine(title);
            //}
            
        }

        //static int GetPrice(Book b)
        //{
        //    return b.Price;
        //}
    }
}
