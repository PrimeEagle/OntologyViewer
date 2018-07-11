<%@ Page language="c#" Codebehind="CreateDef.aspx.cs" AutoEventWireup="false" Inherits="OntView.CreateDef" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>CreateDef</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="GridLayout">
	
    <form id="CreateDef" method="post" runat="server">
<asp:Label id=Label1 style="Z-INDEX: 101; LEFT: 88px; POSITION: absolute; TOP: 40px" runat="server" Width="472px" Height="56px">Download the OntConv tool. This will convert Visio documents to a compliant XML format. These Visio files must be created using the Ontology stencil, and should not contain any shapes that are not in this stencil. Note that you need Visio installed on your machine to use this tool!</asp:Label>
<asp:Label id=Label4 style="Z-INDEX: 106; LEFT: 88px; POSITION: absolute; TOP: 216px" runat="server" Width="472px" Height="24px">Upload the generated XML file, using the website, and you're ready to go!</asp:Label>
<asp:Label id=Label3 style="Z-INDEX: 102; LEFT: 64px; POSITION: absolute; TOP: 40px" runat="server" Font-Bold="True">1</asp:Label>
<asp:Label id=Label2 style="Z-INDEX: 103; LEFT: 64px; POSITION: absolute; TOP: 216px" runat="server" Font-Bold="True">2</asp:Label>
<asp:HyperLink id=HyperLink1 style="Z-INDEX: 104; LEFT: 88px; POSITION: absolute; TOP: 136px" runat="server" NavigateUrl="OntConv_Setup.zip">Download OntConv Tool</asp:HyperLink>
<asp:HyperLink id=HyperLink2 style="Z-INDEX: 105; LEFT: 88px; POSITION: absolute; TOP: 160px" runat="server" NavigateUrl="Ontology.vss">Download Ontology Stencil for Visio</asp:HyperLink>
<asp:HyperLink id=HyperLink3 style="Z-INDEX: 107; LEFT: 88px; POSITION: absolute; TOP: 280px" runat="server" NavigateUrl="Default.aspx">Back to the Ontology Viewer</asp:HyperLink>

     </form>
	
  </body>
</HTML>
