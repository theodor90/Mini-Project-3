using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// subclass for phones
class Phone : Asset
{
    public Phone(string name, string model, DateTime purchaseDate, decimal price, string office) : base(name, model, purchaseDate, price, office)
    {

    }
}