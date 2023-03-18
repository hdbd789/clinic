using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Clinic.ClinicException;
using Clinic.Data.Models;
using Clinic.Helpers;
using CsvHelper;
using CsvHelper.TypeConversion;
using log4net;

namespace Clinic.Business
{
    public class CSVExportFile : IExportFile
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void ExportAction(List<InfoPatient> infoPatients)
        {
            FileDialog fileDialog = new SaveFileDialog
            {
                AddExtension = true,
                Title = "Xuất file",
                DefaultExt = ".csv",
                FileName = "Bệnh nhân",
                Filter = "CSV file|*.csv"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                HelperControl.Instance.DoAsyncAction(() =>
                {
                    try
                    {
                        using (var writer = new StreamWriter(fileDialog.FileName))
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            var options = new TypeConverterOptions { Formats = new[] { ClinicConstant.DateTimeFormat } };
                            csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);
                            csv.WriteRecords(infoPatients);
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
