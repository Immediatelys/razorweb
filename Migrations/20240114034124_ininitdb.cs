using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using RazorWeb.Models;

#nullable disable

namespace RazorWeb.Migrations
{
    public partial class ininitdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });

            Randomizer.Seed = new Random(8675309);
            var fakerAricle = new Faker<Article>();

            fakerAricle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5));
            fakerAricle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2021, 4, 20)));
            fakerAricle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 4));

            for(int i = 0; i < 100; i++)
            {
                Article article = fakerAricle.Generate();

                migrationBuilder.InsertData(
                    table: "articles",
                    columns: new[] { "Title", "Created", "Content" },
                    values: new object[]
                    {
                        article.Title,
                        article.Created,
                        article.Content
                    }
                );
            }

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
