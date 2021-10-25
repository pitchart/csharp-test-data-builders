using System;
using System.Collections.Generic;
using System.Text;
using Application.Purchase;
using Application.Report;
using Application.Tests.Storage;
using Xunit;

namespace Application.Tests
{
    public class ReportGeneratorTests
    {
        [Fact]
        public void test()
        {
            //Arrange
            ReportGenerator generator = new ReportGenerator();
            InMemoryRepository inMemoryRepository = new InMemoryRepository();
            MainRepository.Override(inMemoryRepository);

            Invoice invoice = new Invoice()
            {
                PurchasedBooks =
                {
                    new PurchasedBook
                    {

                    }
                }
            };
            inMemoryRepository.AddInvoice();

            //Act
            var amount = generator.GetTotalAmount();

            //Assert

            MainRepository.Reset();
        }
    }
}
