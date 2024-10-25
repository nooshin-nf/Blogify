using System.Diagnostics;

namespace Blogify.NSwag
{
    public class ClientApiGenerator
    {
        public static string Generate(string? apiName, string? apiVersion)
        {
            // Path to the swagger.json file and the output directory for the client
            var swaggerSettings = new SwaggerSettings();
            var baseUrl = swaggerSettings.BaseUrl;

            var apiList = swaggerSettings.Apis;
            if (!string.IsNullOrEmpty(apiName))
                apiList = apiList.Where(x => x.Name == apiName).ToList();

            if (apiList.Count == 0)
                return "No APIs found. Please check the swagger settings file.";

            foreach (var api in apiList)
            {
                var apiVersionList = api.Versions;
                if (!string.IsNullOrEmpty(apiVersion))
                    apiVersionList = apiVersionList.Where(x => x == apiVersion).ToList();

                if (apiVersionList.Count == 0)
                    return "No API version found. Please check the swagger settings file.";

                foreach (var version in apiVersionList)
                {
                    try
                    {
                        var dir = GetCurrentDirectory();
                        string outputPath = @$"{dir}/ClientApis/{version.ToUpper()}/{api.Name}Api.cs";
                        var swaggerUrl = $"{baseUrl}/{version}/{api.Name.ToLower()}";
                        var namespaceName = $"Blogify.{api.Name}API.{version.ToUpper()}";
                        var className = $"{api.Name}Api{version.ToUpper()}";
                        UpdateNswagFile(swaggerUrl, className, namespaceName, outputPath);

                        // Command to generate the NSwag client
                        string nswagCommand = $@"nswag run api.nswag";

                        ExecuteShellCommand(nswagCommand);
                    }
                    catch
                    {
                    }
                }
            }

            return "API Client Generation Was Successful! :D";
        }

        private static void ExecuteShellCommand(string command)
        {
            Process process = new();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/C {command}";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();
            Console.WriteLine(output);
        }

        private static void UpdateNswagFile(string swaggerUrl, string className, string namespaceName, string outputPath)
        {
            var dir = GetCurrentDirectory();
            string nswagFilePath = "api.nswag";
            string fileContent = File.ReadAllText($"{dir}/{nswagFilePath}");

            // Replace placeholders
            fileContent = fileContent.Replace("YOUR_SWAGGER_URL_HERE", swaggerUrl)
                                     .Replace("YOUR_CLASS_NAME_HERE", className)
                                     .Replace("YOUR_NAMESPACE_HERE", namespaceName)
                                     .Replace("YOUR_OUTPUT_PATH_HERE", outputPath);

            // Save the updated content back to the file
            File.WriteAllText(nswagFilePath, fileContent);
        }

        private static string GetCurrentDirectory()
        {
            string startupPath = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            return startupPath.Replace('\\', '/');
        }

        private static void AddPrivateNuGetSource(string sourceUrl, string apiKey)
        {
            string command = $"nuget sources Add -Name PrivateSource -Source {sourceUrl} && nuget setapikey {apiKey} -Source {sourceUrl}";

            ExecuteShellCommand(command);

            Console.WriteLine($"Private NuGet source '{sourceUrl}' has been added.");
        }
    }
}
