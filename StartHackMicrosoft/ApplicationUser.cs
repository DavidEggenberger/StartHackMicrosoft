using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ApplicationUser : IdentityUser
    {
        public bool PrivateProfile { get; set; }
        public int TabsOpen { get; set; }
        public bool IsOnline { get; set; }
        public string Motto { get; set; }
    }
}
