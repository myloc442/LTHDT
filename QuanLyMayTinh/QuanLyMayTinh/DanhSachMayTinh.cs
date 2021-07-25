using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Để đọc file

namespace QuanLyMayTinh
{
    class DanhSachMayTinh
    {
        List<MayTinh> collection = new List<MayTinh>();

        // Hàm đọc file
        public void DocTuFile()
        {
            string path = @"Data.txt";
            StreamReader sr = new StreamReader(path);
            string str = "";
            while ((str = sr.ReadLine()) != null)
            {
                // Nó đọc 1 vào dòng -> dòng đó sẽ 1 máy tính
                // str = "CPU, Intel, 3500000 | RAM, Consair, 2000000"
                collection.Add(new MayTinh(str));
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

        // ===== Tìm máy tính có giá rẻ nhất ===== 
        public List<MayTinh> TimMayTinhCoGiaReNhat()
        {
            int min = collection.Min(item => item.GiaMayTinh);
            return collection.FindAll(item => item.GiaMayTinh == min);
        }

        // ===== Tìm máy tính có CPU có giá rẻ nhất =====
        public List<MayTinh> TimMayTinhCoGiaCPUReNhat()
        {
            int min = collection.Min(item => item.GiaThietBiThapNhat());
            return collection.FindAll(item => item.GiaThietBiThapNhat() == min);
        }
    }
}
