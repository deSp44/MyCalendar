using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MyCalendarApp.Helpers
{
    public class FileHelpersXml<T> where T : new()
    {
        private readonly string _filePath;

        public FileHelpersXml(string filePath)
        {
            _filePath = filePath;
        }

        public void SerializeToFile(T param)
        {
            var serializer = new XmlSerializer(typeof(T));

            using var streamWriter = new StreamWriter(_filePath);
            serializer.Serialize(streamWriter, param);
            streamWriter.Close();
        }

        public T DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return new T();

            var serializer = new XmlSerializer(typeof(T));

            using var streamReader = new StreamReader(_filePath);
            var collectedData = (T)serializer.Deserialize(streamReader);
            streamReader.Close();

            return collectedData;
        }
    }
}