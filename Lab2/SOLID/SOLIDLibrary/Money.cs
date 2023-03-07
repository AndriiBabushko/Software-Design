using System.Globalization;

namespace SOLIDLibrary
{
    public class Money
    {
        private int _bills;
        private int _coins;
        private char _currency;

        public int Bills
        {
            get => this._bills;
            set
            {
                if (value >= 0)
                    this._bills = value;
                else
                    this._bills = 0;
            }
        }

        public int Coins
        {
            get => this._coins;
            set
            {
                if ((value >= 0) && (value <= 99))
                    this._coins = value;
                else
                    this._coins = 0;
            }
        }

        public char Currency
        {
            get => this._currency;
            set
            {
                if (CharUnicodeInfo.GetUnicodeCategory(value) == UnicodeCategory.CurrencySymbol)
                    this._currency = value;
                else
                    this._currency = '$';
            }
        }

        public Money(int bills = 0, int coins = 0, char currency = '$')
        {
            this.Bills = bills;
            this.Coins = coins;
            this.Currency = currency;
        }

        // Single Responsibility Principle - method does one certain thing
        // Also DRY - Don't repeat yourself. Method used 3 times
        public double GetMoneyNumber() => (double)(this.Bills + this.Coins / 100.0);

        // Open-Closed Principle - open to expansion, closed to changes
        public override string ToString() => String.Format("{0}{1}", this.Currency, this.GetMoneyNumber());
    }
}