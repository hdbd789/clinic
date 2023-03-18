using System;
using System.Collections.Generic;
using Clinic.Data.Models;
using Clinic.Helpers;
using Clinic.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PhongKham;

namespace Clinic.Business
{
    public static class PrintPrescription
    {
        public static void CreateAPdfExamination(InfoClinic InformationOfClinic, InfoPatient infoPatient, List<Medicine> Medicines, string taikham, int Stt)
        {
            Document document = new Document();
            document.Info.Author = "Luong Y";
            PageSetup.GetPageSize(PageFormat.A5, out Unit width, out Unit height);
            document.DefaultPageSetup.PageWidth = width;
            document.DefaultPageSetup.PageHeight = height;

            int tongTienThuoc = 0;
            AddSection("TOA THUỐC \n \n", document, InformationOfClinic, infoPatient, Medicines, false, taikham, ref tongTienThuoc, Stt);

            AddSection("Bảng Dịch Vụ \n \n", document, InformationOfClinic, infoPatient, Medicines, true, taikham, ref tongTienThuoc, Stt);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save("firstpage.pdf");
        }

        public static void CreateAPdfAdvisory(InfoClinic InformationOfClinic, InfoPatient infoPatient, List<Medicine> Medicines, string taikham, int Stt)
        {
            Document document = new Document();
            document.Info.Author = "Luong Y";
            PageSetup.GetPageSize(PageFormat.A5, out Unit width, out Unit height);
            document.DefaultPageSetup.PageWidth = width;
            document.DefaultPageSetup.PageHeight = height;

            int tongTienThuoc = 0;

            AddSection("Bảng Dịch Vụ Tư Vấn \n \n", document, InformationOfClinic, infoPatient, Medicines, true, taikham, ref tongTienThuoc, Stt);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save("firstpage.pdf");
        }

        private static void AddSection(string title, Document document, InfoClinic InformationOfClinic, InfoPatient infoPatient, List<Medicine> Medicines, bool onlyServices, string taikham, ref int tongTienThuoc, int Stt)
        {
            Section section = document.AddSection();
            section.PageSetup.LeftMargin = 20;

            AddHeader(InformationOfClinic, section);
            section.AddParagraph("\n");
            AddTitle(title, section);
            AddSTT(infoPatient, Stt, section);

            Table table = AddInfoPatient(infoPatient);

            Table tableMedicines = new Table();
            tableMedicines.Borders.Width = 0;
            tableMedicines.BottomPadding = 10;
            Column columnMedicines1 = tableMedicines.AddColumn(30);
            Column columnMedicines2;
            if (onlyServices)
            {
                columnMedicines2 = tableMedicines.AddColumn(140);
            }
            else
            {
                columnMedicines2 = tableMedicines.AddColumn(240);
            }
            Column columnMedicines3 = tableMedicines.AddColumn(70);
            Column columnMedicines4 = tableMedicines.AddColumn(130);
            Row rowMedicinesHeader = tableMedicines.AddRow();
            rowMedicinesHeader.Cells[0].AddParagraph("STT").Format.Font.Bold = true;
            if (!onlyServices)
            {
                rowMedicinesHeader.Cells[1].AddParagraph("Tên thuốc/Cách dùng").Format.Font.Bold = true;
            }
            else
            {
                rowMedicinesHeader.Cells[1].AddParagraph("Tên dịch vụ").Format.Font.Bold = true;
            }
            rowMedicinesHeader.Cells[2].AddParagraph("Số lượng").Format.Font.Bold = true;


            if (onlyServices)
            {
                rowMedicinesHeader.Cells[3].AddParagraph("Số tiền").Format.Font.Bold = true;
                int totalServices = 0;
                int indexServices = 1;
                for (int i = 0; i < Medicines.Count; i++)
                {
                    if (Medicines[i].Name[0] == '@')
                    {
                        string name = Medicines[i].Name.Substring(1, Medicines[i].Name.Length - 1);
                        Row rowDetail = tableMedicines.AddRow();
                        rowDetail.Cells[0].AddParagraph(indexServices.ToString());
                        rowDetail.Cells[1].AddParagraph(name + "\n" + Medicines[i].HDSD);
                        rowDetail.Cells[2].AddParagraph(Medicines[i].Number.ToString());
                        int thanhtien = Medicines[i].CostOut * Medicines[i].Number;
                        rowDetail.Cells[3].AddParagraph(thanhtien.ToMoney());
                        indexServices++;

                        totalServices += thanhtien;
                    }

                }
                //tong cong thuoc

                Row rowTotalThuoc = tableMedicines.AddRow();
                rowTotalThuoc.Cells[1].AddParagraph("Thuốc");
                rowTotalThuoc.Cells[3].AddParagraph(tongTienThuoc.ToMoney());



                Row gachdit = tableMedicines.AddRow();
                gachdit.Cells[3].AddParagraph("________________");

                int total = totalServices + tongTienThuoc;

                Row rowTotal = tableMedicines.AddRow();
                rowTotal.Cells[2].AddParagraph("Tổng cộng:");
                rowTotal.Cells[3].AddParagraph(total.ToMoney());
            }
            else
            {
                int indexMedicines = 1;
                for (int i = 0; i < Medicines.Count; i++)
                {
                    if (Medicines[i].Name[0] != '@')
                    {
                        Row rowDetail = tableMedicines.AddRow();
                        rowDetail.Cells[0].AddParagraph(indexMedicines.ToString());
                        rowDetail.Cells[1].AddParagraph(Medicines[i].Name + "\n" + Medicines[i].HDSD);
                        rowDetail.Cells[2].AddParagraph(Medicines[i].Number.ToString());
                        indexMedicines++;
                        tongTienThuoc += Medicines[i].Number * Medicines[i].CostOut;
                    }
                }
            }

            //Table loi dan , chu ky
            Table signatureAndMore = new Table();
            signatureAndMore.Borders.Width = 0;
            Column columnsignatureAndMore1 = signatureAndMore.AddColumn(150);
            Column columnsignatureAndMore2 = signatureAndMore.AddColumn(50);
            Column columnsignatureAndMore3 = signatureAndMore.AddColumn(210);
            Row rowsignatureAndMore1 = signatureAndMore.AddRow();

            if (!onlyServices)
            {
                // rowsignatureAndMore1.Cells[0].AddParagraph("Lời dặn: " + InformationOfClinic.Advice);
            }
            Paragraph paramNgayThang = rowsignatureAndMore1.Cells[2].AddParagraph("Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year);
            paramNgayThang.Format.Alignment = ParagraphAlignment.Center;
            Row rowsignatureAndMore2 = signatureAndMore.AddRow();
            rowsignatureAndMore2.VerticalAlignment = VerticalAlignment.Center;
            //rowsignatureAndMore2.Cells[0].AddParagraph(taikham + ": " + reasonComeBack);
            Paragraph para = rowsignatureAndMore2.Cells[2].AddParagraph(" \n \n" + Form1.NameOfDoctor);
            para.Format.Alignment = ParagraphAlignment.Center;
            para.Format.Font.Bold = true;

            document.LastSection.Add(table);
            document.LastSection.AddParagraph("\n");
            document.LastSection.Add(tableMedicines);
            document.LastSection.AddParagraph("\n");
            document.LastSection.Footers.Primary.Add(signatureAndMore);

        }

        private static Table AddInfoPatient(InfoPatient infoPatient)
        {
            Table table = new Table();
            table.Borders.Width = 0;
            Column column = table.AddColumn();
            column.Width = 100;
            table.AddColumn(440);

            Row row = table.AddRow();
            row.Cells[0].AddParagraph("Tên bệnh nhân: ");
            row.Cells[1].AddParagraph(infoPatient.Name);
            Row row2 = table.AddRow();
            row2.Cells[0].AddParagraph("Ngày sinh:");
            row2.Cells[1].AddParagraph(infoPatient.Birthday.ToString("dd-MM-yyyy"));
            Row row3 = table.AddRow();
            row3.Cells[0].AddParagraph("Địa chỉ: ");
            row3.Cells[1].AddParagraph(infoPatient.Address);
            Row row4 = table.AddRow();
            row4.Cells[0].AddParagraph("Chẩn đoán: ");
            row4.Cells[1].AddParagraph(infoPatient.Diagnose);

            return table;
        }

        private static void AddSTT(InfoPatient infoPatient, int Stt, Section section)
        {
            Paragraph paragraph = section.AddParagraph();
            Table tableSTT = new Table();
            tableSTT.TopPadding = 10;
            tableSTT.Borders.Width = 0;
            tableSTT.AddColumn(300);
            tableSTT.AddColumn(120);
            Row rowSTT = tableSTT.AddRow();
            Paragraph paragraphHeaderSTT = rowSTT.Cells[1].AddParagraph();
            paragraphHeaderSTT.AddText("ID : " + infoPatient.Id);
            paragraphHeaderSTT.AddText(" \n");
            paragraphHeaderSTT.AddText("STT : " + Stt);
            paragraph.Section.Add(tableSTT);
        }

        private static void AddTitle(string title, Section section)
        {
            Paragraph paragraphTitle = section.Headers.Primary.AddParagraph();
            paragraphTitle.Format.Borders.Width = 0;
            paragraphTitle.Format.Alignment = ParagraphAlignment.Center;
            paragraphTitle.AddTab();
            paragraphTitle.AddTab();
            Font font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 15)
            {
                Bold = true
            };
            paragraphTitle.AddFormattedText(title, font);
        }

