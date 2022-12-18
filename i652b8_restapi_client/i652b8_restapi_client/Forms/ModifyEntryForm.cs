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
    public partial class ModifyEntryForm : Form
    {
        public ModifyEntryForm(RestClient client, int id, string password, string md5, string sha1, string sha256)
        {
            InitializeComponent();
            this.client = client;
            this.id = id;
            passwd = password;
            passwordTb.Text = password;
            this.md5 = md5;
            md5Tb.Text = md5;
            this.sha1 = sha1;
            sha1Tb.Text = sha1;
            this.sha256 = sha256;
            sha256Tb.Text = sha256;
        }
        RestClient client;
        int id;
        string passwd;
        string md5;
        string sha1;
        string sha256;
        public bool modified = false;

        private void resetBtn_Click(object sender, EventArgs e)
        {
            passwordTb.Text = passwd;
            md5Tb.Text = md5;
            sha1Tb.Text = sha1;
            sha256Tb.Text = sha256;
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            var request = new RestRequest(Method.PUT);
            request.RequestFormat = DataFormat.Json;
            string password = passwordTb.Text;
            string md5 = md5Tb.Text;
            string sha1 = sha1Tb.Text;
            string sha256 = sha256Tb.Text;


            request.AddJsonBody(new
            {
                username = Config.CurrentUser.Username,
                password = Config.CurrentUser.Password,
                id = id,
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
                    modified = true;
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
