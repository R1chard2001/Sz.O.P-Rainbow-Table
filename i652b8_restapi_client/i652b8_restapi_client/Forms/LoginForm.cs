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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            client = new RestClient($"http://{Config.Ip}:{Config.Port}/login");
        }
        RestClient client;

        private void Login()
        {
            string username = usernameTb.Text;
            string password = passwordTb.Text;
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddObject(new
            {
                username = usernameTb.Text,
                password = passwordTb.Text
            });

            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                MessageBox.Show(response.ErrorMessage);
                return;
            }
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
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
                if (res.Error != 0)
                {
                    MessageBox.Show(res.Message);
                    return;
                }
                else
                {
                    Config.CurrentUser = new User() { Username = username, Password = password };
                }
                this.Hide();
                new MainWindow(this).Show();
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                MessageBox.Show("Incorrect username or password!");
            }
        }

        private void ResetInput()
        {
            usernameTb.Text = "";
            passwordTb.Text = "";
            Config.CurrentUser = null;
        }

        public void ResetForm()
        {
            ResetInput();
            int width = Screen.FromControl(this).Bounds.Width;
            int height = Screen.FromControl(this).Bounds.Height;
            this.Location = new Point(width / 2 - this.Width / 2, height / 2 - this.Height / 2);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            ResetInput();
        }
    }
}
