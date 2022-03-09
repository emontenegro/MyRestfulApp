using System.IO;

namespace MyConsoleApp.Currency.Writer
{
    public static class JsonWriter
    {
        public static void Write(string json, string filename)
        {
            File.WriteAllText($".\\{filename}.json", json);
        }
    }
}
