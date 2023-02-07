

using Lager.Entities;
using System.ComponentModel.DataAnnotations;

namespace Lager.DataProvider
{
    public interface IMaterialsProvider
    {

        // select LINQ
        List<string> GetUniqueMaterialCountry();
        List<Material> GetSpecificColumns();
        double GetMinimumPriceOfMaterial();
        string AnonymousClass();

        // order by
        List<Material> OrderByName();
        List<Material> OrderByNameDescending();
        List<Material> OrderByNameAndCountry();
        List<Material> OrderByNameAndCountryDescending();
        List<Material> OrderByQuantity();
        List<Material> OrderByValue();

        // where 

        List<Material> WhereStartsWith(string prefix);
        List<Material> WhereStartsWithAndPriceIsGreaterThan(string prefix, double cost);
        List<Material> WhereCountryIs(string color);

        // first, single, last
        Material FirstByCountry(string country);
        Material? FirstOrDefaultByCountry(string country);
        Material FirstOrDefaultByCountryWithDefault(string country);
        Material LastByCountry(string country);
        Material SingleById(int id);
        Material? SingleOrDefault(int id);

        // take
        List<Material> TakeMaterials(int howMany);
        List<Material> TakeMaterials(Range range);
        List<Material> TakeMaterialsWhileNameStartsWith(string prefix);

        // skip 

        List<Material> SkipMaterials(int howMany);
        List<Material> SkipMaterialsWhileNameStartsWith(string prefix);

        List<Material> SkipTakePage(int howManySkip, int howManyTake);

        // distinct 
        List<string>? DistinctAllCountry();
        List<Material> DistinctByCountry();

        //chunk, paczki

        List<Material[]> ChunckMaterials(int size);

    }
}
