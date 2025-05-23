using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.data;
using api.Mappers;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StockController(ApplicationDBContext context){
            _context = context;
       }

       [HttpGet]
       public  IActionResult GetStocks(){
        var stocks = _context.Stocks.ToList().Select(s=>s.ToStockDto());
        return Ok(stocks);
       }

       [HttpGet("{id}")]

       public IActionResult GetStockById([FromRoute] int id){
        var stock = _context.Stocks.Find(id);
        if(stock == null){
            return NotFound();
        }
        return Ok(stock.ToStockDto());
       }
    }}
