<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="OntView.WebForm1" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.116, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>OntView</title>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body MS_POSITIONING="GridLayout">
<form id="Form1" method="post" enctype="multipart/form-data" runat="server">
<iewc:treeview id=tvOnt style="Z-INDEX: 100; LEFT: 448px; POSITION: absolute; TOP: 144px" runat="server" ShowToolTip="False" SelectExpands="True" Width="400px" BackColor="#E0E0E0" BorderColor="Gray" BorderStyle="Groove" ExpandLevel="1" Height="600px" OnSelectedIndexChange="tvOnt_SelectedIndexChange" AutoPostBack="True" AutoSelect="True"></iewc:treeview>
<asp:label id=Label5 style="Z-INDEX: 113; LEFT: 456px; POSITION: absolute; TOP: 48px" runat="server" Font-Bold="True">Notes on current category:</asp:label><asp:label id=Label2 style="Z-INDEX: 108; LEFT: 24px; POSITION: absolute; TOP: 200px" runat="server" Font-Bold="True">Add a New Ontology Definition:</asp:label><asp:dropdownlist id=ddlXML style="Z-INDEX: 101; LEFT: 160px; POSITION: absolute; TOP: 104px" runat="server" Width="200px"></asp:dropdownlist><asp:button id=bGenerate style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 136px" runat="server" Width="96px" Text="Generate Tree"></asp:button><INPUT 
id=browseFile style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 224px" 
type=file name=File1 runat="server"> <asp:button id=bUpload style="Z-INDEX: 104; LEFT: 24px; POSITION: absolute; TOP: 256px" runat="server" Width="120px" Text="Upload New XML"></asp:button><asp:label id=Status style="Z-INDEX: 105; LEFT: 24px; POSITION: absolute; TOP: 376px" runat="server" Width="336px" Height="56px" Font-Bold="True" ForeColor="Red" Font-Size="Medium"></asp:label><asp:label id=Label1 style="Z-INDEX: 106; LEFT: 24px; POSITION: absolute; TOP: 104px" runat="server" Font-Bold="True">View an Ontology:</asp:label><asp:label id=Label3 style="Z-INDEX: 109; LEFT: 32px; POSITION: absolute; TOP: 32px" runat="server" Width="232px" Height="36px" ForeColor="Purple" Font-Size="X-Large">Ontology Viewer</asp:label><asp:hyperlink id=HyperLink1 style="Z-INDEX: 110; LEFT: 24px; POSITION: absolute; TOP: 336px" runat="server" NavigateUrl="CreateDef.aspx">click here for instructions.</asp:hyperlink><asp:label id=Label4 style="Z-INDEX: 111; LEFT: 24px; POSITION: absolute; TOP: 312px" runat="server" Height="20px">If you'd like to create your own Ontology Definition XML files, </asp:label>
<asp:Label id=lblNotes style="Z-INDEX: 112; LEFT: 456px; POSITION: absolute; TOP: 72px" runat="server" Width="280px" Height="64px"></asp:Label></form>
	</body>
</HTML>
