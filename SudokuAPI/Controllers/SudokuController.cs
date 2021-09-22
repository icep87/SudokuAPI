using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SudokuAPI.Data;
using SudokuAPI.Models.Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SudokuAPI.Controllers
{
    [Route("api/[controller]")]
    public class SudokuController : Controller
    {
        private readonly DatabaseContext _context;

        public SudokuController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sudoku>>> GetSudoku([FromQuery] int level = 0)
        {
            if (level == 0)
            {
                return await _context.Sudokus.ToListAsync();
            }

            // TODO: Add a function to return random row
            return await _context.Sudokus.Where(s => s.Id == level).ToListAsync();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            JArray board = new JArray();
            JArray row = new JArray();
            row.Add(5);
            row.Add(6);
            row.Add("");
            row.Add(1);
            row.Add("");
            row.Add(9);
            row.Add("");
            row.Add(7);           
            row.Add(8);

            board.Add(row);


            return  JsonConvert.SerializeObject(board);

            //return JsonConvert.DeserializeObject<string>(@"['', 5, '', '', 1   '', '', '', 3]");

        }


    }
}