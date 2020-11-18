using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaMo.ViewModels
{
    public class DetailDk
    {
        public int id { get; set; }
        public string ten { get; set; }
        public string hinhAnh { get; set; }
        public decimal tien { get; set; }
        public string loai { get; set; }

        public DateTime NgayTao { get; set; }

        public string NgayTaoString { get; set; }
    }
}