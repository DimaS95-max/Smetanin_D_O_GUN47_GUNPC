using System.Text.Json;

/// Сервис сохранения данных в файловую систему.

namespace FinalTask.Services
{

    public class FileSystemSaveLoadService<T> : ISaveLoadService<T>
    {
        private readonly string _path;

        public FileSystemSaveLoadService(string path)
        {
            _path = path;
            if (!System.IO.Directory.Exists(_path))
            {
                System.IO.Directory.CreateDirectory(_path);
            }
        }

        public void SaveData(T data, string identifier)
        {
            string filePath = System.IO.Path.Combine(_path, $"{identifier}.json");
            string json = JsonSerializer.Serialize(data);
            System.IO.File.WriteAllText(filePath, json);
        }

        public T LoadData(string identifier)
        {
            string filePath = System.IO.Path.Combine(_path, $"{identifier}.json");
            if (!System.IO.File.Exists(filePath))
            {
                return default!;
            }

            string json = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json)!;
        }
    }
}
