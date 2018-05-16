<%@ Page Language="C#" MasterPageFile="~/Views/Shared/GeneralMaster.master" Inherits="System.Web.Mvc.ViewPage<MyDistributionOutlet.Models.SearchProductModelList>" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
 
    <div class="container-fluid">
        <div class="row">
            <div class="card-group">


                <%
                    int p_counter = 0;
                    TempData["currModel"] = Model;
                    foreach (var sresult in Model.listofsearchproducts)
                    {
                   
                %>

                <div class="col-sm-3" style="border: 1px solid white;">


                    <div class="container" style="display: inline;height:900px"">
                        <!-- single card tabs content  -->
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#tabone<%= p_counter.ToString() %>">Product</a></li>
                            <li class ="<%= sresult.m_supplierName != null? "bg-success" : "bg-warning" %>"><a data-toggle="tab" href="#tabtwo<%= p_counter.ToString() %>">Shipment</a></li>
                            <li><a data-toggle="tab" href="#tabthree<%= p_counter.ToString() %>">Options</a></li>
                        </ul>

                        <div class="tab-content">
                            <div id="tabone<%= p_counter.ToString() %>" class="tab-pane fade in active">
                                <div class="card">
                                    <div class="card-block">
                                       
                                            <div class="row">
                                               
                                                <div class="col-xs-6 text-left">
                                                    <h4 class="card-title"><%= sresult.m_productName  %></h4>
                                                  
                                                </div>
                                                <div class="col-xs-6 text-right">
                                                    <form class="navbar-form navbar-left" action="/Warehouse/CopyProduct" name="cpForm" method="post">
                                                        <input type="hidden" name="hprodid" value="<%= sresult.m_productId  %>" />
                                                        <%--<button type="button" class="btn btn-default" data-toggle="modal" data-target="#myModal">Copy this product</button>--%>

                                                        <button type="submit" class="btn btn-default" onclick="alert('product copied')">Copy this product</button>

                                                    </form>

                                                </div>
                                                     
                                            </div>
                                       
                                        
                                        
                                        <p class="card-text" style="word-wrap: break-word"><%= sresult.m_productDescriptionLong %></p>
                                    </div>

                                    <a href="#"  onclick ="javascript:alert('test');"><img class=" img-responsive img-thumbnail card-img-top" src="../../Images/product-empty.png" alt="Card image cap"></a>

                                    <ul class="list-group list-group-flush">
                                        <li class="list-group-item"><b>Color:</b><%= sresult.m_productColor %></li>
                                        <li class="list-group-item"><b>Price:</b><%= sresult.m_productPrice %></li>
                                        <li class="list-group-item"><b>Size:</b><%= sresult.m_productSize %></li>
                                        <li class="list-group-item"><b>Weight:</b><%= sresult.m_productWeight %></li>
                                        <li class="list-group-item" style="word-wrap: break-word"><b>Serial No:</b><%= sresult.m_productSerialNumber %></li>
                                    </ul>
                                    <div class="card-block">
                                        <a href="#" class="card-link">Card link</a>
                                        <a href="#" class="card-link">Another link</a>
                                    </div>
                                </div>
                            </div>
                            <div id="tabtwo<%= p_counter.ToString() %>" class="tab-pane fade">
                                <h3>Shipment Details</h3>
                                <div class="card" style ="height:900px">
                                    <div class="card-block">
                                        <h4 class="card-title"><%= sresult.m_productName  %></h4>
                                        <p class="card-text" style="word-wrap: break-word"><%= sresult.m_productDescriptionLong %></p>
                                    </div>
                                    <h4>Supplier</h4>
                                    <ul class="list-group list-group-flush">
                                        <li class="list-group-item" style ="height:36px;"><b>Name:</b><%= sresult.m_supplierName %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Country:</b><%= sresult.m_supplierCountry %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Province:</b><%= sresult.m_supplierProvince %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>City:</b><%= sresult.m_supplierCity %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Street:</b><%= sresult.m_supplierStreet %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Unit Number:</b><%= sresult.m_supplierUnitNumber %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Email:</b><%= sresult.m_supplierEmail %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Fax:</b><%= sresult.m_supplierFax %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Postal Code:</b><%= sresult.m_supplierPostalCode %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Telephone:</b><%= sresult.m_supplierTelephone %></li>

                                    </ul>
                                    <h4>Shipment</h4>
                                    <ul class="list-group list-group-flush">
                                        <li class="list-group-item" style ="height:36px;"><b>Country:</b><%= sresult.m_shipmentCountry %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>City:</b><%= sresult.m_shipmentCity %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Province:</b><%= sresult.m_shipmentProvince %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Date:</b><%= sresult.m_shipmentDate %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Estimated arrival date:</b><%= sresult.m_shipmentEstimatedArrivalDate %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Arrival date:</b><%= sresult.m_shipmentArrivalDate %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Method:</b><%= sresult.m_shipmentMethod %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Num of product kinds:</b><%= sresult.m_shipmentNumberOfProductsGeneral %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Num of boxes:</b><%= sresult.m_shipmentNumberOfBoxes %></li>
                                        <li class="list-group-item" style ="height:36px;"><b>Num of packs:</b><%= sresult.m_shipmentNumberofPacks %></li>
                                    </ul>
                                    <div class="card-block">
                                        <a href="#" class="card-link">Card link</a>
                                        <a href="#" class="card-link">Another link</a>
                                    </div>
                                </div>
                            </div>
                            <div id="tabthree<%= p_counter.ToString() %>" class="tab-pane fade">
                                <h3>Menu 2</h3>
                                <p>Some content in menu 2.</p>
                            </div>
                        </div>
                        <!-- single card tabs content  -->
                    </div>

                </div>

                <%
                
                        p_counter++;
                    } 
                %>
            </div>
        </div>
    </div>

</asp:Content>
