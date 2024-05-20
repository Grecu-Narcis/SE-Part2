using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CsvHelper;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace Backend.Models
{
    public class ExportManager : IPDFExporter, ICSVExporter, IEmailSender
    {
        public void ExportPDF(
            AdvertisementStatistics stats,
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
            bool downloadButtonChecked)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfBrush color = new PdfSolidBrush(System.Drawing.Color.Black);
            int height = 20;
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            if (fontIndex == 1)
            {
                font = font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            }

            if (fontIndex == 2)
            {
                font = font = new PdfStandardFont(PdfFontFamily.Courier, 12);
            }

            try
            {
                float parsedFontSize = fontSize;
            }
            catch
            {
                throw new Exception("Wrong Size Input");
            }

            if (colorIndex == 1)
            {
                color = new PdfSolidBrush(System.Drawing.Color.Gray);
            }

            if (colorIndex == 2)
            {
                color = new PdfSolidBrush(System.Drawing.Color.Red);
            }

            graphics.DrawString("Advertisement Statistics Report", font, color, new PointF((page.Size.Width / 2f) - 100, 10));

            if (impressionsChecked == true)
            {
                graphics.DrawString("\nAmount of Impressions: " + stats.Views.ToString(), font, color, new PointF(10, height));
                height += 20;
            }

            if (clicksChecked == true)
            {
                graphics.DrawString("\nAmount of Clicks: " + stats.Clicks.ToString(), font, color, new PointF(10, height));
                height += 20;
            }

            if (buysChecked == true)
            {
                graphics.DrawString("\nAmount of Purchases: " + stats.Buys.ToString(), font, color, new PointF(10, height));
                height += 20;
            }

            if (timeChecked == true)
            {
                graphics.DrawString("\nTotal Time Viewed: " + stats.Time.ToString(), font, color, new PointF(10, height));
                height += 20;
            }

            if (ctrChecked == true)
            {
                graphics.DrawString("\nClick Through Ratio: " + ((float)(stats.Clicks / stats.Views)).ToString(), font, color, new PointF(10, height));
                height += 20;
            }

            if (dateChecked == true)
            {
                graphics.DrawString("Created on:", font, color, new PointF(20, page.Size.Height - 120));
                graphics.DrawString(DateTime.Now.ToString(), font, color, new PointF(20, page.Size.Height - 100));
            }

            if (signatureChecked == true)
            {
                graphics.DrawString("Signature:", font, color, new PointF(page.Size.Width - 200, page.Size.Height - 120));
                graphics.DrawString(user.Username, font, color, new PointF(page.Size.Width - 200, page.Size.Height - 100));
            }

            if (recipientChecked == true)
            {
                graphics.DrawString("Intended Recipient:", font, color, new PointF((page.Size.Width / 2f) - 50, page.Size.Height - 120));
                graphics.DrawString(recipientInput, font, color, new PointF((page.Size.Width / 2f) - 50, page.Size.Height - 100));
            }

            if (emailButtonChecked == true)
            {
                string outputPath = "C:\\Users\\User\\Downloads\\output.pdf";
                document.Save(outputPath);
                this.SendDocEmailAsync(recipientInput, "C:\\Users\\User\\Downloads\\output.pdf");
            }

            if (downloadButtonChecked == true)
            {
                string outputPath = "C:\\Users\\User\\Downloads\\output.pdf";
                document.Save(outputPath);
            }

            document.Close(true);
        }

        public void ExportCSV(
            AdvertisementStatistics stats,
            bool impressionsChecked,
            bool clicksChecked,
            bool buysChecked,
            bool ctrChecked,
            bool timeChecked,
            string outputPath,
            string emailRecipient)
        {
            using (var writer = new StreamWriter(outputPath))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                List<AdvertisementStatistics> records = new List<AdvertisementStatistics> { stats };

                foreach (var record in records)
                {
                    if (impressionsChecked)
                    {
                        csvWriter.WriteField(record.Views);
                    }

                    if (clicksChecked)
                    {
                        csvWriter.WriteField(record.Clicks);
                    }

                    if (buysChecked)
                    {
                        csvWriter.WriteField(record.Buys);
                    }

                    if (ctrChecked)
                    {
                        csvWriter.WriteField((float)record.Views / record.Clicks);
                    }

                    if (timeChecked)
                    {
                        csvWriter.WriteField(record.Time);
                    }

                    csvWriter.NextRecord();
                }
            }

            if (!string.IsNullOrEmpty(emailRecipient))
            {
                this.SendDocEmailAsync(emailRecipient, outputPath);
            }
        }

        public Task SendDocEmailAsync(string recipient, string filename)
        {
            var senderEmail = "osvathrobert03@gmail.com";
            var password = "daes ndml ukpj qvuj";

            var subject = "Statistics Report";
            var message = "Attached are the requested documents";

            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(senderEmail, password),
                EnableSsl = true,
            };

            var mail = new MailMessage(
                from: senderEmail,
                to: recipient,
                subject: subject,
                body: message);

            mail.Attachments.Add(new Attachment(filename));
            return client.SendMailAsync(mail);
        }
    }
}
