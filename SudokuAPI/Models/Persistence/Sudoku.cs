using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SudokuAPI.Models.Persistence
{
    public class Sudoku
    {
        

        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Notes { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Board { get; set; }



        [NotMapped]
        public BoardNumbers _Board
        {
            get { return Board == null ? null : JsonConvert.DeserializeObject<BoardNumbers>(Board); }
            set { Board = JsonConvert.SerializeObject(value); }
        }

    }
}