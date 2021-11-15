using Application.Domain.Country;

namespace Application.Tests.Builders
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

        public static CountryBuilder Usa => new CountryBuilder("USA", Currency.UsDollar, Language.English);
        public static CountryBuilder France => new CountryBuilder("France", Currency.Euro, Language.French);

        public Country Build()
        {
            return new Country(_name, _currency, _language);
        }
    }
}
