using System;
using System.Collections.Generic;
using Application.Domain.Book;
using Application.Domain.Country;
using Diverse;

namespace Application.Tests.Builders
{
    public class BookBuilder
    {
        private string _name;
        private double _price;
        private Author _author;
        private Language _language;
        private Type _type;
        private List<Genre> _genres = new List<Genre>();
        private Category _category;
        private readonly IFuzz _fuzzer;

        private BookBuilder(string name, int price, Author author, Language language, Type type)
        {
            _name = name;
            _price = price;
            _author = author;
            _language = language;
            _type = type;
        }

        private BookBuilder(IFuzz fuzz, Type type)
        {
            _name = fuzz.GenerateSentence(10);
            _price = fuzz.GeneratePositiveInteger(200);
            _author = AuthorBuilder.StanLee.Build();
            _language = fuzz.GenerateEnum<Language>();
            _type = type;
            _fuzzer = fuzz;
        }

        public static BookBuilder ANovel =>
            new BookBuilder("Novel", 10, AuthorBuilder.StanLee.Build(), Language.English, typeof(Novel));

        public static BookBuilder AnEducationBook() =>
            new BookBuilder("EducationalBook", 10, AuthorBuilder.StanLee.Build(), Language.English,
                typeof(EducationalBook));

        public static BookBuilder AnEducationBook(IFuzz fuzz) =>
            new BookBuilder(fuzz,
                typeof(EducationalBook));

        public IBook Build()
        {
            if (_type == typeof(Novel))
            {
                return new Novel(_name, _price, _author, _language, _genres);
            }

            return new EducationalBook(_name, _price, _author, _language, _category);
        }

        public BookBuilder Coasting(int price)
        {
            _price = price;
            return this;
        }
    }
}
