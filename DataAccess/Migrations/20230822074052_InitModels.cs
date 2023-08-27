using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Candidat__3214EC0723EAB85E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__3214EC07CA3A503B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    SalaryFrom = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalaryTo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkingArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benefits = table.Column<string>(type: "ntext", nullable: true),
                    Description = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Jobs__3214EC07E4A654A8", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Position__3214EC07D6944344", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__3214EC0788086A30", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InterviewTimeStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    InterviewTimeEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MeetingId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Schedule__3214EC07646F1A23", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skills__3214EC07AAF5A10E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC07F7063020", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Users__Departmen__29572725",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Users__RoleId__286302EC",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    IsMustHave = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JobSkill__3214EC075029025A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__JobSkill__JobId__300424B4",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__JobSkill__SkillI__30F848ED",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CVAttachment = table.Column<string>(type: "ntext", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    YearOfExperience = table.Column<int>(type: "int", nullable: true),
                    RecruiterId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Candidat__3214EC07193A6F0B", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Candidate__Recru__36B12243",
                        column: x => x.RecruiterId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Candidate__Statu__35BCFE0A",
                        column: x => x.StatusId,
                        principalTable: "CandidateStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InterviewerSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewId = table.Column<int>(type: "int", nullable: false),
                    SheduleId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Intervie__3214EC07F3C79308", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Interview__Inter__3F466844",
                        column: x => x.InterviewId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Interview__Shedu__403A8C7D",
                        column: x => x.SheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    OfferStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BonusRate = table.Column<int>(type: "int", nullable: true),
                    ApprovedByManagerId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Offers__3214EC073B7C222F", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Offers__Approved__45F365D3",
                        column: x => x.ApprovedByManagerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Offers__Departme__44FF419A",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Offers__Position__46E78A0C",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Candidat__3214EC078B72FF3B", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Candidate__Candi__398D8EEE",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Candidate__Skill__3A81B327",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_RecruiterId",
                table: "Candidates",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_StatusId",
                table: "Candidates",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkill_CandidateId",
                table: "CandidateSkill",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkill_SkillId",
                table: "CandidateSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewerSchedule_InterviewId",
                table: "InterviewerSchedule",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewerSchedule_SheduleId",
                table: "InterviewerSchedule",
                column: "SheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_JobId",
                table: "JobSkill",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_SkillId",
                table: "JobSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ApprovedByManagerId",
                table: "Offers",
                column: "ApprovedByManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_DepartmentId",
                table: "Offers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PositionId",
                table: "Offers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateSkill");

            migrationBuilder.DropTable(
                name: "InterviewerSchedule");

            migrationBuilder.DropTable(
                name: "JobSkill");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CandidateStatus");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
