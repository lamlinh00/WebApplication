using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace btlltw
{
    public partial class Trangchu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = "listProduct.xml";

            List<Product> list = new List<Product>();

            if (File.Exists(Server.MapPath(path)))
            {
                // Đọc file
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Product>));
                StreamReader file = new StreamReader(Server.MapPath(path));

                list = (List<Product>)reader.Deserialize(file);
                list = list.OrderByDescending(Product => Product.Id).ToList();
                file.Close();
            }

            int count = 0;

            string html = "";

            foreach (Product product in list)
            {
                if (count < 4)
                {
                    count++;
                }
                else { break; }

                html += "<div class=\"col-xs-12 col-sm-6 col-md-3 col-lg-3 product\">";
                html += "<a href=ChiTietMatHang.aspx?id=" + product.Id + ">";
                html += "<div class=\"anhproduct\">" +
                                    "<img src=\"" + product.Url_img + "\" width=\"100%\" alt=\"\">" +
                                "</div>";
                if (product.Giamgia > 0)
                {
                    html += "<div class=\"infoproduct\">";
                    html += "<center><p>" + product.Giamgia + " %</p></center>";
                    html += "</div>";
                    html += "<div class=\"infonew\">";
                    html += "<center><p>sale</p></center>";
                    html += "</div>";
                }
                html += "<div class=\"addclass\">";
                html += "<center>";
                html += "<div class=\"iconadd\">";
                html += "<button type=\"submit\" class=\"btn\" value=\"" + product.Id + "\" name=\"btnAddWish\">" +
                                                "<i class=\"fa fa-heart - o\" aria-hidden=\"true\"></i>" +
                                            "</button>";
                html += "<button type=\"submit\" class=\"btn\" value=\"" + product.Id + "\" name=\"btnAddCart\">" +
                                                "<i class=\"fa fa-shopping-cart\" aria-hidden=\"true\"></i>" +
                                            "</button>";
                html += "</div>";
                html += "</center>";
                html += "<center>";
                html += "<h4>" + product.Tensp + "</h4>";
                if (product.Giamgia > 0)
                {
                    html += "<h5 class=\"colorprice\"><b>" + product.Gia * (100 - product.Giamgia) / 100 + " vnd</b> &nbsp<del><i>" + product.Gia + " vnd</i></del></h5>";
                }
                else
                {
                    html += "<h5 class=\"colorprice\"><b>" + product.Gia + " vnd</b></h5>";
                }
                html += "</center>";
                html += "</div>";
                html += "</a>";
                html += "</div>";
            }

            listNewProduct.InnerHtml = html;

            html = "";
            count = 0;
            foreach(Product product in list)
            {
                if (count < 8)
                {
                    count++;
                }
                else { break; }

                if (product.Giamgia == 0)
                {
                    count--;
                    continue;
                }
                else
                {
                    html += "<div class=\"col-xs-12 col-sm-6 col-md-3 col-lg-3 product\">";
                    html +=     "<a href=ChiTietMatHang.aspx?id=" + product.Id + ">";
                    html +=         "<div class=\"anhproduct\">" +
                                        "<img src=\"" + product.Url_img + "\" width=\"100%\" alt=\"\">" +
                                    "</div>";
                    if (product.Giamgia > 0)
                    {
                        html +=     "<div class=\"infoproduct\">";
                        html +=         "<center><p>" + product.Giamgia + " %</p></center>";
                        html +=     "</div>";
                        html +=     "<div class=\"infonew\">";
                        html +=         "<center><p>sale</p></center>";
                        html +=     "</div>";
                    }
                    html +=         "<div class=\"addclass\">";
                    html +=             "<center>";
                    html +=                 "<div class=\"iconadd\">";
                    html +=                     "<button type=\"submit\" class=\"btn\" value=\"" + product.Id + "\" name=\"btnAddWish\">" +
                                                    "<i class=\"fa fa-heart - o\" aria-hidden=\"true\"></i>" +
                                                "</button>";
                    html +=                     "<button type=\"submit\" class=\"btn\" value=\"" + product.Id + "\" name=\"btnAddCart\">" +
                                                    "<i class=\"fa fa-shopping-cart\" aria-hidden=\"true\"></i>" +
                                                "</button>";
                    html +=                 "</div>";
                    html +=             "</center>";
                    html +=             "<center>";
                    html +=                 "<h4>" + product.Tensp + "</h4>";
                    if (product.Giamgia > 0)
                    {
                        html +=             "<h5 class=\"colorprice\"><b>" + product.Gia * (100 - product.Giamgia) / 100 + " vnd</b> &nbsp<del><i>" + product.Gia + " vnd</i></del></h5>";
                    }
                    else
                    {
                        html +=             "<h5 class=\"colorprice\"><b>" + product.Gia + " vnd</b></h5>";
                    }
                    html +=             "</center>";
                    html +=         "</div>";
                    html +=     "</a>";
                    html += "</div>";
                }

                listBestProduct.InnerHtml = html;

            }
                if (Request.Form["btnAddCart"] != null)
                {
                    List<Cart> carts = (List<Cart>)Session["Cart"];

                    IPHostEntry Ip = new IPHostEntry();
                    string HostName = Dns.GetHostName();
                    Ip = Dns.GetHostByName(HostName);

                    if ((bool)Session["login"] == true)
                    {
                        Cart cart = new Cart((string) Convert.ToString(Session["id"]), Convert.ToInt32(Request.Form["btnAddCart"]));
                        carts.Add(cart);
                    }
                    //else
                    //{
                    //    Cart cart = new Cart(Ip.ToString(), Convert.ToInt32(Request.Form["btnAddCart"]));
                    //    carts.Add(cart);
                    //}
                    else
                {
                    Cart cart = new Cart(Ip.ToString(), Convert.ToInt32(Request.Form["btnAddCatr"]));
                    carts.Add(cart);
                }

                    Session["Cart"] = carts;
                 }
        }
    }
}