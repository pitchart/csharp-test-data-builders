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
            var Usa = CountryBuilder.USA().Build();
            var StanLee = AuthorBuilder.StanLee().From(Usa).Build();

            inMemoryRepository.AddInvoice(null);

            //Act
            var amount = generator.GetTotalAmount();

            //Assert

            MainRepository.Reset();
        }
    }
}
