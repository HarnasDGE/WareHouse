using Lager.Entities;
using Lager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lager.DataProvider
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeProvider(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<string> DistinctAllCountry()
        {
            throw new NotImplementedException();
        }

        public List<Employee> OrderByCountry()
        {
            var employee = _employeeRepository.GetAll();

            return employee
                .OrderBy(x => x.Country)
                .ToList();
        }

        public List<Employee> OrderByDataBegin()
        {
            var employee = _employeeRepository.GetAll();

            return employee
                .OrderBy(x => x.DataBegin)
                .ToList();
        }

        public List<Employee> OrderByDataBeginDesc()
        {
            var employee = _employeeRepository.GetAll();

            return employee
                .OrderByDescending(x => x.DataBegin)
                .ToList();
        }

        public List<Employee> OrderByHours()
        {
            var employee = _employeeRepository.GetAll();

            return employee
                .OrderBy(x => DateTime.Parse(x.Hours))
                .ToList();
        }

        public List<Employee> OrderByName()
        {
            var employee = _employeeRepository.GetAll();

            return employee
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();
        }

        public List<Employee> OrderByPoints()
        {
            var employee = _employeeRepository.GetAll();

            return employee
                .OrderBy(x => x.Points)
                .ToList();
        }

        public List<Employee> OrderByPrice()
        {
            throw new NotImplementedException();
        }

        public List<Employee> SelectAllFromCountry(string country)
        {
            throw new NotImplementedException();
        }

        public List<Employee> SelectByPrefix(string prefix)
        {
            throw new NotImplementedException();
        }

        public List<Employee> SelectMoreThanPoints(int points)
        {
            throw new NotImplementedException();
        }

        public Employee SingleById(int id)
        {
            var employees = _employeeRepository.GetAll();
            return employees.Single(x => x.Id == id);
        }

        public List<Employee> SkipTakePage(int skip, int take)
        {
            var employees = _employeeRepository.GetAll();

            return employees
               .OrderBy(x => x.Id)
               .Skip(skip)
               .Take(take)
               .ToList();
        }

        public List<Employee> WhereAddressIs(string prefix)
        {
            var employees = _employeeRepository.GetAll();

            return employees
                .OrderBy(x => x.Id)
                .Where(x => x.Address.ToUpper().StartsWith(prefix.ToUpper()))
                .ToList();
        }

        public List<Employee> WhereFirstNameIs(string firstName)
        {
            var employees = _employeeRepository.GetAll();

            return employees
                .OrderBy(x => x.FirstName)
                .Where(x => x.FirstName.ToUpper().StartsWith(firstName.ToUpper()))
                .ToList();
        }

        public List<Employee> WhereLastNameIs(string lastName)
        {
            var employees = _employeeRepository.GetAll();

            return employees
                .OrderBy(x => x.LastName)
                .Where(x => x.LastName.ToUpper().StartsWith(lastName.ToUpper()))
                .ToList();
        }

        public List<Employee> WhereStartWith(string prefix)
        {
            var employees = _employeeRepository.GetAll();

                return employees
                .OrderBy(x => x.Id)
                .Where(x => x.FirstName.ToUpper().StartsWith(prefix.ToUpper()))
                .ToList();
        }
    }
}
