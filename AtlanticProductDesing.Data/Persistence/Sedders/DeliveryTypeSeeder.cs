namespace AtlanticProductDesing.Infrastruture.Persistence.Sedders
{
    public static class DeliveryTypeSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // Check if data already exists
            //if (await context.DeliveryType.AnyAsync())
            //{
            //    // Data already exists; do not execute the seeder
            //    return;
            //}
            //try
            //{
            //    // Get the base directory of the application
            //    var basePath = AppDomain.CurrentDomain.BaseDirectory;

            //    // Build the path to the JSON file
            //    var seedDataPath = Path.Combine(basePath, "persistence", "seedData", "DeliveryTypeSeedData.json");

            //    // Check if the file exists
            //    if (!File.Exists(seedDataPath))
            //    {
            //        throw new FileNotFoundException($"The seed data file was not found at path: {seedDataPath}");
            //    }

            //    // Read and deserialize the JSON file
            //    var seedDataJson = await File.ReadAllTextAsync(seedDataPath);
            //    var entities = JsonConvert.DeserializeObject<List<DeliveryType>>(seedDataJson);

            //    // Add the data to the database
            //    await context.DeliveryType.AddRangeAsync(entities);
            //    await context.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    // Exception handling
            //    Console.WriteLine($"Error executing the GeographicalDivision seeder: {ex.Message}");
            //    // Optional: rethrow the exception if you want the application to fail
            //    throw;
            //}
        }
    }
}
