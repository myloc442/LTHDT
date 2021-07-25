using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiDeOOP2020
{
    abstract class NhanVien
    {
        // ======= Fields =======
        protected string _hoTen;
        protected DateTime _ngayThangNamSinh;
        protected int _thang;

        // ======= Property =======
        public string HoTen { get => _hoTen; set => _hoTen = value; }
        public int Thang { get => _thang; set => _thang = value; }
        public DateTime NgayThangNamSinh { get => _ngayThangNamSinh; set => _ngayThangNamSinh = value; }
        public string Loai { get; set; } // Phân biệt loại nhân viên

        /* ======= Cắt chuỗi họ và tên thành họ, tên lót, tên ======= */
        public string Ho
        {
            get
            {
                string result = HoTen.Substring(0, _hoTen.IndexOf(' '));
                return result;
            }
        }
        public string TenLot
        {
            get
            {
                string result = HoTen.Substring(HoTen.IndexOf(' ') + 1, HoTen.LastIndexOf(' ') - Ho.Length - 1);
                return result;
            }
        }
        public string Ten
        {
            get
            {
                string result = HoTen.Substring(HoTen.LastIndexOf(' ') + 1);
                return result;
            }
        }

        // ======= Phương thức khỏi tạo =======
        public NhanVien()
        {

        }

        public NhanVien(string line)
        {
            string[] str = line.Split(',');
            HoTen = str[1].Trim();
            NgayThangNamSinh = DateTime.Parse(str[2]);
            Thang = int.Parse(str[3]);
        }

        // ======= Phương thức =======
        public abstract int TinhLuong();
        public override string ToString()
        {
            return $"{Loai} - {HoTen} - {NgayThangNamSinh.ToShortDateString()} - {Thang} - {TinhLuong()}";
        }
    }
}
