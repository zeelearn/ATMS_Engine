using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using ShoppingCart.BL;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Data.OleDb;
using System.IO;
using System.Data.Odbc;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;


public partial class PO_Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");
            lblHeader_User_Code.Text = UserID;


        }
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Divbtnimport.Visible = false;
        datalist_NewUploads1.Visible = false;
        divdlGridDisplay.Visible = false;
        Msg_Error.Visible = false;
        DivSearchPanel.Visible = false;
        DivNew_Upload.Visible = true;
        DivResultPanel.Visible = false;
        txtuploadnameSearch.Text = "";
        txtuploadName.Text = "";
        Search.Visible = true;
        btnnew.Visible = false;
        Clear_Error_Success_Box();

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        if (id_date_range_picker_2.Value == "")
        {
            Show_Error_Success_Box("E", "Select date range ");
            return;
        }
        else
        {
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;
            try
            {
                string FromDate, ToDate;
                if (id_date_range_picker_2.Value == "")
                {
                    FromDate = "";
                    ToDate = "";
                }
                else
                {
                    string DateRange = "";
                    DateRange = id_date_range_picker_2.Value;

                    FromDate = DateRange.Substring(0, 10);
                    ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
                }
                string UplaodNm = txtuploadnameSearch.Text;
                if (UplaodNm == "")
                {
                    UplaodNm = "%";
                }
                else
                {
                    UplaodNm = txtuploadnameSearch.Text;
                }

                // DateTime.ParseExact(lblP_O_Date.Text.Trim(), "MM/dd/yyyy", null).ToString("dd/MM/yyyy");

                DataSet ds = ProductController.SerchPo_Upload(1, FromDate, ToDate, UplaodNm);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dlGridDisplay.DataSource = ds;
                    dlGridDisplay.DataBind();
                    lbltotalcount.Text = ds.Tables[0].Rows.Count.ToString();
                    Msg_Error.Visible = false;
                    DivSearchPanel.Visible = false;
                    DivResultPanel.Visible = true;
                    divdlGridDisplay.Visible = true;
                }
                else
                {
                    Msg_Error.Visible = true;
                    lblerror.Visible = true;
                    lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";
                    DivSearchPanel.Visible = true;
                }
            }

            catch (Exception ex)
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblerror.Text = ex.ToString();
                UpdatePanelMsgBox.Update();
                return;
            }
        }

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        DivNew_Upload.Visible = false;
        DivSearchPanel.Visible = true;
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;

    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        id_date_range_picker_2.Value = "";
        txtuploadName.Text = "";
        Msg_Error.Visible = false;
    }
    protected void fillThrouhExcel()
    {

        datalist_NewUploads1.Visible = true;
        //installed "2007 Office System Driver: Data Connectivity Components" for OLEDB connectivity Error on my machine.
        String strConnection = "ConnectionString";
        string connectionString = "";
        if (!uploadfile.HasFile)
        {


            //DataSet ds = new DataSet();
            //ds = ImportExcelXLS(Server.MapPath("~/Images/Excel Upload/" + fileName), true);
            //if (ds.Tables[0].Rows.Count > 6000)
            //{
            //    Msg_Error.Visible = true;
            //    Msg_Success.Visible = false;
            //    lblerror.Text = "Total No of Records in your Excel Sheet Cannot be greater than 6000...!";
            //    return;
            //}

            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = "Please Select File...!";
            return;

        }
        else
        {
            divdlGridDisplay.Visible = true;
            Msg_Error.Visible = false;
            string fileName = Path.GetFileName(uploadfile.PostedFile.FileName);
            lbluploadfileName.Text = Path.GetFileName(uploadfile.PostedFile.FileName);
            string fileExtension = Path.GetExtension(uploadfile.PostedFile.FileName);
            string fileLocation = Server.MapPath("~/PO_Upload/" + fileName);

            bool exists = System.IO.Directory.Exists(Server.MapPath("~/PO_Upload"));

            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath("~/PO_Upload"));

            uploadfile.SaveAs(fileLocation);
            if (fileExtension == ".xls")
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (fileExtension == ".xlsx")
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            DataSet dtExcelRecords = new DataSet();
            OleDbConnection con = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);


            con.Open();
            DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
            cmd.CommandText = "SELECT * FROM [Sheet1$] where P_O_Number IS NOT NULL";

            dAdapter.SelectCommand = cmd;

            dAdapter.Fill(dtExcelRecords);
            datalist_NewUploads1.DataSource = dtExcelRecords;



            // New code for changing date format taken a new datalist
            DataTable dtTempEntry = new DataTable();
            DataRow NewRow = null;


            var _with2 = dtTempEntry;
            _with2.Columns.Add("P_O_Number");
            _with2.Columns.Add("P_O_Date");
            _with2.Columns.Add("Vendor_Code");
            _with2.Columns.Add("Order_Qty");
            _with2.Columns.Add("Vendor_Name");
            _with2.Columns.Add("Material_Code");
            _with2.Columns.Add("Material_Description");
            _with2.Columns.Add("Order_By");
            _with2.Columns.Add("Rate");
            ////_with2.Columns.Add("Status");



            int count;
            count = dtExcelRecords.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {

                try
                {
                    string PO_Number = dtExcelRecords.Tables[0].Rows[i]["P_O_Number"].ToString();
                    // DateTime PODate_New = Convert.ToDateTime(dtExcelRecords.Tables[0].Rows[i]["P_O_Date(dd/mm/yyyy)"]);
                    // DateTime PO_Date = 
                    string PODate_New = dtExcelRecords.Tables[0].Rows[i]["P_O_Date"].ToString();
                    string VenodrCode = dtExcelRecords.Tables[0].Rows[i]["Vendor_Code"].ToString();
                    string OrderQty = dtExcelRecords.Tables[0].Rows[i]["Order_Qty"].ToString();
                    string VendorName = dtExcelRecords.Tables[0].Rows[i]["Vendor_Name"].ToString();
                    string MaterialCode = dtExcelRecords.Tables[0].Rows[i]["Material_Code"].ToString();
                    string Matrerial_Dscr = dtExcelRecords.Tables[0].Rows[i]["Material_Description"].ToString();
                    string OrderBy = dtExcelRecords.Tables[0].Rows[i]["Order_By"].ToString();
                    string Rate = dtExcelRecords.Tables[0].Rows[i]["Rate"].ToString();
                    ////string Status = dtExcelRecords.Tables[0].Rows[i]["Status"].ToString();

                    NewRow = dtTempEntry.NewRow();
                    NewRow["P_O_Number"] = PO_Number;
                    NewRow["P_O_Date"] = PODate_New;
                    NewRow["Vendor_Code"] = VenodrCode;
                    NewRow["Order_Qty"] = OrderQty;
                    NewRow["Vendor_Name"] = VendorName;
                    NewRow["Material_Code"] = MaterialCode;
                    NewRow["Material_Description"] = Matrerial_Dscr;
                    NewRow["Order_By"] = OrderBy;
                    NewRow["Rate"] = Rate;
                    ////NewRow["Status"] = Status;
                    dtTempEntry.Rows.Add(NewRow);

                }
                catch (Exception)
                {
                    lblerror.Visible = true;
                    lblerror.Text = "date should be dd/mm/yyyy format";
                }


            }



            datalist_NewUploads1.DataSource = dtTempEntry;
            datalist_NewUploads1.DataBind();
            //////////////////////////////////////////////////// till here ////////
        


        }
    }
    protected void Abc()
    {

        if (!string.IsNullOrEmpty(uploadfile.FileName))
        {
            lbluploadfileName.Text = Path.GetFileName(uploadfile.FileName);
            string FullName = Server.MapPath("~/PO_Upload") + "\\" + Path.GetFileName(uploadfile.FileName);
            lblfilepath.Text = FullName;
            string strFileType = Path.GetExtension(uploadfile.FileName).ToLower();
            if (strFileType != ".csv")
            {

            }

            else
            {
                uploadfile.SaveAs(FullName);

                DataTable dtRaw = new DataTable();



                //create object for CSVReader and pass the stream
                ////CSVReader reader = new CSVReader(FFLExcel.PostedFile.InputStream);
                FileStream fileStream = new FileStream(FullName, FileMode.Open);
                CSVReader reader = new CSVReader(fileStream);
                //get the header
                string[] headers = reader.GetCSVLine();

                //add headers
                foreach (string strHeader in headers)
                {
                    dtRaw.Columns.Add(strHeader);

                }
                DataRow NewRow = null;
                int CurRowNo = 0;


                //  DateTime.ParseExact(lblP_O_Date.Text.Trim(), "MM/dd/yyyy", null).ToString("dd/MM/yyyy");

                string[] data = null;


                data = reader.GetCSVLine();
                //Read first line
                CurRowNo = 1;
                while (data != null)
                {
                    dtRaw.Rows.Add(data);

                NextCSVLine:


                    data = reader.GetCSVLine();
                    //Read next line
                    CurRowNo = CurRowNo + 1;
                }
                datalist_NewUploads1.DataSource = dtRaw;
                datalist_NewUploads1.DataBind();
                datalist_NewUploads1.Visible = true;
                Divbtnimport.Visible = true;
                Msg_Error.Visible = false;
            }


        }
        else
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = "Please Select File...!";
            Divbtnimport.Visible = false;
            return;
        }

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        ////try
        ////{
        ////    fillThrouhExcel();
        ////}
        ////catch (Exception ex)
        ////{
        ////    Msg_Error.Visible = true;
        ////    Msg_Success.Visible = false;
        ////    lblerror.Text = ex.ToString();
        ////}
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
       


        try
        {
            if (txtuploadName.Text == "")
            {
                Msg_Error.Visible = true;
                lblerror.Text = "Enter Upload Name";

            }
            else
            {

                Abc();
            }
        }

        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();

        }

    }
    protected void BtndwnldTemplate_Click(object sender, EventArgs e)
    {
        //FileInfo file = new FileInfo("~/Template/" + "Template");
        //if (file.Exists)
        //{
        //    Response.Clear();
        //    Response.ClearHeaders();
        //    Response.ClearContent();
        //    Response.AddHeader("content-disposition", "attachment; filename=" + "Template");
        //    Response.AddHeader("Content-Type", "application/Excel");
        //    Response.ContentType = "application/vnd.xls";
        //    Response.AddHeader("Content-Length", file.Length.ToString());
        //    Response.WriteFile(file.FullName);
        //    Response.End();
        //}
        //else
        //{
        //    Response.Write("This file does not exist.");
        //}

        New_UploadGrid.Visible = true;
        //To Get the physical Path of the file(me2.doc)
        string filepath = Server.MapPath("~/Template/Template.csv");



        // Create New instance of FileInfo class to get the properties of the file being downloaded
        FileInfo myfile = new FileInfo(filepath);

        // Checking if file exists
        if (myfile.Exists)
        {
            // Clear the content of the response
            Response.ClearContent();

            // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
            Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

            // Add the file size into the response header
            Response.AddHeader("Content-Length", myfile.Length.ToString());

            // Set the ContentType
            //Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

            // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
            Response.TransmitFile(myfile.FullName);

            // End the response
            Response.End();
        }


    }
    private void Show_Error_Success_Box(string BoxType, string Error_Code)
    {
        if (BoxType == "E")
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
            Msg_Error.Focus();
        }
        else
        {
            Msg_Success.Visible = true;
            Msg_Error.Visible = false;
            lblSuccess.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
        }
    }

    protected void BindEmployees()
    {



        string conString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conString))
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Usp_Insert_T804_PurchaseOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                datalist_NewUploads1.DataSource = dt;
                datalist_NewUploads1.DataBind();
            }
            else
            {
                datalist_NewUploads1.DataSource = null;
                datalist_NewUploads1.DataBind();
            }
        }
    }

    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {


        Clear_Error_Success_Box();
        
        string PO_Code = "";
        string Po_Code = ProductController.GetPo_ImportCode(PO_Code);


        foreach (DataListItem item in datalist_NewUploads1.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblPOnumber = (Label)item.FindControl("lblPOnumber");
                Label lblP_O_Date = (Label)item.FindControl("lblP_O_Date");
                Label lblVendor_Code = (Label)item.FindControl("lblVendor_Code");
                Label lblMaterial_Code = (Label)item.FindControl("lblMaterial_Code");
                Label lblOrder_Qty = (Label)item.FindControl("lblOrder_Qty");
                Label lblRate = (Label)item.FindControl("lblRate");
                Label lblstatuss = (Label)item.FindControl("labelSTATUS");
                Label lblMaterialCode = (Label)item.FindControl("lblMaterial_Code");
                Label OrderBy = (Label)item.FindControl("lblOrderBY");
                Label Cost_Center = (Label)item.FindControl("Cost_Center");
                float PurchaseOrder_Amount;

            

                float val1;
                float val2;

             //   if ()

                if (!float.TryParse(lblRate.Text, out val1) || !float.TryParse(lblOrder_Qty.Text, out val2))
                    return;

                float val3 = val1 * val2;
                // Here you define what lbl should show the multiplication result
                PurchaseOrder_Amount = val3;
               // if (lblPOnumber.Text == "" || lblP_O_Date.Text == "" || lblVendor_Code.Text == "" || lblMaterial_Code.Text == "" || lblOrder_Qty.Text == "" || lblRate.Text == "")

                if (lblPOnumber.Text == "")
                {

                    lblstatuss.Text = "PO_Number is blank";
                }
                else if (lblP_O_Date.Text == "")
                {

                    lblstatuss.Text = "PO_Date is blank";
                }
                else if (lblVendor_Code.Text == "")
                {

                    lblstatuss.Text = "Vendor_Code is blank";
                }
                else if (lblMaterial_Code.Text == "")
                {

                    lblstatuss.Text = "Material_Code is blank";
                }

                else if (lblOrder_Qty.Text == "")
                {

                    lblstatuss.Text = "Order_Qty is blank";
                }

                else if (lblRate.Text == "")
                {

                    lblstatuss.Text = "Rate is blank";
                }

                else if (Cost_Center.Text == "")
                {

                    lblstatuss.Text = "Cost Center is blank";
                }
              
                else
                {
                    lblstatuss.Text = "Success";


                }

                //string ItemCount = datalist_NewUploads1.Items.Count.ToString();
                string ItemCount = "0";
                int IsActive = 1;
                //string CreatedBy ="";
                DateTime CreatedOn = DateTime.Now;
                string AlteredBy = "";
                DateTime AlteredOn = DateTime.Now;

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                Label lblHeader_User_Code = default(Label);
                lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

                string CreatedBy = null;
                CreatedBy = UserID;
                DateTime ImportDate = DateTime.Now;
                DateTime a = DateTime.Now;
                //String Ab = a.ToString("DD.MM.YYYY");

                string d = lblP_O_Date.Text;
                DateTime dt = DateTime.Now;
                string format = "dd.mm.yyyy";
                string dtTObeInsertedInSQL = dt.ToString(format);
              

                string Descr = lbluploadfileName.Text;

                try
                {
                  
                    
                    string date = lblP_O_Date.Text;
                    string[] arrDate = date.Split('.');

                    //now use array to get specific date object
              

                    string day = arrDate[0].ToString();
                    string month = arrDate[1].ToString();
                    string year = arrDate[2].ToString();

                  
                    string Current = DateTime.Now.ToString("dd.MM.yyyy");
                    string[] arrDate1 = Current.Split('.');
                  
                    //if (ss < date)
                    //{
                    //    Show_Error_Success_Box("E", "Date Should not greater than current date");
                    //    lblP_O_Date.Focus();
                    //    DivResultPanel.Visible = false;
                    //    DivSearchPanel.Visible = true;
                    //    return;
                    //}




                    //converted date dd/mm/yyy to mm/dd/yyy


                    //string currDT = DateTime.Now.ToString("dd.MM.yyyy");
                    ////string NewCurrentDate = DateTime.ParseExact(currDT, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
                    ////DateTime date = DateTime.ParseExact(currDT, "dd/MM/YYYY", null);
                    //DateTime CurrentDate = DateTime.ParseExact(currDT, "dd.MM.yyyy", null);


                    //string DateRange = lblP_O_Date.Text;
                    //string FromDate = DateRange.Substring(0, 10);
                    //string Todate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;




                  

                    //now use array to get specific date object


                    string day1 = arrDate1[0].ToString();
                    string month2 = arrDate1[1].ToString();
                    string Current_year = arrDate1[2].ToString();
                   // DateTime UserToDate = DateTime.ParseExact(DateRange, "dd.MM.yyyy", null);
                    if ((Convert.ToInt32(month) > 12)) 
                    {
                        lblstatuss.Text = "Date Should be in DD.MM.YYYY";
                    }
                    else if ((Convert.ToInt32(year)) > (Convert.ToInt32(Current_year)) )
                        
                    {
                        lblstatuss.Text = "You Have Entere Future Date Please Check...";
                    }

     

                   

                           

                //     else if ((CurrentDate < UserToDate) ||(Convert.ToInt32(month) > 12))
                //    {
                //        // Show_Error_Success_Box("E", "Date Should not greater than current date");
                //        lblstatuss.Text = "You Have Entere Future Date Please Check...";
                //        // id_date_range_picker_1.Focus();
                //        // DivResultPanel.Visible = false;
                //        // DivSearchPanel.Visible = true;
                //        // return;
                //    }
                //     else
                //     {
                //}



                    if (lblstatuss.Text == "Success")
                    {

                        //DateTime dt = Convert.ToDateTime(lblP_O_Date.Text);
                        DateTime dt1 = DateTime.ParseExact(lblP_O_Date.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);

                        string ResultId = ProductController.InsertPurchaseOrder(1, lblPOnumber.Text, dt1, lblVendor_Code.Text, ItemCount, "", IsActive, CreatedBy,
                        CreatedOn, lblHeader_User_Code.Text, AlteredOn, "", lblMaterial_Code.Text, lblOrder_Qty.Text, lblRate.Text, PurchaseOrder_Amount, Po_Code, ImportDate, lbluploadfileName.Text, "", CreatedBy, AlteredOn, txtuploadName.Text, Cost_Center.Text);

                        if (ResultId == "")
                        {

                            lblstatuss.Text = "Error(Vendor code not Match)";

                        }
                        else if (ResultId == "-1")
                        {
                            lblstatuss.Text = "Error (Already Exist)";
                            Msg_Success.Visible = false;
                           // Msg_Error.Visible = true;
                           // lblerror.Text = "Record not Saved!";
                           // lblerror.Text = "Record not saved";

                        }

                        else if (ResultId == "-2")
                        {
                            lblstatuss.Text = "Error -Please enter correct Cost Center Code ";
                        }

                        else if (ResultId == "1")
                        {
                            lblstatuss.Visible = true;
                            lblSuccess.Visible = true;
                            Msg_Success.Visible = true;
                            lblstatuss.Text = "Success";
                            lblSuccess.Text = "Data Saved a successfully";
                            
                           
                        }


                    }
                    else
                    {
                        Msg_Error.Visible = true;
                        Msg_Success.Visible = false;
                        lblerror.Text = "Record not Saved!";
                    }

                }
                catch (Exception ex)
                {
                    lblstatuss.Text = ex.ToString();

                    lblstatuss.Text = "Error:Not Saved";
                }
            }

        }



    }
    protected void HLExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "PO_UploadDetails_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        // HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='4'>PO Upload Report Details </b></TD></TR></Table>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='15'>PO Upload Report Details </b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        dlGridDisplay.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

    }
    protected void btnclosedlGridDisplay_Click(object sender, EventArgs e)
    {
        divdlGridDisplay.Visible = false;
        DivSearchPanel.Visible = true;
        Divbtnimport.Visible = false;

    }


    protected void Search_Click(object sender, EventArgs e)
    {
        divdlGridDisplay.Visible = false;
        DivSearchPanel.Visible = true;
        Divbtnimport.Visible = false;
        DivNew_Upload.Visible = false;
        Search.Visible = false;
        btnnew.Visible = true;
    }
}