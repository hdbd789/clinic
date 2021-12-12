using Clinic.ClinicException;
using Clinic.Helpers;
using Clinic.Models;
using log4net;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Clinic.Business
{
    public class ExcelExportFile : IExportFile
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void ExportAction(List<InfoPatient> infoPatients)
        {
            FileDialog fileDialog = new SaveFileDialog
            {
                AddExtension = true,
                Title = "Xuất file",
                DefaultExt = ".xlsx",
                FileName = "Bệnh nhân",
                Filter = "Excel file|*.xlsx"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                HelperControl.Instance.DoAsyncAction(() =>
                {
                    try
                    {
                        using (var fs = new FileStream(fileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            IWorkbook workbook = new XSSFWorkbook();
                            ISheet excelSheet = workbook.CreateSheet("Data");
                            excelSheet.DefaultColumnWidth = 12;
                            
                            IRow row = excelSheet.CreateRow(0);
                            row.CreateCell(0).SetCellValue("Ngày khám");
                            row.CreateCell(1).SetCellValue("Tên bệnh nhân");
                            row.CreateCell(2).SetCellValue("Ngày sinh");
                            row.CreateCell(3).SetCellValue("Số điện thoại");
                            row.CreateCell(4).SetCellValue("Địa chỉ");
                            row.CreateCell(5).SetCellValue("Chiều cao");
                            row.CreateCell(6).SetCellValue("Cân nặng");
                            row.CreateCell(7).SetCellValue("Triệu chứng");
                            row.CreateCell(8).SetCellValue("Chẩn đoán");
                            row.CreateCell(9).SetCellValue("Nhiệt độ");
                            row.CreateCell(10).SetCellValue("Huyết áp");
                            row.CreateCell(11).SetCellValue("Tên bác sĩ");
                            row.CreateCell(12).SetCellValue("Lí do");
                            row.CreateCell(13).SetCellValue("Bệnh");
                            row.CreateCell(14).SetCellValue("Ngày tái khám");
                            row.CreateCell(15).SetCellValue("Trạng thái");
                            row.CreateCell(16).SetCellValue("Thuốc/ Dịch vụ");

                            int RowIndex = 1;
                            foreach (var patient in infoPatients)
                            {
                                row = excelSheet.CreateRow(RowIndex);
                                row.CreateCell(0).SetCellValue(patient.NgayKham.ToString("dd-MM-yyyy"));
                                row.CreateCell(1).SetCellValue(patient.Name);
                                row.CreateCell(2).SetCellValue(patient.Birthday.ToString("dd-MM-yyyy"));
                                row.CreateCell(3).SetCellValue(patient.Phone);
                                row.CreateCell(4).SetCellValue(patient.Address);
                                row.CreateCell(5).SetCellValue(patient.Height);
                                row.CreateCell(6).SetCellValue(patient.Weight);
                                row.CreateCell(7).SetCellValue(patient.Symptom);
                                row.CreateCell(8).SetCellValue(patient.Diagnose);
                                row.CreateCell(9).SetCellValue(patient.Temperature);
                                row.CreateCell(10).SetCellValue(patient.HuyenAp);
                                row.CreateCell(11).SetCellValue(patient.NameOfDoctor);
                                row.CreateCell(12).SetCellValue(patient.Reason);
                                row.CreateCell(13).SetCellValue(patient.Benh);
                                row.CreateCell(14).SetCellValue(patient.NgayTaiKham);
                                row.CreateCell(15).SetCellValue(patient.Status);
                                row.CreateCell(16).SetCellValue(patient.Medicines);
                                RowIndex++;
                            }
                            workbook.Write(fs);
                        }
                    }
                    catch (IOException ex)
                    {
                        Log.Error(ex.Message, ex);
                        throw new FunctionalException($"Chúng tôi không thể truy cập file {fileDialog.FileName}. Xin hãy tắt file đang mở.", ex);
                    }

                });
            }
        }
    }
}
