using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public interface IPDFExporter
    {
        void ExportPDF(
            AdvertisementStatistics statistics,
            User user,
            int fontSize,
            int fontIndex,
            int colorIndex,
            bool impressionsChecked,
            bool clicksChecked,
            bool buysChecked,
            bool timeChecked,
            bool ctrChecked,
            bool dateChecked,
            bool signatureChecked,
            bool recipientChecked,
            string recipientInput,
            bool emailButtonChecked,
            bool downloadButtonChecked);
    }
}
