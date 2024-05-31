﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMMLDotNetCore.ConsoleApp.Model
{
    [Table("Tbl_Blog")]
    public class BlogModel
    {
        [Key]
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
