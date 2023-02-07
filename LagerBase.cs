namespace Lager
{
    public abstract class LagerBase : NamedLager
    {

        public abstract void Add(string title, string name, double buyprice, int id_section);
        public abstract void OptionAdd();

    }

}
