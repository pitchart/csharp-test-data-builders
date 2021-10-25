using Application.Domain.Country;

namespace Application.Tests
{
    public class CountryBuilder
    {
        private readonly string _name;
        private readonly Language _language;
        private readonly Currency _currency;

        private CountryBuilder(string name, Currency currency, Language language)
        {
            _currency = currency;
            _name = name;
            _language = language;
        }

        public static CountryBuilder USA()
        {
            return new CountryBuilder("USA", Currency.UsDollar, Language.English);
        }

        public Country Build()
        {
            return new Country(_name, _currency, _language);
        }
    }
}