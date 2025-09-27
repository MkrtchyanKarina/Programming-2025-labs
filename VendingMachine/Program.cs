using System.ComponentModel;
using System.ComponentModel.Design;
using VendingMachine;

Dictionary<ushort, ushort> money = new Dictionary<ushort, ushort>(){
    { 1, 10 },
    { 2, 10 },
    { 5, 10 },
    { 10, 10 },
    { 50, 10 },
    { 100, 5 },
    { 200, 5 },
    { 500, 5 },
    { 1000, 2 },
    { 2000, 2 },
    { 5000, 2 }};
Dictionary<ushort, string> products = new Dictionary<ushort, string>();
Dictionary<ushort, List<ushort>> products_info = new Dictionary<ushort, List<ushort>>();
products[1] = "Шоколад Белый";
products[2] = "Шоколад Горький";

products_info[1] = new List<ushort> { 100, 3 };
products_info[2] = new List<ushort> { 120, 4 };


Machine machine = new Machine(money, products, products_info);


machine.PrintOptions();
