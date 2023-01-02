using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using ShoppingCart.BL;
using System.Data;

public partial class Dispatch_Print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDDL_TransferType();
            FillDDL_Godown();
            FillDDL_Function();

            string DispatchCode = null, UserID=null;
            DispatchCode = Request.QueryString["DispatchCode"];
            UserID = Request.QueryString["UserID"];
            DataSet ds = null;

            dynamic document = new Document(PageSize.A4.Rotate(), 50, 50, 20, 20);
          


            // Create a new PdfWriter object, specifying the output stream
            dynamic output = new MemoryStream();
            dynamic writer = PdfWriter.GetInstance(document, output);



            




            dynamic TitleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
            dynamic subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            dynamic boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            dynamic endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            dynamic bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            BaseFont font_bold = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);


            // Open the Document for writing

            document.Open();

            var content = writer.DirectContent;
            var pageBorderRect = new Rectangle(document.PageSize);

            pageBorderRect.Left -= document.LeftMargin;
            pageBorderRect.Right += document.RightMargin;
            pageBorderRect.Top += document.TopMargin;
            pageBorderRect.Bottom -= document.BottomMargin;

            content.SetColorStroke(BaseColor.BLACK);
            content.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
            content.Stroke();

            ds = ProductController.Get_DispatchChallan_Report(1, DispatchCode, UserID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                float YPos1 = 0;
                YPos1 =523;
                PdfContentByte cb1 = writer.DirectContent;
                cb1.MoveTo(20, YPos1);
                cb1.LineTo(820, YPos1);

                YPos1 = 505;
                cb1.MoveTo(20, YPos1);
                cb1.LineTo(820, YPos1);

                YPos1 = 490;
                cb1.MoveTo(20, YPos1);
                cb1.LineTo(820, YPos1);

                YPos1 = 460;
                cb1.MoveTo(20, YPos1);
                cb1.LineTo(820, YPos1);
                //cb1.LineTo(445, YPos1);
                //cb1.LineTo(445, YPos1 - 145);
                
                cb1.Stroke();

                //YPos1 = 315;
                //cb1.MoveTo(20, YPos1);
                //cb1.LineTo(820, YPos1);

                //YPos1 = -10;
                //cb1.MoveTo(20, YPos1= -10 );
                //cb1.LineTo(820, YPos1 - 10);

                YPos1 = 580;
                cb1.MoveTo(20, YPos1);
                cb1.LineTo(820, YPos1);
                cb1.MoveTo(20, YPos1);
                cb1.LineTo(20, YPos1 - 570);
                cb1.MoveTo(820, YPos1);
                cb1.LineTo(820, YPos1 -570);
                cb1.Stroke();

                YPos1 = 20;
                cb1.MoveTo(20, YPos1);
                cb1.LineTo(820, YPos1);
               
                
                
                float YPos = 0;
                YPos = 500;

                try
                {
                    // jpg = iTextSharp.text.Image.GetInstance(Server.MapPath(ds.Tables[0].Rows[0]["ReceiptLogoImagePath"].ToString()));
                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(ds.Tables[0].Rows[0]["ReceiptLogoImagePath"].ToString()));
                    logo.SetAbsolutePosition(30, YPos);
                    logo.ScaleToFit(200, 95);
                    logo.ScaleAbsolute(80, 82);
                    //logo.ScalePercent(35);
                    document.Add(logo);
                }
                catch (Exception ex)
                {
                }

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                float Col0Left = 30;
                float Col1Left = 750;

                PdfContentByte cb = writer.DirectContent;
                cb.BeginText();

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(710, YPos + 65);
                cb.SetFontAndSize(bf, 9);
                cb.ShowText("Rule 55 Of CGST");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);




                cb.SetFontAndSize(bf, 15);

                cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["Receipt_head1"].ToString(), false)) / 2)), YPos + 60);
                cb.SetFontAndSize(bf, 15);
                cb.ShowText(ds.Tables[0].Rows[0]["Receipt_head1"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 11);
                cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["Receipt_head2"].ToString(), false)) / 2)), YPos + 45);
                cb.SetFontAndSize(bf, 11);
                cb.ShowText(ds.Tables[0].Rows[0]["Receipt_head2"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["Receipt_head3"].ToString(), false)) / 2)), YPos + 30);
                cb.SetFontAndSize(bf, 9);
                cb.ShowText(ds.Tables[0].Rows[0]["Receipt_head3"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 12);
                cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth("DELIVERY CHALLAN ", false)) / 2)), YPos +10);
                cb.SetFontAndSize(bf, 12);
                cb.ShowText(" DELIVERY CHALLAN ");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth("ORIGINAL For Consignee/ DUPLICATE For Transporter/ TRIPLICATE For Consignor", false)) / 2)), YPos - 8);
                cb.SetFontAndSize(bf, 10);
                cb.ShowText("ORIGINAL For Consignee/ DUPLICATE For Transporter/ TRIPLICATE For Consignor ");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix(30, YPos - 20);
                cb.ShowText("Delivery challan number:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix(140, YPos - 20);
                cb.ShowText(ds.Tables[1].Rows[0]["DeliveryChalan"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix(30, YPos - 30);
                cb.ShowText("Delivery challan date:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix(140, YPos - 30);
                cb.ShowText(ds.Tables[1].Rows[0]["ChallanDate"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix(30, YPos - 50);
                cb.ShowText("Consignor details:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix(140, YPos - 50);
                //cb.ShowText(lblStudname.Text);
                cb.ShowText(ds.Tables[1].Rows[0]["From_Location1"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                            

                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix(450, YPos - 50);
                cb.ShowText("Consignee details:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix(550, YPos - 50);
                cb.ShowText(ds.Tables[1].Rows[0]["Tolocation1"].ToString());
               //cb.ShowText(lblproduct.Text);
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
             //========

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(30, YPos - 60);
                cb.ShowText("Address 1:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(140, YPos - 60);
                cb.ShowText(ds.Tables[1].Rows[0]["From_Location"].ToString());
                //cb.ShowText(ddlSubjectGroup.SelectedItem.ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(450, YPos - 60);
                cb.ShowText("Address 1:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(550, YPos - 60);
                cb.ShowText(ds.Tables[1].Rows[0]["Tolocation"].ToString());
                //cb.ShowText(lblacadyear.Text);
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

   ///=======================================================================
                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(30, YPos - 70);
                cb.ShowText("");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                  float Yp2PDF = 0;
                //float ActPos = 0;
                string TotalMatter5 = null;
                string DummyMatter5 = null;
                string PrintMatter5 = null;
                dynamic SplitMatter5 = null;


                Yp2PDF = YPos - 70;
                TotalMatter5 = (ds.Tables[1].Rows[0]["FromAddress"].ToString());
                int Cntt = 0;
                Cntt = 0;
                if (!string.IsNullOrEmpty((TotalMatter5.Trim())))
                {
                    Yp2PDF = Yp2PDF  +10;
                    //cb.SetTextMatrix(140, YPos - 70);
                    DummyMatter5 = TotalMatter5;
                    SplitMatter5 = TotalMatter5.Split(Environment.NewLine.ToCharArray());
                    for (int EntCnt = 0; EntCnt <= Cntt; EntCnt++)
                    {
                        TotalMatter5 = SplitMatter5[EntCnt];
                    Again1PDF:
                       Yp2PDF = Yp2PDF - 10; //space between nxt line 
                         PrintMatter5 = "";
                        for (int ChrCnt = 1; ChrCnt <= (TotalMatter5.Length); ChrCnt++)
                        {
                            if (string.IsNullOrEmpty((TotalMatter5.Trim())))
                            {
                                PrintMatter5 = "";
                            }
                            else
                            {
                                PrintMatter5 = TotalMatter5.Substring(0, ChrCnt);
                            }
                            if (cb.GetEffectiveStringWidth(PrintMatter5, true) >= (240 - 1))  //475 Attend x position AND 201 Chapter x position
                            {
                                //Search for last blank space
                                ChrCnt = PrintMatter5.LastIndexOf(' ');
                                PrintMatter5 = TotalMatter5.Substring(0, ChrCnt);
                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(140, Yp2PDF);
                                cb.ShowText(PrintMatter5);
                                TotalMatter5 = TotalMatter5.Substring(PrintMatter5.Length, TotalMatter5.Length - ChrCnt);
                                goto Again1PDF;
                            }
                        }
                        cb.SetTextMatrix(140, Yp2PDF);
                        cb.SetFontAndSize(bf, 9);
                        cb.ShowText(PrintMatter5);
                    }
                }

                //float Yp2PDF1 = 0;
               // YPos = Yp2PDF - 70;
        /// =============================================================

                //float Yp2PDF = 0;
                ////float ActPos = 0;
                //string TotalMatter5 = null;
                //string DummyMatter5 = null;
                //string PrintMatter5 = null;
                //dynamic SplitMatter5 = null;


                Yp2PDF = YPos - 70;
                TotalMatter5 = (ds.Tables[1].Rows[0]["TOaddress"].ToString());
                //int Cntt = 0;
                Cntt = 0;
                if (!string.IsNullOrEmpty((TotalMatter5.Trim())))
                {
                    Yp2PDF = Yp2PDF + 10;
                    //cb.SetTextMatrix(140, YPos - 70);
                    DummyMatter5 = TotalMatter5;
                    SplitMatter5 = TotalMatter5.Split(Environment.NewLine.ToCharArray());
                    for (int EntCnt = 0; EntCnt <= Cntt; EntCnt++)
                    {
                        TotalMatter5 = SplitMatter5[EntCnt];
                    Again1PDF:
                        Yp2PDF = Yp2PDF - 10; //space between nxt line 
                        PrintMatter5 = "";
                        for (int ChrCnt = 1; ChrCnt <= (TotalMatter5.Length); ChrCnt++)
                        {
                            if (string.IsNullOrEmpty((TotalMatter5.Trim())))
                            {
                                PrintMatter5 = "";
                            }
                            else
                            {
                                PrintMatter5 = TotalMatter5.Substring(0, ChrCnt);
                            }
                            if (cb.GetEffectiveStringWidth(PrintMatter5, true) >= (240 - 1))  //475 Attend x position AND 201 Chapter x position
                            {
                                //Search for last blank space
                                ChrCnt = PrintMatter5.LastIndexOf(' ');
                                PrintMatter5 = TotalMatter5.Substring(0, ChrCnt);
                                 cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(550, Yp2PDF);
                                cb.ShowText(PrintMatter5);
                                TotalMatter5 = TotalMatter5.Substring(PrintMatter5.Length, TotalMatter5.Length - ChrCnt);
                                goto Again1PDF;
                            }
                        }
                        cb.SetTextMatrix(550, Yp2PDF);
                        cb.SetFontAndSize(bf, 9);
                        cb.ShowText(PrintMatter5);
                    }
                }

                //float Yp2PDF1 = 0;
                YPos = Yp2PDF - 70;






        //===================================================================================
              cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(450, YPos - 70);
                cb.ShowText("");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                  


                //===========statename
                Yp2PDF = YPos +30;
                //Yp2PDF = Yp2PDF1;
                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(30, Yp2PDF = YPos + 40);
                cb.ShowText("State Name & Code:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                Yp2PDF = YPos - 20;
                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(140, Yp2PDF = YPos + 40);
                cb.ShowText(ds.Tables[1].Rows[0]["ConsignorStatename"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(450, Yp2PDF = YPos + 40);
                cb.ShowText("State Name & Code:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(550, Yp2PDF = YPos + 40);
                cb.ShowText(ds.Tables[1].Rows[0]["ConsigneeStatename"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                //========Gstin

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(30, Yp2PDF = YPos + 30);
                cb.ShowText("GSTIN:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(140, Yp2PDF = YPos + 30);
                cb.ShowText(ds.Tables[1].Rows[0]["ConsignorGSTIN"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(450, Yp2PDF = YPos + 30);
                cb.ShowText("GSTIN:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(550, Yp2PDF = YPos + 30);
                cb.ShowText(ds.Tables[1].Rows[0]["ConsigneeGSTIN"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                //================cin no
                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(30, Yp2PDF = YPos + 20);
                cb.ShowText("CIN No:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(140, Yp2PDF = YPos + 20);
                cb.ShowText(ds.Tables[1].Rows[0]["ConsignorCIN"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(450, Yp2PDF = YPos + 20);
                cb.ShowText("CIN No:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(550, Yp2PDF = YPos + 20);
                cb.ShowText(ds.Tables[1].Rows[0]["ConsigneeCIN"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

          //==== Order No


          //      cb.SetFontAndSize(bf, 9);
          //      cb.SetTextMatrix(450, Yp2PDF = YPos + 10);
          //      cb.ShowText("Order No:");
          //      cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

          //      cb.SetFontAndSize(bf, 9);
          //      cb.SetTextMatrix(550, Yp2PDF = YPos + 10);
          //      cb.ShowText(ds.Tables[1].Rows[0]["Ordernumber"].ToString());
          //      cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

          ////===== Order Date

          //      cb.SetFontAndSize(bf, 9);
          //      cb.SetTextMatrix(450, Yp2PDF = YPos  -0);
          //      cb.ShowText("Order Date:");
          //      cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

          //      cb.SetFontAndSize(bf, 9);
          //      cb.SetTextMatrix(550, Yp2PDF = YPos - 0);
          //      cb.ShowText(ds.Tables[1].Rows[0]["Orderdate"].ToString());
          //      cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.EndText();
                Yp2PDF = YPos + 15;
                cb1.MoveTo(20, Yp2PDF);
                cb1.LineTo(820, Yp2PDF);
                cb.BeginText();


           //Transport details
                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(30, Yp2PDF = YPos  +5);
                cb.ShowText("Transport Details");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

        //vehicle&invoice

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(30, Yp2PDF = YPos - 5);
                cb.ShowText("Vehicle Details:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(140, Yp2PDF = YPos - 5);
                cb.ShowText(ds.Tables[1].Rows[0]["vehicaldetails"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(450, Yp2PDF = YPos - 5);
                cb.ShowText("Invoice Number:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(550, Yp2PDF = YPos - 5);
                cb.ShowText(ds.Tables[1].Rows[0]["invoienumber"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

        //transpoter&invoice date

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(30, Yp2PDF = YPos - 15);
                cb.ShowText("Transporter Details:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(140, Yp2PDF = YPos - 15);
                cb.ShowText(ds.Tables[1].Rows[0]["transporterdetails"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(450, Yp2PDF = YPos - 15);
                cb.ShowText("Invoice Date:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(550, Yp2PDF = YPos - 15);
                cb.ShowText(ds.Tables[1].Rows[0]["invoicedate"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
        //LR/PO

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(30, Yp2PDF = YPos - 25);
                cb.ShowText("LR/GC Note & Date:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(140, Yp2PDF = YPos - 25);
                cb.ShowText(ds.Tables[1].Rows[0]["LRtr"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(450, Yp2PDF = YPos - 25);
                cb.ShowText("PO number:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(550, Yp2PDF = YPos - 25);
                cb.ShowText(ds.Tables[1].Rows[0]["POnumber"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

        //MODE OF TRNASPROT & PODATE

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(30, Yp2PDF = YPos - 35);
                cb.ShowText("Mode of Transport:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(140, Yp2PDF = YPos - 35);
                cb.ShowText(ds.Tables[1].Rows[0]["modeoftrans"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(450, Yp2PDF = YPos - 35);
                cb.ShowText("PO Date:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(550, Yp2PDF = YPos - 35);
                cb.ShowText(ds.Tables[1].Rows[0]["podate"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                YPos1 = 460;
                Yp2PDF = YPos - 60;
                cb1.MoveTo(20, Yp2PDF);
                cb1.LineTo(820, Yp2PDF);
                cb1.MoveTo(445, Yp2PDF + 190);
                 cb1.LineTo(445, Yp2PDF);
                 
        //PLACE OF SUPPLY
                 cb.BeginText();
                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(30, Yp2PDF = YPos - 45);
                cb.ShowText("Place of supply:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(140, Yp2PDF = YPos - 45);
                cb.ShowText(ds.Tables[1].Rows[0]["ConsigneeStatename"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();
               

                YPos = YPos - 80;
//============================================================================
                cb.MoveTo(30, YPos);
                cb.LineTo(800, YPos);
                cb.MoveTo(30, YPos);
                cb.LineTo(30, YPos - 20);
                cb.Stroke();

                cb.BeginText();
                cb.SetFontAndSize(bf, 10);
               cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Sr.No", 45, YPos - 12, 0f);
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();
///===========================================================================
                cb.MoveTo(60, YPos);
                cb.LineTo(60, YPos - 20);
                cb.Stroke();

                cb.BeginText();
                cb.SetFontAndSize(bf, 10);
                //cb.SetTextMatrix(50, YPos - 12);
                Col0Left = 90;
                Col1Left = 90;
                cb.SetTextMatrix(62, YPos - 12);
                cb.ShowText("Description");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                cb.MoveTo(180, YPos);
                cb.LineTo(180, YPos - 20);
                cb.Stroke();
//============================================================================
                cb.BeginText();
                cb.SetFontAndSize(bf, 10);
                //cb.SetTextMatrix(50, YPos - 12);
                Col0Left = 180;
                Col1Left = 180;
                cb.SetTextMatrix(185, YPos - 12);
                cb.ShowText("HSN");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                cb.MoveTo(220, YPos);
                cb.LineTo(220, YPos - 20);
                cb.Stroke();
//==============================================================================
                cb.BeginText();
                cb.SetFontAndSize(bf, 10);
                //cb.SetTextMatrix(50, YPos - 12);
                Col0Left = 220;
                Col1Left = 220;
                cb.SetTextMatrix(231, YPos - 12);
                cb.ShowText("Asset No");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                cb.MoveTo(290, YPos);
                cb.LineTo(290, YPos - 20);
                cb.Stroke();
   //==============================================================================

                cb.BeginText();
                cb.SetFontAndSize(bf, 10);
                //cb.SetTextMatrix(50, YPos - 12);
                Col0Left = 290;
                Col1Left = 290;
                cb.SetTextMatrix(300, YPos - 12);
                cb.ShowText("Mat Code");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();
//==============================================================================
                cb.MoveTo(380, YPos);
                cb.LineTo(380, YPos - 20);
                cb.Stroke();

                cb.BeginText();
                cb.SetFontAndSize(bf, 10);
                //cb.SetTextMatrix(50, YPos - 12);
                Col0Left = 380;
                Col1Left = 380;
                cb.SetTextMatrix(385, YPos - 12);
                cb.ShowText("Qty");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();
//============================================================================
                cb.MoveTo(410, YPos);
                cb.LineTo(410, YPos - 20);
                cb.Stroke();

                cb.BeginText();
                cb.SetFontAndSize(bf, 10);
                //cb.SetTextMatrix(50, YPos - 12);
                Col0Left = 410;
                Col1Left = 410;
                cb.SetTextMatrix(411, YPos - 12);
                cb.ShowText("Unt");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();
//============================================================================
                cb.MoveTo(430, YPos);
                cb.LineTo(430, YPos - 20);
                cb.Stroke();

                cb.BeginText();
                cb.SetFontAndSize(bf, 10);
                //cb.SetTextMatrix(50, YPos - 12);
                Col0Left = 430;
                Col1Left = 430;
                cb.SetTextMatrix(435, YPos - 12);
                cb.ShowText("Rate");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();
//============================================================================

                cb.MoveTo(470, YPos - 20);
                cb.LineTo(470, YPos);
                cb.Stroke();

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                Col0Left = 470;
                Col1Left = 470;
                cb.SetTextMatrix(485, YPos - 8);
                cb.ShowText("Value");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

//===========================================================================
                //cb.BeginText();
                //cb.SetFontAndSize(bf, 8);
                ////cb.SetTextMatrix(50, YPos - 12);
                //Col0Left = 400;
                //Col1Left = 400;
                //cb.SetTextMatrix(410, YPos - 18);
                //cb.ShowText("%");
                //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                //cb.EndText();

                //cb.MoveTo(400, YPos - 10);
                //cb.LineTo(800, YPos - 10);
                //cb.MoveTo(450, YPos);
                //cb.LineTo(450, YPos );
                //cb.Stroke();

                //cb.BeginText();
                //cb.SetFontAndSize(bf, 8);
                ////cb.SetTextMatrix(50, YPos - 12);
                //Col0Left = 450;
                //Col1Left = 450;
                //cb.SetTextMatrix(451, YPos - 18);
                //cb.ShowText("Amt");
                //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                //cb.EndText();

                cb.MoveTo(520, YPos);
                cb.LineTo(800, YPos );
                cb.MoveTo(520, YPos - 20);
                cb.LineTo(520, YPos);
                cb.Stroke();
//===========================================================================
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                //cb.SetTextMatrix(50, YPos - 12);
                Col0Left = 520;
                Col1Left = 520;
                cb.SetTextMatrix(541, YPos - 8);
                cb.ShowText("CGST");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();


                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                Col0Left = 520;
                Col1Left = 520;
                cb.SetTextMatrix(525, YPos - 18);
                cb.ShowText("%");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                cb.MoveTo(520, YPos - 10);
                cb.LineTo(800, YPos - 10);
                cb.MoveTo(520, YPos);
                cb.LineTo(520, YPos);
                cb.Stroke();


                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                Col0Left = 520;
                Col1Left = 520;
                cb.SetTextMatrix(555, YPos - 18);
                cb.ShowText("Amt");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                cb.MoveTo(590, YPos - 10);
                cb.LineTo(800, YPos - 10);
                cb.MoveTo(590, YPos - 20);
                cb.LineTo(590, YPos);
                cb.Stroke();

//=============================================================================
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                //cb.SetTextMatrix(50, YPos - 12);
                Col0Left = 590;
                Col1Left = 590;
                cb.SetTextMatrix(601, YPos - 8);
                cb.ShowText("SGST/UTGST");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();


                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                Col0Left = 590;
                Col1Left = 590;
                cb.SetTextMatrix(595, YPos - 18);
                cb.ShowText("%");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                cb.MoveTo(620, YPos - 10);
                cb.LineTo(800, YPos - 10);
                cb.MoveTo(620, YPos);
                cb.LineTo(620, YPos);
                cb.Stroke();



                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                Col0Left = 620;
                Col1Left = 620;
                cb.SetTextMatrix(621, YPos - 18);
                cb.ShowText("Amt");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                cb.MoveTo(660, YPos - 10);
                cb.LineTo(800, YPos - 10);
                cb.MoveTo(660, YPos - 20);
                cb.LineTo(660, YPos);
                cb.Stroke();


    //=======================================================================

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                Col0Left = 660;
                Col1Left = 660;
                cb.SetTextMatrix(675, YPos - 8);
                cb.ShowText("IGST");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();


                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                Col0Left = 650;
                Col1Left = 650;
                cb.SetTextMatrix(665, YPos - 18);
                cb.ShowText("%");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                cb.MoveTo(690, YPos - 10);
                cb.LineTo(690, YPos - 10);
                cb.MoveTo(690, YPos);
                cb.LineTo(690, YPos);
                cb.Stroke();


                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                Col0Left = 690;
                Col1Left = 690;
                cb.SetTextMatrix(701, YPos - 18);
                cb.ShowText("Amt");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                cb.MoveTo(730, YPos - 10);
                cb.LineTo(730, YPos - 10);
                cb.MoveTo(730, YPos);
                cb.LineTo(730, YPos - 20);
                cb.Stroke();



//===========================================================================

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                //cb.SetTextMatrix(50, YPos - 12);
                Col0Left = 730;
                Col1Left = 730;
                cb.SetTextMatrix(741, YPos - 8);
                cb.ShowText("Amount");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                cb.MoveTo(800, YPos);
                cb.LineTo(800, YPos -20);
                //cb.MoveTo(800, YPos);
                //cb.LineTo(800, YPos - 20);
                cb.Stroke();
//========================================================================= 
                YPos = YPos - 20;
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    cb.MoveTo(30, YPos);
                    cb.LineTo(800, YPos);

                    cb.MoveTo(30, YPos);
                    cb.LineTo(30, YPos - 20);
                    cb.Stroke();

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    //cb.SetTextMatrix(32, YPos - 12);
                    //cb.ShowText(ds.Tables[1].Rows[i]["PKeyNo"].ToString());
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, ds.Tables[1].Rows[i]["SRNo"].ToString(), 45, YPos - 10, 0f);
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();
//=========================================================================== des
                    cb.MoveTo(60, YPos);
                    cb.LineTo(60, YPos - 20);
                    cb.Stroke();

                    //cb.BeginText();
                    //cb.SetFontAndSize(bf, 8);
                    //cb.SetTextMatrix(62, YPos - 12);
                    //cb.ShowText(ds.Tables[1].Rows[i]["DescriptionofGoods"].ToString());
                    //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    //cb.EndText();

                    cb.MoveTo(180, YPos);
                    cb.LineTo(180, YPos - 20);
                    cb.Stroke();

//=========================================================================
                    float Yp2PDF1 = 0;
                    //float ActPos = 0;
                    string TotalMatter51 = null;
                    string DummyMatter51 = null;
                    string PrintMatter51 = null;
                    dynamic SplitMatter51 = null;


                    Yp2PDF1 = YPos - 60;
                    TotalMatter51 = (ds.Tables[1].Rows[i]["DescriptionofGoods"].ToString());
                    int Cntt1 = 0;
                    Cntt1 = 0;
                    cb.BeginText();

                    if (!string.IsNullOrEmpty((TotalMatter51.Trim())))
                    {
                        Yp2PDF1 = Yp2PDF1 +60;
                        //cb.SetTextMatrix(140, YPos - 70);
                        DummyMatter51 = TotalMatter51;
                        SplitMatter51 = TotalMatter51.Split(Environment.NewLine.ToCharArray());
                        for (int EntCnt = 0; EntCnt <= Cntt1; EntCnt++)
                        {
                            TotalMatter51 = SplitMatter51[EntCnt];
                        Again1PDF:
                            Yp2PDF1 = Yp2PDF1 - 10; //space between nxt line 
                            PrintMatter51 = "";
                            for (int ChrCnt = 1; ChrCnt <= (TotalMatter51.Length); ChrCnt++)
                            {
                                if (string.IsNullOrEmpty((TotalMatter51.Trim())))
                                {
                                    PrintMatter51 = "";
                                }
                                else
                                {
                                    PrintMatter51 = TotalMatter51.Substring(0, ChrCnt);
                                }
                                if (cb.GetEffectiveStringWidth(PrintMatter51, true) >= (110 - 1))  //475 Attend x position AND 201 Chapter x position
                                {
                                    //Search for last blank space
                                    ChrCnt = PrintMatter51.LastIndexOf(' ');
                                    PrintMatter51 = TotalMatter51.Substring(0, ChrCnt);
                                    cb.SetFontAndSize(bf, 8);
                                    cb.SetTextMatrix(62, Yp2PDF1);
                                    cb.ShowText(PrintMatter51);
                                    TotalMatter51 = TotalMatter51.Substring(PrintMatter51.Length, TotalMatter51.Length - ChrCnt);
                                    goto Again1PDF;
                                }
                            }
                            cb.SetTextMatrix(62, Yp2PDF1);
                            cb.SetFontAndSize(bf, 9);
                            cb.ShowText(PrintMatter51);
                        }
                    }

                    cb.EndText();
//========================================================================= hsn

                     cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(181, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["HSNgoods"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    cb.MoveTo(220, YPos);
                    cb.LineTo(220, YPos - 20);
                    cb.Stroke();

//========================================================================== asset

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(221, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["AssetCODE"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    cb.MoveTo(290, YPos);
                    cb.LineTo(290, YPos - 20);
                    cb.Stroke();
//========================================================================== Code
                                     
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(291, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["ITEMCODE"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();


                    cb.MoveTo(380, YPos);
                    cb.LineTo(380, YPos - 20);
                    cb.Stroke();

//===========================================================================Quntiy

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(382, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["Quntity"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    cb.MoveTo(410, YPos);
                    cb.LineTo(410, YPos - 20);
                    cb.Stroke();

//============================================================================= Unit
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(411, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["UNIT"].ToString());
                    ///cb.ShowText(ds.Tables[1].Rows[i]["Rate"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    cb.MoveTo(430, YPos);
                    cb.LineTo(430, YPos - 20);
                    cb.Stroke();
  //====================================================================== RATE

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(435, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["Rate"].ToString());
                   // cb.ShowText(ds.Tables[1].Rows[i]["Value"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    cb.MoveTo(470, YPos);
                    cb.LineTo(470, YPos - 20);
                    cb.Stroke();
          
//==================================================================== VALUE


                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(480, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["Value"].ToString());
                    // cb.ShowText(ds.Tables[1].Rows[i]["Value"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    cb.MoveTo(520, YPos);
                    cb.LineTo(520, YPos - 20);
                    cb.Stroke();


//=================================================================CGST
                     cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(525, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["CGSTRate"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    cb.MoveTo(540, YPos);
                    cb.LineTo(540, YPos - 20);
                    cb.Stroke();

                    //cb.MoveTo(620, YPos);
                    //cb.LineTo(620, YPos - 20);
                    //cb.Stroke();

                    //cb.MoveTo(545, YPos);
                    //cb.LineTo(800, YPos);
                    cb.MoveTo(540, YPos - 20);
                    cb.LineTo(540, YPos + 10);
                    cb.Stroke();

//=====================================================================

                    //cb.MoveTo(430, YPos);
                    //cb.LineTo(430, YPos - 20);
                    //cb.Stroke();

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(555, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["CgstTaxamt"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    cb.MoveTo(590, YPos);
                    cb.LineTo(590, YPos - 20);
                    cb.Stroke();

                    //cb.MoveTo(560, YPos);
                    //cb.LineTo(800, YPos);
                    //cb.MoveTo(560, YPos - 20);
                    //cb.LineTo(560, YPos);
                    //cb.Stroke();
//===========================================================


                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(595, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["UTGSTRate"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    cb.MoveTo(610, YPos);
                    cb.LineTo(610, YPos - 20);
                    cb.Stroke();
                    cb.MoveTo(610, YPos - 20);
                    cb.LineTo(610, YPos + 10);
                    cb.Stroke();

//================================================================


                    //cb.MoveTo(520, YPos);
                    //cb.LineTo(520, YPos - 20);
                    //cb.Stroke();

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(615, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["UTGSTTaxamt"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    cb.MoveTo(660, YPos);
                    cb.LineTo(660, YPos - 20);
                    cb.Stroke();

                    //cb.MoveTo(615, YPos);
                    //cb.LineTo(800, YPos);
                    //cb.MoveTo(615, YPos - 20);
                    //cb.LineTo(615, YPos);
                    //cb.Stroke();

//=============================================================================

                    //cb.MoveTo(580, YPos);
                    //cb.LineTo(580, YPos - 20);
                    //cb.Stroke();

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(665, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["IGSTRate"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    //cb.MoveTo(680, YPos);
                    //cb.LineTo(680, YPos - 20);
                    //cb.Stroke();

                    //cb.MoveTo(620, YPos);
                    //cb.LineTo(800, YPos);
                    cb.MoveTo(680, YPos - 20);
                    cb.LineTo(680, YPos + 10);
                    cb.Stroke();
//=============================================================================

                    //cb.MoveTo(610, YPos);
                    //cb.LineTo(610, YPos - 20);
                    //cb.Stroke();

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(685, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["IGSTTaxamt"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    //cb.MoveTo(730, YPos);
                    //cb.LineTo(730, YPos - 20);
                    //cb.Stroke();


                    cb.MoveTo(730, YPos);
                    cb.LineTo(800, YPos);
                    cb.MoveTo(730, YPos - 20);
                    cb.LineTo(730, YPos);
                    cb.Stroke();
//===============================================================================


                    //cb.MoveTo(650, YPos);
                    //cb.LineTo(650, YPos - 20);
                    //cb.Stroke();

//                    cb.BeginText();
//                    cb.SetFontAndSize(bf, 8);
//                    cb.SetTextMatrix(661, YPos - 12);
//                    cb.ShowText(ds.Tables[1].Rows[i]["CESS"].ToString());
//                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
//                    cb.EndText();

//                    cb.MoveTo(650, YPos);
//                    cb.LineTo(650, YPos - 20);
//                    cb.Stroke();

//                    cb.MoveTo(690, YPos);
//                    cb.LineTo(800, YPos);
//                    cb.MoveTo(690, YPos - 20);
//                    cb.LineTo(690, YPos +10);
//                    cb.Stroke();
////================================================================================


//                    cb.MoveTo(690, YPos);
//                    cb.LineTo(690, YPos - 20);
//                    cb.Stroke();

//                    cb.BeginText();
//                    cb.SetFontAndSize(bf, 8);
//                    cb.SetTextMatrix(703, YPos - 12);
//                    cb.ShowText(ds.Tables[1].Rows[i]["CESSTaxamt"].ToString());
//                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
//                    cb.EndText();

//                    cb.MoveTo(690, YPos);
//                    cb.LineTo(690, YPos - 20);
//                    cb.Stroke();

                    //cb.MoveTo(700, YPos);
                    //cb.LineTo(800, YPos);
                    //cb.MoveTo(700, YPos - 20);
                    //cb.LineTo(700, YPos);
                    //cb.Stroke();

//=================================================================================


                    cb.MoveTo(730, YPos);
                    cb.LineTo(730, YPos - 20);
                    cb.Stroke();

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(743, YPos - 12);
                    cb.ShowText(ds.Tables[1].Rows[i]["TOTALAMOUNT"].ToString());
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.EndText();

                    cb.MoveTo(800, YPos);
                    cb.LineTo(800, YPos - 20);
                    cb.MoveTo(800, YPos);
                    cb.LineTo(800, YPos - 20);
                    cb.Stroke();

                    YPos = YPos - 20;


                    if (YPos <= 40)
                    {                        
                        cb.MoveTo(30, YPos);
                        cb.LineTo(800, YPos);
                        cb.Stroke();
                        document.NewPage();
                        YPos = 500;

                        YPos1 = 580;
                        cb1.MoveTo(20, YPos1);
                        cb1.LineTo(820, YPos1);
                        cb1.MoveTo(20, YPos1);
                        cb1.LineTo(20, YPos1 - 570);
                        cb1.MoveTo(820, YPos1);
                        cb1.LineTo(820, YPos1 - 570);
                        cb1.Stroke();
                        YPos1 = 20;
                        cb1.MoveTo(20, YPos1);
                        cb1.LineTo(820, YPos1);


                    }
                }

                cb.MoveTo(30, YPos);
                cb.LineTo(800, YPos);
                cb.Stroke();
                //=========================================================

                cb.MoveTo(660, YPos);
                cb.LineTo(660, YPos - 20);
                cb.Stroke();

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(664, YPos - 12);
                cb.ShowText("Total Amount");
                //cb.ShowText(ds.Tables[1].Rows[0]["TOTALAMOUNT"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                cb.MoveTo(660, YPos);
                cb.LineTo(660, YPos - 20);
                cb.MoveTo(660, YPos);
                cb.LineTo(660, YPos - 20);
                //cb.MoveTo(690, YPos - 20);
                cb.LineTo(730, YPos - 20);
                cb.Stroke();

               // =========================================================

                cb.MoveTo(730, YPos);
                cb.LineTo(730, YPos - 20);
                cb.Stroke();

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(743, YPos - 12);
                cb.ShowText(ds.Tables[2].Rows[0]["TOTALAMOUNT"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();

                cb.MoveTo(800, YPos);
                cb.LineTo(800, YPos - 20);
                cb.MoveTo(800, YPos);
                cb.LineTo(800, YPos - 20);
                //cb.MoveTo(690, YPos - 20);
                cb.LineTo(730, YPos -20);
                cb.Stroke();


                //=========================================================

                cb.BeginText();
                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix(680, YPos - 40);
                cb.ShowText("FOR MT EDUCARE LIMITED");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                

                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(50, Yp2PDF = YPos - 80);
                cb.ShowText("Created By:");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(98, YPos - 80);
                cb.ShowText(ds.Tables[1].Rows[0]["createdby"].ToString());
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                
                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix(700, YPos - 80);
                cb.ShowText("Authorised Signatory");
                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                cb.EndText();



                //document.NewPage();
                
            }
            document.Close();

            string CurTimeFrame = null;
            CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Delivery_Challan_{0}.pdf", CurTimeFrame));
            Response.BinaryWrite(output.ToArray());

        }
    }

   
    protected void btnprint_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=DispatchPrint.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        pnlPerson.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    
    }

    

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    private void FillDDL_TransferType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        BindDDL(ddlLocationType, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlLocationType.Items.Insert(0, "Select Location");
        ddlLocationType.SelectedIndex = 0;
    }

    private void FillDDL_Godown()
    {
        ddlgodownFR_SRSearch.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(1);
        BindDDL(ddlgodownFR_SRSearch, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlgodownFR_SRSearch.Items.Insert(0, "Select Godown");
        ddlgodownFR_SRSearch.SelectedIndex = 0;
    }

    
    private void FillDDL_Function()
    {
        ddlFunctionFR_SRSearch.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunctionFR_SRSearch, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunctionFR_SRSearch.Items.Insert(0, "Select Function");
        ddlFunctionFR_SRSearch.SelectedIndex = 0;
    }

}