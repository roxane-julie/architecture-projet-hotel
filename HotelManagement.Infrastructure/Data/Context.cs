using HotelManagement.Domain;
using System.Text.Json;

namespace HotelManagement.Infrastructure.Data
{
    /// <summary>
    /// Abstract class for simulate a context  ( replace context EF core in exemple ) 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Context<T> where T : IEntity
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        public async Task<List<T>> GetDataJsonFile(string path)
        {
            string json = File.ReadAllText(path) ?? string.Empty;
            if (string.IsNullOrEmpty(json))
            {
                return await Task.FromResult(new List<T>());
            }
            List<T> rooms = JsonSerializer.Deserialize<List<T>>(json, options) ?? [];
            return await Task.FromResult(rooms);
        }

        public async Task<T> AddData(string path, T data)
        {
            List<T> list = await GetDataJsonFile(path);
            list.Add(data);
            File.WriteAllText(path, JsonSerializer.Serialize(list));

            return data;
        }

        public async Task<T> UpdateData(string path, T data)
        {
            List<T> list = await GetDataJsonFile(path);
            list[index: list.FindIndex(i => i.Id == data.Id)] = data;
            File.WriteAllText(path, JsonSerializer.Serialize(list));

            return data;
        }
    }
}
