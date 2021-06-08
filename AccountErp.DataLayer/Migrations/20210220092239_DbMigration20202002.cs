using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class DbMigration20202002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LastLogOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COA_Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COA_AccountTypeId = table.Column<int>(nullable: false),
                    AccountName = table.Column<string>(nullable: true),
                    AccountCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COA_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COA_AccountMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountMasterName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COA_AccountMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    CompanyTenantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.CompanyTenantId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 1000, nullable: true),
                    IsoCode = table.Column<string>(maxLength: 10, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(maxLength: 25, nullable: false),
                    CardHolderName = table.Column<string>(maxLength: 250, nullable: false),
                    BankName = table.Column<string>(maxLength: 250, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productcategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productcategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesTaxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TaxPercentage = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    BankAccountId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTaxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScreenDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScreenName = table.Column<string>(nullable: false),
                    ScreenCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WareHouse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Location = table.Column<string>(maxLength: 1000, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COA_AccountType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COA_AccountMasterId = table.Column<int>(nullable: false),
                    AccountTypeName = table.Column<string>(nullable: true),
                    AccountTypeCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COA_AccountType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COA_AccountType_COA_AccountMaster_COA_AccountMasterId",
                        column: x => x.COA_AccountMasterId,
                        principalTable: "COA_AccountMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: true),
                    StreetNumber = table.Column<string>(maxLength: 50, nullable: true),
                    StreetName = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 1000, nullable: true),
                    State = table.Column<string>(maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    CountryId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId1",
                        column: x => x.CountryId1,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: true),
                    ShipTo = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    DeliveryInstruction = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingAddress_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Rate = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    IsTaxable = table.Column<bool>(nullable: false),
                    SalesTaxId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    isForSell = table.Column<bool>(nullable: true),
                    BankAccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_SalesTaxes_SalesTaxId",
                        column: x => x.SalesTaxId,
                        principalTable: "SalesTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserScreenAccess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserRoleId = table.Column<int>(nullable: false),
                    ScreenId = table.Column<int>(nullable: false),
                    CanAccess = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserScreenAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserScreenAccess_ScreenDetail_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "ScreenDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    CompanyTenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Companys_CompanyTenantId",
                        column: x => x.CompanyTenantId,
                        principalTable: "Companys",
                        principalColumn: "CompanyTenantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    IsTaxable = table.Column<bool>(nullable: false),
                    SalesTaxId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    InitialStock = table.Column<int>(nullable: true),
                    SellingPrice = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    BuyingPrice = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    BankAccountId = table.Column<int>(nullable: true),
                    ProductCategoryId = table.Column<int>(nullable: true),
                    WareHouseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Productcategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "Productcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_SalesTaxes_SalesTaxId",
                        column: x => x.SalesTaxId,
                        principalTable: "SalesTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_WareHouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: true),
                    COA_AccountTypeId = table.Column<int>(nullable: true),
                    AccountHolderName = table.Column<string>(maxLength: 250, nullable: true),
                    BankName = table.Column<string>(maxLength: 100, nullable: true),
                    BranchName = table.Column<string>(maxLength: 250, nullable: true),
                    Ifsc = table.Column<string>(maxLength: 20, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    AccountCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    LedgerType = table.Column<int>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    AccountId = table.Column<string>(nullable: true),
                    IsForEdit = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_COA_AccountType_COA_AccountTypeId",
                        column: x => x.COA_AccountTypeId,
                        principalTable: "COA_AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HSTNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Fax = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 250, nullable: false),
                    Website = table.Column<string>(maxLength: 250, nullable: true),
                    BillingAddressId = table.Column<int>(nullable: true),
                    ShippingAddressId = table.Column<int>(nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: true),
                    BankName = table.Column<string>(maxLength: 250, nullable: true),
                    BankBranch = table.Column<string>(maxLength: 250, nullable: true),
                    Ifsc = table.Column<string>(maxLength: 50, nullable: true),
                    Discount = table.Column<decimal>(type: "NUMERIC(5,2)", nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_Addresses_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendors_Addresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: true),
                    ShippingAddressId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 250, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 250, nullable: true),
                    LastName = table.Column<string>(maxLength: 250, nullable: true),
                    Email = table.Column<string>(maxLength: 250, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: true),
                    BankName = table.Column<string>(maxLength: 250, nullable: true),
                    BankBranch = table.Column<string>(maxLength: 250, nullable: true),
                    Ifsc = table.Column<string>(maxLength: 50, nullable: true),
                    Discount = table.Column<decimal>(type: "NUMERIC(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_ShippingAddress_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "ShippingAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoginModule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    createdOn = table.Column<DateTime>(nullable: true),
                    status = table.Column<bool>(nullable: true),
                    RoleId = table.Column<int>(nullable: true),
                    CompanyTenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginModule_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EndingStatementBalance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndingBalanceDate = table.Column<DateTime>(nullable: true),
                    EndingBalanceAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    BankAccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndingStatementBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EndingStatementBalance_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reconciliations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankAccountId = table.Column<int>(nullable: false),
                    ReconciliationDate = table.Column<DateTime>(nullable: true),
                    StatementBalance = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    IcloseBalance = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    IsReconciliation = table.Column<bool>(nullable: false),
                    ReconciliationStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reconciliations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reconciliations_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    BankAccountId = table.Column<int>(nullable: true),
                    ContactId = table.Column<int>(nullable: true),
                    TransactionTypeId = table.Column<int>(nullable: false),
                    TransactionNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    DebitAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    CreditAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ContactType = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    isForTransEntry = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VendorId = table.Column<int>(nullable: false),
                    RefrenceNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Tax = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Remark = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    StrBillDate = table.Column<string>(nullable: true),
                    BillDate = table.Column<DateTime>(nullable: false),
                    StrDueDate = table.Column<string>(nullable: true),
                    PoSoNumber = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    BillNumber = table.Column<string>(nullable: true),
                    SubTotal = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    LineAmountSubTotal = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    BillType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: true),
                    VendorId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 250, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 250, nullable: true),
                    LastName = table.Column<string>(maxLength: 250, nullable: true),
                    JobTitle = table.Column<string>(maxLength: 250, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    InvoiceNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Tax = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Remark = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    CustomerId1 = table.Column<int>(nullable: true),
                    StrInvoiceDate = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    StrDueDate = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    PoSoNumber = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    SubTotal = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    LineAmountSubTotal = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    InvoiceType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    QuotationNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Tax = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Remark = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    StrQuotationDate = table.Column<string>(nullable: true),
                    QuotationDate = table.Column<DateTime>(nullable: false),
                    StrExpireDate = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    PoSoNumber = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    SubTotal = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    LineAmountSubTotal = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    QuotationType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecurringInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    RecInvoiceNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Tax = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Remark = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    StrRecInvoiceDate = table.Column<string>(nullable: true),
                    RecInvoiceDate = table.Column<DateTime>(nullable: false),
                    StrRecDueDate = table.Column<string>(nullable: true),
                    RecDueDate = table.Column<DateTime>(nullable: false),
                    PoSoNumber = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    SubTotal = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    LineAmountSubTotal = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringInvoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    FileName = table.Column<string>(maxLength: 255, nullable: false),
                    OriginalFileName = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillAttachments_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillPayments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillId = table.Column<int>(nullable: false),
                    PaymentMode = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: true),
                    BankAccountId = table.Column<int>(nullable: true),
                    CreditCardId = table.Column<int>(nullable: true),
                    DepositTo = table.Column<string>(maxLength: 50, nullable: true),
                    ChequeNumber = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillPayments_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillPayments_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BillId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Rate = table.Column<decimal>(type: "NUMERIC(10,2)", nullable: false),
                    Price = table.Column<decimal>(type: "NUMERIC(10,2)", nullable: false),
                    TaxId = table.Column<int>(nullable: true),
                    TaxPercentage = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TaxPrice = table.Column<decimal>(nullable: false),
                    LineAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillServices_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillServices_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillServices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillServices_SalesTaxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "SalesTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditMemo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    InvoiceNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Tax = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Remark = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    StrInvoiceDate = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    StrDueDate = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    PoSoNumber = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    SubTotal = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    LineAmountSubTotal = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    InvoiceId = table.Column<int>(nullable: true),
                    OldAmmount = table.Column<decimal>(nullable: false),
                    NewAmmount = table.Column<decimal>(nullable: false),
                    DiffAmmount = table.Column<decimal>(nullable: false),
                    CreditMemoNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditMemo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditMemo_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditMemo_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    FileName = table.Column<string>(maxLength: 255, nullable: false),
                    OriginalFileName = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceAttachments_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoicePayments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceId = table.Column<int>(nullable: false),
                    PaymentMode = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: true),
                    DepositFrom = table.Column<string>(maxLength: 50, nullable: true),
                    BankAccountId = table.Column<int>(nullable: true),
                    ChequeNumber = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoicePayments_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoicePayments_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Rate = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Price = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    TaxId = table.Column<int>(nullable: true),
                    TaxPrice = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    TaxPercentage = table.Column<decimal>(nullable: true),
                    LineAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceServices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceServices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceServices_Items_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceServices_SalesTaxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "SalesTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuotationAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuotationId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    FileName = table.Column<string>(maxLength: 255, nullable: false),
                    OriginalFileName = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationAttachments_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuotationId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Rate = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Price = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    TaxId = table.Column<int>(nullable: true),
                    TaxPrice = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    TaxPercentage = table.Column<decimal>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    LineAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationServices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuotationServices_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationServices_Items_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuotationServices_SalesTaxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "SalesTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecurringInvoiceAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecInvoiceId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    FileName = table.Column<string>(maxLength: 255, nullable: false),
                    OriginalFileName = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringInvoiceAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringInvoiceAttachments_RecurringInvoices_RecInvoiceId",
                        column: x => x.RecInvoiceId,
                        principalTable: "RecurringInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecurringInvoiceServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecInvoiceId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Price = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    TaxId = table.Column<int>(nullable: true),
                    TaxPercentage = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    TaxPrice = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    LineAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringInvoiceServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringInvoiceServices_RecurringInvoices_RecInvoiceId",
                        column: x => x.RecInvoiceId,
                        principalTable: "RecurringInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecurringInvoiceServices_Items_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecurringInvoiceServices_SalesTaxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "SalesTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditMemoService",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreditMemoId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Rate = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Price = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    TaxId = table.Column<int>(nullable: true),
                    TaxPrice = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    TaxPercentage = table.Column<decimal>(nullable: true),
                    LineAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    OldQuantity = table.Column<int>(nullable: false),
                    NewQuantity = table.Column<int>(nullable: false),
                    OldAmmount = table.Column<decimal>(nullable: false),
                    NewAmmount = table.Column<decimal>(nullable: false),
                    DiffAmmount = table.Column<decimal>(nullable: false),
                    TaxDiffAmmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditMemoService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditMemoService_CreditMemo_CreditMemoId",
                        column: x => x.CreditMemoId,
                        principalTable: "CreditMemo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditMemoService_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditMemoService_Items_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditMemoService_SalesTaxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "SalesTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId1",
                table: "Addresses",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_COA_AccountTypeId",
                table: "BankAccounts",
                column: "COA_AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BillAttachments_BillId",
                table: "BillAttachments",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillPayments_BankAccountId",
                table: "BillPayments",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BillPayments_BillId",
                table: "BillPayments",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_VendorId",
                table: "Bills",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_BillServices_BillId",
                table: "BillServices",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillServices_ItemId",
                table: "BillServices",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BillServices_ProductId",
                table: "BillServices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BillServices_TaxId",
                table: "BillServices",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_COA_AccountType_COA_AccountMasterId",
                table: "COA_AccountType",
                column: "COA_AccountMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AddressId",
                table: "Contacts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_VendorId",
                table: "Contacts",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditMemo_CustomerId",
                table: "CreditMemo",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditMemo_InvoiceId",
                table: "CreditMemo",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditMemoService_CreditMemoId",
                table: "CreditMemoService",
                column: "CreditMemoId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditMemoService_ProductId",
                table: "CreditMemoService",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditMemoService_ServiceId",
                table: "CreditMemoService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditMemoService_TaxId",
                table: "CreditMemoService",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ShippingAddressId",
                table: "Customers",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EndingStatementBalance_BankAccountId",
                table: "EndingStatementBalance",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAttachments_InvoiceId",
                table: "InvoiceAttachments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayments_BankAccountId",
                table: "InvoicePayments",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayments_InvoiceId",
                table: "InvoicePayments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId1",
                table: "Invoices",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceServices_InvoiceId",
                table: "InvoiceServices",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceServices_ProductId",
                table: "InvoiceServices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceServices_ServiceId",
                table: "InvoiceServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceServices_TaxId",
                table: "InvoiceServices",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SalesTaxId",
                table: "Items",
                column: "SalesTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginModule_UserId",
                table: "LoginModule",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SalesTaxId",
                table: "Products",
                column: "SalesTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WareHouseId",
                table: "Products",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationAttachments_QuotationId",
                table: "QuotationAttachments",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CustomerId",
                table: "Quotations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationServices_ProductId",
                table: "QuotationServices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationServices_QuotationId",
                table: "QuotationServices",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationServices_ServiceId",
                table: "QuotationServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationServices_TaxId",
                table: "QuotationServices",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Reconciliations_BankAccountId",
                table: "Reconciliations",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringInvoiceAttachments_RecInvoiceId",
                table: "RecurringInvoiceAttachments",
                column: "RecInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringInvoices_CustomerId",
                table: "RecurringInvoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringInvoiceServices_RecInvoiceId",
                table: "RecurringInvoiceServices",
                column: "RecInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringInvoiceServices_ServiceId",
                table: "RecurringInvoiceServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringInvoiceServices_TaxId",
                table: "RecurringInvoiceServices",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_CountryId",
                table: "ShippingAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_BankAccountId",
                table: "Transaction",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyTenantId",
                table: "Users",
                column: "CompanyTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserScreenAccess_ScreenId",
                table: "UserScreenAccess",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_BillingAddressId",
                table: "Vendors",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_ShippingAddressId",
                table: "Vendors",
                column: "ShippingAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BillAttachments");

            migrationBuilder.DropTable(
                name: "BillPayments");

            migrationBuilder.DropTable(
                name: "BillServices");

            migrationBuilder.DropTable(
                name: "COA_Account");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "CreditMemoService");

            migrationBuilder.DropTable(
                name: "EndingStatementBalance");

            migrationBuilder.DropTable(
                name: "InvoiceAttachments");

            migrationBuilder.DropTable(
                name: "InvoicePayments");

            migrationBuilder.DropTable(
                name: "InvoiceServices");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "LoginModule");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "QuotationAttachments");

            migrationBuilder.DropTable(
                name: "QuotationServices");

            migrationBuilder.DropTable(
                name: "Reconciliations");

            migrationBuilder.DropTable(
                name: "RecurringInvoiceAttachments");

            migrationBuilder.DropTable(
                name: "RecurringInvoiceServices");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "UserScreenAccess");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "CreditMemo");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "RecurringInvoices");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "ScreenDetail");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Productcategory");

            migrationBuilder.DropTable(
                name: "WareHouse");

            migrationBuilder.DropTable(
                name: "SalesTaxes");

            migrationBuilder.DropTable(
                name: "COA_AccountType");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "COA_AccountMaster");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ShippingAddress");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
