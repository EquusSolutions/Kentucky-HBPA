using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public static class RoleName
    {
        public const string Administrator = "Administrator";
        public const string Staff = "Staff";
    }

    public enum Role
    {
        Administrator,
        Staff,
        Member
    }
}