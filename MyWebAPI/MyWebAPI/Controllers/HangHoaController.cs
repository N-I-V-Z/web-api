using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoa = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoa);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(string id)
        {
            //LINQ Query
            try
            {
                var hanghoa = hangHoa.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                    return NotFound();
                return Ok(hanghoa);
            } catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa()
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hangHoa.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hangHoa
            }); ;
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hHEdit)
        {
            try
            {
                var hanghoa = hangHoa.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                    return NotFound();
               
                hanghoa.TenHangHoa = hHEdit.TenHangHoa;
                hanghoa.DonGia = hHEdit.DonGia;
                return Ok(hanghoa);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remote(string id)
        {
            try
            {
                var hanghoa = hangHoa.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                    return NotFound();
                hangHoa.Remove(hanghoa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
