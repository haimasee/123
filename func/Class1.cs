using Newtonsoft.Json;
using System;
using System.IO;

namespace func
{
    public class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }

        public T Deserialize<T>()
        {
            string text = File.ReadAllText(PATH);
            T result = JsonConvert.DeserializeObject<T>(text);
            return result;
        }
        public void Serialize<T>(T tasks)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string json = JsonConvert.SerializeObject(tasks);
                writer.WriteLine(json);
            }
        }
    }
}
