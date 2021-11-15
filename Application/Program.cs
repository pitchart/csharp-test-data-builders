using System;
using Application.Report;
using Application.Storage;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var reportGenerator = new ReportGenerator(new JsonRepository());

            Console.WriteLine("****************************************************");
            Console.WriteLine("*****************Application Report*****************");
            Console.WriteLine("****************************************************");
            Console.WriteLine();
            Console.WriteLine($"The total number of books sold is: {reportGenerator.GetTotalSoldBooks()}");
            Console.WriteLine($"The total number of issued invoices is: {reportGenerator.GetNumberOfIssuedInvoices()}");
            Console.WriteLine($"The total amount of all invoices in USD is: {reportGenerator.GetTotalAmount():N}");
            Console.WriteLine();
            Console.WriteLine("****************************************************");
            Console.WriteLine("****************************************************");
        }
    }
}

