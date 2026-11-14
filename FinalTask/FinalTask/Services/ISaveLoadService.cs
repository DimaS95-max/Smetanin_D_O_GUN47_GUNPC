namespace FinalTask.Services;

/// Интерфейс для сервисов сохранения и загрузки данных.

public interface ISaveLoadService<T>
{
    void SaveData (T data, string identifier);
    T LoadData (string identifier);
}
