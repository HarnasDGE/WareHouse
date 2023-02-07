using Lager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lager.DataProvider
{
    public interface IEmployeeProvider
    {
        List<Employee> OrderByName();
        List<Employee> OrderByCountry();
        List<string> DistinctAllCountry();
        List<Employee> OrderByPoints();
        List<Employee> OrderByPrice();
        List<Employee> OrderByHours();
        List<Employee> OrderByDataBegin();
        List<Employee> OrderByDataBeginDesc();
        List<Employee> SelectAllFromCountry(string country);
        List<Employee> SelectMoreThanPoints(int points);
        Employee SingleById(int id);
        List<Employee> WhereStartWith(string prefix);
        List<Employee> WhereFirstNameIs(string firstName);
        List<Employee> WhereLastNameIs(string lastName);
        List<Employee> WhereAddressIs(string prefix);

        List<Employee> SkipTakePage(int skip, int take);

    }
}
