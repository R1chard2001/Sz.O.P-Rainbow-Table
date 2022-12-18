using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using RestSharp.Serialization.Json;

namespace i652b8_restapi_client
{
    public partial class ModifyUserForm : Form
    {
        public ModifyUserForm(User user, RestClient client)
        {
            InitializeComponent();
            this.client = client;
            usernameTb.Text = user.Username;
            passwordTb.Text = user.Password;
            isAdminCb.Checked = user.IsAdmin == 1;
            id = user.Id;
            currentUser = user.Username == Config.CurrentUser.Username;
        }
        RestClient client;
        int id;
        bool currentUser;
        public bool edited = false;
        public bool authorized = true;

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            var request = new RestRequest(Method.PUT);
            request.RequestFormat = DataFormat.Json;


            request.AddJsonBody(new
            {
                username = Config.CurrentUser.Username,
                password = Config.CurrentUser.Password,
                id = id,
                newUsername = usernameTb.Text,
                newPassword = passwordTb.Text,
                isAdmin = isAdminCb.Checked ? 1 : 0
            });

            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                MessageBox.Show(response.ErrorMessage);
                return;
            }
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    authorized = false;
                    this.Close();
                }
                try
                {
                    Response res = new JsonSerializer().Deserialize<Response>(response);
                    if (res.Error == 1)
                    {
                        MessageBox.Show(res.Message);
                    }
                }
                catch
                {
                    MessageBox.Show(response.StatusDescription);
                }
                return;
            }

            try
            {
                Response res = new JsonSerializer().Deserialize<Response>(response);
                MessageBox.Show(res.Message);
                if (res.Error == 0)
                {
                    if (currentUser)
                    {
                        Config.CurrentUser.Username = usernameTb.Text;
                        if (passwordTb.Text != "")
                        {
                            Config.CurrentUser.Password = passwordTb.Text;
                        }
                    }
                    edited = true;
                    this.Close();
                }
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
