using Microsoft.EntityFrameworkCore;
using StokTakip.EntityFramework;
using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services
{
    interface IHistoryService
    {
        string GetHistories();
        void UpdateHistories(Models.Action action);
    }

    public class HistoryService : IHistoryService
    {
        MainContext dbContext = new MainContext();

        public String GetHistories()
        {
            var veri = dbContext.Changed.ToList();
            string metin = "";
            foreach (var row in veri)
            {

                var duzenle = $"Zaman: {row.ActionTime.ToString()} - İşlem: {row.ActionName.ToString()} \n";
                metin = metin + duzenle;

            }
            return metin;
        }

        public void UpdateHistories(Models.Action action)
        {
            var updateDetails = new Changed { ActionName = action, ActionTime = DateTime.Now};
            dbContext.Add(updateDetails);
            dbContext.SaveChanges();
        }
    }
}
