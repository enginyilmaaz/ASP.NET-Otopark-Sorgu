<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OtoparkSorgulama.sorgulama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
body  {
    background-color:#005cad;
   font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
   color:white
}
</style>



   <div class="form-horizontal" style="  background-color:#005cad;">

     

           


        <div class="form-group">
    <label for="inputEmail3" class="col-sm-2 control-label">Şehir Seç:</label>
    <div class="col-sm-5">
      <asp:DropDownList  CssClass="form-control" style="background-color:#005cad;border-style: dotted;border-width: 2px;border-color:white;color:white" ID="ddlSehir" runat="server" AutoPostBack="True"  OnSelectedIndexChanged = "ilceGetir" ReadOnly="true"></asp:DropDownList>
            
    </div>
  </div>




       
        <div class="form-group">
    <label for="inputEmail3" class="col-sm-2 control-label">İlçe Seç:</label>
    <div class="col-sm-5">
      <asp:DropDownList  CssClass="form-control" style="background-color:#005cad;border-style: dotted;border-width: 2px;border-color:white;color:white" ID="ddl_ilce" runat="server" AutoPostBack="True"   OnSelectedIndexChanged = "otoparkGetir" ReadOnly="true"></asp:DropDownList>
            
    </div>
  </div>





  <div class="form-group">
    <label for="inputEmail3" class="col-sm-2 control-label">Otopark Seç:</label>
    <div class="col-sm-5">
      <asp:DropDownList  CssClass="form-control" style="background-color:#005cad;border-style: dotted;border-width: 2px;border-color:white;color:white" ID="ddlOtopark" runat="server" AutoPostBack="True"  OnSelectedIndexChanged = "otoparkBilgiGetir" ReadOnly="true"></asp:DropDownList>
            
    </div>
  </div>


 <%if (ddlOtopark.Text != "Otopark Bulunamadı") { %>

       
               <div class="form-group">
    <label for="inputPassword3" class="col-sm-2 control-label">Otopark Adresi:</label>
    <div class="col-sm-5">
     <asp:TextBox  CssClass="form-control" style="background-color:#005cad;border-style: dotted;border-width: 2px;border-color:white;color:white" ID="tbAdres" runat="server" ReadOnly="true" ></asp:TextBox>
     
    </div>
  </div>
       
               <div class="form-group">
    <label for="inputPassword3" class="col-sm-2 control-label">Otopark Türü:</label>
    <div class="col-sm-5">
     <asp:TextBox  CssClass="form-control" style="background-color:#005cad;border-style: dotted;border-width: 2px;border-color:white;color:white" ID="tbOtoparkTuru" runat="server" ReadOnly="true" ></asp:TextBox>
     
    </div>
  </div>
     
       

  <div class="form-group">
    <label for="inputEmail3" class="col-sm-2 control-label">Kapasite:</label>
    <div class="col-sm-5">
      <asp:TextBox  CssClass="form-control" style="background-color:#005cad;border-style: dotted;border-width: 2px;border-color:white;color:white"  ID ="tbToplamKapasite" runat="server" ReadOnly="true"></asp:TextBox>
            
    </div>
  </div>


  <div class="form-group">
    <label for="inputPassword3" class="col-sm-2 control-label">Boş Araç Sayısı:</label>
    <div class="col-sm-5">
     <asp:TextBox  CssClass="form-control"  style="background-color:#005cad;border-style: dotted;border-width: 2px;border-color:white;color:white" ID="tbBosSayisi" runat="server" ReadOnly="true" ></asp:TextBox>
     
    </div>
  </div>


       <%} %>




      








</div>




    
   









</asp:Content>
   