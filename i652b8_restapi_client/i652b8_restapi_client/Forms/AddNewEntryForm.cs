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
    public partial class AddNewEntryForm : Form
    {
        public AddNewEntryForm(RestClient client)
        {
            InitializeComponent();
            this.client = client;
        }
        RestClient client;
        public bool added = false;
        private void resetBtn_Click(object sender, EventArgs e)
        {
            passwordTb.Text = "";
            md5Tb.Text = "";
            sha1Tb.Text = "";
            sha256Tb.Text = "";
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string password = passwordTb.Text;
            string md5 = md5Tb.Text;
            string sha1 = sha1Tb.Text;
            string sha256 = sha256Tb.Text;


            request.AddObject(new
            {
                username = Config.CurrentUser.Username,
                password = Config.CurrentUser.Password,
                hashedPassword = password,
                md5 = md5,
                sha1 = sha1,
                sha256 = sha256
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
                MessageBox.Show(res.Message);
                if (res.Error == 0)
                {
                    added = true;
                    this.Close();
                }
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void autofillBtn_Click(object sender, EventArgs e)
        {
            if (passwordTb.Text != "")
            {
                md5Tb.Text = Hash.MD5sum(passwordTb.Text);
                sha1Tb.Text = Hash.SHA1sum(passwordTb.Text);
                sha256Tb.Text = Hash.SHA256sum(passwordTb.Text);
            }
        }
    }
}
