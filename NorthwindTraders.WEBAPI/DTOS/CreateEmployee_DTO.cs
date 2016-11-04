﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindTraders.WEBAPI.DTOS
{
    public class CreateEmployee_DTO
    {
        ///  <summary>
        /// LastName read write string
        /// </summary>
        public string LastName { get; set; }
        ///  <summary>
        /// FirstName read write string
        /// </summary>
        public string FirstName { get; set; }
        ///  <summary>
        /// Title read write string
        /// </summary>
        public string Title { get; set; }
        ///  <summary>
        /// HomePhone read write string
        /// </summary>
        public string HomePhone { get; set; }
        ///  <summary>
        /// HireDate read write date time
        /// </summary>
        public DateTime? HireDate { get; set; }
    }
}