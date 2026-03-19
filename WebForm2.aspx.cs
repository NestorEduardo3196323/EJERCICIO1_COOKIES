using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicio1_3196323
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Safely read cookies (they may be missing or contain non-numeric values)
                var cCat = Request.Cookies["ddlCategory"];
                if (cCat != null)
                    ddlCategory.SelectedValue = cCat.Value;

                var cSup = Request.Cookies["ddlSupplier"];
                if (cSup != null)
                    ddlSupplier.SelectedValue = cSup.Value;

                lblProduct.Text = Request.Cookies["strProduct"]?.Value ?? string.Empty;
                txtDescription.Text = Request.Cookies["strDescription"]?.Value ?? string.Empty;
                lblImage.Text = Request.Cookies["strImage"]?.Value ?? string.Empty;

                decimal decPrice = 0m;
                decimal.TryParse(Request.Cookies["decPrice"]?.Value, out decPrice);
                lblPrice.Text = decPrice.ToString("c");

                byte bytNumberInStock = 0;
                byte bytNumberOnOrder = 0;
                byte bytReorderLevel = 0;
                byte.TryParse(Request.Cookies["bytNumberInStock"]?.Value, out bytNumberInStock);
                byte.TryParse(Request.Cookies["bytNumberOnOrder"]?.Value, out bytNumberOnOrder);
                byte.TryParse(Request.Cookies["bytReorderLevel"]?.Value, out bytReorderLevel);

                lblReorderLevel.Text = bytReorderLevel.ToString();

                decimal decValueInStock = decPrice * bytNumberInStock;
                decimal decValueOnOrder = decPrice * bytNumberOnOrder;

                lblValueInStock.Text = decValueInStock.ToString("c");
                lblValueOnOrder.Text = decValueOnOrder.ToString("c");
            }
        }

        

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}