using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDistributionOutlet.Models
{
    public class SearchProductModel
    {
        //product description detail
        public bool m_add_new_product;
        public long m_productId;
        public string m_productPrice;
        public string m_productSize;
        public string m_productWeight;
        public string m_productColor;
        //product description
        public string m_productDescriptionLong;
        public string m_productPicture;
        //product
        public string m_productSerialNumber;
        public string m_productName;
        public Dictionary<long, string> copiedProducts;

        //product edit mode
        public bool isInEditMode = false;

        //supplier details
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

        //supplier

        public Dictionary<string, string> supplierShipment_D_Model;

        //shipment
        public bool m_add_new_shipment;
        public string m_shipmentCountry;
        public string m_shipmentCity;
        public string m_shipmentProvince;
        public DateTime? m_shipmentDate;
        public DateTime? m_shipmentEstimatedArrivalDate;
        public DateTime? m_shipmentArrivalDate;
        public string m_shipmentMethod;
        public long? m_shipmentNumberOfProductsGeneral;
        public long m_shipmentNumberOfBoxes;
        public long m_shipmentNumberofPacks;
        public long m_shipmentNumberOfProductsDetail;
        public long m_shipmentNumberOfProductsPerPack;
        public long m_shipmentNumberOfPacksPerBox;

    }
}