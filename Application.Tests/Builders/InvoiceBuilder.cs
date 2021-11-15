using System.Collections.Generic;
using Application.Purchase;

namespace Application.Tests.Builders
{
    internal class InvoiceBuilder
    {
        private string _clientName;
        private Domain.Country.Country _country;
        private List<PurchasedBook> _books;

        public InvoiceBuilder(string clientName, Domain.Country.Country country, List<PurchasedBook> purchasedBooks)
        {
            _clientName = clientName;
            _country = country;
            _books = purchasedBooks;
        }

        internal static InvoiceBuilder AnEmptyInvoice =>
            new InvoiceBuilder("David", CountryBuilder.Usa.Build(), new List<PurchasedBook>());

        internal Invoice Build()
        {
            var invoice = new Invoice(_clientName, _country);
            invoice.AddPurchasedBooks(_books);

            return invoice;
        }

        internal InvoiceBuilder From(Domain.Country.Country country)
        {
            _country = country;
            return this;
        }

        internal InvoiceBuilder WithPurchaseBook(PurchasedBook purchasedBook)
        {
            _books.Add(purchasedBook);
            return this;
        }
    }
}
