using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMayTinh
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DanhSachMayTinh ds = new DanhSachMayTinh();
            ds.DocTuFile();
            Console.WriteLine(ds);
            Console.WriteLine("Danh sách máy tính có giá CPU rẻ nhất: ");
            var newList = ds.TimMayTinhCoGiaCPUReNhat();
            newList.ForEach(item => Console.WriteLine(item));
            Console.ReadLine();
        }
    }
}
