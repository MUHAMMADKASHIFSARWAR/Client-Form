<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestJavascript.aspx.cs" Inherits="clientForm.TestJavascript" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="https://code.jquery.com/jquery-2.2.4.min.js"
        integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44="
        crossorigin="anonymous"></script>
    <script type="text/javascript">
     function SavePersonRecord() {  
          
        var Name = $.trim($('#<%=txtName.ClientID %>').val());  
        var LName = $.trim($('#<%=txtLastName.ClientID %>').val());  
  
        var Messege = "";  
         
        if (Name == '') {  
            Messege = "Can not Blank Name";  
        }  
          
        if (LName == '') {  
            Messege += "Can not Blank Last Name";  
        }  
  
        if (Messege.length == 0) {  
      
            $.ajax({  
                type: "POST",  
                dataType: "json",  
                contentType: "application/json; charset=utf-8",  
                url: 'TestJavascript.aspx/InsertPersonRecord',
                data: "{'Name':'" + Name + "', 'LName':'" + LName + "'}",  
                success: function (Record) {  
                       
                        $('#txtName').val();  
                        $('#txtLastName').val();  
  
  
                    if (Record.d == true) {  
                  
                        $('#Result').text("Your Record insert");  
                    }  
                    else {  
                        $('#Result').text("Your Record Not Insert");  
                    }  
  
                },  
                Error: function (textMsg) {  
                      
                    $('#Result').text("Error: " + Error);  
                }  
            });  
        }  
        else {             
            $('#Result').html('');  
            $('#Result').html(Messege);  
        }  
        $('#Result').fadeIn();  
    }  
    </script>  
  
</head>
<body>
    <form id="form1" runat="server">
  
    <asp:Table runat="server" >  
        <asp:TableRow>  
            <asp:TableCell>Name </asp:TableCell><asp:TableCell><asp:TextBox ID="txtName" runat="server" ></asp:TextBox></asp:TableCell>  
        </asp:TableRow>  
     
       <asp:TableRow>  
            <asp:TableCell>Last Name</asp:TableCell><asp:TableCell><asp:TextBox ID="txtLastName" runat="server" ></asp:TextBox></asp:TableCell>  
        </asp:TableRow>  
  
         <asp:TableRow>  
            <asp:TableCell></asp:TableCell><asp:TableCell><asp:Button ID="btnInsertRecord" runat="server" Text="Save"  OnClientClick="SavePersonRecord(); return false"/></asp:TableCell>  
        </asp:TableRow>  
  
     </asp:Table>  
    </form>
</body>
</html>
