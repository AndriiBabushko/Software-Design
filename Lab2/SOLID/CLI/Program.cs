using SOLIDLibrary;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

void BeautifyOutput(string Output, string OutputColor)
{
    if(OutputColor == "Green")
        Console.ForegroundColor = ConsoleColor.Green;

    if (OutputColor == "Red")
        Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine(Output);
    Console.ForegroundColor = ConsoleColor.White;
}

BeautifyOutput("КПЗ. Лабораторна робота №2. SOLID. Виконав студент групи ВТ-21-1 - Бабушко Андрій.", "Red");

BeautifyOutput("\nПриклад використання класу Money.\n", "Red");
Money MyMoney = new Money(99, 99, '$');
BeautifyOutput("Отримання даних класу Money у вигляді числа:", "Green");
Console.WriteLine(MyMoney.GetMoneyNumber());
BeautifyOutput("Отримання даних класу Money у вигляді рядка:", "Green");
Console.WriteLine(MyMoney);

BeautifyOutput("\nПриклад використання класу Product.", "Red");
Product MyProduct = new Product("Цукерки 'Roshen'", "Цукерки українського виробництва!", 20, "кг.", 11, 99, '€');
BeautifyOutput("\nДані класу Product до зменшення ціни:", "Green");
Console.WriteLine(MyProduct);
MyProduct.ReducePrice(11);
BeautifyOutput("\nДані класу Product післ зменшення ціни на 11:", "Green");
Console.WriteLine(MyProduct);

BeautifyOutput("\nПриклад використання класу Warehouse.", "Red");
Warehouse MyWarehouse = new Warehouse("Склад компанії 'Roshen'", "Україна, м. Житомир, вул. Степана Бандери 24.", 500);
BeautifyOutput("\nДані класу Warehouse без продуктів:", "Green");
Console.WriteLine(MyWarehouse);
MyWarehouse.AddProduct(MyProduct);
BeautifyOutput($"\nДані класу Warehouse після додавання продукту:", "Green");
Console.WriteLine(MyWarehouse);
MyWarehouse.RemoveProduct(MyProduct);
BeautifyOutput($"\nДані класу Warehouse після видалення продукту:", "Green");
Console.WriteLine(MyWarehouse);

BeautifyOutput("\nПриклад використання класу Reporting.\n", "Red");
Reporting MyReporting = new Reporting();
MyReporting.GenerateInventoryReport();
MyReporting.RegisterReceipt(MyProduct, 2);
MyReporting.RegisterShipment(MyProduct, 1);
MyReporting.GenerateInventoryReport();
