using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtoparkSorgulama
{
    public partial class sorgulama : System.Web.UI.Page
    {
        protected void ilceGetir(object sender, EventArgs e)
        {
           int sehirID=Convert.ToInt16(ddlSehir.SelectedItem.Value);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server = DESKTOP-4MMOK87\\SQLEXPRESS; database = OtoparkApp;Integrated Security = true;";


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT * from ilceler where SehirId=@sehirId order by ilceAdi";
            cmd.Parameters.AddWithValue("@sehirId", sehirID);
            SqlDataReader reader;
            cmd.Connection = con;
            con.Open();
            reader = cmd.ExecuteReader();
            //DropDownList için verilerimi yazıyorum. Databinding yapıyorum.
            ddl_ilce.DataSource = reader;
            ddl_ilce.DataValueField = "ilceID";
            ddl_ilce.DataTextField = "ilceAdi";
            ddl_ilce.DataBind();
            reader.Close();
            con.Close();
            otoparkGetir(sender, e);
            otoparkBilgiGetir(sender, e);
        }


        protected void otoparkGetir(object sender, EventArgs e)
        {
            int ID = Convert.ToInt16(ddl_ilce.SelectedItem.Value);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server = DESKTOP-4MMOK87\\SQLEXPRESS; database = OtoparkApp;Integrated Security = true;";


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select distinct  otoparkID, otoparkAdi,  i.SehirAdi ,  ii.ilceAdi, 
o.adres ,  o.aracKapasitesi , o.anlikKapasite, CASE o.otoparkTuru WHEN 1 THEN 'Açık' else 'Kapalı' END as [Otopark Türü]
from Otopark as o
 join ilceler as ii on ii.ilceID=o.ilceID
 join iller as i on i.SehirId=ii.SehirID
where  ii.ilceID=@ilceID and isActive=1";
            cmd.Parameters.AddWithValue("@ilceID", ID);
         
            cmd.Connection = con;
            con.Open();
            
          
            
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            con.Close();
            if ( tbl.Rows.Count <= 0)

            {
                ddlOtopark.Items.Clear();
                ddlOtopark.Items.Add("Otopark Bulunamadı");
                ddlOtopark.SelectedIndex = 0;
                ddlOtopark.Enabled = false;


            }
            else
            {
                ddlOtopark.Enabled = true;
                SqlDataReader reader;
                cmd.Connection = con;
                con.Open();
                reader = cmd.ExecuteReader();
                //DropDownList için verilerimi yazıyorum. Databinding yapıyorum.
                ddlOtopark.DataSource = reader;
                ddlOtopark.DataValueField = "otoparkID";
                ddlOtopark.DataTextField = "otoparkAdi";
                ddlOtopark.DataBind();
                reader.Close();
                con.Close();

             
              
            }
            otoparkBilgiGetir(sender, e);
        }





        protected void otoparkBilgiGetir(object sender, EventArgs e)
        {

            if (ddlOtopark.Text != "Otopark Bulunamadı")
            {
                int ID = Convert.ToInt16(ddlOtopark.SelectedItem.Value);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server = DESKTOP-4MMOK87\\SQLEXPRESS; database = OtoparkApp;Integrated Security = true;";


                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select distinct  otoparkID, otoparkAdi,  i.SehirAdi ,  ii.ilceAdi, 
o.adres ,  o.aracKapasitesi , o.anlikKapasite, CASE o.otoparkTuru WHEN 1 THEN 'Açık' else 'Kapalı' END as [Otopark Türü]
from Otopark as o
 join ilceler as ii on ii.ilceID=o.ilceID
 join iller as i on i.SehirId=ii.SehirID
where  otoparkID=@otoparkID and isActive=1";
                cmd.Parameters.AddWithValue("@otoparkID", ID);

                cmd.Connection = con;
                con.Open();

             
                DataTable tbl = new DataTable();
                tbl.Load(cmd.ExecuteReader());
                con.Close();
            
                    ddlOtopark.Enabled = true;
                   

                   
                    tbAdres.Text = tbl.Rows[0]["adres"].ToString();
                    tbOtoparkTuru.Text = tbl.Rows[0]["Otopark Türü"].ToString();
                    tbToplamKapasite.Text = tbl.Rows[0]["aracKapasitesi"].ToString();
                    tbBosSayisi.Text = tbl.Rows[0]["anlikKapasite"].ToString(); ;



                

            }
        }







        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

               
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server = DESKTOP-4MMOK87\\SQLEXPRESS; database = OtoparkApp;Integrated Security = true;";

                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT distinct sehirAdi, SehirId from iller order by sehirAdi ";
                SqlDataReader reader;
                cmd.Connection = con;
                con.Open();
                reader = cmd.ExecuteReader();
                //DropDownList için verilerimi yazıyorum. Databinding yapıyorum.
                ddlSehir.DataSource = reader;
                ddlSehir.DataValueField = "SehirId";
                ddlSehir.DataTextField = "sehirAdi";
                ddlSehir.DataBind();
                reader.Close();
                con.Close();



                ilceGetir(sender, e);
                otoparkGetir(sender, e);
                otoparkBilgiGetir(sender, e);


            }
        }
    }
}