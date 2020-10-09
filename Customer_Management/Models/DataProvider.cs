using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer_Management.Models
{
    public static class DataProvider
    {
        /// <summary>
        /// Khai báo 1 thuộc tính để truy xuất và làm việc với db qua EF
        /// </summary>
        private static Customer_Management_Context _Entities = null;

        public static Customer_Management_Context Entities
        {
            get
            {
                if (_Entities == null)
                {
                    _Entities = new Customer_Management_Context();
                }
                return _Entities;
            }
            set
            {
                _Entities = value;
            }
        }
    }
}