using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddInterviewAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterviewAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InterviewerId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    InterviewType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ScheduledDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remarks = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewAssignments_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewAssignments_Interviewers_InterviewerId",
                        column: x => x.InterviewerId,
                        principalTable: "Interviewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewAssignments_CandidateId",
                table: "InterviewAssignments",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewAssignments_InterviewerId",
                table: "InterviewAssignments",
                column: "InterviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewAssignments");
        }
    }
}
