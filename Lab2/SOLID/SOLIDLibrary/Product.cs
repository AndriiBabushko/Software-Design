namespace SOLIDLibrary
{
    public class Product : Money
    {
        private int _quantity;
        private string _dimension;

        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity
        {
            get => this._quantity;
            set
            {
                if (value >= 0)
                    this._quantity = value;
                else
                    this._quantity = 0;
            }
        }
        public string Dimension
        {
            get => this._dimension;
            set
            {
                if (value.Trim() == "piece" || value.Trim() == "kilo" || value.Trim() == "шт." || value.Trim() == "кг.")
                    this._dimension = value;
                else
                    this._dimension = "piece";
            }
        }

        public Product(string name, string description, int quantity, string dimension, int bills, int coins, char currency) : base(bills, coins, currency)
        {
            this.Name = name;
            this.Description = description;
            this.Quantity = quantity;
            this.Dimension = dimension;
        }

        // Single Responsibility Principle
        public void ReducePrice(double ReducePrice)
        {
            if (this.GetMoneyNumber() - ReducePrice > 0)
            {
                int ReduceBills = (int)ReducePrice;
                int ReduceCoins = (int)(Math.Round(ReducePrice % 1, 2) * 100);
                this.Bills -= ReduceBills;
                this.Coins -= ReduceCoins;
                return;
            }

            Console.WriteLine($"Помилка: Не можна зменшити на ціну: {ReducePrice}");
        }

        // Open-Closed Principle
        public override string ToString()
        {
            return $"\n\tПро продукт\n\nНазва: {this.Name}\nОпис: {this.Description}\nКількість: {this.Quantity}{this.Dimension}\nЦіна: {this.GetMoneyNumber()}";
        }
    }
}
