using Lager.DataProvider;
using Lager.Entities;
using Lager.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lager
{
    public class App : IApp
    {
        private readonly IRepository<Employee> _employeesRepository;
        private readonly IRepository<Material> _materialRepository;
        private readonly IMaterialsProvider _materialsProvider;
        private readonly IEmployeeProvider _employeeProvider;
        public App(IRepository<Employee> employeesRepository, IRepository<Material> materialRepository, IMaterialsProvider materialsProvider, IEmployeeProvider employeeProvider)
        {
            _employeesRepository = employeesRepository;
            _materialRepository = materialRepository;
            _materialsProvider = materialsProvider;
            _employeeProvider = employeeProvider;
        }
        public void Run()
        {
        }

        public List<string> GetAllEmployees()
        {
            var results = _employeesRepository.GetAll();

            results = results
                .OrderBy(x => x.Id)
                .ToList();

            List<string> newList = new();
            foreach (var item in results)
            {
                newList.Add(item.OfficialView());
            }
            return newList;
        }

        public List<string> GetEmployeeByName(string prefix)
        {
            var resultsFirstName = _employeeProvider.WhereFirstNameIs(prefix);
            var resultsLastName = _employeeProvider.WhereLastNameIs(prefix);

            List<string> newList = new();

            foreach (var item in resultsFirstName)
            {
                newList.Add(item.ToString());
            }

            foreach (var item in resultsLastName)
            {
                newList.Add(item.ToString());
            }

            return newList;
        }

        public List<string> GetEmployeeByAddress(string prefix)
        {
            var resultsAddress = _employeeProvider.WhereAddressIs(prefix);

            List<string> newList = new();
            foreach(var item in resultsAddress)
            {
                newList.Add(item.ToString());
            }

            return newList;
        }

        public List<string> GetAllMaterials()
        {
            var results = _materialRepository.GetAll();
            results = results
                .OrderBy(x => x.Id)
                .ToList();

            List<string> newList = new();
            foreach (var item in results)
            {
                newList.Add(item.OfficialView());
            }
            return newList;
        }

        public List<string> GetMaterialsByPrefix(string prefix)
        {
            var results = _materialsProvider.WhereStartsWith(prefix);

            List<string> newList = new();
            foreach (var item in results)
            {
                newList.Add(item.ToString());
            }

            return newList;
        }

        public List<string> GetMaterialsCountries()
        {
            var materials = _materialsProvider.DistinctAllCountry();
            return materials;
        }

        public List<string> GetMaterialsByCountry(string country)
        {
            var materials = _materialsProvider.WhereCountryIs(country);
            List<string> newList = new();
            foreach(var item in materials)
            {
                newList.Add(item.ToString());
            }

            return newList;
        }

        public string GetMaterialById(string sid)
        {
            var checkParse = int.TryParse(sid, out var id);
            if (checkParse) return _materialsProvider.SingleById(id).ToString();
            else return $"This is not ID";
        }

        public string GetEmployeeById(string sid)
        {
            var checkParse = int.TryParse(sid, out var id);
            if (checkParse) return _employeeProvider.SingleById(id).ToString();
            else return $"This is not ID";
        }

        public List<string> GetEmployeeByPrefix(string prefix)
        {
            var employees = _employeeProvider.WhereStartWith(prefix).ToList();
            List<string> newList = new();

            foreach (var item in employees)
            {
                newList.Add(item.ToString());
            }

            return newList;
        }

        public void AddEmployee(string? firstName, string? lastName, string? address, string? phoneNumber, string? email, string? country, string? dataBirthDay, string? dataBegin, string? hours, int points, string? price)
        {

            var newEmployee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email,
                Country= country,
                BirthdayDate= dataBirthDay,
                DataBegin= dataBegin,
                Hours= hours,
                Points = points,
                Price= price
            };

            _employeesRepository.Add(newEmployee);

        }

        public void AddMaterial(string? name, string? country, string? typeBox, double price, int quantityBox, float quantityPerBox)
        {
            DateTime actualDate = DateTime.Now;

            var newMaterial = new Material
            {
                Name = name,
                Country = country,
                TypeBox = typeBox,
                Price = price,
                TimeAcceptance = actualDate,
                QuantityBox = quantityBox,
                QuantityPerBox = quantityPerBox
            };

            _materialRepository.Add(newMaterial);
        }

        public List<string> OrderEmployeesByPoint()
        {
            var employees = _employeeProvider.OrderByPoints();
            List<string> newList = new();
            foreach (var item in employees)
            {
                StringBuilder sb = new();
                sb.Append($" Id: {item.Id}");
                sb.Append($" Name: {item.FirstName} {item.LastName}");
                sb.Append($" Points: {item.Points}");
                newList.Add(sb.ToString());
            }

            return newList;
        }

        public List<string> OrderEmployeesByHours()
        {
            var employees = _employeeProvider.OrderByHours();
            List<string> newList = new();
            foreach (var item in employees)
            {
                StringBuilder sb = new();
                sb.Append($" Id: {item.Id}");
                sb.Append($" Name: {item.FirstName} {item.LastName}");
                sb.Append($" Hours: {item.Hours}");
                newList.Add(sb.ToString());
            }

            return newList; ;
        }

        public List<string> OrderEmployeesByBeginAsc()
        {
            var employees = _employeeProvider.OrderByDataBegin();
            DateTime dataToday = DateTime.Now;
            List<string> newList = new();
            foreach (var item in employees)
            {
                StringBuilder sb = new();
                sb.Append($" Id: {item.Id}");
                sb.Append($" Name: {item.FirstName} {item.LastName}");
                sb.Append($" Date Begin: {item.DataBegin}");
                newList.Add(sb.ToString());
            }

            return newList;
        }

        public List<string> OrderEmployeesByBeginDesc()
        {
            var employees = _employeeProvider.OrderByDataBeginDesc();
            List<string> newList = new();
            foreach (var item in employees)
            {
                StringBuilder sb = new();
                sb.Append($" Id: {item.Id}");
                sb.Append($" Name: {item.FirstName} {item.LastName}");
                sb.Append($" Date Begin: {item.DataBegin}");
                newList.Add(sb.ToString());
            }

            return newList;
        }

        public List<string> OrderMaterialsByQuantity()
        {
            var materials = _materialsProvider.OrderByQuantity();
            List<string> newList = new();
            foreach (var item in materials)
            {
                StringBuilder sb = new();
                sb.Append($" Id: {item.Id}");
                sb.Append($" Name: {item.Name}");
                sb.Append($" Quantity: {item.QuantityBox}");
                newList.Add(sb.ToString());
            }

            return newList;
        }

        public List<string> OrderMaterialsByPrice()
        {
            var materials = _materialsProvider.OrderByValue();
            List<string> newList = new();
            foreach (var item in materials)
            {
                StringBuilder sb = new();
                sb.Append($" Id: {item.Id}");
                sb.Append($" Name: {item.Name}");
                sb.Append($" Price: {item.PriceAll}");
                sb.Append($" ({item.Price} per BOX");
                newList.Add(sb.ToString());
            }

            return newList;
        }
    }
}
