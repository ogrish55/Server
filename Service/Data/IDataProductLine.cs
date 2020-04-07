﻿using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public interface IDataProductLine
    {
        void UpdateProductProductLine(ServiceProductLine serviceProductLine);
        void InsertProductLine(ServiceProductLine serviceProductLine);
        void DeleteProductLine(int productLineId);
    }
}
