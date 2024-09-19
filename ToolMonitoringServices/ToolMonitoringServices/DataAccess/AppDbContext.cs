using Microsoft.EntityFrameworkCore;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.DataAccess
{
    public class AppDbContext : DbContext
    {
        private readonly ILogger<AppDbContext> _logger;

        public AppDbContext(DbContextOptions<AppDbContext> options, ILogger<AppDbContext> logger) : base(options)
        {
            _logger = logger;
        }
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SupplierMaster> SupplierMaster { get; set; }

        public DbSet<Region> Region { get; set; }

        public DbSet<ToolMaster> ToolMaster { get; set; }

        public DbSet<ToolCategories> ToolCategories { get; set; }

        public DbSet<ToolHierarchyModel> ToolHierarchy { get; set; }

        public DbSet<Node> MindMapNodeLists { get; set; }

        public DbSet<ToolSupplierAssessment> ToolSupplierAssessment { get; set; }

        public DbSet<ToolConditionMaster> ToolConditionMaster { get; set; }

        public DbSet<GetAdmin> User { get; set; }

        public DbSet<GetLocationByPin> GetLocationByPin { get; set; }
    }
}
