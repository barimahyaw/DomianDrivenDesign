namespace Domain.Shared.Enum;

public abstract class CreditCard : Enumeration<CreditCard>
{
    public static readonly CreditCard Standard = new StandardCreditCard();
    public static readonly CreditCard Premium = new PremiumCreditCard();
    public static readonly CreditCard Gold = new GoldCreditCard();
    public static readonly CreditCard Platinum = new PlatinumCreditCard();
    public static readonly CreditCard Black = new BlackCreditCard();


    protected CreditCard(int value, string name) 
        : base(value, name)
    {
    }

    public abstract double Discount { get; }

    private sealed class StandardCreditCard : CreditCard
    {
        public StandardCreditCard() 
            : base(2, "Standard")
        {
        }

        public override double Discount => 0.01;
    }

    private sealed class PremiumCreditCard : CreditCard
    {
        public PremiumCreditCard() 
            : base(2, "Premium")
        {
        }

        public override double Discount => 0.02;
    }

    private sealed class GoldCreditCard : CreditCard
    {
        public GoldCreditCard() 
            : base(3, "Gold")
        {
        }

        public override double Discount => 0.03;
    }

    private sealed class PlatinumCreditCard : CreditCard
    {
        public PlatinumCreditCard() 
            : base(3, "Platinum")
        {
        }

        public override double Discount => 0.04;
    }

    private sealed class BlackCreditCard : CreditCard
    {
        public BlackCreditCard() 
            : base(4, "Black")
        {
        }

        public override double Discount => 0.05;
    }
}
