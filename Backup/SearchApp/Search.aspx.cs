using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SearchApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
            
               BindGrid();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }


        private void BindGrid()
        {
           
                string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                DataTable SearchResultsTable = new DataTable();
                SqlConnection conn = new SqlConnection(ConnectionString);
                try
                    {
                SqlCommand cmd = new SqlCommand("spSearch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", txtEmpName.Text.Trim());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(SearchResultsTable);

                if (SearchResultsTable.Rows.Count > 0)
                {
                    Session["SearchResultsTable"] = SearchResultsTable;
                    gvEmpDetails.DataSource = SearchResultsTable;
                    gvEmpDetails.DataBind();
                }
                else
                {
                    DataTable emptyDt = new DataTable();
                    gvEmpDetails.DataSource = emptyDt;
                    gvEmpDetails.DataBind();
                }

                }
                catch (Exception ex)
                {
                          
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
        
                 
        }


        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }





        protected void gvEmpDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmpDetails.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void gvEmpDetails_Sorting(object sender, GridViewSortEventArgs e)
        {

            DataTable dt = Session["SearchResultsTable"] as DataTable;

            if (dt != null)
            {

              
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvEmpDetails.DataSource = Session["SearchResultsTable"];
                gvEmpDetails.DataBind();
            }

          
        }

        





    }
}
