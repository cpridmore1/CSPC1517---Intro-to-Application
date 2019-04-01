using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.Data;
using NorthwindSystem.Data.Views;
using NorthwindSystem.BLL;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
#endregion

namespace WebApp.NorthwindPages
{
    public partial class ProductCRUD : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();

            if (!Page.IsPostBack)
            {
                BindProductList();
                BindSupplierList();
                BindCategoryList();
            }

        }

        //use this method to discover the inner most error message.
        //this rotuing has been created by the user
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        //use this method to load a DataList with a variable
        //number of message lines.
        //each line is a string
        //the strings (lines) are passed to this routine in
        //   a List<string>
        //second parameter is the bootstrap cssclass
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void BindProductList()
        {
            try
            {
                ProductController sysmger = new ProductController();

                List<Product> datainfo = sysmger.Product_List();
                datainfo.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));

                ProductList.DataSource = datainfo;
                ProductList.DataTextField = nameof(Product.ProductName);
                ProductList.DataValueField = nameof(Product.ProductID);
                ProductList.DataBind();
                ProductList.DataBind();
                ProductList.Items.Insert(0, "select...");

            }
            catch(Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");

            }
        }

        protected void BindSupplierList()
        {
            try
            {
                SupplierController sysmger = new SupplierController();

                List<Supplier> datainfo = sysmger.Supplier_List();
                datainfo.Sort((x, y) => x.CompanyName.CompareTo(y.CompanyName));

                SupplierList.DataSource = datainfo;
                SupplierList.DataTextField = nameof(Supplier.CompanyName);
                SupplierList.DataValueField = nameof(Supplier.SupplierID);
                SupplierList.DataBind();
                SupplierList.DataBind();
                SupplierList.Items.Insert(0, "select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");

            }
        }

        protected void BindCategoryList()
        {
            try
            {
                CategoryController sysmger = new CategoryController();

                List<Category> datainfo = sysmger.Category_List();
                datainfo.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));

                SupplierList.DataSource = datainfo;
                SupplierList.DataTextField = nameof(Category.CategoryName);
                SupplierList.DataValueField = nameof(Category.CategoryID);
                SupplierList.DataBind();
                SupplierList.DataBind();
                SupplierList.Items.Insert(0, "select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");

            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {

        }

        protected void Clear_Click(object sender, EventArgs e)
        {

        }

        protected void AddProduct_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid)
            //{
                //add any additional logic validation required for processing 
                //in this example, we will assume the supplier id and category id are required.
                if (SupplierList.SelectedIndex == 0)
                {
                    errormsgs.Add("Please select a supplier");
                    LoadMessageDisplay(errormsgs, "alert alert-warning");

                }
                else if (CategoryList.SelectedIndex == 0)
                {
                    errormsgs.Add("Please select a category");
                    LoadMessageDisplay(errormsgs, "alert alert-warning");
                }
                else
                {

                    try
                    {
                        //Create an instance of product
                        Product item = new Product();
                        //collect the data from the web form and place in the product instance
                        item.ProductName = ProductName.Text;
                        item.SupplierID = int.Parse(SupplierList.SelectedValue);
                        item.CategoryID = int.Parse(CategoryList.SelectedValue);
                        item.QuantityPerUnit = string.IsNullOrEmpty(QuantityPerUnit.Text.Trim()) ? null : QuantityPerUnit.Text.Trim();
                        if (string.IsNullOrEmpty(UnitPrice.Text))
                        {
                            item.UnitPrice = null;
                        }
                        else
                        {
                            item.UnitPrice = decimal.Parse(UnitPrice.Text);
                        }

                        if (string.IsNullOrEmpty(UnitsInStock.Text))
                        {
                            item.UnitsInStock = null;
                        }
                        else
                        {
                            item.UnitsInStock = Int16.Parse(UnitsInStock.Text);
                        }

                        if (string.IsNullOrEmpty(UnitsOnOrder.Text))
                        {
                            item.UnitsOnOrder = null;
                        }
                        else
                        {
                            item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text);
                        }

                        if (string.IsNullOrEmpty(ReorderLevel.Text))
                        {
                            item.ReorderLevel = null;
                        }
                        else
                        {
                            item.ReorderLevel = Int16.Parse(ReorderLevel.Text);
                        }

                        //handeling of the discontinued, can be done manually or logically
                        item.Discontinued = false;

                        //connect to the appropriate bll controller
                        ProductController sysmgr = new ProductController();

                        //issue a call to the appropriate bll controller method
                        int newProductID = sysmgr.Product_Add(item);
                        //handel results. 

                        errormsgs.Add(ProductName.Text + " has been added to the database with a key of " + newProductID.ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-success");

                        //if any control on this form uses this new instance for a query or other action, you must update (refresh) that control

                        BindProductList();
                        ProductID.Text = newProductID.ToString();
                        ProductList.SelectedValue = ProductID.Text;


                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }

                }
            //}
        }
    }
}