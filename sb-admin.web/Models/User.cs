using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sb_admin.web.Models
{
    public class User
    {
        public int Id { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public bool estatus { get; set; }
        public bool RememberMe { get; set; }

    }
}