

//using Unity.Plastic.Newtonsoft.Json;
//using Unity.Plastic.Newtonsoft.Json.Linq;

namespace Core.Services.Save
{
    /*public class JsonSaveService : ISaveService
    {
        /*public Task SaveObject(string path, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, json);
            return Task.CompletedTask;
        }

        public Task<T> LoadObject<T>(string path)
        {
            using var file = File.OpenText(path);
            using var reader = new JsonTextReader(file);
            var o2 = (JObject)JToken.ReadFrom(reader);
            return Task.FromResult(o2.ToObject<T>());
        }#1#
    }*/
}