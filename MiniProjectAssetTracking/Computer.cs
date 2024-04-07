using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


// subclass for computers
class Computer : Asset
{
    public Computer(string name, string model, DateTime purchaseDate, decimal price, string office) : base(name, model, purchaseDate, price, office)
    {

    }
}
