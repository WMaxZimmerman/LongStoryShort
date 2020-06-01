using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LongStoryShort.DAL.Repositories
{
    public interface IFileRepository
    {
        IEnumerable<string> ReadLines(string path);

        void WriteLines(string path, IEnumerable<string> lines);

        T ImportJsonFile<T>(string path);

        void ExportJsonFile<T>(string path, T content);
    }
    
    public class FileRepository: IFileRepository
    {
        public IEnumerable<string> ReadLines(string path)
        {
            return File.ReadLines(path);
        }

        public void WriteLines(string path, IEnumerable<string> lines)
        {
            File.WriteAllLines(path, lines);
        }

        public T ImportJsonFile<T>(string path)
        {
            using (var r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
                var thing = JsonConvert.DeserializeObject<T>(json);
                return thing;
            }
        }

        public void ExportJsonFile<T>(string path, T content)
        {
            using (var w = new StreamWriter(path))
            {
                var json = JsonConvert.SerializeObject(content);
                w.Write(json);
            }
        }
    }
}
