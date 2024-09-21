# dbcontext-unittest-environment-variable
## How to unit test DBContext when using Azure and Local Database(s)
Using environment variables allows for unit testing of EntityFramework.Core (EFCore) projects.
### Settings of interest
<ol>
  <li>In the EFCoreProject, update the OnConfiguring method to the following:
  <ol>
    <li> protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING"));
    }</li>
    <li>This allows for changing of connection strings via Environment Variable</li>
    <li><The Unit Test will handle setting the value.</li>
  </ol>
</ol>

