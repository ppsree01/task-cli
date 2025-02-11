using System.IO;
using System.Text.Json;

internal static class FileManager {

    public static string path = "";
    public static void CreateFileIfNotExist() {
        string currentDirectory = Directory.GetCurrentDirectory();
        path = currentDirectory + "/data.json";
        bool dataDumpExists = File.Exists(path); 

        if (!dataDumpExists) {
            File.Create(path);
        }
        WriteData(new List<Task>());
    }

    public static List<Task> ReadData() {
        List<Task> tasks = new List<Task>();

        using (StreamReader sr = new StreamReader(path)) {
            string json = sr.ReadToEnd();
            if (json == null) {
                return tasks;
            }
            tasks = JsonSerializer.Deserialize<List<Task>>(json);
        }
        return tasks;
    }

    public static void WriteData(List<Task> tasks) {
        using (StreamWriter sw = new StreamWriter(path)) {
            sw.WriteLine(JsonSerializer.Serialize(tasks));
        }
    }
}