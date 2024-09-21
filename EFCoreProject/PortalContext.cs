using Microsoft.EntityFrameworkCore;

namespace EFCoreProject;

public class PortalContext : DbContext
{
    public PortalContext()
    {
    }


    public PortalContext(DbContextOptions<PortalContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CONTEXT_CONNECTIONSTRING"));
    }
}