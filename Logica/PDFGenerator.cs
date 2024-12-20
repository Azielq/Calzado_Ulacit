using Calzado_Ulacit.Logica;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace Calzado_Ulacit.Utilidades
{
    public class PDFGenerator
    {
        public void GenerateInvoicePDF(Invoice invoice, List<InvoiceItem> items, string clientName, decimal subtotal, decimal tax, decimal total, string filePath)
        {
            // Crear el documento PDF
            Document document = new Document(PageSize.A4);
            try
            {
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Título
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                Paragraph title = new Paragraph("Invoice - Ulacit Shoes", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20
                };
                document.Add(title);

                // Información de la factura
                var infoFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                PdfPTable infoTable = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };
                infoTable.AddCell(new Phrase("Invoice ID:", infoFont));
                infoTable.AddCell(new Phrase(invoice.InvoiceId.ToString(), infoFont));
                infoTable.AddCell(new Phrase("Client:", infoFont));
                infoTable.AddCell(new Phrase(clientName, infoFont));
                infoTable.AddCell(new Phrase("Invoice Date:", infoFont));
                infoTable.AddCell(new Phrase(invoice.InvoiceDate.ToString("dd/MM/yyyy"), infoFont));
                infoTable.AddCell(new Phrase("Invoice Discount (%):", infoFont));
                infoTable.AddCell(new Phrase((invoice.Discount * 100).ToString("F2"), infoFont));

                // **Añadir Método de Pago**
                infoTable.AddCell(new Phrase("Payment Method:", infoFont));
                infoTable.AddCell(new Phrase(invoice.PaymentMethod, infoFont));

                document.Add(infoTable);
                document.Add(new Paragraph("\n"));

                // Tabla de ítems
                PdfPTable table = new PdfPTable(5)
                {
                    WidthPercentage = 100
                };
                table.SetWidths(new float[] { 10, 40, 15, 15, 20 });

                // Encabezados
                table.AddCell(new Phrase("ID", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                table.AddCell(new Phrase("Shoe", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                table.AddCell(new Phrase("Amount", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                table.AddCell(new Phrase("Unit Price", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                table.AddCell(new Phrase("Discount", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));

                // Datos de los ítems
                foreach (var item in items)
                {
                    table.AddCell(new Phrase(item.ShoeId.ToString(), infoFont));
                    table.AddCell(new Phrase(item.ShoeName, infoFont)); // Usar ShoeName directamente
                    table.AddCell(new Phrase(item.Quantity.ToString(), infoFont));
                    table.AddCell(new Phrase(item.UnitPrice.ToString("C2"), infoFont));
                    table.AddCell(new Phrase(item.Discount.ToString("C2"), infoFont));
                }

                document.Add(table);
                document.Add(new Paragraph("\n"));

                // Totales
                PdfPTable totalTable = new PdfPTable(2)
                {
                    WidthPercentage = 40,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                };
                totalTable.SetWidths(new float[] { 1, 1 });

                totalTable.AddCell(new Phrase("Subtotal:", infoFont));
                totalTable.AddCell(new Phrase(subtotal.ToString("C2"), infoFont));
                totalTable.AddCell(new Phrase("Tax (13%):", infoFont));
                totalTable.AddCell(new Phrase(tax.ToString("C2"), infoFont));
                totalTable.AddCell(new Phrase("Total:", infoFont));
                totalTable.AddCell(new Phrase(total.ToString("C2"), infoFont));

                document.Add(totalTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar el PDF: " + ex.Message);
                throw;
            }
            finally
            {
                document.Close();
            }
        }
    }
}
