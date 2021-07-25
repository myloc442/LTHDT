using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMayTinh
{
    abstract class ThietBi // class Cha
    {
        // Property
        protected string hang;
        protected int gia;
        
        public string Hang { get => hang; set => hang = value; }
        public string Loai { get; set; }
        public int Gia { get => gia; set => gia = value; }

        // Phương thức khởi tạo
        public ThietBi() { }
        public ThietBi(string line) 
        {
            string[] data = line.Split(',');
            Loai = data[0].Trim();
            Hang = data[1].Trim();
            Gia = int.Parse(data[2]);
        }

        // Phương thức 
        public override string ToString()
        {
            return $"{Loai} - {Hang} - {Gia} đồng";
        }
    }
}
