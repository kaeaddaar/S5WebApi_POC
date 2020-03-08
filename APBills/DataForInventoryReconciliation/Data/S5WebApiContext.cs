using DataForInventoryReconciliation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DataForInventoryReconciliation.Data
{
    public class S5WebApiContext : DbContext
    {
        public DbSet<APBill> APBills { get; set; }
        public DbSet<BillHeader> BillHeaders { get; set; }
        public DbSet<BillLine> BillLines { get; set; }
        public DbSet<BillPayee> Payees { get; set; }
        public DbSet<BillSupplier> Suppliers { get; set; }
        public DbSet<BillCommentLine> BillCommentLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings == null)
            {
                throw new ArgumentNullException("You must have a connection string stored in the App.config file under ConnectionStrings");
            }

            if (settings["connectionString"] == null)
            {
                string str = string.Empty;
                // Get the current configuration file.
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(
                        ConfigurationUserLevel.None) as Configuration;

                str = str + "Reading configuration information:";

                ContextInformation evalContext =
                    config.EvaluationContext as ContextInformation;
                str = str + $"Machine level: {evalContext.IsMachineLevel.ToString()}";

                string filePath = config.FilePath;
                str = str + $"File path: {filePath}";

                bool hasFile = config.HasFile;
                str = str + $"Has file: {hasFile.ToString()}";

                ConfigurationSectionGroupCollection
                    groups = config.SectionGroups;
                str = str + $"Groups: {groups.Count.ToString()}";
                foreach (ConfigurationSectionGroup group in groups)
                {
                    str = str + $"Group Name: {group.Name}";
                    // Console.WriteLine("Group Type: {0}", group.Type);
                }

                ConfigurationSectionCollection
                    sections = config.Sections;
                str = str + $"Sections: {sections.Count.ToString()}";

                throw new ArgumentNullException($"Null config info, see info here ({str})");
            }

            // Problem: Value cannot be null. (Parameter 'Null config value, see info here (Reading configuration information:Machine level: FalseFile path: E:\_P\S5WebAPI_POC\APBills\APBills\bin\Debug\netcoreapp3.0\ef.dll.configHas file: FalseGroups: 0Sections: 8)')
            // I duplicated the config file in the location below as it is what entity framework is using. This way I work around the problem shown above
            //E:\_P\S5WebAPI_POC\APBills\APBills\bin\Debug\netcoreapp3.0\ef.dll.config
            optionsBuilder.UseSqlServer(settings["connectionString"].ConnectionString);

        }
    }
}
