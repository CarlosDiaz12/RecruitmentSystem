using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Infrastructure.Helper
{
    public class ExportFileResult
    {
        public string FileName { get; set; }
        public byte[] File { get; set; }
    }
    public static class ReportGenerator
    {
        public static ExportFileResult GenerateExcel(string workSheetName,DataTable data, string[] columns)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(workSheetName);
                    var currentRow = 1;

                    for (int i = 0; i < columns.Length; i++)
                    {
                        worksheet.Cell(currentRow, i + 1).Value = columns[i];
                    }

                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        currentRow++;
                        for (int j = 0; j < columns.Length; j++)
                        {
                            worksheet.Cell(currentRow, j + 1).Value = data.Rows[i][columns[j]];
                        }
                    }
                    using var stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    stream.Close();
                    return new ExportFileResult()
                    {
                        File = content,
                        FileName = "file.xls",
                    };
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
