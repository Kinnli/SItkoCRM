using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SitkoCRM.Migrations
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Clients",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(),
                    UpdatedAt = table.Column<DateTimeOffset>(),
                    Name = table.Column<string>(nullable: true),
                    KPP = table.Column<string>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Active = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_Clients", x => x.Id); });

            migrationBuilder.CreateTable(
                "DomainStatuses",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(),
                    UpdatedAt = table.Column<DateTimeOffset>(),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_DomainStatuses", x => x.Id); });

            migrationBuilder.CreateTable(
                "Operations",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(),
                    UpdatedAt = table.Column<DateTimeOffset>(),
                    Data = table.Column<string>("jsonb", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Operations", x => x.Id); });

            migrationBuilder.CreateTable(
                "Servers",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(),
                    UpdatedAt = table.Column<DateTimeOffset>(),
                    Name = table.Column<string>(nullable: true),
                    IPv4 = table.Column<string>(nullable: true),
                    IPv6 = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Servers", x => x.Id); });

            migrationBuilder.CreateTable(
                "ServicePrices",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(),
                    UpdatedAt = table.Column<DateTimeOffset>(),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_ServicePrices", x => x.Id); });

            migrationBuilder.CreateTable(
                "ServiceStatuses",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(),
                    UpdatedAt = table.Column<DateTimeOffset>(),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_ServiceStatuses", x => x.Id); });

            migrationBuilder.CreateTable(
                "ClientContacts",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(),
                    UpdatedAt = table.Column<DateTimeOffset>(),
                    PhoneNum = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContacts", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientContacts_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Services",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(),
                    UpdatedAt = table.Column<DateTimeOffset>(),
                    ActiveTo = table.Column<DateTime>(),
                    ClientId = table.Column<int>(),
                    StatusId = table.Column<int>(),
                    PriceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        "FK_Services_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Services_ServicePrices_StatusId",
                        x => x.StatusId,
                        "ServicePrices",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Services_ServiceStatuses_StatusId",
                        x => x.StatusId,
                        "ServiceStatuses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Bills",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(),
                    UpdatedAt = table.Column<DateTimeOffset>(),
                    Sum = table.Column<int>(),
                    IsBilled = table.Column<bool>(),
                    IsSended = table.Column<bool>(),
                    IsPayed = table.Column<bool>(),
                    ServiceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        "FK_Bills_Services_ServiceId",
                        x => x.ServiceId,
                        "Services",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Hosts",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(),
                    UpdatedAt = table.Column<DateTimeOffset>(),
                    Name = table.Column<string>(nullable: true),
                    ServiceId = table.Column<int>(),
                    ServerId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                    table.ForeignKey(
                        "FK_Hosts_Servers_ServerId",
                        x => x.ServerId,
                        "Servers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Hosts_Services_ServiceId",
                        x => x.ServiceId,
                        "Services",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Domains",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(),
                    UpdatedAt = table.Column<DateTimeOffset>(),
                    Name = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(),
                    HostId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                    table.ForeignKey(
                        "FK_Domains_Hosts_HostId",
                        x => x.HostId,
                        "Hosts",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Domains_DomainStatuses_StatusId",
                        x => x.StatusId,
                        "DomainStatuses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "DomainServices",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(),
                    UpdatedAt = table.Column<DateTimeOffset>(),
                    ServiceId = table.Column<int>(),
                    DomainId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainServices", x => x.Id);
                    table.ForeignKey(
                        "FK_DomainServices_Domains_DomainId",
                        x => x.DomainId,
                        "Domains",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_DomainServices_Services_ServiceId",
                        x => x.ServiceId,
                        "Services",
                        "Id",
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
                "IX_DomainServices_DomainId",
                "DomainServices",
                "DomainId");

            migrationBuilder.CreateIndex(
                "IX_DomainServices_ServiceId",
                "DomainServices",
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
                "DomainServices");

            migrationBuilder.DropTable(
                "Operations");

            migrationBuilder.DropTable(
                "Domains");

            migrationBuilder.DropTable(
                "Hosts");

            migrationBuilder.DropTable(
                "DomainStatuses");

            migrationBuilder.DropTable(
                "Servers");

            migrationBuilder.DropTable(
                "Services");

            migrationBuilder.DropTable(
                "Clients");

            migrationBuilder.DropTable(
                "ServicePrices");

            migrationBuilder.DropTable(
                "ServiceStatuses");
        }
    }
}
