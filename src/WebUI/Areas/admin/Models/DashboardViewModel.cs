using System.Collections.Generic;
using Domain.Entities;

namespace WebUI.Areas.admin.Models
{
    public class DashboardViewModel
    {
        public int Produkte { get; set; }
        public decimal Porosi { get; set; }
        public decimal Mesatarja { get; set; }
        public int Konsumator { get; set; }
        public List<Order> Orders { get; set; }
    }
}