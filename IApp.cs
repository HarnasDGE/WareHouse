using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lager
{
    public interface IApp
    {

        void Run();

        List<string> GetAllEmployees();
        string GetEmployeeById(string sid);
        List<string> GetEmployeeByName(string prefix);
        List<string> GetEmployeeByAddress(string prefix);
        List<string> GetAllMaterials();
        List<string> GetMaterialsByPrefix(string prefix);
        List<string> GetMaterialsCountries();
        List<string> GetMaterialsByCountry(string prefix);
        string GetMaterialById(string sid);

        List<string> OrderEmployeesByPoint();
        List<string> OrderEmployeesByHours();
        List<string> OrderEmployeesByBeginAsc();
        List<string> OrderEmployeesByBeginDesc();
        List<string> OrderMaterialsByQuantity();
        List<string> OrderMaterialsByPrice();


        void AddEmployee(string? firstName, string? lastName, string? address, string? phoneNumber, string? email,string? country, string? dataBirthDay, string dataBegin, string? hours, int points, string? price);
        void AddMaterial(string? name, string? country, string? typeBox, double price,int quantityBox,float quantityPerBox);
    }
}
