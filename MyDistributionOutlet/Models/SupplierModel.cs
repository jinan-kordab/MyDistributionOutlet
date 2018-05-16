using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDistributionOutlet.Models
{
    public class SupplierModel
    {
        public long m_supplierId;
        public string m_supplierName;
        public string m_supplierCountry;
        public string m_supplierProvince;
        public string m_supplierCity;
        public string m_supplierPostalCode;
        public string m_supplierTelephone;
        public string m_supplierFax;
        public string m_supplierEmail;
        public string m_supplierStreet;
        public string m_supplierUnitNumber;

        public long m_shipment_id;
        public DateTime m_shipment_date;

    }
}