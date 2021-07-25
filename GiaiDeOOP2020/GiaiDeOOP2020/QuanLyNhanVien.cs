using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GiaiDeOOP2020
{
    class QuanLyNhanVien : IComparer<NhanVien>
    {
        List<NhanVien> collection = new List<NhanVien>();
        KieuSapXep kieu;

        public void DocTuFile()
        {
            string path = @"Data.txt";
            StreamReader sr = new StreamReader(path);
            string str = "";
            while ((str = sr.ReadLine()) != null)
            {
                string[] data = str.Split(',');
                if (data[0].Contains("TG"))
                    collection.Add(new NhanVienBanThoiGian(str));
                if (data[0].Contains("HD"))
                    collection.Add(new NhanVienHopDong(str));
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (var item in collection)
            {
                str += item + "\n";
            }
            return str;
        }

        public List<NhanVien> TimDanhSachNhanVienBanThoiGianTheoThang(int thang)
        {
            return collection.Where(item => item is NhanVienBanThoiGian && item.Thang == thang).ToList();
        }

        public List<NhanVien> Cau2_TimNhanVienBanThoiGianCoSoGioLamViecItNhatTheoMotThangNaoDo(int thang)
        {
            List<NhanVien> result = TimDanhSachNhanVienBanThoiGianTheoThang(thang);
            int min = result.Min(item => ((NhanVienBanThoiGian)item).SoGioLamViec);
            return result.Where(item => item.Thang == thang && ((NhanVienBanThoiGian)item).SoGioLamViec == min).ToList();
        }

        public int TinhLuongPhaiTraChoNhanVienBanThoiGianTheoThang(int thang)
        {
            return collection.Where(item => item is NhanVienBanThoiGian && item.Thang == thang).Sum(item => item.TinhLuong());
        }

        public List<int> TinhLuongPhaiTraChoNhanVienBanThoiGianAllThang()
        {
            List<int> result = new List<int>();
            foreach (var item in collection)
            {
                if (item is NhanVienBanThoiGian)
                    result.Add(TinhLuongPhaiTraChoNhanVienBanThoiGianTheoThang(item.Thang));
            }
            return result;
        }

        public List<int> Cau3_TimThangTraLuongChoNhanVienBanThoiGianThapNhat()
        {
            int min = TinhLuongPhaiTraChoNhanVienBanThoiGianAllThang().Min();
            var result = from p in collection
                         where p is NhanVienBanThoiGian && TinhLuongPhaiTraChoNhanVienBanThoiGianTheoThang(p.Thang) == min
                         select p.Thang;
            return result.Distinct().ToList();
        }

        public int DemSLNhanVienBanThoiGianLamViecTheoThang(int thang)
        {
            return collection.Where(item => item is NhanVienBanThoiGian && item.Thang == thang).Count();
        }

        public List<int> DemSLNhanVienBanThoiGianChoAllThang()
        {
            List<int> result = new List<int>();
            foreach (var item in collection)
            {
                if (item is NhanVienBanThoiGian)
                    result.Add(DemSLNhanVienBanThoiGianLamViecTheoThang(item.Thang));
            }
            return result;
        }

        public List<int> Cau4_TimThangCoNhanVienBanThoiGianLamViecItNhat()
        {
            int min = DemSLNhanVienBanThoiGianChoAllThang().Min();
            var result = from p in collection
                         where p is NhanVienBanThoiGian && DemSLNhanVienBanThoiGianLamViecTheoThang(p.Thang) == min
                         select p.Thang;
            return result.Distinct().ToList();
        }

        public List<int> Cau5_TimThangKhongCoNhanVienBanThoiGian()
        {
            List<int> Thang = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<int> result = new List<int>();
            foreach (var item in Thang)
            {
                if (DemSLNhanVienBanThoiGianLamViecTheoThang(item) == 0)
                    result.Add(item);
            }
            return result;
        }

        public int DemSoLuongNhanVienTheoThangVaNgaySinh(int thang, DateTime ntns)
        {
            int count = 0;
            foreach (var item in collection)
            {
                if (item.Thang == thang && DateTime.Compare(ntns, item.NgayThangNamSinh) == 0)
                    count++;
            }
            return count;
        }

        public List<int> DemSoLuongNhanVienTheoAllThangVaNgaySinh()
        {
            List<int> result = new List<int>();
            foreach (var item in collection)
            {
                result.Add(DemSoLuongNhanVienTheoThangVaNgaySinh(item.Thang, item.NgayThangNamSinh));
            }
            return result;
        }

        public List<int> Cau6_TimThangCoNhieuNhanVienCoCungNgaySinhNhat()
        {
            int max = DemSoLuongNhanVienTheoAllThangVaNgaySinh().Max();
            var result = from p in collection
                         where DemSoLuongNhanVienTheoThangVaNgaySinh(p.Thang, p.NgayThangNamSinh) == max
                         select p.Thang;
            return result.Distinct().ToList();
        }

        public List<NhanVien> LayDanhSachNhanVien<T>()
        {
            return collection.Where(item => item is T).ToList();
        }

        public bool KiemTraNhanVienHopDongCoCungNgaySinh(DateTime ntns)
        {
            List<NhanVien> ds = LayDanhSachNhanVien<NhanVienHopDong>();
            int count = 0;
            foreach (var item in ds)
            {
                if (item is NhanVienHopDong && DateTime.Compare(ntns, item.NgayThangNamSinh) == 0)
                {
                    count++;
                    if (count > 1)
                        return true;
                }
            }
            return false;
        }

        public IEnumerable<IGrouping<DateTime, NhanVien>> Cau7_TimNhanVienHopDongCoCungNgaySinh()
        {
            var result = from p in collection
                         where p is NhanVienHopDong && KiemTraNhanVienHopDongCoCungNgaySinh(p.NgayThangNamSinh)
                         select p;
            return result.GroupBy(item => item.NgayThangNamSinh);
        }

        public int Compare(NhanVien x, NhanVien y)
        {
            if (kieu == KieuSapXep.TangDanTheoHo)
                return x.Ho.CompareTo(y.Ho);
            if (kieu == KieuSapXep.TangDanTheoTenDem)
                return x.TenLot.CompareTo(y.TenLot);
            if (kieu == KieuSapXep.TangDanTheoTen)
                return x.Ten.CompareTo(y.Ten);
            return 0;
        }

        public void Cau8_SortTheoEnum(KieuSapXep kieu)
        {
            this.kieu = kieu;
            collection.Sort(this);
        }


    }
}