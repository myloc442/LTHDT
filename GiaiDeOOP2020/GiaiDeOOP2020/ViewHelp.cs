using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiDeOOP2020
{
    class ViewHelp
    {
        public const int DON_GIA_NV_HOP_DONG = 300000;
        public const int DON_GIA_NV_BAN_THOI_GIAN = 25000;

        public static void ChayChuongTrinh()
        {
            QuanLyNhanVien ds = new QuanLyNhanVien();
            bool kt = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" -------------------------------------------- MENU CHỨC NĂNG -------------------------------------------- ");
                Console.WriteLine("1. Đọc dữ liệu từ file");
                Console.WriteLine("2. Tìm nhân viên bán thời gian có số giờ làm việc ít nhất theo một tháng nào đó");
                Console.WriteLine("4. Tìm tháng có số nhân viên bán thời gian làm việc ít nhất");
                Console.WriteLine("5. Tìm tháng không có nhân viên bán thời gian làm việc");
                Console.WriteLine("6. Tìm tháng có nhiều nhân viên có cùng ngày sinh nhất");
                Console.WriteLine("7. Tìm danh sách nhân viên hợp đồng có cùng ngày sinh nhất");
                Console.WriteLine("8. Sắp xếp tăng dần");
                Console.WriteLine("9. Thưởng cho mỗi nhân viên bán thời gian số giờ làm việc là 30 giờ trong tháng 5 lưu lại dữ liệu vào file");
                Console.WriteLine(" -------------------------------------------------------------------------------------------------------- ");

                Console.Write("Nhập vào tùy chọn (0->9): ");
                Menu tuyChon = (Menu)int.Parse(Console.ReadLine());

                switch (tuyChon)
                {
                    case Menu.DocDuLieuTuFile:
                        {
                            if (!kt)
                            {
                                ds.DocTuFile();
                                Console.WriteLine("Nhập file thành công!");
                                Console.WriteLine("Danh sách nhân viên\n" + ds);
                                kt = true;
                            }
                            else
                            {
                                Console.WriteLine("Dữ liệu đã được nhập!");
                            }
                            break;
                        }
                    case Menu.TimNhanVienBanHangCoThoiGianLamViecItNhatTheoMotThang:
                        {
                            Console.WriteLine("Danh sách nhân viên\n" + ds);
                            Console.Write("Nhập số tháng muốn tìm: ");
                            int thang = int.Parse(Console.ReadLine());
                            var result = ds.Cau2_TimNhanVienBanThoiGianCoSoGioLamViecItNhatTheoMotThangNaoDo(thang);
                            result.ForEach(item => Console.WriteLine(item));
                            break;
                        }
                    case Menu.TimThangTraLuongChoNhanVienBanThoiGianItNhat:
                        {
                            Console.WriteLine("Danh sách nhân viên\n" + ds);
                            Console.Write("Tháng trả lương cho nhân viên bán thời gian ít nhất là: ");
                            var result = ds.Cau3_TimThangTraLuongChoNhanVienBanThoiGianThapNhat();
                            result.ForEach(item => Console.Write(item + "\t"));
                            Console.WriteLine();
                            break;
                        }
                    case Menu.TimThangCoSoNhanVienBanThoiGianLamViecItNhat:
                        {
                            Console.WriteLine(ds.DemSLNhanVienBanThoiGianLamViecTheoThang(5));
                            break;
                        }
                    case Menu.TimThangKhongCoNhanVienBanThoiGianLamViec:
                        {
                            var result = ds.Cau5_TimThangKhongCoNhanVienBanThoiGian();
                            result.ForEach(item => Console.WriteLine(item));
                            break;
                        }
                    case Menu.TimThangCoNhieuNhanVienCoCungNgaySinhNhat:
                        {
                            var kq = ds.Cau6_TimThangCoNhieuNhanVienCoCungNgaySinhNhat();
                            kq.ForEach(item => Console.WriteLine(item));
                            break;
                        }
                    case Menu.TimDanhSachNhanVienHopDongCoCungNgaySinh:
                        {
                            var result = ds.Cau7_TimNhanVienHopDongCoCungNgaySinh();
                            foreach (var group in result)
                            {
                                Console.WriteLine("\nNgày sinh nhật: " + group.Key.ToShortDateString());
                                foreach (var item in group)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                            break;
                        }
                    case Menu.SapXep:
                        {
                            Console.WriteLine("\t\t\tSẮP XẾP TĂNG THEO HỌ");
                            ds.Cau8_SortTheoEnum(KieuSapXep.TangDanTheoHo);
                            Console.WriteLine(ds + "\n\n");
                            Console.WriteLine("\t\t\tSẮP XẾP TĂNG THEO HỌ LÓT");
                            ds.Cau8_SortTheoEnum(KieuSapXep.TangDanTheoTenDem);
                            Console.WriteLine(ds + "\n\n");
                            Console.WriteLine("\t\t\tSẮP XẾP TĂNG THEO TÊN");
                            ds.Cau8_SortTheoEnum(KieuSapXep.TangDanTheoTen);
                            Console.WriteLine(ds + "\n\n");
                            break;
                        }
                    case Menu.ThuongChoNhanVienBanThoiGianCoSoLamViecLa30TrongThang5:
                        break;
                    case Menu.Thoat:
                        {
                            return;
                        }
                    default:
                        break;
                }
                Console.Write("Nhấn một phím bất kì để tiếp tục . . .");
                Console.ReadKey();
            }
        }
    }
}
