using SimpleWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleWebApplication.Views
{
    public partial class EditUser : System.Web.UI.Page
    {
        int userId = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
                if (Request.QueryString["userId"] != "")
                    userId = int.Parse(Request.QueryString["userId"]);
                else
                    Response.Redirect("~/Views/Users.aspx");

                if (!IsPostBack)
                    FillUserData();
        }

        private void FillUserData()
        {
            User user = new User();

            user = user.GetUserData(userId);

            UserIdLabel.Text = user.UserId.ToString();
            NameTextBox.Text = user.Name;
            EmailTextBox.Text = user.Email;
            FirstNameTextBox.Text = user.FirstName;
            LastNameTextBox.Text = user.LastName;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                UserId = int.Parse(Request.QueryString["userId"]),
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text
            };

            user.EditUser(user);

            Response.Redirect("~/Views/Users.aspx");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Users.aspx");
        }
    }
}