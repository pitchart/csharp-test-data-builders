using System;
using System.Collections.Generic;
using System.Linq;
using Application.Finance;
using Application.Purchase;
using Application.Storage;

namespace Application.Report
{
    public class ReportGenerator
    {
        private readonly IRepository _repository ;

        public ReportGenerator(IRepository repository)
        {
            _repository = repository;
        }
        
        public double GetTotalAmount()
        {
            var invoices = _repository.GetInvoiceMap().Values;
            var totalAmount = invoices.Sum(invoice => CurrencyConverter.ToUsd(invoice.ComputeTotalAmount(), invoice.Country.Currency));
            totalAmount = Math.Round(totalAmount * 100) / 100;
            return totalAmount;
        }

        public int GetTotalSoldBooks()
        {
            var invoices = _repository.GetInvoiceMap().Values;
            var totalSoldBooks = invoices
                .Sum(invoice => invoice.PurchasedBooks.Sum(purchasedBook => purchasedBook.Quantity));

            return totalSoldBooks;
        }

        public long GetNumberOfIssuedInvoices() => _repository.GetInvoiceMap().Count;
    }
}
