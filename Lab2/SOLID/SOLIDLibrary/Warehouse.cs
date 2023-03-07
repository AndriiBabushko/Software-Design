namespace SOLIDLibrary
{
    public class Warehouse
    {
        private double _area;

        public List<Product> Products { get; set; }
        public string Name;
        public string Adress;
        public double Area
        {
            get => this._area;
            set
            {
                if (value > 0)
                    this._area = value;
                else
                    this._area = 0;
            }
        }
        public DateTime LastDelivery;

        public Warehouse(string name, string adress, double area)
        {
            this.Products = new List<Product>();
            this.Name = name;
            this.Adress = adress;
            this.Area = area;
        }

        // Single Responsibility Principle
        public void AddProduct(Product NewProduct)
        {
            if (!this.Products.Contains(NewProduct))
            {
                this.Products.Add(NewProduct);
                this.LastDelivery = DateTime.Now;
            }
        }

        // Single Responsibility Principle
        public void RemoveProduct(Product ExistingProduct)
        {
            if (this.Products.Contains(ExistingProduct))
                this.Products.Remove(ExistingProduct);
        }

        // Open-Closed Principle
        public string GetProductsAsString()
        {
            string OutputString = "";

            for (int i = 0; i < this.Products.Count; i++)
            {
                OutputString += this.Products[i].ToString();
            }

            return OutputString;
        }

        // Open-Closed Principle
        public override string ToString()
        {
            string ProductsString = GetProductsAsString();
            if (ProductsString == "")
                ProductsString = "Товарів на складі немає!";

            return $"\n\tПро склад:\n\nНазва: {this.Name}\nАдреса: {this.Adress}\nПлоща: {this.Area}\n{ProductsString}";
        }
    }
}
