using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Excercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Size = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Since = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Until = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Competition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Groupsize = table.Column<int>(name: "Group_size", type: "INTEGER", nullable: false),
                    Since = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Until = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Locationid = table.Column<int>(name: "Location_id", type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competition_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sports_school",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Messageid = table.Column<int>(name: "Message_id", type: "INTEGER", nullable: false),
                    MessageId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports_school", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sports_school_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Monthly_subscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sportsschoolid = table.Column<int>(name: "Sports_school_id", type: "INTEGER", nullable: false),
                    SportsschoolId = table.Column<int>(name: "Sports_schoolId", type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monthly_subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monthly_subscription_Sports_school_Sports_schoolId",
                        column: x => x.SportsschoolId,
                        principalTable: "Sports_school",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Locationid = table.Column<int>(name: "Location_id", type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: true),
                    Excerciseid = table.Column<int>(name: "Excercise_id", type: "INTEGER", nullable: false),
                    ExcerciseId = table.Column<int>(type: "INTEGER", nullable: true),
                    Sportsschoolid = table.Column<int>(name: "Sports_school_id", type: "INTEGER", nullable: false),
                    SportsschoolId = table.Column<int>(name: "Sports_schoolId", type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_Excercise_ExcerciseId",
                        column: x => x.ExcerciseId,
                        principalTable: "Excercise",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Training_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Training_Sports_school_Sports_schoolId",
                        column: x => x.SportsschoolId,
                        principalTable: "Sports_school",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Sportsschoolid = table.Column<int>(name: "Sports_school_id", type: "INTEGER", nullable: false),
                    SportsschoolId = table.Column<int>(name: "Sports_schoolId", type: "INTEGER", nullable: true),
                    Usertypeid = table.Column<int>(name: "User_type_id", type: "INTEGER", nullable: false),
                    UsertypeId = table.Column<int>(name: "User_typeId", type: "INTEGER", nullable: true),
                    Competitionid = table.Column<int>(name: "Competition_id", type: "INTEGER", nullable: false),
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: true),
                    Monthlysubscriptionid = table.Column<int>(name: "Monthly_subscription_id", type: "INTEGER", nullable: false),
                    MonthlysubscriptionId = table.Column<int>(name: "Monthly_subscriptionId", type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Monthly_subscription_Monthly_subscriptionId",
                        column: x => x.MonthlysubscriptionId,
                        principalTable: "Monthly_subscription",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Sports_school_Sports_schoolId",
                        column: x => x.SportsschoolId,
                        principalTable: "Sports_school",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_User_type_User_typeId",
                        column: x => x.UsertypeId,
                        principalTable: "User_type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User_at_training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Since = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Until = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Userid = table.Column<int>(name: "User_id", type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    Trainingid = table.Column<int>(name: "Training_id", type: "INTEGER", nullable: false),
                    TrainingId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_at_training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_at_training_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_at_training_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User_in_group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Since = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Until = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Userid = table.Column<int>(name: "User_id", type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    Usergroupid = table.Column<int>(name: "User_group_id", type: "INTEGER", nullable: false),
                    UsergroupId = table.Column<int>(name: "User_groupId", type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_in_group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_in_group_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_in_group_User_group_User_groupId",
                        column: x => x.UsergroupId,
                        principalTable: "User_group",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competition_LocationId",
                table: "Competition",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Monthly_subscription_Sports_schoolId",
                table: "Monthly_subscription",
                column: "Sports_schoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_school_MessageId",
                table: "Sports_school",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_ExcerciseId",
                table: "Training",
                column: "ExcerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_LocationId",
                table: "Training",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_Sports_schoolId",
                table: "Training",
                column: "Sports_schoolId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompetitionId",
                table: "User",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Monthly_subscriptionId",
                table: "User",
                column: "Monthly_subscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Sports_schoolId",
                table: "User",
                column: "Sports_schoolId");

            migrationBuilder.CreateIndex(
                name: "IX_User_User_typeId",
                table: "User",
                column: "User_typeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_at_training_TrainingId",
                table: "User_at_training",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_User_at_training_UserId",
                table: "User_at_training",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_in_group_User_groupId",
                table: "User_in_group",
                column: "User_groupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_in_group_UserId",
                table: "User_in_group",
                column: "UserId");
        }

        /// <inheritdoc />
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
                name: "User_at_training");

            migrationBuilder.DropTable(
                name: "User_in_group");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "User_group");

            migrationBuilder.DropTable(
                name: "Excercise");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Monthly_subscription");

            migrationBuilder.DropTable(
                name: "User_type");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Sports_school");

            migrationBuilder.DropTable(
                name: "Message");
        }
    }
}
