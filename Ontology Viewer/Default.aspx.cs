using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.IO;
using Microsoft.Web.UI.WebControls;
using System.Xml;

namespace OntView {
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page {
		protected System.Web.UI.WebControls.DropDownList ddlXML;
		protected System.Web.UI.WebControls.Button bGenerate;
		protected System.Web.UI.WebControls.Button bUpload;
		protected System.Web.UI.HtmlControls.HtmlInputFile browseFile;
		protected System.Web.UI.WebControls.Label Status;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblNotes;
		protected Microsoft.Web.UI.WebControls.TreeView tvOnt;
		protected System.Web.UI.WebControls.Label Label5;
		Hashtable htNotes = new Hashtable();
	
		private void Page_Load(object sender, System.EventArgs e) {
			// Put user code to initialize the page here
			try {
				if (!Page.IsPostBack) {
					RefreshData();
					Status.Text = "";
				}
			} catch(Exception exc) {
				Status.Text = "EXCEPTION: " + exc.Message;
			}
		}

		private string ExtractFileName(string path) {
			string[] tokens;
			char[] splitter = {'\\'};
			
			try {
				tokens = path.Split(splitter);
				Status.Text = "";
				return tokens[tokens.Length - 1];
			} catch(Exception exc) {
				Status.Text = "EXCEPTION: " + exc.Message;
				return "";
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e) {
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {    
			this.tvOnt.SelectedIndexChange += new Microsoft.Web.UI.WebControls.SelectEventHandler(this.tvOnt_SelectedIndexChange);
			this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
			this.bUpload.Click += new System.EventHandler(this.bUpload_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void RefreshData() {
			
			ddlXML.Items.Clear();
			string [] fileEntries = Directory.GetFiles(Server.MapPath(null) + "/xml");
			foreach(string fileName in fileEntries) {
				if(fileName.Substring(fileName.Length - 4, 4) == ".xml") {
					ddlXML.Items.Add(ExtractFileName(fileName));
				}
			}
		}
		private void bUpload_Click(object sender, System.EventArgs e) {
			string path = Server.MapPath(null) + "\\xml";

			if (browseFile.PostedFile != null) {
				try {
					string fileName = ExtractFileName(browseFile.PostedFile.FileName);
					if (fileName.Substring(fileName.Length - 4, 4) == ".xml") {
						browseFile.PostedFile.SaveAs(path + "//" + fileName);
						Status.Text = "";
						RefreshData();
					} else {
						Status.Text = "Only XML Documents (*.xml) may be uploaded.";
					}
				} catch (Exception exc) {
					Status.Text = "Exception: " + exc.Message;
				}
			}
		}

		private void bGenerate_Click(object sender, System.EventArgs e) {
			XmlDocument xmlDoc = new XmlDocument();

			try {
				xmlDoc.Load(Server.MapPath(null) + "\\xml" + "\\" + ddlXML.SelectedItem.Text);

				XmlNode xmlRootNode = xmlDoc.GetElementsByTagName("TREENODES").Item(0);

				tvOnt.Nodes.Clear();
				XmlNode childNode = xmlRootNode.FirstChild;
				while (childNode != null) {
					TreeNode treeNode = new TreeNode();
					treeNode.Text = childNode.Attributes["Text"].Value;
					treeNode.ID = childNode.Attributes["ID"].Value;
					htNotes.Add(childNode.Attributes["ID"].Value, childNode.Attributes["Notes"].Value);
					//Debug.WriteLine(childNode.Attributes["ID"].Value + " --- " + (string)htNotes[childNode.Attributes["ID"].Value]);
					GenerateFromRoot(childNode, treeNode);
					tvOnt.Nodes.Add(treeNode);

					childNode = childNode.NextSibling;
					Session.Add("notes", htNotes);
				}
				Status.Text = "";
				lblNotes.Text = (string)htNotes[tvOnt.GetNodeFromIndex(tvOnt.SelectedNodeIndex).ID];
			} catch(Exception exc) {
				Status.Text = "EXCEPTION: " + exc.Message;
			}
		}

		private void GenerateFromRoot(XmlNode xmlLastRoot, TreeNode treeLastRoot) {
			try {
				XmlNode xmlSibling = xmlLastRoot.FirstChild;
				while (xmlSibling != null) {
					TreeNode treeChild = new TreeNode();
					treeChild.ID = xmlSibling.Attributes["ID"].Value;
					treeChild.Text = xmlSibling.Attributes["Text"].Value;
					htNotes.Add(xmlSibling.Attributes["ID"].Value, xmlSibling.Attributes["Notes"].Value);
					//Debug.WriteLine(xmlSibling.Attributes["ID"].Value + " --- " + (string)htNotes[xmlSibling.Attributes["ID"].Value]);
					treeLastRoot.Nodes.Add(treeChild);
					if (xmlSibling.HasChildNodes) {
						GenerateFromRoot(xmlSibling, treeChild);
					}
					xmlSibling = xmlSibling.NextSibling;				
				}
			} catch(Exception exc) {
				Status.Text = "EXCEPTION: " + exc.Message;
			}
		}

		public void tvOnt_SelectedIndexChange(object sender, Microsoft.Web.UI.WebControls.TreeViewSelectEventArgs e) {
			string k = tvOnt.GetNodeFromIndex(e.NewNode).ID;
			Hashtable htSessionNotes;
			htSessionNotes = (Hashtable)Session["notes"];

			//Debug.WriteLine(htSessionNotes.Count + " items in hashtable.");
			//Debug.WriteLine("Checking for key: '" + k + "' ...");
			if (htSessionNotes.ContainsKey(k)) {
				string n = (string)htSessionNotes[k];
				//Debug.WriteLine("     Found !: '" + n + "'");
				lblNotes.Text = n;
			} else {
				//Debug.WriteLine("     not found.");
			}
		}
	}
}