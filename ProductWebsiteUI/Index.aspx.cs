using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using System.Text;
using System.Security.Policy;
using System.Net.Http.Headers;

namespace ProductWebsiteUI
{
	public partial class Index : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if(!IsPostBack)
            {
                fetch();
            }
		}

		public class SaneProducts
		{
			public int id { get; set; }

			public int? product_code { get; set; }

			[StringLength(100)]
			public string product_name { get; set; }

			public int? quantity { get; set; }

			public double? rate { get; set; }

			public double? tax_amount { get; set; }

			public double? tax_percentage { get; set; }

			public double? gross_total { get; set; }
		}

        protected void btnInsert_Click(object sender, EventArgs e)
        {
			string apiUrl = "https://localhost:44369/api/tbl_products_master_trans";

			var sudharProduct = new
			{
				product_code = txt_product_code.Text.Trim(),
				product_name = txt_product_name.Text.Trim(),
				quantity = txt_quantity.Text.Trim(),
				rate = txt_Rate.Text.Trim(),
				tax_percentage = txt_TaxPercentage.Text.Trim(),

				tax_amount = (
				Convert.ToInt32(txt_quantity.Text.Trim()) * 
				Convert.ToInt32(txt_Rate.Text.Trim()) )/ 
				Convert.ToInt32(txt_TaxPercentage.Text.Trim()),

				gross_total = (
				Convert.ToInt32(txt_quantity.Text.Trim()) * 
				Convert.ToInt32(txt_Rate.Text.Trim())
				)
				+ (
				Convert.ToInt32(txt_quantity.Text.Trim()) * Convert.ToInt32(txt_Rate.Text.Trim())
				)
				/ Convert.ToInt32(txt_TaxPercentage.Text.Trim())
			};

			string inputJson = (new JavaScriptSerializer().Serialize(sudharProduct));
			HttpClient client = new HttpClient();
			HttpContent content = new StringContent(inputJson, Encoding.UTF8, "application/json");
			HttpResponseMessage response = client.PostAsync(apiUrl + "/tbl_products_master_trans", content).Result;
			if(response.IsSuccessStatusCode)
			{
				lblSuccessMessage.Text=("data inserted");
                lblErrorMessage.Text = "";
                fetch();
			}
		}

        public void fetch()
        {
            string apiUrl = "https://localhost:44369/api/tbl_products_master_trans";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                //row by row data edu
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<SaneProducts>>().Result;
                GridView1.DataSource = dataObjects;
                GridView1.DataBind();
            }
        }

        //Select
        protected void Button1_Click(object sender, EventArgs e)
        {
            fetch();
        }

        private SaneProducts GetProductById(int id)
        {
            string apiUrl = $"https://localhost:44369/api/tbl_products_master_trans/{id}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                var product = response.Content.ReadAsAsync<SaneProducts>().Result;
                return product;
               
            }
            else
            {
                // Handle error or return null if product not found
                return null;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
			if (int.TryParse(txt_search.Text.Trim(), out int id))
			{
                SaneProducts product = GetProductById(id);

                if (product != null)
                {
                    txt_product_code.Text = product.product_code.ToString();
                    txt_product_name.Text = product.product_name;
                    txt_quantity.Text = product.quantity.ToString();
                    txt_Rate.Text = product.rate.HasValue ? product.rate.Value.ToString() : "";
                    txt_TaxPercentage.Text = product.tax_percentage.HasValue ? product.tax_percentage.Value.ToString() : "";
                    // Populate other fields as necessary
                    lblErrorMessage.Text = "";
                    lblSuccessMessage.Text = "";
                }
                else
                {
                 
                    lblErrorMessage.Text=("Product not found.");
                    lblSuccessMessage.Text = "";
                }
            }
            else
            {
				lblErrorMessage.Text= ("invalid id");
                lblSuccessMessage.Text = "";
            }
        }

        //Update
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txt_search.Text.Trim(), out int id))
            {
                SaneProducts product = new SaneProducts
                {
                    id = id,
                    product_code = Convert.ToInt32( txt_product_code.Text),
                    product_name = txt_product_name.Text,
                    quantity = Convert.ToInt32(txt_quantity.Text),
                    rate = Convert.ToDouble(txt_Rate.Text),
                    tax_percentage = double.TryParse(txt_TaxPercentage.Text, out double taxPercentage) ? taxPercentage : (double?)null,
                    tax_amount = (
                Convert.ToInt32(txt_quantity.Text.Trim()) *
                Convert.ToInt32(txt_Rate.Text.Trim())) /
                Convert.ToInt32(txt_TaxPercentage.Text.Trim()),

                    gross_total = (
                Convert.ToInt32(txt_quantity.Text.Trim()) *
                Convert.ToInt32(txt_Rate.Text.Trim())
                )
                + (
                Convert.ToInt32(txt_quantity.Text.Trim()) * Convert.ToInt32(txt_Rate.Text.Trim())
                )
                / Convert.ToInt32(txt_TaxPercentage.Text.Trim())
                };

                bool isUpdated = UpdateProduct(product);

                if (isUpdated)
                {
                   lblSuccessMessage.Text= ("data updated successfully");
                    lblErrorMessage.Text = "";
                    fetch();
                    clear();
                }
                else
                {
                    
                    lblErrorMessage.Text = "Error updating product.";
                }
            }
            else
            {
                lblSuccessMessage.Text = "";
                 lblErrorMessage.Text = "Invalid ID.";
            }
        }

        private bool UpdateProduct(SaneProducts product)
        {
            string apiUrl = $"https://localhost:44369/api/tbl_products_master_trans/{product.id}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PutAsJsonAsync(apiUrl, product).Result;

            return response.IsSuccessStatusCode;
        }

        //Delete
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txt_search.Text.Trim(), out int id))
            {
                bool isDeleted = DeleteProductById(id);

                if (isDeleted)
                {
                    clear();
                     lblSuccessMessage.Text = "Product deleted successfully.";
                    lblErrorMessage.Text = "";
                    fetch();
                }
                else
                {
                    lblSuccessMessage.Text = "";
                    lblErrorMessage.Text = "Error deleting product.";
                }
            }
            else
            {
                // Handle invalid id input
                lblErrorMessage.Text = "Invalid ID.";
                lblSuccessMessage.Text = "";
            }
        }

        private bool DeleteProductById(int id)
        {
            string apiUrl = $"https://localhost:44369/api/tbl_products_master_trans/{id}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync(apiUrl).Result;

            return response.IsSuccessStatusCode;
        }

        public void clear()
        {
            txt_product_code.Text = "";
            txt_product_name.Text = "";
            txt_quantity.Text = "";
            txt_Rate.Text = "";
            txt_TaxPercentage.Text = "";
            txt_search.Text = string.Empty;
            
        }
    }
}