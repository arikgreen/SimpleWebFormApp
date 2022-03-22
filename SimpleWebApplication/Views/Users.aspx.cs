using SimpleWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleWebApplication.Views
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillUsersGrid();


        }

        protected void gridUserList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='#C5BBAF';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        private void FillUsersGrid()
        {
            List<User> userList = new List<User>();
            User user = new User();

            userList = user.GetUsers();

            gridUserList.DataSource = userList;
            gridUserList.DataBind();
        }

        protected void BtnNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/NewUser.aspx");
        }

        protected void BtnEditUser_Click(object sender, EventArgs e)
        {
            string userId = null;

            if (gridUserList.SelectedIndex != -1)
                userId = gridUserList.SelectedRow.Cells[0].Text;

            Response.Redirect("~/Views/EditUser.aspx?userId=" + userId);
        }

        protected void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            int userId = 0;

            if(gridUserList.SelectedIndex != -1)
            {
                userId = Convert.ToInt32(gridUserList.SelectedRow.Cells[0].Text);

                User user = new User();

                user.DeleteUser(userId);

                FillUsersGrid();
            }
        }

        //private override void Render(HtmlTextWriter writer)
        //{


        //    base.Render(writer);
        //}


    }
}