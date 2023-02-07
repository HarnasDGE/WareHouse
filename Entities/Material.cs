

using Lager.DataProvider;
using Lager.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Lager.Entities
{
    public class Material : EntityBase
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? TypeBox { get; set; } 
        public double Price { get; set; } 
        public DateTime TimeAcceptance { get; set; }
        public int QuantityBox { get; set; }
        public float QuantityPerBox { get; set; }
        
        public double PriceAll
        {
            get
            {
                return QuantityBox * Price;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new (1024);
            sb.Append($"ID: {Id} Name: {Name}");
            sb.Append($" Country: {Country} ");
            sb.Append($" Count: {TypeBox} {QuantityBox}");
            sb.Append($" {Price} * ({QuantityPerBox}) = { PriceAll}");
            sb.Append($" Date: {TimeAcceptance.ToString("MM/dd/yyyy")}");

            return sb.ToString();
        }

        public string OfficialView()
        {
            StringBuilder sb = new();
            sb.Append($"ID: {Id}".PadRight(8, ' '));
            sb.Append($"Name: {Name}".PadRight(20, ' '));
            sb.Append($"Country: {Country}".PadRight(25, ' '));
            sb.Append($"Date: {TimeAcceptance.ToString("MM/dd/yyyy")}".PadRight(25, ' '));

            return sb.ToString();
        }
    }
}
