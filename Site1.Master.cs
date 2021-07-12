using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyCity
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LinkButton1.Visible = true; // user login link button
                    LinkButton2.Visible = true; // sign up link button

                    LinkButton3.Visible = false; // logout link button
                    LinkButton7.Visible = false; // hello user link button


                    LinkButton5.Visible = true; // admin login link button
                    LinkButton13.Visible = false; // owner management link button
                    LinkButton14.Visible = false; // hub management link button
                    LinkButton15.Visible = false; // cycle inventory link button
                    LinkButton16.Visible = false; // cycle renting link button
                    LinkButton17.Visible = false; // member management link button

                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello " + Session["username"].ToString();

                    LinkButton5.Visible = true; // admin login link button
                    LinkButton13.Visible = false; // owner management link button
                    LinkButton14.Visible = false; // hub management link button
                    LinkButton15.Visible = false; // cycle inventory link button
                    LinkButton16.Visible = false; // cycle renting link button
                    LinkButton17.Visible = false; // member management link button
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello Admin";


                    LinkButton5.Visible = false; // admin login link button
                    LinkButton13.Visible = true; // owner management link button
                    LinkButton14.Visible = true; // hub management link button
                    LinkButton15.Visible = true; // cycle inventory link button
                    LinkButton16.Visible = true; // cycle renting link button
                    LinkButton17.Visible = true; // member management link button
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminownermanagement.aspx");
        }

        protected void LinkButton14_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminhubmanagement.aspx");
        }

        protected void LinkButton15_Click(object sender, EventArgs e)
        {
            Response.Redirect("cycleinventory.aspx");
        }

        protected void LinkButton16_Click(object sender, EventArgs e)
        {
            Response.Redirect("admincyclerenting.aspx");
        }

        protected void LinkButton17_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = true; // sign up link button

            LinkButton3.Visible = false; // logout link button
            LinkButton7.Visible = false; // hello user link button

            LinkButton5.Visible = true; // admin login link button
            LinkButton13.Visible = false; // owner management link button
            LinkButton14.Visible = false; // hub management link button
            LinkButton15.Visible = false; // cycle inventory link button
            LinkButton16.Visible = false; // cycle renting link button
            LinkButton17.Visible = false; // member management link button
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewcycles.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}