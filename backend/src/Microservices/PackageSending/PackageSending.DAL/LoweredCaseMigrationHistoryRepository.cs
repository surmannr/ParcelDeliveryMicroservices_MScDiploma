using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageSending.DAL
{
    public class LoweredCaseMigrationHistoryRepository : NpgsqlHistoryRepository
    {
        public LoweredCaseMigrationHistoryRepository(HistoryRepositoryDependencies dependencies)
        : base(dependencies)
        {
        }
        protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
        {
            base.ConfigureTable(history);
            history.Property(h => h.MigrationId).HasColumnName("migrationid");
            history.Property(h => h.ProductVersion).HasColumnName("productversion");
        }
    }
}
