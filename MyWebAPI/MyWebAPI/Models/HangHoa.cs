﻿namespace MyWebAPI.Models
{
    public class HangHoaVM
    {
        public String TenHangHoa { get; set; }
        public double DonGia { get; set; }
    }

    public class HangHoa : HangHoaVM
    {
        public Guid MaHangHoa { get; set; }
    }

    public class HangHoaModel
    {
        public Guid MaHangHoa { get; set; }
        public String TenHangHoa { get; set; }
        public double DonGia { get; set; }
        public string TenLoai { get; set; }
    }
}
