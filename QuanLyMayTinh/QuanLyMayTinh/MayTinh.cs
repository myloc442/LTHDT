using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMayTinh
{
    class MayTinh
    {
        List<ThietBi> collection = new List<ThietBi>();
        public int GiaMayTinh { get => TinhTongThietBi(); }
        public MayTinh(string line)
        {
            // line = "CPU, Intel, 3500000 | RAM, Consair, 2000000"
            // line chứa thông tin của cpu với ram
            // cần tách riêng ram-> class ram  -  tách cpu riêng ra cho dô class cpu
            string[] data = line.Split('|');
            foreach (var item in data)
            {
                if (item.Contains("CPU"))
                    collection.Add(new Cpu(item));
                else if (item.Contains("RAM"))
                    collection.Add(new Ram(item));
            }
        }
        public override string ToString()
        {
            string str = "\n ----- Thông tin máy tính ----- \n";
            foreach (var item in collection)
            {
                str += item + "\n";
            }
            str = str + $" -> Tổng giá: {GiaMayTinh}";
            return str;
        }

        // ===== Tính tổng máy tính =====
        private int TinhTongThietBi() => collection.Sum(item => item.Gia);

        public List<int> GiaThietBi<T>()
        {
            var result = from p in collection
                         where p is T
                         select p.Gia;
            return result.ToList();
        }
        
        // ===== Tìm giá CPU rẻ nhất =====
        public int GiaThietBiThapNhat()
        {
            var result = GiaThietBi<Cpu>();
            return result.Min();
        }
    }
}
