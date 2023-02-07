using System;

namespace Lager
{
    public class NamedLager
    {
        public string Name { get; set;}
        public int ID { get; set;}
        public string Country { get; set;}
        public string Type_Box { get; set;}
        public double BuyPrice { get; set;}
        public string Date_start { get; set;}
        public int Id_section {get; set;}


        public const string LOGS = "logs/log.txt";
        public const string FGLAGER = "base/lager_base.txt";

        public NamedLager()
        {
            Country = "";
            ID = File.ReadLines(FGLAGER).Count();
            Name = "";
            Type_Box = "";
            BuyPrice = 0.00;
            Date_start = "";
            Id_section = 0;
        }
    }

    


}
