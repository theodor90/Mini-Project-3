using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// base class for assets
class Asset
{
    public string Name { get; set; }
    public string Model { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }
    public string Office { get; set; }

    public Asset(string name, string model, DateTime purchaseDate, decimal price, string office)
    {
        Name = name;
        Model = model;
        PurchaseDate = purchaseDate;
        Price = price;
        Office = office;
    }

    // Check life of product 
    public virtual bool IsCloseToEndOfLife()
    {
        return PurchaseDate.AddYears(3).AddMonths(-3) <= DateTime.Now;
    }

    public virtual bool IsNearingEndOfLife()
    {
        return PurchaseDate.AddYears(3).AddMonths(-6) <= DateTime.Now;
    }
}