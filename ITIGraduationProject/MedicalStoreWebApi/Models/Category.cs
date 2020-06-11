﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicalStoreWebApi.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
      //  [Display("Category Name")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}