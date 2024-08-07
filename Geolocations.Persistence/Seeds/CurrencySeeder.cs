using Geolocations.Domain.Entities;

namespace Geolocations.Persistence.Seeds;

public class CurrencySeeder
{
    public static Currency[] GetData() => [
        new Currency {
            ISOCode = "UAH",
            ISONumber = 980,
            ShortName = "uah",
            FullName = "Ukrainian hryvnia",
            Symbol = "₴"
        },
        new Currency {
            ISOCode = "USD",
            ISONumber = 840,
            ShortName = "usd",
            FullName = "American dollar",
            Symbol = "$"
        },
        new Currency {
            ISOCode = "EUR",
            ISONumber = 978,
            ShortName = "eur",
            FullName = "Euro",
            Symbol = "€"
        },
        new Currency {
            ISOCode = "RUB",
            ISONumber = 643,
            ShortName = "rub",
            FullName = "Russian rubble",
            Symbol = "₽"
        },
    ];
}