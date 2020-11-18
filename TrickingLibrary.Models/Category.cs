﻿using System.Collections.Generic;

namespace TrickingLibrary.Models
{
    public class Category : BaseModel<string>
    {
        public string Name { get; set; }
        public string Descrption { get; set; }
        public IList<TrickCategory> Tricks { get; set; }
    }
}