using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace StudioElf.CodeBehindTemplates.Migrations.EntityBuilders
{
    public class CodeBehindTemplatesEntityBuilder : AuditableBaseEntityBuilder<CodeBehindTemplatesEntityBuilder>
    {
        private const string _entityTableName = "StudioElfCodeBehindTemplates";
        private readonly PrimaryKey<CodeBehindTemplatesEntityBuilder> _primaryKey = new("PK_StudioElfCodeBehindTemplates", x => x.CodeBehindTemplatesId);
        private readonly ForeignKey<CodeBehindTemplatesEntityBuilder> _moduleForeignKey = new("FK_StudioElfCodeBehindTemplates_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public CodeBehindTemplatesEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override CodeBehindTemplatesEntityBuilder BuildTable(ColumnsBuilder table)
        {
            CodeBehindTemplatesId = AddAutoIncrementColumn(table,"CodeBehindTemplatesId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> CodeBehindTemplatesId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
