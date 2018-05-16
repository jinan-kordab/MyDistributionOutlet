<%@ Page Language="C#" MasterPageFile="~/Views/Shared/GeneralMaster.master" Inherits="System.Web.Mvc.ViewPage<MyDistributionOutlet.Models.SearchProductModelList>" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-fluid">
        <table class="table table-bordered">
            <thead style ="height:25px">
                <tr class="text-muted">
                    <th class="sortable-column"></th>
                    <th>#</th>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Color</th>
                    <th>Price</th>
                    <th>Size</th>
                    <th>Weight</th>
                    <th>Serial Num</th>
                    <th></th>
                </tr>
            </thead>
            <tbody class="bg-inverse">
                <%
                    int p_counter = 1;
                    TempData["currModel"] = Model;
                    foreach (var sresult in Model.listofsearchproducts)
                    {          
                %>

                <tr>
                    <th>
                        <a href="javascript:void(0);" data-toggle="collapse" data-target="#demo<%= p_counter.ToString() %>">Supplier</a>
                    </th>
                    <th><%= p_counter.ToString() %><input type="hidden" id="pId" name="pId" value="<%= sresult.m_productId %>" /></th>
                    <th><%= sresult.m_productName  %></th>
                    <th><%= sresult.m_productDescriptionLong %></th>
                    <th><%= sresult.m_productColor %></th>
                    <th><%= sresult.m_productPrice %></th>
                    <th><%= sresult.m_productSize %></th>
                    <th><%= sresult.m_productWeight %></th>
                    <th><%= sresult.m_productSerialNumber %></th>
                    <th>    <a href="javascript:void(0);" data-toggle="collapse" data-target="#DivEdit<%= p_counter.ToString() %>">Edit</a></th>
                </tr>
            

                <!-- EDITABLE ROW SECTION -->

                <tr id="DivEdit<%= p_counter.ToString() %>" class="collapse primary">
                    <th colspan="11">
                        <table class=" table table-condensed  table-bordered">
                            <thead>
                                <tr>
                                    
                                    <th><u>Name</u></th>
                                    <th><u>Description</u></th>
                                    <th><u>Color</u></th>
                                    <th><u>Price</u></th>
                                    <th><u>Size</u></th>
                                    <th><u>Weight</u></th>
                                    <th><u>Serial Num</u></th>
                                
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    

                                    <th>
                                        <input type="text" class="form-control input-sm" value="<%= sresult.m_productName  %>" /></th>
                                    <th>
                                        <input type="text" class="form-control input-sm" value="<%= sresult.m_productDescriptionLong %>" /></th>
                                    <th>
                                        <input type="text" class="form-control input-sm" value="<%= sresult.m_productColor %>" /></th>
                                    <th>
                                        <input type="text" class="form-control input-sm" value="<%= sresult.m_productPrice %>" /></th>
                                    <th>
                                        <input type="text" class="form-control input-sm" value="<%= sresult.m_productSize %>" /></th>
                                    <th>
                                        <input type="text" class="form-control input-sm" value="<%= sresult.m_productWeight %>" /></th>
                                    <th>
                                        <input type="text" class="form-control input-sm" value="<%= sresult.m_productSerialNumber %>" /></th>
                                    <th>
                                        <button type="button" onclick ="UpdateRecord();" class="btn btn-primary">Update</button></th>
                                    <th>
                                        <button type="button" class="btn btn-primary">Delete</button></th>

                                 
                                </tr>
                            </tbody>
                        </table>


                    </th>
                </tr>


                <tr id="demo<%= p_counter.ToString() %>" class="collapse primary"  >
                    <th colspan="11">
                            <table class=" table table-condensed  table-bordered">
                                <thead>
                                    <tr>
                                        <th>&nbsp;</th>
                                        <th><u>Supplier Name</u></th>
                                        <th><u>Country</u></th>
                                        <th><u>Province</u></th>
                                        <th><u>City</u></th>
                                        <th><u>Street</u></th>
                                        <th><u>Unit Number</u></th>
                                        <th><u>Email</u></th>
                                        <th><u>Fax</u></th>
                                        <th><u>Postal Code</u></th>
                                        <th><u>Telephone</u></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>&nbsp;</th>
                                        <th><%= sresult.m_supplierName %></th>
                                        <th><%= sresult.m_supplierCountry %></th>
                                        <th><%= sresult.m_supplierProvince %></th>
                                        <th><%= sresult.m_supplierCity %></th>
                                        <th><%= sresult.m_supplierStreet %></th>
                                        <th><%= sresult.m_supplierUnitNumber %></th>
                                        <th><%= sresult.m_supplierEmail %></th>
                                        <th><%= sresult.m_supplierFax %></th>
                                        <th><%= sresult.m_supplierPostalCode %></th>
                                        <th><%= sresult.m_supplierTelephone %></th>
                                    </tr>
                                </tbody>
                            </table>
                       

                    </th>
                </tr>

                <%
                          p_counter++;
                      } 
                %>
            </tbody>
        </table>

    </div>

</asp:Content>