        private static void AddHeader(InfoClinic InformationOfClinic, Section section)
        {
            Table tableHeader = section.Headers.Primary.AddTable();
            tableHeader.Borders.Width = 0;
            tableHeader.BottomPadding = 0;
            Column columnHeader1 = tableHeader.AddColumn(100);
            Column columnHeader2 = tableHeader.AddColumn(270);
            columnHeader1.Format.Alignment = ParagraphAlignment.Right;
            columnHeader2.Format.Alignment = ParagraphAlignment.Left;

            Row rowHeader = tableHeader.AddRow();
            Paragraph paragraphHeader1 = rowHeader.Cells[0].AddParagraph();
            Paragraph paragraphHeader2 = rowHeader.Cells[1].AddParagraph();
            Paragraph paragraphHeader3 = rowHeader.Cells[1].AddParagraph();
            paragraphHeader3.Format.Font.Size = 10;

            Image logo = paragraphHeader1.AddImage("Images/logo_exam.png");
            logo.Width = 80;
            logo.Height = 55;
            paragraphHeader2.Format.Alignment = ParagraphAlignment.Center;
            paragraphHeader2.Format.Font = new Font()
            {
                Bold = true,
                Size = 10
            };
            paragraphHeader2.AddText(InformationOfClinic.Name);

            string[] addressArray = InformationOfClinic.Address.Split(';');
            try
            {
                paragraphHeader3.AddSpace(int.Parse(addressArray[0]));
                paragraphHeader3.AddText($"Địa chỉ : {addressArray[1]}");
                paragraphHeader3.AddText(" \n");

                string[] sdtArray = InformationOfClinic.Sdt.Split(';');
                paragraphHeader3.AddSpace(int.Parse(sdtArray[0]));
                paragraphHeader3.AddText($"Số điện thoại: {sdtArray[1]}");
            }
            catch
            {
                paragraphHeader3.AddSpace(10);
            }
        }
    }
}
