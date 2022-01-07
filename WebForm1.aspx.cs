using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1Lab.Controllers
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        SoundPlayer splayer = new SoundPlayer(@"C:/Users/ahmed/Desktop/New folder (10)/WebProj/WebProj/SFX/Sound.wav");
        protected void Page_Load(object sender, EventArgs e)
        {
            ManageUI();
            RefreshConversation();
            if (Application["ImageUrl"] != null)
            {
                Image2.ImageUrl = (string)Application["ImageUrl"];
                Image2.Height = 200;
                Image2.Width = 200;

            }
            if (Application["SoundUrl"] != null)
            {

                Literal1.Text = "<audio Controls autoplay><Source src =" + (string)Application["SoundUrl"] + " type=audio/mpeg></video>";



            }
            //ButtonSubmitID.Text = Session.Timeout.ToString();
            //TextBoxUserID.Text=this.Session.Timeout.ToString();
        }
        //step1
        protected string GetUserID()
        {
            string strUserID = (string)Session["UserID"];
            return strUserID;
        }
        //step 2
        void ManageUI()
        {
            if (GetUserID() == null)
            {
                // if this is the first request, then get the user’s ID
                MsgBox.Enabled = false;
                DisplayMsg.Enabled = false;
                SendButton.Enabled = false;
                EnterName.Enabled = true;
                NameBox.Enabled = true;
                UploadBtn.Enabled = false;
                FileUpload1.Enabled = false;
                
            }
            else
            {
               //else
                MsgBox.Enabled = true;
                DisplayMsg.Enabled = true;
                SendButton.Enabled = true;
                EnterName.Enabled = false;
                NameBox.Enabled = false;
                UploadBtn.Enabled = true;
                FileUpload1.Enabled = true;
            }
            

        }
        //step 1
        protected void EnterName_Click(object sender, EventArgs e)
        {
            if(NameBox.Text != "")
            {
                Session["UserID"] = NameBox.Text;
                
            }

            ManageUI();
        }

        void RefreshConversation()
        {
            List<string> messages = (List<string>)Cache["Messages"];
           
            if (messages != null)
            {
                string Conversation = "";
                //bt3d 3dd elements el mwgwoda fe el array
                int nMessages = messages.Count;

                //a5r message btprint mn fo22
                for (int i = nMessages - 1; i >= 0; i--)
                {
                    string s;
                    s = messages[i];
                    Conversation += s;
                    Conversation += "\r\n";
                }
                DisplayMsg.Text = Conversation;
            }

        }
        
        protected void SendBtn_Click(object sender, EventArgs e)
        {
            if (MsgBox.Text.Length > 0)
            {
                List<string> messages = (List<string>)Cache["Messages"];
                if (messages != null)
                {
                    DisplayMsg.Text = "";
                    string strUserID = GetUserID();
                   
                    if (strUserID != null)
                    {
                        messages.Add(strUserID + ": " + MsgBox.Text);
                       
                        splayer.Play();
                        RefreshConversation();
                        MsgBox.Text = "";
                    }
                }
            }
           
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {

            
            if (FileUpload1.HasFile)
            {
                string fileExtension = Path.GetExtension(FileUpload1.FileName);
                if (fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".gif")
                {
                    //C:\Users\ahmed\Desktop\New folder (10)\WebProj\WebProj\Media
                    FileUpload1.SaveAs("C:/Users/ahmed/Desktop/New folder (10)/WebProj/WebProj/Media/" + FileUpload1.FileName);
                    Application["ImageUrl"] = "/Media/" + FileUpload1.FileName;

                }


                if (fileExtension.ToLower() == ".wav" || fileExtension.ToLower() == ".mp3" || fileExtension.ToLower() == ".ogg")
                {
                    FileUpload1.SaveAs("C:/Users/ahmed/Desktop/New folder (10)/WebProj/WebProj/Media/" + FileUpload1.FileName);
                    Application["SoundUrl"] = "/Media/" + FileUpload1.FileName;


                }

            }


        }

        protected void DisplayMsg_TextChanged(object sender, EventArgs e)
        {

        }
        //box el keber
        protected void DisplayMsg_TextChanged1(object sender, EventArgs e)
        {

        }
        //box el name
        protected void NameBox_TextChanged(object sender, EventArgs e)
        {

        }
        //el bn nktb feh
        protected void MsgBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}