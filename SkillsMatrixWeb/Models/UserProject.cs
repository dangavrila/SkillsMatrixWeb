﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Models
{
    public class UserProject : IdentityUser
    {
        public int Id { get; set; }
        public DateTime EnrollDate { get; set; }
    }
}