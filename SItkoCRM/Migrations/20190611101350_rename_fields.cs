using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SitkoCRM.Migrations
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class rename_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "updated_at",
                "ServicesStatuses",
                "UpdatedAt");

            migrationBuilder.RenameColumn(
                "created_at",
                "ServicesStatuses",
                "CreatedAt");

            migrationBuilder.RenameColumn(
                "updated_at",
                "Services",
                "UpdatedAt");

            migrationBuilder.RenameColumn(
                "created_at",
                "Services",
                "CreatedAt");

            migrationBuilder.RenameColumn(
                "updated_at",
                "Servers",
                "UpdatedAt");

            migrationBuilder.RenameColumn(
                "created_at",
                "Servers",
                "CreatedAt");

            migrationBuilder.RenameColumn(
                "updated_at",
                "Prices",
                "UpdatedAt");

            migrationBuilder.RenameColumn(
                "created_at",
                "Prices",
                "CreatedAt");

            migrationBuilder.RenameColumn(
                "updated_at",
                "Operations",
                "UpdatedAt");

            migrationBuilder.RenameColumn(
                "created_at",
                "Operations",
                "CreatedAt");

            migrationBuilder.RenameColumn(
                "updated_at",
                "Hosts",
                "UpdatedAt");

            migrationBuilder.RenameColumn(
                "created_at",
                "Hosts",
                "CreatedAt");

            migrationBuilder.RenameColumn(
                "updated_at",
                "DomainsStatuses",
                "UpdatedAt");

            migrationBuilder.RenameColumn(
                "created_at",
                "DomainsStatuses",
                "CreatedAt");

            migrationBuilder.RenameColumn(
                "updated_at",
                "DomainsServices",
                "UpdatedAt");

            migrationBuilder.RenameColumn(
                "created_at",
                "DomainsServices",
                "CreatedAt");

            migrationBuilder.RenameColumn(
                "updated_at",
                "Domains",
                "UpdatedAt");

            migrationBuilder.RenameColumn(
                "created_at",
                "Domains",
                "CreatedAt");

            migrationBuilder.RenameColumn(
                "updated_at",
                "Clients",
                "UpdatedAt");

            migrationBuilder.RenameColumn(
                "created_at",
                "Clients",
                "CreatedAt");

            migrationBuilder.RenameColumn(
                "updated_at",
                "ClientContacts",
                "UpdatedAt");

            migrationBuilder.RenameColumn(
                "created_at",
                "ClientContacts",
                "CreatedAt");

            migrationBuilder.RenameColumn(
                "updated_at",
                "Bills",
                "UpdatedAt");

            migrationBuilder.RenameColumn(
                "created_at",
                "Bills",
                "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "UpdatedAt",
                "ServicesStatuses",
                "updated_at");

            migrationBuilder.RenameColumn(
                "CreatedAt",
                "ServicesStatuses",
                "created_at");

            migrationBuilder.RenameColumn(
                "UpdatedAt",
                "Services",
                "updated_at");

            migrationBuilder.RenameColumn(
                "CreatedAt",
                "Services",
                "created_at");

            migrationBuilder.RenameColumn(
                "UpdatedAt",
                "Servers",
                "updated_at");

            migrationBuilder.RenameColumn(
                "CreatedAt",
                "Servers",
                "created_at");

            migrationBuilder.RenameColumn(
                "UpdatedAt",
                "Prices",
                "updated_at");

            migrationBuilder.RenameColumn(
                "CreatedAt",
                "Prices",
                "created_at");

            migrationBuilder.RenameColumn(
                "UpdatedAt",
                "Operations",
                "updated_at");

            migrationBuilder.RenameColumn(
                "CreatedAt",
                "Operations",
                "created_at");

            migrationBuilder.RenameColumn(
                "UpdatedAt",
                "Hosts",
                "updated_at");

            migrationBuilder.RenameColumn(
                "CreatedAt",
                "Hosts",
                "created_at");

            migrationBuilder.RenameColumn(
                "UpdatedAt",
                "DomainsStatuses",
                "updated_at");

            migrationBuilder.RenameColumn(
                "CreatedAt",
                "DomainsStatuses",
                "created_at");

            migrationBuilder.RenameColumn(
                "UpdatedAt",
                "DomainsServices",
                "updated_at");

            migrationBuilder.RenameColumn(
                "CreatedAt",
                "DomainsServices",
                "created_at");

            migrationBuilder.RenameColumn(
                "UpdatedAt",
                "Domains",
                "updated_at");

            migrationBuilder.RenameColumn(
                "CreatedAt",
                "Domains",
                "created_at");

            migrationBuilder.RenameColumn(
                "UpdatedAt",
                "Clients",
                "updated_at");

            migrationBuilder.RenameColumn(
                "CreatedAt",
                "Clients",
                "created_at");

            migrationBuilder.RenameColumn(
                "UpdatedAt",
                "ClientContacts",
                "updated_at");

            migrationBuilder.RenameColumn(
                "CreatedAt",
                "ClientContacts",
                "created_at");

            migrationBuilder.RenameColumn(
                "UpdatedAt",
                "Bills",
                "updated_at");

            migrationBuilder.RenameColumn(
                "CreatedAt",
                "Bills",
                "created_at");
        }
    }
}
