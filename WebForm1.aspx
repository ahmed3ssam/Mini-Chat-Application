<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1Lab.Controllers.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Development Project</title>
    <style>
        body {
            background-image:url('SFX/4k-desktop-wallpaper.-1920×1080.jpg');
        }
        h1 {
            color:white;
            text-align:center;
        }
        
    </style>
</head>
<body style="height: 127px">
    <form id="form1" runat="server">
        <h1 style="text-align:left;text-shadow:20px;font-style:italic;">Group Chatting <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl="/SFX/chat.png" Width="63px" BorderStyle="None" style="margin-left: 1px"/>
        </h1>
        <div>
        <p>
    <asp:Label style="margin-left:35%;font-style:italic" ID="Label1" runat="server" Text="Enter Username:" ForeColor="White"></asp:Label>
            <asp:TextBox style="filter:opacity(0.5); border:10px;border-radius:10px;text-align:center;" ID="NameBox" runat="server" Width="200px" OnTextChanged="NameBox_TextChanged"></asp:TextBox>
            <asp:Button style="margin-top:2%; border:10px;border-radius:10px;" ID="EnterName" runat="server" Text="Enter" OnClick="EnterName_Click" />
            
            </p>
                
            </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                
                <asp:TextBox style="filter:opacity(0.7);border-radius:20px;background-color:; color:orangered;margin-left:30%;margin-top:3%; font-size:30px;" ID="DisplayMsg" runat="server" TextMode="MultiLine" Width="600px" Height ="400px" ReadOnly="True" OnTextChanged="DisplayMsg_TextChanged1"></asp:TextBox>
                
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                <asp:AsyncPostBackTrigger ControlID="SendButton" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
         <asp:Label style="border:10px;border-radius:10px; margin-left:30%;" ID="Label3" runat="server" Text="Enter Message:" ForeColor="White"></asp:Label> <br />
        <asp:TextBox style="filter:opacity(0.7);border:10px;border-radius:10px; margin-left:30%;text-align:center; font-size:20px;font-style:italic;" ID="MsgBox" runat="server"  Enabled ="False" Width="700px" TextMode="MultiLine" OnTextChanged="MsgBox_TextChanged"></asp:TextBox>
        <asp:Button style="border:10px;border-radius:10px;" ID="SendButton" runat="server" Text="Send" OnClick="SendBtn_Click" />
        <p>
            <asp:Timer ID="Timer1" runat="server" Interval="1000">
            </asp:Timer>
            <asp:FileUpload style="border:10px;border-radius:10px;" ID="FileUpload1" runat="server" />
            <asp:Button style="border:10px;border-radius:10px;" ID="UploadBtn" runat="server" OnClick="UploadBtn_Click" Text="Upload" />
        </p>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Image ID="Image2" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </ContentTemplate>
        </asp:UpdatePanel>
        
        
        
    </form>
</body>
</html>
