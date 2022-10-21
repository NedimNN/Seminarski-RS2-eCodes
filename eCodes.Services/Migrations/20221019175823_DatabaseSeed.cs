using Microsoft.EntityFrameworkCore.Migrations;
using System.Data;
using System.Reflection;

#nullable disable

namespace eCodes.Services.Migrations
{
    public partial class DatabaseSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = typeof(DatabaseSeed).Namespace + ".20221019175823_DatabaseSeed.sql";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string sqlResult = reader.ReadToEnd();
                    migrationBuilder.Sql(sqlResult);
                }
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
