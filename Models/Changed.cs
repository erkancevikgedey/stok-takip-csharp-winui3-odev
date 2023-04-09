using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Models
{
    public enum Action
    {
        Edit,
        StockUp,
        StockDown,
        Delete,
        AddBulk,
        AddStock
    }
    public class Changed
    {
        public int Id { get; set; }
        public Action ActionName { get; set; }
        public DateTime ActionTime { get; set; }
    }
}
