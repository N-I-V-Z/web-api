using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyWebAPI.Data;
using MyWebAPI.Models;
using System.Linq;

namespace MyWebAPI.Services
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private readonly MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 3;

        public HangHoaRepository(MyDbContext context)
        {
            _context = context;
        }
        public List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page)
        {
            var allProducts = _context.HangHoas.Include(hh => hh.Loai).AsQueryable();

            #region Filter
            if (!search.IsNullOrEmpty())
            {
                allProducts = allProducts.Where(hh => hh.TenHH.Contains(search));
            }
 
            if (from.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia >= from);
            }
            if (to.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia <= to);
            }
            #endregion

            #region Sort
            //Default sort by Name 
            allProducts = allProducts.OrderBy(hh => hh.TenHH);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "TenHH_DESC": allProducts = allProducts.OrderByDescending(hh => hh.TenHH); break;
                    case "DonGia_DESC": allProducts = allProducts.OrderByDescending(hh => hh.DonGia); break; 
                    case "DonGia_ASC": allProducts = allProducts.OrderBy(hh => hh.DonGia); break; 
                }
            }
            #endregion

            //#region Paging
            //allProducts = allProducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion

            //var result = allProducts.Select(hh => new HangHoaModel
            //{
            //    MaHangHoa = hh.MaHH,
            //    TenHangHoa = hh.TenHH,
            //    DonGia = hh.DonGia,
            //    TenLoai = hh.Loai.TenLoai
            //});
            //return result.ToList();

            var result = PaginatedList<Data.HangHoa>.Create(allProducts, page, PAGE_SIZE);

            return result.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHH,
                TenHangHoa = hh.TenHH,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai?.TenLoai
            }).ToList();
        }

    }
}
