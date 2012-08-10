using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string conString = "Server=user-PC\\ang_marcus;Database=Ang_Marcus;UID=sa;PWD=benilde";
        SqlConnection scnMarcus;

        void RefreshGrid()
        {
            scnMarcus.Open();

            string strSelect = "Select * from tblReview";

            SqlCommand scmSelect = new SqlCommand(strSelect, scnMarcus);
            SqlDataReader sdrSelect = scmSelect.ExecuteReader();
            GridView1.DataSource = sdrSelect;
            GridView1.DataBind();
            sdrSelect.Dispose();
            scmSelect.Dispose();

            

            scnMarcus.Close();

            
        }

        void RefreshGrid2()
        {
            scnMarcus.Open();

            string strSelect = "Select * from tblReview2 ";
            SqlCommand scmSelect = new SqlCommand(strSelect, scnMarcus);
            SqlDataReader sdrSelect = scmSelect.ExecuteReader();
            GridView2.DataSource = sdrSelect;
            GridView2.DataBind();
            sdrSelect.Dispose();
            scmSelect.Dispose();

            
            scnMarcus.Close();

            
        }

        void DisplyFamilyID()
        {
            scnMarcus.Open();

            string strSelect = "Select * from tblReview2 where FamilyID = '" + int.Parse(Session["FamilyID"].ToString()) + "'";
            SqlCommand scmSelect = new SqlCommand(strSelect, scnMarcus);
            SqlDataReader sdrSelect = scmSelect.ExecuteReader();
            GridView2.DataSource = sdrSelect;
            GridView2.DataBind();
            sdrSelect.Dispose();
            scmSelect.Dispose();

            scnMarcus.Close();
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            scnMarcus = new SqlConnection(conString);
            RefreshGrid();
            RefreshGrid2();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            scnMarcus.Open();

            string strAdd = "Insert Into tblReview (Name, Age, Relation) Values ('" + txtName.Text + "', '" + txtAge.Text + "', '" + txtRelation.Text + "')";
            SqlCommand scmAdd = new SqlCommand(strAdd, scnMarcus);
            scmAdd.ExecuteNonQuery();
            scmAdd.Dispose();

            scnMarcus.Close();

            RefreshGrid();

            txtName.Text = "";
            txtAge.Text = "";
            txtRelation.Text = "";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            scnMarcus.Open();

            string strAdd = "Insert Into tblReview2 (School, YearLevel, FamilyID) Values ('" + txtSchool.Text + "', '" + txtYearlvl.Text + "', '" + int.Parse(Session["FamilyID"].ToString()) + "')";
            SqlCommand scmAdd = new SqlCommand(strAdd, scnMarcus);
            scmAdd.ExecuteNonQuery();
            scmAdd.Dispose();

            scnMarcus.Close();
            DisplyFamilyID();

            txtYearlvl.Text = "";
            txtSchool.Text = "";



        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Add("FamilyID", GridView1.SelectedRow.Cells[1].Text);
            DisplyFamilyID();


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            RefreshGrid2();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            scnMarcus.Open();

            string strDelete = "Delete from tblReview Where FamilyID = '" + int.Parse(Session["FamilyID"].ToString()) + "'";
            SqlCommand scmDelete = new SqlCommand(strDelete, scnMarcus);
            scmDelete.ExecuteNonQuery();
            scmDelete.Dispose();

            scnMarcus.Close();

            RefreshGrid();
        }
    }
}