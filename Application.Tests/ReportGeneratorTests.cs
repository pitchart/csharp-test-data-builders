using System;
using System.Text;
using Application.Domain.Book;
using Application.Purchase;
using Application.Report;
using Application.Storage;
using Application.Tests.Builders;
using Application.Tests.Storage;
using Diverse;
using Xunit;
using Xunit.Abstractions;

namespace Application.Tests
{
    public class ReportGeneratorTests
    {
        private Fuzzer _fuzzer;

        public ReportGeneratorTests(ITestOutputHelper outputHelper)
        {
            Fuzzer.Log = outputHelper.WriteLine;
            _fuzzer = new Fuzzer();
        }
        
        [Fact]
        public void ShouldComputeTotalAmount_WithoutDiscount_WithoutTaxExchange()
        {
            //Arrange
            InMemoryRepository inMemoryRepository = new InMemoryRepository();
            ReportGenerator generator = new ReportGenerator(inMemoryRepository);

            var Usa = CountryBuilder.Usa.Build();

            EducationalBook book = (EducationalBook)_fuzzer.AnEducationBook().Coasting(10).Build();

            PurchasedBook purchasedBook = PurchasedBookBuilder.APurchase.Containing(1, book).Build();

            Invoice invoice = InvoiceBuilder.AnEmptyInvoice.WithPurchaseBook(purchasedBook).From(Usa).Build();

            inMemoryRepository.AddInvoice(invoice);

            //Assert
            Assert.Equal(10 * 1.15, generator.GetTotalAmount());
            Assert.Equal(1, generator.GetNumberOfIssuedInvoices());
            Assert.Equal(1, generator.GetTotalSoldBooks());

        }
        
        [Fact]
        public void ShouldComputeTotalAmount_WithoutDiscount_WithTaxExchange()
        {
            //Arrange
            InMemoryRepository inMemoryRepository = new InMemoryRepository();
            ReportGenerator generator = new ReportGenerator(inMemoryRepository);
            
            var France = CountryBuilder.France.Build();

            EducationalBook book = (EducationalBook)BookBuilder.AnEducationBook().Build();

            PurchasedBook purchasedBook = PurchasedBookBuilder.APurchase.Containing(1, book).Build();

            Invoice invoice = InvoiceBuilder.AnEmptyInvoice.WithPurchaseBook(purchasedBook).From(France).Build();

            inMemoryRepository.AddInvoice(invoice);

            //Assert
            Assert.Equal(Math.Round(10 * 1.14 * 1.25*100)/100, generator.GetTotalAmount());
            Assert.Equal(1, generator.GetNumberOfIssuedInvoices());
            Assert.Equal(1, generator.GetTotalSoldBooks());

        }

        [Fact]
        public void ShouldFixTheBug()
        {
            //Arrange
            ReportGenerator generator = new ReportGenerator( new JsonRepository() );
            
            //Assert
            Assert.Equal(424.57, generator.GetTotalAmount());
            Assert.Equal(6, generator.GetNumberOfIssuedInvoices());
            Assert.Equal(16, generator.GetTotalSoldBooks());
        }
        
    }
}
