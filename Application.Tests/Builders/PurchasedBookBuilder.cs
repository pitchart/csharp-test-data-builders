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

        public PurchasedBookBuilder WithBook(IBook book)
        {
            _book = book;
            return this;
        }
        public PurchasedBookBuilder Containing(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public PurchasedBook Build()
        {
            return new PurchasedBook(_book, _quantity);
        }

        public static PurchasedBookBuilder APurchase()
        {
            return new PurchasedBookBuilder(3, BookBuilder.AEducationBook().Build());
        }


    }
}