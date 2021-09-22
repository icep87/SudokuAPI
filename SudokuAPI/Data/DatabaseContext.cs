using System;
using SudokuAPI.Models.Persistence;
using Microsoft.EntityFrameworkCore;
namespace SudokuAPI.Data
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Sudoku> Sudokus { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add the different category levels
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Super Easy" },
                new Category { Id = 2, Name = "Easy" },
                new Category { Id = 3, Name = "Intermediate" },
                new Category { Id = 4, Name = "Hard" },
                new Category { Id = 5, Name = "Extreme" }
            );

            modelBuilder.Entity<Sudoku>().HasData(new Sudoku[]
            {
                new Sudoku { Id = 1, CategoryId = 1, Board = "{BoardNumber:[[9, \"\", 4, 2, 8, 6, 1, 3, 5],[6, 2, 8, 3, 5, 1, 7, 4, 9],[3, 1, 5, 7, 9, 4, 6, 8, 2],[2, 5, 6, 9, 1, 8, 4, 7, 3],[4, 3, 9, 6, 7, 5, 2, 1, 8],[7, 8, 1, 4, 3, 2, 5, 9, 6],[5, 6, 7, 8, 4, 3, 9, 2, 1],[1, 4, 3, 5, 2, 9, 8, 6, 7],[8, 9, 2, 1, 6, 7, 3, 5, \"\"]]}"},
                new Sudoku { Id = 2, CategoryId = 2, Board = "{BoardNumber:[[5, 6, \"\", 1, \"\", 9, \"\", 7, 8],[4, \"\", \"\", 5, \"\", \"\", 3, \"\", 2],[2, 9, \"\", 3, \"\", \"\", \"\", 1, \"\"],[\"\", 4, 6, \"\", 8, 5, 9, 2, 3],[9, 5, 7, \"\", 3, \"\", \"\", 4, 1],[\"\", 3, \"\", 4, \"\", \"\", 7, \"\", \"\"],[\"\", 2, \"\", 8, 5, 7, \"\", \"\", \"\"],[\"\", \"\", \"\", \"\", 4, \"\", 6, \"\", \"\"],[3, \"\", 4, \"\", 1, \"\", 2, \"\", \"\"]]}"},
                new Sudoku { Id = 3, CategoryId = 3, Board = "{BoardNumber:[[1, 2, 3, \"\", \"\", \"\", \"\", 9, \"\"],[\"\", \"\", 7, 9, \"\", \"\", 4, \"\", 6],[\"\", 6, 4, \"\", 5, \"\", \"\", 7, \"\"],[7, \"\", 1, 8, \"\", \"\", 9, \"\", \"\"],[\"\", \"\", \"\", \"\", \"\", \"\", 6, 3, \"\"],[\"\", 8, \"\", \"\", 2, \"\", \"\", 4, \"\"],[5, \"\", \"\", 4, 6, 9, 3, \"\", \"\"],[4, \"\", \"\", \"\", 8, 7, \"\", 2, \"\"],[3, \"\", \"\", \"\", \"\", \"\", 7, 6, \"\"]]}"},
                new Sudoku { Id = 4, CategoryId = 4, Board = "{BoardNumber:[[\"\", 5, \"\", \"\", 1, \"\", \"\", \"\", 3],[\"\", 7, \"\", \"\", 2, \"\", 8, \"\", \"\"],[\"\", \"\", \"\", 9, 7, \"\", \"\", \"\", 4],[\"\", 2, \"\", \"\", \"\", \"\", 1, \"\", \"\"],[8, \"\", \"\", 4, \"\", \"\", 3, \"\", \"\"],[\"\", \"\", \"\", \"\", \"\", \"\", 5, \"\", \"\"],[\"\", \"\", \"\", \"\", 5, \"\", 4, 8, 6],[9, \"\", 3, \"\", \"\", \"\", 7, 1, \"\"],[4, \"\", \"\", 1, \"\", \"\", \"\", 3, \"\"]]}"},
            });
        }
    }
}
