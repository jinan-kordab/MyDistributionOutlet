<%@ Page Language="C#"  MasterPageFile="~/Views/Shared/GeneralMaster.master" Inherits="System.Web.Mvc.ViewPage<MyDistributionOutlet.Models.SearchProductModel>" %>
 
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-fluid">
        <div class="row">
            <div class="card-group">
                <div class="col-sm-3" style="border: 1px solid white; height: 690px">
                    <div class="container" style="display: inline">
                        <!-- single card tabs content  -->
                        <ul class="nav nav-tabs">
                            <li class="<%= Model.m_add_new_product == true ? "active":"info" %>"><a data-toggle="tab" href="#tabone">PRODUCT</a></li>
                            <li class="<%= Model.m_add_new_shipment == true ? "active":"info" %>"><a data-toggle="tab" href="#tabtwo">ORDER</a></li>
                        </ul>
                        <div class="tab-content">
                            <div id="tabone" class="tab-pane fade in <%= Model.m_add_new_product == true ? "active":"info" %>">

                                <form class="navbar-form navbar-left" action="/DOutlet/AddNewProduct" name="searchForm" method="post">
                                    <div class="card">
                                        <div class="card-block">
                                            <div class="alert alert-success fade in" <%= (TempData["productAdded"]!= null && TempData["productAdded"] == "true") ? "" : "hidden" %>>

                                                <a href="#" class="close" data-dismiss="alert">&times;</a>

                                                <strong>Success!</strong> Product added.

                                            </div>

                                            <h4 class="card-title">Select copied product to populate:</h4>
                                            <select class="form-control" id="copiedprods" style="width: 100%">
                                                <option value="0">Select copied product</option>
                                                <%
                                                    
                                                    foreach (var copied_product in Model.copiedProducts)
                                                    {
                                                %>
                                                <option value="<%= copied_product.Key %>"><%= copied_product.Value %></option>
                                                <%
                                                          
                                                    }
                                                       
                                                %>
                                            </select>
                                            



                                            <h4 class="card-title">
                                                <b>Product Name:</b><input type="text" name="pName" class="form-control" placeholder="Product Name" style="width: 100%" /></h4>
                                            <p class="card-text" style="word-wrap: break-word"></p>
                                        </div>
                   

                                        <input type="hidden" name="filePathFromUserToUpload" />
                                        <input type="file" id="fileToUpload">
<input type="button" value="Upload" id="uploadButton" style ="width:100%" class ="btn btn-default" />
<br>
<div id="productPhoto" ></div>



                                        <ul class="list-group list-group-flush">
                                             <li class="list-group-item"><b>Long description:</b>
                                                <input type="text" name="pLongDescription" class="form-control" placeholder="Long description" style="width: 100%" /></li>

                                            <li class="list-group-item"><b>Color:</b>
                                                <input type="text" name="pProdutColor" class="form-control" placeholder="Product color" style="width: 100%" /></li>
                                            <li class="list-group-item"><b>Price:</b>
                                                <input type="text" name="pProductPrice" class="form-control" placeholder="Product price" style="width: 100%" /></li>
                                            <li class="list-group-item"><b>Size:</b>
                                                <input type="text" name="pProductSize" class="form-control" placeholder="Product size" style="width: 100%" /></li>
                                            <li class="list-group-item"><b>Weight:</b>
                                                <input type="text" name="pProductWeight" class="form-control" placeholder="Product weight" style="width: 100%" /></li>
                                            <li class="list-group-item" style="word-wrap: break-word"><b>Serial No:</b>
                                                <input type="text" name="pSerialNumber" class="form-control" placeholder="Serial Number" style="width: 100%" /></li>

                                            <li class="list-group-item" style="word-wrap: break-word">



                                                <div class="text-right">
                                                    <input type="submit" class="btn btn-primary" value="Create new product" />
                                                </div>


                                            </li>
                                        </ul>
                                        <div class="card-block">
                                            <a href="#" class="card-link">Card link</a>
                                            <a href="#" class="card-link">Another link</a>
                                        </div>
                                    </div>
                                </form>

                            </div>
                            <div id="tabtwo" class="tab-pane fade in <%= Model.m_add_new_shipment == true ? "active":"info" %>">
                                <form class="navbar-form navbar-left" action="/Warehouse/NewShipment" name="newShipmentForm" method="post">
                                    <h3>Make your selections</h3>
                                    <ul class="list-group">
                                        <li class="list-group-item" style="word-wrap: break-word">
                                            <label for="sSupplierName">Choose supplier:</label>

                                            <select multiple name="allSuppliers" id="allSuppliers" class="form-control" style="width: 100%;" onchange="fillProductsFromSupplier(this);">
                                                <option value="Pick supplier" style="border-bottom: 1px solid black">Pick supplier</option>
                                              
                                               
                                                    <option  value="test"></option>

                                                 
                                                </optgroup>
                                                
                                            </select>

                                        </li>

                                           

                                           <li class="list-group-item" style="word-wrap:break-word">
                                                <label for="productSelectList">Choose product:</label>
                                               <select multiple class="form-control" id="productSelectList" name="productSelectList" style="width:100%" data-style="border:1px solid black">
                                                   <option>1</option>
                                                   <option>2</option>
                                                   <option>3</option>
                                                   <option>4</option>
                                                   <option>5</option>
                                               </select>
                                           </li>
                                        <li class="list-group-item" style="word-wrap: break-word">
                                            <label for="time">Shipment Date:</label>
                                            <input type="text" id="shipmentdate" class="form-control" style="width: 100%">
                                        </li>

                                        <li class="list-group-item" style="word-wrap: break-word">
                                            <label for="time">Shipment estimated arrival date:</label>
                                            <input type="text" id="shEsArrDate" class="form-control" style="width: 100%">
                                        </li>
                                        <li class="list-group-item" style="word-wrap: break-word">

                                            <label for="time">Shipment arrival date:</label>
                                            <input type="text" id="shArrDate" class="form-control" style="width: 100%">
                                        </li>

                                        <li class="list-group-item" style="word-wrap: break-word">
                                            <label for="time">Shipment method:</label>
                                            <input type="text" id="shMethod" class="form-control" style="width: 100%">
                                        </li>

                                        <li class="list-group-item" style="word-wrap: break-word">
                                            <label for="time">Number of products:</label>
                                            <div class="input-group">
                                                <span class="input-group-addon btn btn-primary btn-sm" onclick="decrnop()"><b>-</b></span>
                                                <input type="number" id="s_numOfProducts" class="form-control" min="0" style="width: 100%; text-align: center;" onkeypress='return event.charCode >= 48 && event.charCode <= 57' value="0">
                                                <span class="input-group-addon btn btn-primary btn-sm" onclick="incrnop()"><b>+</b></span>
                                            </div>
                                        </li>
                                    </ul>
                                </form>
                            </div>
                        </div>
                        <!-- single card tabs content  -->
                    </div>
                </div>
            </div>
             
        </div>

          




    </div>
</asp:Content>