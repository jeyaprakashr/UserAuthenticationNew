namespace DataAccess
{
    using System;
    using System.Collections.Generic;

    public class Customer
    {
        public string CustomerCode { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string InActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }

        //public List<SelectListItem> GetCountryCode { get; set; }
        //public List<SelectListItem> GetStateCode { get; set; }
        //public List<SelectListItem> GetCompany { get; set; }
        //public int RecordCount { get; set; }
    }
}
