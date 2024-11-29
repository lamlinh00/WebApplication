using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace btlltw
{
    public class Product
    {
        int id;
        string tensp;
        string url_img;
        float gia;
        float giamgia;

        public int Id { get => id; set => id = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public float Gia { get => gia; set => gia = value; }
        public string Url_img { get => url_img; set => url_img = value; }
        public float Giamgia { get => giamgia; set => giamgia = value; }
    }
}