﻿using Application.Domain.Book;
using Application.Domain.Country;

namespace Application.Tests
{
    public class AuthorBuilder
    {
        private string _name;
        private Country _country;

        private AuthorBuilder(string name, Country country)
        {
            _name = name;
            _country = country;
        }

        public static AuthorBuilder StanLee()
        {
            return new AuthorBuilder("Stan Lee", CountryBuilder.USA().Build());
        }

        public AuthorBuilder From(Country country)
        {
            _country = country;
            return this;
        }
        
        public Author Build()
        {
            return new Author(_name, _country);
        }

    }
}