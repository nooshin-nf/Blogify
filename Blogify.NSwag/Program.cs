using Blogify.NSwag;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("API Clients Generator using NSwag...");
        Console.WriteLine(Environment.NewLine + "Do you want to generate a client for a specific API?");
        Console.WriteLine("Enter 'y' for YES or 'n' for NO. Default is 'n' ...");

        var generateApiResponse = Console.ReadLine();

        string apiName = null, apiVersion = null;

        if (!string.IsNullOrEmpty(generateApiResponse) && generateApiResponse.ToLower() == "y")
        {
            Console.WriteLine("Enter the name of the API (e.g., core or auth):");
            apiName = Console.ReadLine();

            Console.WriteLine(Environment.NewLine + "Do you want to generate a specific version or for all versions?");
            Console.WriteLine("Enter version (e.g., v1) or press Enter for all ...");

            var generateVersionResponse = Console.ReadLine();

            if (!string.IsNullOrEmpty(generateVersionResponse))
                apiVersion = generateVersionResponse.ToLower();
        }

        string? result = ClientApiGenerator.Generate(apiName, apiVersion);
        Console.WriteLine(result);
        Console.ReadKey();
    }

}

