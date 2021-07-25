using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMayTinh
{
    class Menu
    {
        public static void ChayChuongTrinh()
        {
            bool kt = false;
            DanhSachMayTinh ds = new DanhSachMayTinh();
            while (true)
            {
                Console.Clear();
                // Hien thi menu
                Console.WriteLine(" =========================== QUẢN LÝ MÁY TÍNH =========================== ");
                Console.WriteLine("0. Thoát khỏi chương trình");
                Console.WriteLine("1. Nhập dữ liệu cho chương trình");
                Console.WriteLine("2. Xem dữ liệu danh sách");
                Console.WriteLine("3. Tìm máy tính có giá cao nhất");
                Console.WriteLine("4. Tìm máy tính có giá CPU rẻ nhất");
                Console.WriteLine("5. Tìm máy tính có giá CPU cao nhất");
                Console.WriteLine("6. Tìm máy tính có giá RAM rẻ nhất");
                Console.WriteLine("7. Tìm máy tính có giá RAM cao nhất");
                Console.WriteLine("8. Tìm hãng có nhiều CPU sử dụng nhất");
                Console.WriteLine("9. Tìm hãng có ít CPU sử dụng nhất");
                Console.WriteLine("10. Tìm hãng có nhiều RAM sử dụng nhất");
                Console.WriteLine("11. Tìm hãng có ít RAM sử dụng nhất");
                Console.WriteLine("12. Sắp xếp tăng dần theo số lượng thiết bị");
                Console.WriteLine("13. Sắp xếp giảm dần theo số lượng thiết bị");
                Console.WriteLine("=========================================================================");
                // Chon menu
                ViewHelp.Write("Nhập tùy chọn: ", ConsoleColor.Green);
                ThucDon tuyChon = (ThucDon)int.Parse(Console.ReadLine());
                // Xu ly
                switch (tuyChon)
                {
                    case ThucDon.Thoat:
                        return;
                    case ThucDon.NhapFile:
                        if (!kt)
                        {
                            ds.DocTuFile();
                            Console.WriteLine("Nhap file thanh cong!");
                            kt = true;
                        }
                        else
                            Console.WriteLine("Du lieu da duoc nhap!");
                        break;
                    case ThucDon.Xuat:
                        Console.WriteLine(ds);
                        break;
                    case ThucDon.TimMayTinhCoGiaReNhat:
                        Console.WriteLine("May tinh co gia cao nhat la: ");
                        var newList = ds.TimMayTinhCoGiaCaoNhat();
                        newList.ForEach(item => Console.WriteLine(item));
                        break;
                    case ThucDon.TimMayTinhCoGiaCPUReNhat:
                        Console.WriteLine("May tinh co gia CPU re nhat la: ");
                        newList = ds.TimMayTinhCoGiaReNhat<CPU>();
                        newList.ForEach(item => Console.WriteLine(item));
                        break;
                    case ThucDon.TimMayTinhCoGiaCPUCaoNhat:
                        Console.WriteLine("May tinh co gia CPU cao nhat la: ");
                        newList = ds.TimMayTinhCoGiaCaoNhat<CPU>();
                        newList.ForEach(item => Console.WriteLine(item));
                        break;
                    case ThucDon.TimMayTinhCoGiaRAMReNhat:
                        Console.WriteLine("May tinh co gia RAM re nhat la: ");
                        newList = ds.TimMayTinhCoGiaReNhat<RAM>();
                        newList.ForEach(item => Console.WriteLine(item));
                        break;
                    case ThucDon.TimMayTinhCoGiaRAMCaoNhat:
                        Console.WriteLine("May tinh co gia RAM cao nhat la: ");
                        newList = ds.TimMayTinhCoGiaCaoNhat<RAM>();
                        newList.ForEach(item => Console.WriteLine(item));
                        break;
                    case ThucDon.TimHangCoNhieuCPUSuDungNhat:
                        break;
                    case ThucDon.TimHangCoItCPUSuDungNhat:
                        break;
                    case ThucDon.TimHangCoNhieuRAMSuDungNhat:
                        break;
                    case ThucDon.TimHangCoItRAMSuDungNhat:
                        break;
                    case ThucDon.SapXepTangTheoSoLuongThietBi:
                        Console.WriteLine("Danh sach truoc khi sap xep: \n" + ds);
                        ds.Sort(SapXep.TangTheoSoLuongThietBi);
                        Console.WriteLine("Danh sach sau khi sap xep tang: \n" + ds);
                        break;
                    case ThucDon.SapXepGiammTheoSoLuongThietBi:
                        Console.WriteLine("Danh sach truoc khi sap xep: \n" + ds);
                        ds.Sort(SapXep.GiamTheoSoLuongThietBi);
                        Console.WriteLine("Danh sach sau khi sap xep giam: \n" + ds);
                        break;
                    default:
                        break;
                }
                ViewHelp.WriteLine("Press one key to coutinue . . .", ConsoleColor.Red);
                Console.ReadKey();
            }
        }
    }
}
