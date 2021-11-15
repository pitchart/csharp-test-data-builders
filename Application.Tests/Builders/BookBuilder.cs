using System;
using System.Collections.Generic;
using Application.Domain.Book;
using Application.Domain.Country;

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

        private BookBuilder(string name, int price, Author author, Language language, Type type)
        {
            _name = name;
            _price = price;
            _author = author;
            _language = language;
            _type = type;
        }

        public static BookBuilder ANovel =>
            new BookBuilder("Novel", 10, AuthorBuilder.StanLee.Build(), Language.English, typeof(Novel));

        public static BookBuilder AnEducationBook =>
            new BookBuilder("EducationalBook", 10, AuthorBuilder.StanLee.Build(), Language.English,
                typeof(EducationalBook));

        public IBook Build()
        {
            if (_type == typeof(Novel))
            {
                return new Novel(_name, _price, _author, _language, _genres);
            }

            return new EducationalBook(_name, _price, _author, _language, _category);
        }
    }
}
