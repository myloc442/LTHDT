using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiDeOOP2020
{
    class NhanVienBanThoiGian : NhanVien
    {
        // ======= Fields =======
        private int _soGioLamVien;
        private int _donGia = ViewHelp.DON_GIA_NV_BAN_THOI_GIAN;

        // ======= Property =======
        public int SoGioLamViec { get => _soGioLamVien; set => _soGioLamVien = value; }

        // ======= Phương thức khỏi tạo =======
        public NhanVienBanThoiGian(string line) : base(line)
        {
            Loai = "Bán thời gian";
            // TG, Tran Thi Ngoc Anh, 26/3/2002, 5, 240
            string[] str = line.Split(',');
            SoGioLamViec = int.Parse(str[4]);
        }

        // ======= Phương thức =======
        public override int TinhLuong()
        {
            return SoGioLamViec * _donGia;
        }

        public override string ToString()
        {
            return base.ToString()
                + $" - {SoGioLamViec} giờ";
        }
    }
}
