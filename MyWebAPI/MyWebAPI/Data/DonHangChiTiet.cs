﻿namespace MyWebAPI.Data
{
    public class DonHangChiTiet
    {
        public Guid MaHH { get; set; }
        public Guid MaDH { get; set; }
        public int SoLuong { get; set; }
        public byte GiamGia { get; set; }

        //relationship
        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }
    }
}
