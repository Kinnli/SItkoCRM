using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SitkoCRM.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Clients",
                table => new
                {
                    ClientId = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(),
                    updated_at = table.Column<DateTime>(),
                    Name = table.Column<string>(nullable: true),
                    KPP = table.Column<string>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Active = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_Clients", x => x.ClientId); });

            migrationBuilder.CreateTable(
                "DomainsStatuses",
                table => new
                {
                    StatusId = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(),
                    updated_at = table.Column<DateTime>(),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_DomainsStatuses", x => x.StatusId); });

            migrationBuilder.CreateTable(
                "Operations",
                table => new
                {
                    OperationId = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(),
                    updated_at = table.Column<DateTime>(),
                    Data = table.Column<string>("jsonb", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Operations", x => x.OperationId); });

            migrationBuilder.CreateTable(
                "Prices",
                table => new
                {
                    SerPriceId = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(),
                    updated_at = table.Column<DateTime>(),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Prices", x => x.SerPriceId); });

            migrationBuilder.CreateTable(
                "Servers",
                table => new
                {
                    ServerId = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(),
                    updated_at = table.Column<DateTime>(),
                    Name = table.Column<string>(nullable: true),
                    IPv4 = table.Column<string>(nullable: true),
                    IPv6 = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Servers", x => x.ServerId); });

            migrationBuilder.CreateTable(
                "ServicesStatuses",
                table => new
                {
                    SerStatusId = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(),
                    updated_at = table.Column<DateTime>(),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_ServicesStatuses", x => x.SerStatusId); });

            migrationBuilder.CreateTable(
                "ClientContacts",
                table => new
                {
                    ContactId = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(),
                    updated_at = table.Column<DateTime>(),
                    PhoneNum = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContacts", x => x.ContactId);
                    table.ForeignKey(
                        "FK_ClientContacts_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Services",
                table => new
                {
                    ServiceId = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(),
                    updated_at = table.Column<DateTime>(),
                    ActiveTo = table.Column<DateTime>(),
                    ClientId = table.Column<int>(),
                    StatusId = table.Column<int>(),
                    PriceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        "FK_Services_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Services_Prices_PriceId",
                        x => x.PriceId,
                        "Prices",
                        "SerPriceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Services_ServicesStatuses_StatusId",
                        x => x.StatusId,
                        "ServicesStatuses",
                        "SerStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Bills",
                table => new
                {
                    BillId = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(),
                    updated_at = table.Column<DateTime>(),
                    Sum = table.Column<int>(),
                    IsBilled = table.Column<bool>(),
                    IsSended = table.Column<bool>(),
                    IsPayed = table.Column<bool>(),
                    ServiceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        "FK_Bills_Services_ServiceId",
                        x => x.ServiceId,
                        "Services",
                        "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Hosts",
                table => new
                {
                    HostId = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(),
                    updated_at = table.Column<DateTime>(),
                    Name = table.Column<string>(nullable: true),
                    ServiceId = table.Column<int>(),
                    ServerId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.HostId);
                    table.ForeignKey(
                        "FK_Hosts_Servers_ServerId",
                        x => x.ServerId,
                        "Servers",
                        "ServerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Hosts_Services_ServiceId",
                        x => x.ServiceId,
                        "Services",
                        "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Domains",
                table => new
                {
                    DomainId = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(),
                    updated_at = table.Column<DateTime>(),
                    Name = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(),
                    HostId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.DomainId);
                    table.ForeignKey(
                        "FK_Domains_Hosts_HostId",
                        x => x.HostId,
                        "Hosts",
                        "HostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Domains_DomainsStatuses_StatusId",
                        x => x.StatusId,
                        "DomainsStatuses",
                        "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "DomainsServices",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(),
                    updated_at = table.Column<DateTime>(),
                    ServiceId = table.Column<int>(),
                    DomainId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainsServices", x => x.Id);
                    table.ForeignKey(
                        "FK_DomainsServices_Domains_DomainId",
                        x => x.DomainId,
                        "Domains",
                        "DomainId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_DomainsServices_Services_ServiceId",
                        x => x.ServiceId,
                        "Services",
                        "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Bills_ServiceId",
                "Bills",
                "ServiceId");

            migrationBuilder.CreateIndex(
                "IX_ClientContacts_ClientId",
                "ClientContacts",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_Domains_HostId",
                "Domains",
                "HostId");

            migrationBuilder.CreateIndex(
                "IX_Domains_StatusId",
                "Domains",
                "StatusId");

            migrationBuilder.CreateIndex(
                "IX_DomainsServices_DomainId",
                "DomainsServices",
                "DomainId");

            migrationBuilder.CreateIndex(
                "IX_DomainsServices_ServiceId",
                "DomainsServices",
                "ServiceId");

            migrationBuilder.CreateIndex(
                "IX_Hosts_ServerId",
                "Hosts",
                "ServerId");

            migrationBuilder.CreateIndex(
                "IX_Hosts_ServiceId",
                "Hosts",
                "ServiceId");

            migrationBuilder.CreateIndex(
                "IX_Services_ClientId",
                "Services",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_Services_PriceId",
                "Services",
                "PriceId");

            migrationBuilder.CreateIndex(
                "IX_Services_StatusId",
                "Services",
                "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Bills");

            migrationBuilder.DropTable(
                "ClientContacts");

            migrationBuilder.DropTable(
                "DomainsServices");

            migrationBuilder.DropTable(
                "Operations");

            migrationBuilder.DropTable(
                "Domains");

            migrationBuilder.DropTable(
                "Hosts");

            migrationBuilder.DropTable(
                "DomainsStatuses");

            migrationBuilder.DropTable(
                "Servers");

            migrationBuilder.DropTable(
                "Services");

            migrationBuilder.DropTable(
                "Clients");

            migrationBuilder.DropTable(
                "Prices");

            migrationBuilder.DropTable(
                "ServicesStatuses");
        }
    }
}
