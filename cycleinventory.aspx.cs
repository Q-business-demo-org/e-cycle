using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CyCity
{
    public partial class cycleinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_cycles;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillOwnerHubValues();
            }
            GridView1.DataBind();
        }
        //add
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfCycleExists())
            {
                Response.Write("<script>alert('Cycle already exists, try some other cycle ID');</script>");
            }
            else
            {
                addNewCycle();
            }
        }
        //update
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateCycleByID();
        }
        //delete
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteCycleByID();
        }
        //go
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getCycleByID();
        }
        //user defined functions
        void fillOwnerHubValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT owner_name from owner_master_tbl;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "owner_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT hub_name from hub_master_tb1;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "hub_name";
                DropDownList2.DataBind();
            }
            catch(Exception e)
            {

            }
        }
        bool checkIfCycleExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from cycle_master_tb1 where cycle_id='" + TextBox1.Text.Trim() + "' OR cycle_name='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void addNewCycle()
        {
            try
            {
                string colors = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    colors = colors + ListBox1.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
                colors = colors.Remove(colors.Length - 1);

                string filepath = "~/cycle_inventory/p-trans.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("cycle_inventory/" + filename));
                filepath = "~/cycle_inventory/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO cycle_master_tb1(cycle_id,cycle_name,color,owner_name,hub_name,acquired_date,cycle_number,cycle_cost,cycle_description,actual_stock,current_stock,cycle_img_link) values(@cycle_id,@cycle_name,@color,@owner_name,@hub_name,@acquired_date,@cycle_number,@cycle_cost,@cycle_description,@actual_stock,@current_stock,@cycle_img_link)", con);
                cmd.Parameters.AddWithValue("@cycle_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@cycle_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@color", colors);
                cmd.Parameters.AddWithValue("@owner_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@hub_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@acquired_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@cycle_number", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@cycle_cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@cycle_description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@cycle_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Cycle added successfully.');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void deleteCycleByID()
        {
            if (checkIfCycleExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from cycle_master_tb1 WHERE cycle_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Cycle Deleted Successfully');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        void updateCycleByID()
        {

            if (checkIfCycleExists())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox5.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_cycles)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued Cycles');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_cycles;
                            TextBox5.Text = "" + current_stock;
                        }
                    }

                    string colors = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        colors = colors + ListBox1.Items[i] + ",";
                    }
                    colors = colors.Remove(colors.Length - 1);

                    string filepath = "~/cycle_inventory/p-trans.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("cycle_inventory/" + filename));
                        filepath = "~/cycle_inventory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE cycle_master_tb1 set cycle_name=@cycle_name, color=@color, owner_name=@owner_name, hub_name=@hub_name, acquired_date=@acquired_date, cycle_number=@cycle_number, cycle_cost=@cycle_cost, cycle_description=@cycle_description, actual_stock=@actual_stock, current_stock=@current_stock, cycle_img_link=@cycle_img_link where cycle_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.Parameters.AddWithValue("@cycle_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@cycle_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@color", colors);
                    cmd.Parameters.AddWithValue("@owner_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@hub_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@acquired_date", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@cycle_number", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@cycle_cost", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@cycle_description", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@cycle_img_link", filepath);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Cycles Updated Successfully');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Cycle ID');</script>");
            }
        }
        void getCycleByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from cycle_master_tb1 WHERE cycle_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["cycle_name"].ToString();
                    TextBox3.Text = dt.Rows[0]["acquired_date"].ToString();
                    TextBox9.Text = dt.Rows[0]["cycle_number"].ToString();
                    TextBox10.Text = dt.Rows[0]["cycle_cost"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["cycle_description"].ToString();
                    TextBox7.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    DropDownList2.SelectedValue = dt.Rows[0]["hub_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["owner_name"].ToString().Trim();

                    ListBox1.ClearSelection();
                    string[] color = dt.Rows[0]["color"].ToString().Trim().Split(',');
                    for (int i = 0; i < color.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == color[i])
                            {
                                ListBox1.Items[j].Selected = true;

                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_cycles = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["cycle_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Cycle ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}