using System.Reflection;

namespace Api
{
    public static class NlogStartup
    {
        public static void SetupNlogFile()
        {
            string assemblyPath = GetAssembyPath();
            // setup your's local path for logs here:
            string logsFilePath = Environment.GetEnvironmentVariable("AngendamentoLogFiles")!;
            string nlogFileContent = ReadNlogTemplateFile(assemblyPath, logsFilePath);
            File.WriteAllText($"{assemblyPath}/nlog.config", nlogFileContent!);
        }

        public static void SetupAppSetting(string path)
        {
            string sqlStringConnection = Environment.GetEnvironmentVariable("AgendamentoDbConnection")!;
            string dev = File.ReadAllText($"{path}/appsettings.Development.json").Replace("\"Nlog\":", $"Nlog\": \"{sqlStringConnection}\"");
            string prod = File.ReadAllText($"{path}/appsettings.json").Replace("\"Nlog\":", $"Nlog\": \"{sqlStringConnection}\"");
            File.WriteAllText($"{path}/appsettings.Development.json", dev!);
            File.WriteAllText($"{path}/appsettings.json", prod!);
        }

        private static string ReadNlogTemplateFile(string assemblyPath, string logsFilePath)
        {
            return File.ReadAllText($"{assemblyPath}/nlog.config").Replace("[YOURS_FILE_PATH]", logsFilePath);
        }

        public static string GetAssembyPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().Location;
            string assemblyPath = Path.GetDirectoryName(codeBase)!;
            return assemblyPath;
        }
    }
}