using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace btlltw
{
    public partial class QuanLyTaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string) Session["NickName"] != "admin@gmail.com" || (bool) Session["login"] == false)
            {
                Response.Redirect("TrangChu.aspx");
            }
            string path = "listMember.xml";


            Table_Load();
        
            List<Member> list = new List<Member>();

            if (File.Exists(Server.MapPath(path)))
            {
                // Đọc file
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
                StreamReader file = new StreamReader(Server.MapPath(path));

                list = (List<Member>)reader.Deserialize(file);
                list = list.OrderBy(Member => Member.Id).ToList();
                file.Close();
            }
            
            if (Request.Form["btnThem"] == "true")
            {
                Member member = new Member();

                member.Id = list.Count;
                member.NickName1 = Request.Form["txtEmail"];
                member.Pass = Request.Form["txtPass"];

                bool checktrung = false;
                foreach (Member mem in list)
                {
                    if (mem.NickName1.Equals(member.NickName1))
                    {
                        checktrung = true;
                        member.Id = mem.Id;
                        break;
                    }
                }

                if (!checktrung)
                {
                    foreach (Member mem in list)
                    {
                        if (mem.Id == member.Id)
                        {
                            member.Id++;
                        }
                    }
                    list.Add(member);
                    //Ghi file
                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));

                    System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));

                    writer.Serialize(_file, list);
                    _file.Close();

                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                    string alert = "";
                    alert += "<script>alert('Tài khoản đã tồn tại!');</script>";
                    Response.Write(alert);
                }
            }

            foreach(Member mb in list)
            {
                if(Request.Form["btnXoa"] == Convert.ToString(mb.Id))
                {
                    list.Remove(mb);
                    //Ghi file
                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));

                    System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));

                    writer.Serialize(_file, list);
                    _file.Close();

                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    break;
                }
            }
        }

        private void Table_Load()
        {
            string path = "listMember.xml";

            List<Member> list = new List<Member>();

            if (File.Exists(Server.MapPath(path)))
            {
                // Đọc file
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
                StreamReader file = new StreamReader(Server.MapPath(path));

                list = (List<Member>)reader.Deserialize(file);
                list = list.OrderBy(Member => Member.Id).ToList();
                file.Close();
            }

            foreach (Member mb in list)
            {
                TableRow row = new TableRow();

                TableCell cId = new TableCell();
                cId.Text = Convert.ToString(mb.Id);
                row.Cells.Add(cId);

                TableCell cNickname = new TableCell();
                cNickname.Text = Convert.ToString(mb.NickName1);
                row.Cells.Add(cNickname);

                TableCell cPass = new TableCell();
                cPass.Text = Convert.ToString(mb.Pass);
                row.Cells.Add(cPass);

                string html = "<button type=\"submit\" value=\""+ mb.Id +"\" class=\"btn btn-basic\" name=\"btnXoa\">" +
                                    "<i class=\"fa fa-trash\" aria-hidden=\"true\"></i> Xóa</button>";
                TableCell cButton = new TableCell();
                cButton.Text = html;
                row.Cells.Add(cButton);
           
                table.Rows.Add(row);
            }
        }
    }
}