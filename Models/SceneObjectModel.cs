﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_test.Models
{
    internal class SceneObjectModel: BaseEntity
    {
        public string Name { get; set; } = "";
        public int SortOrder { get; set; } = 0;
    }
}
