using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyDistributionOutlet.EntityFramework;
using MyDistributionOutlet.Models;

namespace MyDistributionOutlet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(FormCollection w_formCollection)
        {
            string searchTerm = w_formCollection["searchDialog"].ToString();
            string byProduct = w_formCollection["cbProduct"] == null ? "off" : "on";
            string byShipment = w_formCollection["cbShipment"] == null ? "off" : "on";
            string gView = w_formCollection["cbGridview"] == null ? "off" : "on";

            SearchProductModelList spml = new SearchProductModelList();

            List<SearchProductModel> sp = new List<SearchProductModel>();

            using (var searchPhrase = new WH01Entities())
            {


                if (byProduct == "on" && byShipment == "on")
                {

                }
                //only search products
                else if (byProduct == "on" && byShipment == "off")
                {
                    var searchProductresults = from i in searchPhrase.PRODUCT_DESCRIPTION_DETAIL
                                               where i.PRODUCT_DESCRIPTION.PRODUCT.productName.Contains(searchTerm)

                                               select new SearchProductModel()
                                               {
                                                   m_productId = i.PRODUCT_DESCRIPTION.PRODUCT.productID,
                                                   m_productName = i.PRODUCT_DESCRIPTION.PRODUCT.productName,
                                                   m_productSerialNumber = i.PRODUCT_DESCRIPTION.PRODUCT.productSerialNumber,
                                                   m_productDescriptionLong = i.PRODUCT_DESCRIPTION.productDescLong,
                                                   m_productPrice = i.productPrice,
                                                   m_productSize = i.productSize,
                                                   m_productColor = i.productColor,
                                                   m_productWeight = i.productWeight,

                                               };


                    List<SearchProductModel> pmltemp = new List<SearchProductModel>();
                    pmltemp = searchProductresults.ToList();

                    foreach (var searchProduct in pmltemp)
                    {
                        var supplierForProductQuery = from s in searchPhrase.SHIPMENT_PRODUCT_DETAIL
                                                      where (s.productID == searchProduct.m_productId)

                                                      select new SearchProductModel()
                                                      {
                                                          m_supplierId = s.SHIPMENT_DETAIL.SHIPMENT.SHIPMENT_SUPPLIER.Select(sup => sup.SUPPLIER.supplierID).FirstOrDefault(),
                                                          m_supplierName = s.SHIPMENT_DETAIL.SHIPMENT.SHIPMENT_SUPPLIER.Select(sup => sup.SUPPLIER.supplierName).FirstOrDefault(),
                                                          m_supplierCity = s.SHIPMENT_DETAIL.SHIPMENT.SHIPMENT_SUPPLIER.Select(sup => sup.SUPPLIER.supplierCity).FirstOrDefault(),
                                                          m_supplierCountry = s.SHIPMENT_DETAIL.SHIPMENT.SHIPMENT_SUPPLIER.Select(sup => sup.SUPPLIER.COUNTRY.countryName).FirstOrDefault(),
                                                          m_supplierEmail = s.SHIPMENT_DETAIL.SHIPMENT.SHIPMENT_SUPPLIER.Select(sup => sup.SUPPLIER.supplierEmail).FirstOrDefault(),
                                                          m_supplierFax = s.SHIPMENT_DETAIL.SHIPMENT.SHIPMENT_SUPPLIER.Select(sup => sup.SUPPLIER.supplierFax).FirstOrDefault(),
                                                          m_supplierPostalCode = s.SHIPMENT_DETAIL.SHIPMENT.SHIPMENT_SUPPLIER.Select(sup => sup.SUPPLIER.supplierPostalCode).FirstOrDefault(),
                                                          m_supplierProvince = s.SHIPMENT_DETAIL.SHIPMENT.SHIPMENT_SUPPLIER.Select(sup => sup.SUPPLIER.supplierProvince).FirstOrDefault(),
                                                          m_supplierStreet = s.SHIPMENT_DETAIL.SHIPMENT.SHIPMENT_SUPPLIER.Select(sup => sup.SUPPLIER.supplierStreet).FirstOrDefault(),
                                                          m_supplierTelephone = s.SHIPMENT_DETAIL.SHIPMENT.SHIPMENT_SUPPLIER.Select(sup => sup.SUPPLIER.supplierTelephone).FirstOrDefault(),
                                                          m_supplierUnitNumber = s.SHIPMENT_DETAIL.SHIPMENT.SHIPMENT_SUPPLIER.Select(sup => sup.SUPPLIER.supplierUnitNumber).FirstOrDefault(),
                                                          m_shipmentCountry = s.SHIPMENT_DETAIL.SHIPMENT.COUNTRY.countryName,
                                                          m_shipmentCity = s.SHIPMENT_DETAIL.SHIPMENT.shipmentCity,
                                                          m_shipmentProvince = s.SHIPMENT_DETAIL.SHIPMENT.shipmentProvince,
                                                          m_shipmentDate = s.SHIPMENT_DETAIL.shipmentDate,
                                                          m_shipmentEstimatedArrivalDate = s.SHIPMENT_DETAIL.shipmentEstimatedArrivalDate,
                                                          m_shipmentArrivalDate = s.SHIPMENT_DETAIL.shipmentArrivalDate,
                                                          m_shipmentMethod = s.SHIPMENT_DETAIL.shipmentMethod,
                                                          m_shipmentNumberOfProductsGeneral = s.SHIPMENT_DETAIL.numberOfProducts,
                                                          m_shipmentNumberOfBoxes = searchPhrase.PRODUCT_BOXING_DETAILS.Where(d => d.shipmentProductDetailsID.Equals(s.shipmentProductDetailsID)).Select(xo => xo.numberOfBoxes).FirstOrDefault(),
                                                          m_shipmentNumberofPacks = searchPhrase.PRODUCT_BOXING_DETAILS.Where(d => d.shipmentProductDetailsID.Equals(s.shipmentProductDetailsID)).Select(xo => xo.numberOfPacks).FirstOrDefault(),
                                                          m_shipmentNumberOfProductsDetail = searchPhrase.PRODUCT_BOXING_DETAILS.Where(d => d.shipmentProductDetailsID.Equals(s.shipmentProductDetailsID)).Select(xo => xo.numberOfProducts).FirstOrDefault(),
                                                          m_shipmentNumberOfProductsPerPack = searchPhrase.PRODUCT_BOXING_DETAILS.Where(d => d.shipmentProductDetailsID.Equals(s.shipmentProductDetailsID)).Select(xo => xo.numberOfProductsPerPack).FirstOrDefault(),
                                                          m_shipmentNumberOfPacksPerBox = searchPhrase.PRODUCT_BOXING_DETAILS.Where(d => d.shipmentProductDetailsID.Equals(s.shipmentProductDetailsID)).Select(xo => xo.numberOfPacksPerBox).FirstOrDefault()
                                                      };

                        var query = supplierForProductQuery.ToList();

                        //foreach (var suppplierShipment in pmltemp2)
                        //{
                        searchProduct.m_supplierId = Convert.ToInt32(query.Select(m => m.m_supplierId).FirstOrDefault());
                        searchProduct.m_supplierName = query.Select(m => m.m_supplierName).FirstOrDefault();
                        searchProduct.m_supplierCity = query.Select(m => m.m_supplierCity).FirstOrDefault();
                        searchProduct.m_supplierCountry = query.Select(m => m.m_supplierCountry).FirstOrDefault();
                        searchProduct.m_supplierEmail = query.Select(m => m.m_supplierEmail).FirstOrDefault();
                        searchProduct.m_supplierFax = query.Select(m => m.m_supplierFax).FirstOrDefault();
                        searchProduct.m_supplierPostalCode = query.Select(m => m.m_supplierPostalCode).FirstOrDefault();
                        searchProduct.m_supplierProvince = query.Select(m => m.m_supplierProvince).FirstOrDefault();
                        searchProduct.m_supplierStreet = query.Select(m => m.m_supplierStreet).FirstOrDefault();
                        searchProduct.m_supplierTelephone = query.Select(m => m.m_supplierTelephone).FirstOrDefault();
                        searchProduct.m_supplierUnitNumber = query.Select(m => m.m_supplierUnitNumber).FirstOrDefault();
                        searchProduct.m_shipmentCountry = query.Select(m => m.m_shipmentCountry).FirstOrDefault();
                        searchProduct.m_shipmentCity = query.Select(m => m.m_shipmentCity).FirstOrDefault();
                        searchProduct.m_shipmentProvince = query.Select(m => m.m_shipmentProvince).FirstOrDefault();
                        searchProduct.m_shipmentDate = query.Select(m => m.m_shipmentDate).FirstOrDefault();
                        searchProduct.m_shipmentEstimatedArrivalDate = query.Select(m => m.m_shipmentEstimatedArrivalDate).FirstOrDefault();
                        searchProduct.m_shipmentArrivalDate = query.Select(m => m.m_shipmentArrivalDate).FirstOrDefault();
                        searchProduct.m_shipmentMethod = query.Select(m => m.m_shipmentMethod).FirstOrDefault();
                        searchProduct.m_shipmentNumberOfProductsGeneral = query.Select(m => m.m_shipmentNumberOfProductsGeneral).FirstOrDefault();
                        searchProduct.m_shipmentNumberOfBoxes = query.Select(m => m.m_shipmentNumberOfBoxes).FirstOrDefault();
                        searchProduct.m_shipmentNumberofPacks = query.Select(m => m.m_shipmentNumberofPacks).FirstOrDefault();
                        searchProduct.m_shipmentNumberOfProductsDetail = query.Select(m => m.m_shipmentNumberOfProductsDetail).FirstOrDefault();
                        searchProduct.m_shipmentNumberOfProductsPerPack = query.Select(m => m.m_shipmentNumberOfProductsPerPack).FirstOrDefault();
                        searchProduct.m_shipmentNumberOfPacksPerBox = query.Select(m => m.m_shipmentNumberOfPacksPerBox).FirstOrDefault();


                        sp.Add(searchProduct);
                    }

                }
                //only searchshipments 
                else if (byShipment == "on" && byProduct == "off")
                {

                }
                spml.listofsearchproducts = sp;
                return gView == "on" ? View("GridSearch", spml) : View("SearchProduct", spml);
            }
        }
        
        public ActionResult CopyProduct(FormCollection s_formCollection)
        {

            var ModelToReturn = TempData["currModel"];
            var prodId = Convert.ToInt32(s_formCollection["hprodid"]);
            var UpdateContext = new EntityFramework.WH01Entities();

            var quwry = from pdet in UpdateContext.PRODUCT_DESCRIPTION
                        where pdet.productID == prodId
                        select pdet;

            foreach (PRODUCT_DESCRIPTION pd in quwry)
            {
                pd.prodctCopied = true;
            }

            UpdateContext.SaveChanges();


            return View("SearchProduct", ModelToReturn);
        }


        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Warehouse/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Warehouse/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Warehouse/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Warehouse/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Warehouse/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Warehouse/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult NewProduct()
        {
            SearchProductModel addProduct = new SearchProductModel();
            addProduct.m_add_new_product = true;
            addProduct.m_add_new_shipment = false;

            using (var searchPhrase = new WH01Entities())
            {
                var copiedProductsResult = from i in searchPhrase.PRODUCT_DESCRIPTION
                                           where i.prodctCopied == true
                                           select i;

                addProduct.copiedProducts = new Dictionary<long, string>();
                foreach (PRODUCT_DESCRIPTION pdesc in copiedProductsResult)
                {

                    addProduct.copiedProducts.Add(pdesc.productID, pdesc.PRODUCT.productName);
                }
            }


            return View("NewProduct", addProduct);
        }

        [HttpGet]
        public JsonResult PopulateCopiedProduct(long? productid)
        {
            SearchProductModel addProduct = new SearchProductModel();
            addProduct.m_add_new_product = true;
            addProduct.m_add_new_shipment = false;

            if (productid != null)
            {
                using (var searchCopiedProduct = new WH01Entities())
                {
                    var cptoadd = (from j in searchCopiedProduct.PRODUCT_DESCRIPTION_DETAIL
                                   where j.PRODUCT_DESCRIPTION.PRODUCT.productID == productid
                                   select new SearchProductModel()
                                   {
                                       m_productName = j.PRODUCT_DESCRIPTION.PRODUCT.productName,
                                       m_productDescriptionLong = j.PRODUCT_DESCRIPTION.productDescLong,
                                       m_productColor = j.productColor,
                                       m_productPrice = j.productPrice,
                                       m_productSize = j.productSize,
                                       m_productWeight = j.productWeight,
                                       m_productSerialNumber = j.PRODUCT_DESCRIPTION.PRODUCT.productSerialNumber

                                   }).SingleOrDefault();

                    addProduct.m_productName = cptoadd.m_productName;
                    addProduct.m_productDescriptionLong = cptoadd.m_productDescriptionLong;
                    addProduct.m_productColor = cptoadd.m_productColor;
                    addProduct.m_productPrice = cptoadd.m_productPrice;
                    addProduct.m_productSize = cptoadd.m_productSize;
                    addProduct.m_productWeight = cptoadd.m_productWeight;
                    addProduct.m_productSerialNumber = cptoadd.m_productSerialNumber;

                }


            }

            return Json(addProduct, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult GetAllProductsFromSupplier(string supplierID)
        {
            SearchProductModel productPerSupplier = new SearchProductModel();
            //productPerSupplier.m_add_new_product = false;
            //productPerSupplier.m_add_new_shipment = true;

            long suppliershipid = Convert.ToInt32(supplierID);

            string SQL = "SELECT * FROM PRODUCT INNER JOIN ";
            SQL += " SHIPMENT_PRODUCT_DETAIL ON PRODUCT.productID = SHIPMENT_PRODUCT_DETAIL.productID INNER JOIN ";
            SQL += " SHIPMENT_DETAIL ON SHIPMENT_PRODUCT_DETAIL.shipmentDetailsID = SHIPMENT_DETAIL.shipmentDetailsID INNER JOIN ";
            SQL += " SHIPMENT ON SHIPMENT_DETAIL.shipmentID = SHIPMENT.shipmentID ";
            SQL += " WHERE SHIPMENT.shipmentID = " + suppliershipid + "";


            using (var dbContext = new WH01Entities())
            {
                var products = dbContext.PRODUCT.SqlQuery(SQL).ToList();
            }



            //if (supplierShipmentID != null)
            //{
            //    using (var getProductPerSupplier = new WH01Entities())
            //    {
            //        var cptoadd = (from j in getProductPerSupplier.SHIPMENT_PRODUCT_DETAIL
            //                       where j.SHIPMENT_DETAIL.SHIPMENT.shipmentID == 
            //                       select new SearchProductModel()
            //                       {
            //                           m_productName = j.SUPPLIER2.
            //                           m_productDescriptionLong = j.PRODUCT_DESCRIPTION.productDescLong,
            //                           m_productColor = j.productColor,
            //                           m_productPrice = j.productPrice,
            //                           m_productSize = j.productSize,
            //                           m_productWeight = j.productWeight,
            //                           m_productSerialNumber = j.PRODUCT_DESCRIPTION.PRODUCT.productSerialNumber

            //                       }).SingleOrDefault();

            //        addProduct.m_productName = cptoadd.m_productName;
            //        addProduct.m_productDescriptionLong = cptoadd.m_productDescriptionLong;
            //        addProduct.m_productColor = cptoadd.m_productColor;
            //        addProduct.m_productPrice = cptoadd.m_productPrice;
            //        addProduct.m_productSize = cptoadd.m_productSize;
            //        addProduct.m_productWeight = cptoadd.m_productWeight;
            //        addProduct.m_productSerialNumber = cptoadd.m_productSerialNumber;

            //    }


            //}



            return Json(productPerSupplier, JsonRequestBehavior.AllowGet);

        }
        
        [HttpGet]
        public JsonResult ChangeProductPicture(string picture)
        {
            SearchProductModel addProduct = new SearchProductModel();
            addProduct.m_add_new_product = true;
            addProduct.m_add_new_shipment = false;
            addProduct.m_productPicture = picture;




            return Json(addProduct, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult EditProduct(List<SearchProductModel> productModel, string productId)
        {
            foreach (SearchProductModel spm in productModel)
            {
                if (spm.m_productId.ToString() == productId)
                {
                    spm.isInEditMode = true;
                }
            }
            return Json(productModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNewProduct(FormCollection frm_collection)
        {
            string productName = frm_collection["pName"].ToString();
            string productColor = frm_collection["pProdutColor"];
            string productPrice = frm_collection["pProductPrice"];
            string productSize = frm_collection["pProductSize"];
            string productWeight = frm_collection["pProductWeight"];
            string productSerialNumber = frm_collection["pSerialNumber"];
            string pLongDescription = frm_collection["pLongDescription"];

            var fileToUpload = frm_collection["filePathFromUserToUpload"];

            var fileName = System.IO.Path.GetFileName(fileToUpload);
            var path = System.IO.Path.Combine(Server.MapPath("~/App_Data/UploadedImages"), fileName);
            System.IO.File.Create(path);
            //string fileURIDestination = "C:/Users/JINAN/Documents/visual studio 2012/Projects/WH01/Warehouse/Pictures";

            //System.Net.WebClient productPicWebClient = new System.Net.WebClient();
            //byte[] productPicResponseArray = productPicWebClient.UploadFile(fileURIDestination, fileToUpload);





            using (var dbContext = new WH01Entities())
            {

                try
                {
                    PRODUCT n_PRODUCT = new PRODUCT();
                    n_PRODUCT.productName = productName;
                    n_PRODUCT.productSerialNumber = productSerialNumber;

                    dbContext.PRODUCT.Add(n_PRODUCT);
                    dbContext.SaveChanges();

                    PRODUCT_DESCRIPTION n_PRODUCT_DESCRIPTION = new PRODUCT_DESCRIPTION();
                    n_PRODUCT_DESCRIPTION.productID = n_PRODUCT.productID;
                    n_PRODUCT_DESCRIPTION.productDescLong = pLongDescription;

                    dbContext.PRODUCT_DESCRIPTION.Add(n_PRODUCT_DESCRIPTION);
                    dbContext.SaveChanges();

                    PRODUCT_DESCRIPTION_DETAIL n_PRODUCT_DESCRIPTION_DETAIL = new PRODUCT_DESCRIPTION_DETAIL();
                    n_PRODUCT_DESCRIPTION_DETAIL.productDescriptionID = n_PRODUCT_DESCRIPTION.productDescriptionID;
                    n_PRODUCT_DESCRIPTION_DETAIL.productColor = productColor;
                    n_PRODUCT_DESCRIPTION_DETAIL.productWeight = productWeight;
                    n_PRODUCT_DESCRIPTION_DETAIL.productSize = productSize;
                    n_PRODUCT_DESCRIPTION_DETAIL.productPrice = productPrice;

                    dbContext.PRODUCT_DESCRIPTION_DETAIL.Add(n_PRODUCT_DESCRIPTION_DETAIL);
                    dbContext.SaveChanges();

                    TempData["productAdded"] = "true";

                }
                catch (Exception exp)
                {

                }

            }








            SearchProductModel addProduct = new SearchProductModel();
            addProduct.m_add_new_product = true;
            addProduct.m_add_new_shipment = false;

            using (var searchPhrase = new WH01Entities())
            {
                var copiedProductsResult = from i in searchPhrase.PRODUCT_DESCRIPTION
                                           where i.prodctCopied == true
                                           select i;

                addProduct.copiedProducts = new Dictionary<long, string>();
                foreach (PRODUCT_DESCRIPTION pdesc in copiedProductsResult)
                {

                    addProduct.copiedProducts.Add(pdesc.productID, pdesc.PRODUCT.productName);
                }
            }

            return View("NewProduct", addProduct);
        }

        [HttpPost]
        public ActionResult UploadProduct(HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                    try
                    {
                        string path = System.IO.Path.Combine(Server.MapPath("~/Images"),
                                                   System.IO.Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        ViewBag.Message = "File uploaded successfully";
                        file.InputStream.Flush();
                        file.InputStream.Dispose();
                        //traverse uploaded eecel or json file
                        try
                        {   // Open the excel file
                            string filename = "";

                            for (int i = file.FileName.Length - 1; i > 0; i--)
                            {
                                if (file.FileName[i].ToString() == "\\")
                                {
                                    filename = file.FileName.Substring(i + 1);
                                    break;
                                }
                            }

                            System.Data.DataSet ds = ReadExcelFile(filename);
                            // check if product already exists, suggest to copy 
                        }
                        catch (Exception ex)
                        {
                        }


                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.Message = "Please selecta file. No file was selected. :=)";
                }

            }
            catch (Exception exp)
            {
            }
            return View("UploadFromFile");

        }

        public System.Data.DataSet ReadExcelFile(String filename)
        {


            // Create connection string variable.
            String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + Server.MapPath("~/Images/" + filename) + ";" +
            "Extended Properties=Excel 8.0;";

            // Create connection object
            System.Data.OleDb.OleDbConnection objConn = new System.Data.OleDb.OleDbConnection(sConnectionString);

            // Open connection with the database.
            objConn.Open();

            // The code to follow uses a SQL SELECT command to display the data from the worksheet.

            // Create new OleDbCommand to return data from worksheet.
            System.Data.OleDb.OleDbCommand objCmdSelect = new System.Data.OleDb.OleDbCommand("SELECT * FROM [Products$]", objConn);

            // Create new OleDbDataAdapter that is used to build a DataSet
            // based on the preceding SQL SELECT statement.
            System.Data.OleDb.OleDbDataAdapter objAdapter1 = new System.Data.OleDb.OleDbDataAdapter();

            // Pass the Select command to the adapter.
            objAdapter1.SelectCommand = objCmdSelect;

            // Create new DataSet to hold information from the worksheet.
            System.Data.DataSet objDataset1 = new System.Data.DataSet();
            try
            {
                // Fill the DataSet with the information from the worksheet.
                objAdapter1.Fill(objDataset1, "Products");
            }
            catch (Exception exp)
            {
                objConn.ResetState();
                objConn.Dispose();
                objConn.Close();
            }
            //objConn.Dispose();
            // Clean up objects.

            objConn.Close();


            return objDataset1;
        }

        public ActionResult NewShipment()
        {
            SearchProductModel addShipment = new SearchProductModel();
            addShipment.m_add_new_shipment = true;
            addShipment.m_add_new_product = false;

            using (var searchPhrase = new WH01Entities())
            {
                var copiedProductsResult = from i in searchPhrase.PRODUCT_DESCRIPTION
                                           where i.prodctCopied == true
                                           select i;

                addShipment.copiedProducts = new Dictionary<long, string>();
                foreach (PRODUCT_DESCRIPTION pdesc in copiedProductsResult)
                {

                    addShipment.copiedProducts.Add(pdesc.productID, pdesc.PRODUCT.productName);
                }

                //Get all suppliers for new order

                //get distinct supplier ID and NAME
                var distinctSupplierID = (from j in searchPhrase.SHIPMENT_SUPPLIER
                                          select new SupplierModel
                                          {
                                              m_supplierId = j.supplierID,
                                              m_supplierName = j.SUPPLIER.supplierName
                                          }).Distinct().ToList();



                //dictionary holds shipment IDS for each supplier
                Dictionary<string, string> supplierShipment_D = new Dictionary<string, string>();

                string supplierId_Name_D = null;
                string shipmentIDDictionary = "";

                foreach (var distinctsid in distinctSupplierID)
                {
                    var suppliersfno = (from s in searchPhrase.SHIPMENT_SUPPLIER
                                        where s.supplierID == distinctsid.m_supplierId
                                        select s.shipmentID).ToList();

                    supplierId_Name_D = distinctsid.m_supplierId + "," + distinctsid.m_supplierName;


                    foreach (var shipid in suppliersfno)
                    {
                        shipmentIDDictionary = shipmentIDDictionary + shipid + ",";
                    }

                    //fill dictionary
                    supplierShipment_D.Add(supplierId_Name_D, shipmentIDDictionary);

                }

                //Model dictionary that holds all shipments per supplier ex:  supplier:shipment a, shipment b, shipment c et
                addShipment.supplierShipment_D_Model = supplierShipment_D;


            }

            return View("NewProduct", addShipment);
        }

        public ActionResult UploadFromFile()
        {

            return View("UploadFromFile");
        }
        
    }
}
