using Lager.Entities;
using System.Text.Json;
using static System.Environment;

namespace Lager.Repositories
{
    public class FileRepository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;

        private readonly string _pathsave = GetFolderPath(SpecialFolder.Desktop) + "/FileSave/Lager/" + typeof(T).ToString() + ".txt";
        private List<T> _items = new();
        public void Add(T item)
        {
            item.Id = NewID();
            _items.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public IEnumerable<T> GetAll()
        {
            _items.Clear();
            if (File.Exists(_pathsave))
            {
                using (var reader = File.OpenText(_pathsave))
                {
                    var item = reader.ReadLine();
                    while (item != null)
                    {
                        var json = JsonSerializer.Deserialize<T>(item);
                        if(json != null) _items.Add(json);
                        item = reader.ReadLine();
                    }
                }
            }
            return _items.ToList();
        }

        public T? GetById(int Id)
        {
            return _items.Single(item => item.Id == Id);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
            ItemRemoved?.Invoke(this, item);
            Save();
        }

        public void Save()
        {
            List<string> jsons = new();
            if (!File.Exists(_pathsave)) File.Create(_pathsave);
            foreach (var item in _items)
            {
                var json = JsonSerializer.Serialize(item);
                jsons.Add(json);
            }
            File.WriteAllLines(_pathsave, jsons);
        }

        private int NewID()
        {
            var id = -1;
            var check = false;
            do
            {
                id++;
                check = false;
                foreach (var item in _items)
                {
                    if (item.Id == id) check = true;
                }
            } while (check);
            return id;
        }
    }
}
