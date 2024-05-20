using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public interface ICSVExporter
    {
        void ExportCSV(
            AdvertisementStatistics statisctics,
            bool impressionsChecked,
            bool clicksChecked,
            bool buysChecked,
            bool ctrChecked,
            bool timeChecked,
            string outputPath,
            string emailRecipient);
    }
}
