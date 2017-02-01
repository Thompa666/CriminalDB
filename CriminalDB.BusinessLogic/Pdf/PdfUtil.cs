using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using CriminalDB.DomainModels;
using System.Configuration;
using System.Diagnostics;

namespace CriminalDB.Service.Pdf
{
    public class PdfUtil
    {
        private int pageHeight = 842;
        private int pageWidth = 595;
        private int verticalMargin = 72;
        private int horizontalMargin = 36;

        private BaseFont boldMainFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, true);
        private BaseFont normalMainFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);

        private string folderPath = string.Empty;
        private Document doc;
        private PdfContentByte cb;
        private int headerStartYoffSet;
        private int firstBlockXoffset;
        

        public PdfUtil(string _folderPath)
        {
            folderPath = _folderPath;

        }

        public List<string> GenerateAllPdfFiles(List<Result> results)
        {
            List<string> files = new List<string>();
            foreach (var item in results)
            {
                var file = GeneratePdf(item);
                if (!string.IsNullOrEmpty(file))
                    files.Add(file);
            }
            return files;
        }


        private string GeneratePdf(Result record)
        {
            doc = new Document(PageSize.A4);
            string fileSavePath = folderPath + "\\" + DateTime.Now.Ticks + ".pdf";
            var writer = PdfWriter.GetInstance(doc, new FileStream(fileSavePath, FileMode.Create));
            try
            {

                doc.Open();

                cb = writer.DirectContent;
                cb.SetColorFill(BaseColor.BLACK);
                ResetOffsets();

                StartPrint(record);
            }
            catch(Exception e)
            {
                fileSavePath = null;
                Trace.TraceError(e.Message);
            }
            finally
            {
                doc.Close();
            }

            return fileSavePath;
        }
        
        private void StartPrint(Result record)
        {
            PrintHeader(record);
            PrintVerticalSpace();
            PrintHorizontalLine();
            PrintVerticalSpace();
            PrintRecord(record.Offender);
        }

        private void PrintHeader(Result record)
        {
            try
            {
                cb.BeginText();

                AddNewHeaderRow("National Criminal Database Search Result");
                PrintVerticalSpace();
                AppendNewRow("Requested By:", record.Requester, 1);
                AppendNewRow("Created On:", record.ReportDate.ToShortDateString(), 1);
                AppendNewRow("Search Query:", record.SearchQuery, 1);
                AppendNewRow("Search Result:", record.ResultID.ToString() + " of " + record.TotalCount.ToString(), 1);
            }
            finally
            {
                cb.EndText();
            }
            
        }
        
        private void PrintRecord(Offender offender)
        {
            try
            {
                cb.BeginText();

                AppendNewRow("First Name:", offender.FirstName, 1);
                AppendNewRow("Last Name:", offender.LastName, 1);
                AppendNewRow("Date of Birth:", offender.DateOfBirth.Value.ToShortDateString(), 1);
                AppendNewRow("Age:", offender.Age.ToString(), 1);
                AppendNewRow("Sex:", offender.Gender == "M" ? "Male" : "Female", 1);
                AppendNewRow("Height:", offender.Height.ToString() + " cm", 1);
                AppendNewRow("Weight:", offender.Weight.ToString() + " kg", 1);
                AppendNewRow("Nationality:", offender.Nationality, 1);
                AppendNewRow("Address:", offender.Address, 1);
                AppendNewRow("No. of Offenses:", offender.Offenses.Count.ToString(), 1);

                int i = 1;
                foreach(var offense in offender.Offenses)
                {
                    PrintSubRecord(offense, i++);

                    //add a new page if not enough space left
                    if (headerStartYoffSet < 150)
                    {
                        cb.EndText();
                        doc.NewPage();
                        cb.BeginText();
                        ResetOffsets();
                    }
                }
            }
            finally
            {
                cb.EndText();
            }
        }
        
        private void PrintSubRecord(Offense record, int id)
        {
            PrintVerticalSpace();
            AppendNewRow("Offense No.:", id.ToString(), 1);
            AppendNewRow("Case Number:", record.CaseNumber, 1);
            AppendNewRow("Offense Code:", record.OffenseCode, 2);
            AppendNewRow("Date of Crime:", record.CrimeDate.Value.ToShortDateString(), 1);
            AppendNewRow("Crime Country:", record.CrimeCountry, 2);
            AppendNewRow("Category:", record.Category, 1);
            AppendNewRow("Degree:", record.Degree, 2);
            AppendNewRow("Disposition:", record.Disposition, 1);
            AppendNewRow("Description:", record.Description, 1);
        }


        #region core functions
        private void ResetOffsets()
        {
            headerStartYoffSet = pageHeight - verticalMargin;
            firstBlockXoffset = horizontalMargin;
        }

        private void AddNewHeaderRow(string value)
        {
            WriteBoldHeaderText(firstBlockXoffset, headerStartYoffSet, value);
        }

        private void AppendNewRow(string key, string value, int column)
        {
            WriteBoldBodyText(firstBlockXoffset + (column - 1) * 200, headerStartYoffSet -= 14, key);
            WriteNormalBodyText(firstBlockXoffset + 100 + (column - 1) * 200, headerStartYoffSet, value);
        }

        private void WriteBoldHeaderText(int x, int y, string text)
        {
            cb.SetFontAndSize(boldMainFont, 14);
            cb.SetTextMatrix(x, y);
            cb.ShowText(text);
        }

        private void WriteBoldBodyText(int x, int y, string text)
        {
            cb.SetFontAndSize(boldMainFont, 9);
            cb.SetTextMatrix(x, y);
            cb.ShowText(text);
        }

        private void WriteNormalBodyText(int x, int y, string text)
        {
            cb.SetFontAndSize(normalMainFont, 9);
            cb.SetTextMatrix(x, y);
            cb.ShowText(text);
        }

        private void PrintVerticalSpace()
        {
            headerStartYoffSet -= 16;
        }

        private void PrintHorizontalLine()
        {
            cb.MoveTo(horizontalMargin, headerStartYoffSet);
            cb.LineTo(pageWidth - horizontalMargin, headerStartYoffSet);
            cb.Stroke();
        }
        #endregion
    }
}