﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace btlltw
{
    public partial class GioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Cart> idcarts = new List<Cart>();

            idcarts = (List<Cart>)Session["Cart"];

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

            
            string html = "";
            int i = 0;
            foreach (Cart cart in idcarts)
            {
                i++;
                if ((string)Convert.ToString(Session["id"]) == cart.IdMb)
                {
                    Product find_Product = list.Find(item => item.Id == cart.IdProd && cart.IdMb == Convert.ToString(Session["id"]));
                    /*foreach (Product product in list)
                    {
                        if ((string) Convert.ToString(Session["id"]) == cart.IdMb)
                        {
                            if (cart.IdProd == product.Id)
                            {
                                listInCart.Add(product);
                            }
                        }
                    }*/
                    foreach(Product product in list) {
                        if (Convert.ToString(Session["id"]) == cart.IdMb)
                        {
                            if (cart.IdProd == product.Id)
                            {
                                list.Add(product);
                            }
                        }
                    }

                    if (find_Product != null)
                    {
                        html += "<div class='chitietdondathang box effect3'>" +
                                    "<div class='row'>" +
                                        "<div class='col-xs-12 col-sm-6 col-md-3 col-lg-3'>" +
                                            "<label class='checkbox-inline'>";
                        html += "<img src='" + find_Product.Url_img + "' height='auto' width='100%' alt=''>";
                        html += "</label>";
                        html += "</div>";
                        html += "<div class='col-xs-12 col-sm-6 col-md-4 col-lg-4'>";
                        html += "<h4>" + find_Product.Tensp + "</h4>";
                        html += "</div>";
                        html += "<div class='col-xs-12 col-sm-6 col-md-2 col-lg-2'>";
                        if (find_Product.Giamgia > 0)
                        {
                            html += "<h4 style='color:orange;'>" + find_Product.Gia * (100 - find_Product.Giamgia) / 100 + " vnd</h4>";
                            html += "<del>Price: " + find_Product.Gia + " vnd</del>";
                            html += "<h5>Discount: " + find_Product.Giamgia + " %</h5>";
                        }
                        else
                        {
                            html += "<h4 style='color:orange;'>" + find_Product.Gia + " </h4>";
                        }
                        html += "</div>";
                        html += "<div class='col-xs-12 col-sm-6 col-md-3 col-lg-3'>";
                        html += "<button class='btn btn-basic' type='submit' value='" + find_Product.Id + "' id='btnXoa' name='btnXoa' runat='server'>" +
                                                "<i class='fa fa-trash' aria-hidden='true'></i> Xóa" +
                                            "</button>";
                        html += "</div>";
                        html += "</div>";
                        html += "</div>";
                        
                    }
                }
                listCart.InnerHtml = html;
                txtTongsp.InnerText = "Tạm tính (" + i +  ") sản phẩm";
            }


            if (Request.Form["btnXoa"] != null)
            {
                idcarts = (List<Cart>)Session["Cart"];
                var itemToRemove = idcarts.SingleOrDefault(pro => pro.IdProd == Convert.ToInt32(Request.Form["btnXoa"]));
                    if (itemToRemove != null)
                    idcarts.Remove(itemToRemove);
                    Session["Cart"] = idcarts;
                Response.Redirect("GioHang.aspx");
            }
        }
    }
}