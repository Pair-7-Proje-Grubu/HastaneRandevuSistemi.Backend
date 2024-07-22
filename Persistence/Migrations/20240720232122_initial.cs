using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentDuration = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserFeedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoWorkHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoWorkHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    StartBreakTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndBreakTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDurationHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDurationHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentDurationHistory_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockId = table.Column<int>(type: "int", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeLocations_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeLocations_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeLocations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    OfficeLocationId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_OfficeLocations_OfficeLocationId",
                        column: x => x.OfficeLocationId,
                        principalTable: "OfficeLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllergyPatient",
                columns: table => new
                {
                    AllergiesId = table.Column<int>(type: "int", nullable: false),
                    PatientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyPatient", x => new { x.AllergiesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_AllergyPatient_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergyPatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorNoWorkHour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    NoWorkHourId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorNoWorkHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorNoWorkHour_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorNoWorkHour_NoWorkHours_NoWorkHourId",
                        column: x => x.NoWorkHourId,
                        principalTable: "NoWorkHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "No", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, "A", null },
                    { 2, null, null, "B", null },
                    { 3, null, null, "C", null }
                });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "Id", "AppointmentDuration", "CreatedDate", "DeletedDate", "Name", "PhoneNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 30, null, null, "Yoğun Bakım", null, null },
                    { 2, 20, null, null, "Palyatif Bakım", null, null },
                    { 3, 20, null, null, "Beyin ve Sinir Cerrahisi", null, null },
                    { 4, 15, null, null, "Çocuk Sağlığı ve Hastalıkları", null, null },
                    { 5, 15, null, null, "Enfeksiyon Hastalıkları", null, null },
                    { 6, 15, null, null, "Fiziksel Tıp ve Rehabilitasyon", null, null },
                    { 7, 30, null, null, "Genel Cerrahi", null, null },
                    { 8, 20, null, null, "Genel Dahiliye", null, null },
                    { 9, 30, null, null, "Göğüs Cerrahi", null, null },
                    { 10, 30, null, null, "Göğüs Hastalıkları", null, null },
                    { 11, 20, null, null, "Göz Hastalıkları", null, null },
                    { 12, 30, null, null, "Kadın Hastalıkları ve Doğum", null, null },
                    { 13, 20, null, null, "Kalp Damar Cerrahisi", null, null },
                    { 14, 20, null, null, "Kardiyoloji", null, null },
                    { 15, 15, null, null, "Kulak Burun Boğaz", null, null },
                    { 16, 20, null, null, "Nöroloji", null, null },
                    { 17, 15, null, null, "Ortopedi ve Travmatoloji", null, null },
                    { 18, 15, null, null, "Üroloji", null, null }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "No", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, "Zemin", null },
                    { 2, null, null, "1.Kat", null },
                    { 3, null, null, "2.Kat", null },
                    { 4, null, null, "3.Kat", null },
                    { 5, null, null, "4.Kat", null },
                    { 6, null, null, "-1.Kat", null }
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, "Patient", null },
                    { 2, null, null, "Doctor", null },
                    { 3, null, null, "Support", null },
                    { 4, null, null, "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "No", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, "O-1", null },
                    { 2, null, null, "O-2", null },
                    { 3, null, null, "K-1", null },
                    { 4, null, null, "K-2", null },
                    { 5, null, null, "K-3", null },
                    { 6, null, null, "D-1", null },
                    { 7, null, null, "D-2", null },
                    { 8, null, null, "N-1", null },
                    { 9, null, null, "N-2", null },
                    { 10, null, null, "U-1", null },
                    { 11, null, null, "U-2", null }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "TitleName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, "Pratisyen Doktor", null },
                    { 2, null, null, "Uzman Doktor", null },
                    { 3, null, null, "Operatör Doktor", null },
                    { 4, null, null, "Yardımcı Doçent", null },
                    { 5, null, null, "Doçent", null },
                    { 6, null, null, "Profesör", null },
                    { 7, null, null, "Ordinaryüs ", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "DeletedDate", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "PasswordSalt", "Phone", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6034), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6042), null, "admin@hrs.com", "Test", "U", "Admin", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905000000000", null },
                    { 2, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6046), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6047), null, "doctor@hrs.com", "Test", "U", "Doctor", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905000000001", null },
                    { 3, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6051), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6052), null, "patient@hrs.com", "Test", "U", "Patient", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905000000002", null },
                    { 4, new DateTime(1975, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6057), null, "ahmet.yildiz@hrs.com", "Ahmet", "M", "Yıldız", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905301234567", null },
                    { 5, new DateTime(1980, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6060), null, "emine.sahin@hrs.com", "Emine", "F", "Şahin", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905412345678", null },
                    { 6, new DateTime(1972, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6062), null, "mustafa.aydin@hrs.com", "Mustafa", "M", "Aydın", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905523456789", null },
                    { 7, new DateTime(1983, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6064), null, "hacer.korkmaz@hrs.com", "Hacer", "F", "Korkmaz", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905634567890", null },
                    { 8, new DateTime(1978, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6067), null, "ibrahim.arslan@hrs.com", "İbrahim", "M", "Arslan", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905745678901", null },
                    { 9, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6085), null, "ayse.yilmaz@email.com", "Ayşe", "F", "Yılmaz", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905856789012", null },
                    { 10, new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6088), null, "mehmet.kaya@email.com", "Mehmet", "M", "Kaya", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905967890123", null },
                    { 11, new DateTime(1978, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6090), null, "fatma.demir@email.com", "Fatma", "F", "Demir", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905078901234", null },
                    { 12, new DateTime(1995, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6092), null, "ali.ozturk@email.com", "Ali", "M", "Öztürk", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905189012345", null },
                    { 13, new DateTime(1988, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6094), null, "zeynep.celik@email.com", "Zeynep", "F", "Çelik", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905290123456", null },
                    { 14, new DateTime(1982, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6069), null, "seda.kara@hrs.com", "Seda", "F", "Kara", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905356789012", null },
                    { 15, new DateTime(1979, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6071), null, "okan.yilmaz@hrs.com", "Okan", "M", "Yılmaz", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905467890123", null },
                    { 16, new DateTime(1985, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6073), null, "sevgi.ozturk@hrs.com", "Sevgi", "F", "Öztürk", new byte[] { 234, 208, 100, 0, 18, 126, 183, 197, 47, 54, 154, 76, 118, 61, 177, 19, 64, 156, 125, 70, 247, 165, 152, 230, 27, 167, 31, 15, 67, 10, 25, 42, 100, 146, 190, 57, 43, 248, 179, 183, 91, 180, 5, 120, 208, 42, 73, 182, 231, 115, 31, 146, 72, 54, 50, 29, 93, 72, 206, 87, 190, 138, 62, 157 }, new byte[] { 213, 25, 160, 39, 81, 39, 123, 206, 88, 33, 183, 223, 193, 122, 229, 120, 123, 56, 116, 186, 18, 17, 220, 49, 96, 129, 187, 19, 130, 144, 116, 214, 236, 182, 204, 124, 113, 29, 38, 90, 124, 85, 19, 98, 236, 111, 85, 226, 211, 86, 243, 80, 88, 129, 53, 95, 132, 200, 53, 98, 31, 122, 73, 168, 149, 170, 168, 34, 164, 108, 33, 105, 15, 13, 246, 121, 14, 218, 98, 129, 124, 145, 105, 38, 61, 137, 34, 189, 132, 173, 138, 120, 50, 33, 20, 143, 113, 65, 44, 43, 203, 184, 138, 22, 205, 160, 197, 177, 14, 26, 232, 182, 60, 9, 26, 114, 176, 222, 25, 0, 99, 77, 239, 135, 229, 14, 57, 110 }, "+905578901234", null }
                });

            migrationBuilder.InsertData(
                table: "WorkingTimes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "EndBreakTime", "EndTime", "StartBreakTime", "StartTime", "UpdatedDate" },
                values: new object[] { 1, null, null, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 8, 30, 0, 0), null });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6045), null, null });

            migrationBuilder.InsertData(
                table: "OfficeLocations",
                columns: new[] { "Id", "BlockId", "CreatedDate", "DeletedDate", "FloorId", "RoomId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, null, null, 1, 1, null },
                    { 2, 1, null, null, 1, 2, null },
                    { 3, 1, null, null, 2, 3, null },
                    { 4, 1, null, null, 2, 4, null },
                    { 5, 1, null, null, 2, 5, null },
                    { 6, 2, null, null, 1, 6, null },
                    { 7, 2, null, null, 1, 7, null },
                    { 8, 3, null, null, 1, 10, null },
                    { 9, 3, null, null, 1, 11, null }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "BloodType", "EmergencyContact", "FeedbackId" },
                values: new object[,]
                {
                    { 1, null, null, null },
                    { 2, null, null, null },
                    { 3, null, null, null },
                    { 4, null, null, null },
                    { 5, null, null, null },
                    { 6, null, null, null },
                    { 7, null, null, null },
                    { 8, null, null, null },
                    { 9, null, null, null },
                    { 10, null, null, null },
                    { 11, null, null, null },
                    { 12, null, null, null },
                    { 13, null, null, null },
                    { 14, null, null, null },
                    { 15, null, null, null },
                    { 16, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, 1, null, 1 },
                    { 2, null, null, 4, null, 1 },
                    { 3, null, null, 1, null, 2 },
                    { 4, null, null, 2, null, 2 },
                    { 5, null, null, 1, null, 3 },
                    { 6, null, null, 1, null, 4 },
                    { 7, null, null, 2, null, 4 },
                    { 8, null, null, 1, null, 5 },
                    { 9, null, null, 2, null, 5 },
                    { 10, null, null, 1, null, 6 },
                    { 11, null, null, 2, null, 6 },
                    { 12, null, null, 1, null, 7 },
                    { 13, null, null, 2, null, 7 },
                    { 14, null, null, 1, null, 8 },
                    { 15, null, null, 2, null, 8 },
                    { 16, null, null, 1, null, 9 },
                    { 17, null, null, 1, null, 10 },
                    { 18, null, null, 1, null, 11 },
                    { 19, null, null, 1, null, 12 },
                    { 20, null, null, 1, null, 13 },
                    { 21, null, null, 1, null, 14 },
                    { 22, null, null, 2, null, 14 },
                    { 23, null, null, 1, null, 15 },
                    { 24, null, null, 2, null, 15 },
                    { 25, null, null, 1, null, 16 },
                    { 26, null, null, 2, null, 16 }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "ClinicId", "CreatedDate", "DeletedDate", "OfficeLocationId", "TitleId", "UpdatedDate" },
                values: new object[,]
                {
                    { 2, 17, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6050), null, 1, 1, null },
                    { 4, 1, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6074), null, 2, 2, null },
                    { 5, 3, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6076), null, 3, 3, null },
                    { 6, 5, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6077), null, 4, 4, null },
                    { 7, 7, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6078), null, 5, 5, null },
                    { 8, 9, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6079), null, 6, 6, null },
                    { 14, 3, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6081), null, 7, 2, null },
                    { 15, 3, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6082), null, 8, 3, null },
                    { 16, 3, new DateTime(2024, 7, 21, 2, 21, 22, 196, DateTimeKind.Local).AddTicks(6083), null, 9, 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergyPatient_PatientsId",
                table: "AllergyPatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDurationHistory_ClinicId",
                table: "AppointmentDurationHistory",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorNoWorkHour_DoctorId",
                table: "DoctorNoWorkHour",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorNoWorkHour_NoWorkHourId",
                table: "DoctorNoWorkHour",
                column: "NoWorkHourId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ClinicId",
                table: "Doctors",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_OfficeLocationId",
                table: "Doctors",
                column: "OfficeLocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_TitleId",
                table: "Doctors",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeLocations_BlockId",
                table: "OfficeLocations",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeLocations_FloorId",
                table: "OfficeLocations",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeLocations_RoomId",
                table: "OfficeLocations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_FeedbackId",
                table: "Patients",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_AppointmentId",
                table: "Reports",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AllergyPatient");

            migrationBuilder.DropTable(
                name: "AppointmentDurationHistory");

            migrationBuilder.DropTable(
                name: "DoctorNoWorkHour");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "WorkingTimes");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "NoWorkHours");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "OfficeLocations");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
