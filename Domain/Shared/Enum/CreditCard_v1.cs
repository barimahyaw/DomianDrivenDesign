namespace Domain.Shared.Enum;

public class CreditCard_v1 : Enumeration<CreditCard_v1>
{
    public static readonly CreditCard_v1 Visa = new(1, nameof(Visa));
    public static readonly CreditCard_v1 MasterCard = new(2, nameof(MasterCard));
    public static readonly CreditCard_v1 AmericanExpress = new(3, nameof(AmericanExpress));
    public static readonly CreditCard_v1 Discover = new(4, nameof(Discover));
    public static readonly CreditCard_v1 DinersClub = new(5, nameof(DinersClub));
    public static readonly CreditCard_v1 JCB = new(6, nameof(JCB));
    public static readonly CreditCard_v1 Unknown = new(7, nameof(Unknown));

    private CreditCard_v1(int id, string name) : base(id, name) { }

    public static IEnumerable<CreditCard_v1> List() =>
        new[] { Visa, MasterCard, AmericanExpress, Discover, DinersClub, JCB, Unknown };

    public static CreditCard_v1 FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase));

        if (state is null)
        {
            throw new ArgumentException($"Possible values for CreditCard: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static CreditCard_v1 From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state is null)
        {
            throw new ArgumentException($"Possible values for CreditCard: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}


public class Currency : Enumeration<Currency>
{
    public static readonly Currency GHS = new(1, nameof(GHS));
    public static readonly Currency USD = new(1, nameof(USD));
    public static readonly Currency EUR = new(2, nameof(EUR));
    public static readonly Currency GBP = new(3, nameof(GBP));
    public static readonly Currency CAD = new(4, nameof(CAD));
    public static readonly Currency AUD = new(5, nameof(AUD));
    public static readonly Currency NZD = new(6, nameof(NZD));
    public static readonly Currency JPY = new(7, nameof(JPY));
    public static readonly Currency RUB = new(8, nameof(RUB));
    public static readonly Currency INR = new(9, nameof(INR));
    public static readonly Currency BRL = new(10, nameof(BRL));
    public static readonly Currency ZAR = new(11, nameof(ZAR));
    public static readonly Currency CHF = new(12, nameof(CHF));
    public static readonly Currency CNY = new(13, nameof(CNY));
    public static readonly Currency Unknown = new(14, nameof(Unknown));

    private Currency(int id, string name) : base(id, name) { }

    public static IEnumerable<Currency> List() =>
        new[] { GHS, USD, EUR, GBP, CAD, AUD, NZD, JPY, RUB, INR, BRL, ZAR, CHF, CNY, Unknown };

    public static Currency FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase));

        if (state is null)
        {
            throw new ArgumentException($"Possible values for Currency: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static Currency From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state is null)
        {
            throw new ArgumentException($"Possible values for Currency: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}

public class CreditCardType : Enumeration<CreditCardType>
{
    public static readonly CreditCardType Debit = new(1, nameof(Debit));
    public static readonly CreditCardType Credit = new(2, nameof(Credit));
    public static readonly CreditCardType Unknown = new(3, nameof(Unknown));

    private CreditCardType(int id, string name) : base(id, name) { }

    public static IEnumerable<CreditCardType> List() =>
        new[] { Debit, Credit, Unknown };

    public static CreditCardType FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase));

        if (state is null)
        {
            throw new ArgumentException($"Possible values for CreditCardType: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static CreditCardType From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state is null)
        {
            throw new ArgumentException($"Possible values for CreditCardType: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}

public class CreditCardCategory : Enumeration<CreditCardCategory>
{
    public static readonly CreditCardCategory Business = new(1, nameof(Business));
    public static readonly CreditCardCategory Personal = new(2, nameof(Personal));
    public static readonly CreditCardCategory Unknown = new(3, nameof(Unknown));

    private CreditCardCategory(int id, string name) : base(id, name) { }

    public static IEnumerable<CreditCardCategory> List() =>
        new[] { Business, Personal, Unknown };

    public static CreditCardCategory FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase));

        if (state is null)
        {
            throw new ArgumentException($"Possible values for CreditCardCategory: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static CreditCardCategory From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state is null)
        {
            throw new ArgumentException($"Possible values for CreditCardCategory: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}

public class CreditCardExpirationMonth : Enumeration<CreditCardExpirationMonth>
{
    public static readonly CreditCardExpirationMonth January = new(1, nameof(January));
    public static readonly CreditCardExpirationMonth February = new(2, nameof(February));
    public static readonly CreditCardExpirationMonth March = new(3, nameof(March));
    public static readonly CreditCardExpirationMonth April = new(4, nameof(April));
    public static readonly CreditCardExpirationMonth May = new(5, nameof(May));
    public static readonly CreditCardExpirationMonth June = new(6, nameof(June));
    public static readonly CreditCardExpirationMonth July = new(7, nameof(July));
    public static readonly CreditCardExpirationMonth August = new(8, nameof(August));
    public static readonly CreditCardExpirationMonth September = new(9, nameof(September));
    public static readonly CreditCardExpirationMonth October = new(10, nameof(October));
    public static readonly CreditCardExpirationMonth November = new(11, nameof(November));
    public static readonly CreditCardExpirationMonth December = new(12, nameof(December));
    public static readonly CreditCardExpirationMonth Unknown = new(13, nameof(Unknown));

    private CreditCardExpirationMonth(int id, string name) : base(id, name) { }

    public static IEnumerable<CreditCardExpirationMonth> List() =>
        new[] { January, February, March, April, May, June, July, August, September, October, November, December, Unknown };

    public static CreditCardExpirationMonth FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase));

        if (state is null)
        {
            throw new ArgumentException($"Possible values for CreditCardExpirationMonth: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static CreditCardExpirationMonth From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state is null)
        {
            throw new ArgumentException($"Possible values for CreditCardExpirationMonth: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}