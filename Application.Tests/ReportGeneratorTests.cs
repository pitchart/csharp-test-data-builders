using System;
using System.Text;
using Application.Domain.Book;
using Application.Purchase;
using Application.Report;
using Application.Tests.Builders;
using Application.Tests.Storage;
using Xunit;

namespace Application.Tests
{
    public class ReportGeneratorTests
    {
        [Fact]
        public void ShouldComputeTotalAmount_WithoutDiscount_WithoutTaxExchange()
        {
            //Arrange
            InMemoryRepository inMemoryRepository = new InMemoryRepository();
            MainRepository.Override(inMemoryRepository);
            ReportGenerator generator = new ReportGenerator();

            var Usa = CountryBuilder.USA().Build();
            var StanLee = AuthorBuilder.StanLee().From(Usa).Build();

            EducationalBook book = (EducationalBook)BookBuilder.AEducationBook().Build();

            PurchasedBook purchasedBook = PurchasedBookBuilder.APurchase().Containing(1).WithBook(book).Build();

            Invoice invoice = InvoiceBuilder.AEmptyInvoice().WithPurchaseBook(purchasedBook).From(Usa).Build();

            inMemoryRepository.AddInvoice(invoice);
            
            //Assert
            Assert.Equal(10, generator.GetTotalAmount());
            Assert.Equal(1, generator.GetNumberOfIssuedInvoices());
            Assert.Equal(1, generator.GetTotalSoldBooks());

            MainRepository.Reset();
        }
    }
}
