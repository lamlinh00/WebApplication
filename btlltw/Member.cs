using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace btlltw
{
    public class Member
    {
        string NickName;
        int id;
        string pass;
        Boolean gen;

        public string NickName1 { get => NickName; set => NickName = value; }
        public int Id { get => id; set => id = value; }
        public string Pass { get => pass; set => pass = value; }
        public Boolean Gen { get => gen; set => gen = value; }
    }
}