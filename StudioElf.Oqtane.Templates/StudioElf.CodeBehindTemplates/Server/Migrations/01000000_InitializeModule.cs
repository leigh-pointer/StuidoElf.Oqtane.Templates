using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using StudioElf.CodeBehindTemplates.Migrations.EntityBuilders;
using StudioElf.CodeBehindTemplates.Repository;

namespace StudioElf.CodeBehindTemplates.Migrations
{
    [DbContext(typeof(CodeBehindTemplatesContext))]
    [Migration("CodeBehindTemplates.01.00.00.00")]
    public class InitializeModule : MultiDatabaseMigration
    {
        public InitializeModule(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new CodeBehindTemplatesEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Create();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new CodeBehindTemplatesEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Drop();
        }
    }
}
