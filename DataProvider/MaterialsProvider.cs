using Azure;
using Lager.Entities;
using Lager.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lager.DataProvider
{
    public class MaterialsProvider : IMaterialsProvider
    {
        private readonly IRepository<Material> _materialRepository;
        public MaterialsProvider(IRepository<Material> materialRepository)
        {
            _materialRepository = materialRepository;
        }


        public List<string> GetUniqueMaterialCountry()
        {
            var materials = _materialRepository.GetAll();
            var countries = materials
                .Select(x => x.Country)
                .Distinct()
                .ToList();

            return countries;
        }

        public double GetMinimumPriceOfMaterial()
        {
            var materials = _materialRepository.GetAll();
            return materials.Select(x => x.Price).Min();
        }

        public List<Material> GetSpecificColumns()
        {
            var materials = _materialRepository.GetAll();
            var newlist = materials.Select(material => new Material
            {
                Name = material.Name,
                Country = material.Country,
            }).ToList();

            return newlist;
        }

        public string AnonymousClass()
        {
            var materials = _materialRepository.GetAll();
            var newlist = materials.Select(material => new
            {
                Nazwa = material.Name,
                Kraj = material.Country,
            }).ToList();

            StringBuilder sb = new(2048);
            foreach (var material in newlist)
            {
                sb.AppendLine($"Nazwa: {material.Nazwa}, Kraj: {material.Kraj}");
            }

            return sb.ToString();
        }

        public List<Material> OrderByName()
        {
            var materials = _materialRepository.GetAll();
            return materials.OrderBy(x => x.Name).ToList();
        }

        public List<Material> OrderByNameDescending()
        {
            var materials = _materialRepository.GetAll();
            return materials.OrderByDescending(x => x.Name).ToList();
        }

        public List<Material> OrderByNameAndCountry()
        {
            var materials = _materialRepository.GetAll();
            return materials
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Country)
                .ToList();
        }
        public List<Material> OrderByNameAndCountryDescending()
        {
            var materials = _materialRepository.GetAll();
            return materials
                .OrderByDescending(x => x.Name)
                .ThenByDescending(x => x.Country)
                .ToList();
        }

        public List<Material> OrderByQuantity()
        {
            var materials = _materialRepository.GetAll();
            return materials
                .OrderBy(x => x.QuantityBox)
                .ToList();
        }

        public List<Material> OrderByValue()
        {
            var materials = _materialRepository.GetAll();
            return materials
                .OrderBy(x => x.PriceAll)
                .ToList();
        }

        public List<Material> WhereStartsWith(string prefix)
        {
            var materials = _materialRepository.GetAll();
            return materials.Where(x => x.Name.ToUpper().StartsWith(prefix.ToUpper())).ToList();
        }

        public List<Material> WhereCountryIs(string country)
        {
            var materials = _materialRepository.GetAll();
            return materials.Where(x => x.Country.ToUpper() == country.ToUpper()).ToList();
        }

        public List<Material> WhereStartsWithAndPriceIsGreaterThan(string prefix, double cost)
        {
            var materials = _materialRepository.GetAll();
            return materials.Where(x => x.Name.StartsWith(prefix) && x.Price > cost).ToList();
        }

        public Material FirstByCountry(string country)
        {
            var materials = _materialRepository.GetAll();
            return materials.First(x => x.Country == country);
        }

        public Material? FirstOrDefaultByCountry(string country)
        {
            var materials = _materialRepository.GetAll();
            return materials.FirstOrDefault(x => x.Country == country);
        }

        public Material FirstOrDefaultByCountryWithDefault(string country)
        {
            var materials = _materialRepository.GetAll();
            return materials
                .FirstOrDefault(
                x => x.Country == country,
                new Material { Id = -1, Name = "NOT FOUND" });
        }

        public Material LastByCountry(string country)
        {
            var materials = _materialRepository.GetAll();
            return materials.Last(x => x.Country == country);
        }

        public Material SingleById(int id)
        {
            var materials = _materialRepository.GetAll();
            return materials.Single(x => x.Id == id);
        }

        public Material? SingleOrDefault(int id)
        {
            var materials = _materialRepository.GetAll();
            return materials.SingleOrDefault(x => x.Id == id);
        }

        public List<Material> TakeMaterials(int howMany)
        {
            var materials = _materialRepository.GetAll();
            return materials
                .OrderBy(x => x.Name)
                .Take(howMany)
                .ToList();
        }

        public List<Material> TakeMaterials(Range range)
        {
            var materials = _materialRepository.GetAll();
            return materials
                .OrderBy(x => x.Id)
                .Take(range)
                .ToList();
        }

        public List<Material> TakeMaterialsWhileNameStartsWith(string prefix)
        {
            var materials = _materialRepository.GetAll();
            return materials
                .OrderBy(x => x.Name)
                .TakeWhile(x => x.Name.StartsWith(prefix)) //Dziala jedynie na poczatku zbioru, gdy warunek bedzie false reszta danych nie zostanie sprawdzona
                .ToList();
        }

        public List<Material> SkipMaterials(int howMany)
        {
            var materials = _materialRepository.GetAll();
            return materials
                .OrderBy(x => x.Id)
                .Skip(howMany)
                .ToList();
        }

        public List<Material> SkipMaterialsWhileNameStartsWith(string prefix)
        {
            var materials = _materialRepository.GetAll();
            return materials
                .OrderBy(x => x.Name)
                .SkipWhile(x => x.Name.StartsWith(prefix)) //Dziala jedynie na poczatku zbioru, gdy warunek bedzie false reszta danych nie zostanie sprawdzona
                .ToList();
        }


        public List<Material> SkipTakePage(int howManySkip, int howManyTake)
        {
            var result = _materialRepository.GetAll();

            return result
                .OrderBy(x => x.Id)
                .Skip(howManySkip)
                .Take(howManyTake)
                .ToList();
        }

        public List<string> DistinctAllCountry()
        {
            var materials = _materialRepository.GetAll();
            var result = materials
                .Select(x => x.Country)
                .Distinct()
                .OrderBy(c => c)
                .ToList();
            return result;
        }

        public List<Material> DistinctByCountry()
        {
            var result = _materialRepository.GetAll();

            return result
                .DistinctBy(x => x.Country)
                .OrderBy(x => x.Country)
                .ToList();
        }

        public List<Material[]> ChunckMaterials(int size)
        {
            var result = _materialRepository.GetAll();
            return result.Chunk(size).ToList();
        }
    }
}
