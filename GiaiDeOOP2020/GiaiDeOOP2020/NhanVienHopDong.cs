using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiDeOOP2020
{
    class NhanVienHopDong : NhanVien
    {
        // ======= Fields =======
        private int _soNgayLamViec;
        private int _donGia = ViewHelp.DON_GIA_NV_HOP_DONG;

        // ======= Property =======
        public int SoNgayLamViec { get => _soNgayLamViec; set => _soNgayLamViec = value; }

        // ======= Phương thức khỏi tạo =======
        public NhanVienHopDong(string line) : base(line)
        {
            Loai = "Hợp đồng";
            // HD, Tran Nhat Duat, 2/9/2002, 7, 30
            string[] str = line.Split(',');
            SoNgayLamViec = int.Parse(str[4]);
        }

        // ======= Phương thức =======
        public override int TinhLuong()
        {
            return SoNgayLamViec * _donGia;
        }

        public override string ToString()
        {
            return base.ToString()
               + $" - {SoNgayLamViec} ngày";
        }
    }
}
