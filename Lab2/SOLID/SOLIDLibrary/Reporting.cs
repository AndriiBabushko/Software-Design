namespace SOLIDLibrary
{
    // Interface Segregation Principle 
    interface IInvoiceGenerator
    {
        void GenerateInvoice(Product SomeProduct, int Quantity);
    }

    interface IInventoryManager
    {
        void UpdateInventory(Product SomeProduct, int Quantity);
        Dictionary<Product, int> Inventory { get; }
    }

    class RevenueGenerator : IInvoiceGenerator
    {
        public void GenerateInvoice(Product SomeProduct, int Quantity)
        {
            Console.WriteLine($"Отримано {Quantity} {SomeProduct.Name}. Формування прибуткової накладної...\n");
        }
    }

    class ExpenditureGenerator : IInvoiceGenerator
    {
        public void GenerateInvoice(Product SomeProduct, int Quantity)
        {
            Console.WriteLine($"Прибуло {Quantity} {SomeProduct.Name}. Формування видаткової накладної...\n");
        }
    }

    public class InventoryManager : IInventoryManager
    {
        private Dictionary<Product, int> _inventory = new Dictionary<Product, int>();

        public Dictionary<Product, int> Inventory
        {
            get => _inventory;
        }

        public void UpdateInventory(Product NewProduct, int Quantity)
        {
            if (Inventory.ContainsKey(NewProduct))
                Inventory[NewProduct] += Quantity;
            else
                Inventory.Add(NewProduct, Quantity);
        }

        public void GenerateInventoryReport()
        {
            Console.WriteLine("Проводимо інвентаризацію...");
            
            if (Inventory.Count > 0)
            {
                Console.WriteLine("Звіт про інвентаризацію:");

                foreach (KeyValuePair<Product, int> product in Inventory)
                    Console.WriteLine($"{product.Key.Name}: {product.Value}");

                return;
            }

            Console.WriteLine("Продуктів на складі немає.\n");
        }
    }

    public class Reporting
    {
        private RevenueGenerator _revenueGenerator;
        private ExpenditureGenerator _expenditureGenerator;
        private InventoryManager _inventoryManager;

        public Reporting()
        {
            this._revenueGenerator = new RevenueGenerator();
            this._expenditureGenerator = new ExpenditureGenerator();
            this._inventoryManager = new InventoryManager();
        }

        // Single Responsibility Principle
        public void RegisterReceipt(Product SomeProduct, int Quantity)
        {
            _inventoryManager.UpdateInventory(SomeProduct, Quantity);
            _revenueGenerator.GenerateInvoice(SomeProduct, Quantity);
        }

        // Single Responsibility Principle
        public void RegisterShipment(Product SomeProduct, int Quantity)
        {
            if (_inventoryManager.Inventory.ContainsKey(SomeProduct))
            {
                int availableQuantity = _inventoryManager.Inventory[SomeProduct];
                if (availableQuantity >= Quantity)
                {
                    _inventoryManager.UpdateInventory(SomeProduct, -Quantity);
                    _expenditureGenerator.GenerateInvoice(SomeProduct, Quantity);
                }
                else
                    Console.WriteLine($"Помилка: Не достатньо {SomeProduct} для доставки {Quantity} кількості.\n");
            }
            else
                Console.WriteLine($"Помилка: {SomeProduct} немає в наявності.\n");
        }

        // Open-Closed Principle
        public void GenerateInventoryReport()
        {
            _inventoryManager.GenerateInventoryReport();
        }
    }
}
