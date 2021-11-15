using Application.Domain.Book;
using Application.Purchase;
using System;

namespace Application.Tests.Builders
{
    public class PurchasedBookBuilder
    {
        private IBook _book;
        private int _quantity;

        public PurchasedBookBuilder(int quantity, IBook book)
        {
            _book = book;
            _quantity = quantity;
        }

        public static PurchasedBookBuilder APurchase => new PurchasedBookBuilder(3, BookBuilder.AnEducationBook.Build());

        public PurchasedBookBuilder Containing(int quantity, IBook book)
        {
            _quantity = quantity;
            _book = book;
            return this;
        }

        public PurchasedBook Build()
        {
            return new PurchasedBook(_book, _quantity);
        }
    }
}
