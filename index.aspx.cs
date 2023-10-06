using System;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebApplicationcrud
{
    public partial class index : System.Web.UI.Page
    {
        // Removed unnecessary property
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                GridFill();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("ProductAddOrEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.AddWithValue("_productid", Convert.ToInt32(hfProductID.Value == "" ? "0" : hfProductID.Value));
                    sqlCmd.Parameters.AddWithValue("_product", txtProduct.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_price", Convert.ToDecimal(txtPrice.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("_count", Convert.ToInt32(txtCount.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("_description", txtDescription.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    GridFill();
                    Clear();
                    iblSucessMessage.Text = "Submitted Successfully";
                }
            }
            catch (Exception ex)
            {
                IblErrorMessage.Text = ex.Message;
            }
        }

        private void GridFill()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ProductViewAll", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtb1 = new DataTable();
                sqlDa.Fill(dtb1);
                gvProduct.DataSource = dtb1;
                gvProduct.DataBind();
            }
        }

        void Clear()
        {
            hfProductID.Value = "";
            txtProduct.Text = txtPrice.Text = txtCount.Text = txtDescription.Text = "";
            btnSave.Text = "Save";
            btnDeleted.Enabled = false;
            IblErrorMessage.Text = iblSucessMessage.Text = "";
        }

        // Removed unnecessary method declaration

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void InkSelect_OnClick(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ProductViewByID", sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("_productid", productID);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtb1 = new DataTable();
                sqlDa.Fill(dtb1);
                txtProduct.Text = dtb1.Rows[0][1].ToString();
                txtPrice.Text = dtb1.Rows[0][2].ToString();
                txtCount.Text = dtb1.Rows[0][3].ToString();
                txtDescription.Text = dtb1.Rows[0][4].ToString();
                hfProductID.Value = dtb1.Rows[0][0].ToString();
                btnSave.Text = "Update";
                btnDeleted.Enabled = true;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlCommand sqlCmd = new MySqlCommand("ProductDeleteByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("_productid", Convert.ToInt32(hfProductID.Value == "" ? "0" : hfProductID.Value));
                
                sqlCmd.ExecuteNonQuery();
                GridFill();
                Clear();
                iblSucessMessage.Text = "Product Deleted Successfully";

            }
        }


        }
}
