<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fwk.CheckLogging._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #Button1
        {
            height: 26px;
        }
        #Text1
        {
            width: 207px;
        }
        #Password1
        {
            width: 205px;
        }
        #Text2
        {
            width: 201px;
        }
    </style>

    <script language="javascript" type="text/javascript">
// <!CDATA[

        function Button1_onclick() {

        }

        function Button1_onclick() {

        }

// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:80px">
        <div>
        <h4>User domain name</h4>
         <asp:TextBox ID="txtUsr" runat="server"></asp:TextBox>
        </div>
        <div>
        <h4>Password</h4>
        <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
        </div>
        <div>
            <h4>Domain</h4>
         <asp:TextBox ID="txtDomain" runat="server" Text="Pelsoft-ar"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Button2" runat="server" Text="Submit" onclick="Button2_Click" 
                style="height: 26px" />
        
        </div>
    </div>
    
    
          <div  style="border:none #336699">
              <h4>Logging result:</h4>
              <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </div>
        
          <div  style="border:none #336699">
              <h4>Logging Error:</h4>
              <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
