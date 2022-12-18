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
    public partial class MainWindow : Form
    {
        public MainWindow(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            client = new RestClient($"http://{Config.Ip}:{Config.Port}/rainbowtable");
            updateClient = new RestClient($"http://{Config.Ip}:{Config.Port}/changeId");
            isAdminClient = new RestClient($"http://{Config.Ip}:{Config.Port}/isAdmin");
            InitializeRainbowTableDgv();
            GetEntries();
            UpdateTimer.Start();
        }

        private RestClient client;
        private RestClient updateClient;
        private RestClient isAdminClient;
        private LoginForm loginForm;
        private int changeId;
        private bool lastClickedSearch = false;

        private void InitializeRainbowTableDgv()
        {
            rainbowTableDgv.Columns.Clear();
            rainbowTableDgv.Columns.Add("id", "id");
            rainbowTableDgv.Columns["id"].Visible = false;
            rainbowTableDgv.Columns.Add("pwd", "Password");
            rainbowTableDgv.Columns.Add("md5", "MD5 hash");
            rainbowTableDgv.Columns.Add("sha1", "SHA-1 hash");
            rainbowTableDgv.Columns.Add("sha256", "SHA256 hash");

            rainbowTableDgv.Columns["pwd"].Width = 95;
            rainbowTableDgv.Columns["md5"].Width = 265;
            rainbowTableDgv.Columns["sha1"].Width = 327;
            rainbowTableDgv.Columns["sha256"].Width = 520;
        }

        private void GetEntries(string filter = "")
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (filter != "")
            {
                request.AddObject(new
                {
                    username = Config.CurrentUser.Username,
                    password = Config.CurrentUser.Password,
                    filter = filter
                });
            }
            else
            {
                request.AddObject(new
                {
                    username = Config.CurrentUser.Username,
                    password = Config.CurrentUser.Password
                });
            }

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
                if (res.Error == 0)
                {
                    changeId = res.Id;
                    rainbowTableDgv.Rows.Clear();
                    foreach (Entry e in res.Entries)
                    {
                        rainbowTableDgv.Rows.Add(e.Id, e.Passwd, e.Md5, e.Sha1, e.Sha256);
                    }
                }
                else
                {
                    MessageBox.Show(res.Message);
                }
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private int GetCurrentRow()
        {
            try
            {
                return rainbowTableDgv.SelectedCells[0].RowIndex;
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a row!");
                return -1;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateTimer.Stop();
            loginForm.ResetForm();
            loginForm.Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            GetEntries();
            lastClickedSearch = false;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            GetEntries(filterTb.Text);
            lastClickedSearch = true;
        }

        private void addNewBtn_Click(object sender, EventArgs e)
        {
            AddNewEntryForm anef = new AddNewEntryForm(client);
            anef.ShowDialog();
            if (anef.added)
            {
                GetEntries();
            }
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            int rowId = GetCurrentRow();
            if (rowId >= 0)
            {
                int id = int.Parse(rainbowTableDgv.Rows[rowId].Cells["id"].Value.ToString());
                string passwd = rainbowTableDgv.Rows[rowId].Cells["pwd"].Value.ToString();
                string md5 = rainbowTableDgv.Rows[rowId].Cells["md5"].Value.ToString();
                string sha1 = rainbowTableDgv.Rows[rowId].Cells["sha1"].Value.ToString();
                string sha256 = rainbowTableDgv.Rows[rowId].Cells["sha256"].Value.ToString();
                ModifyEntryForm mef = new ModifyEntryForm(client, id, passwd, md5, sha1, sha256);
                mef.ShowDialog();
                if (mef.modified)
                {
                    GetEntries();
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure you want to delete the selected entry?", "Delete entry", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                int rowId = GetCurrentRow();
                if (rowId < 0)
                {
                    return;
                }
                int id = int.Parse(rainbowTableDgv.Rows[rowId].Cells["id"].Value.ToString());
                var request = new RestRequest(Method.DELETE);
                request.RequestFormat = DataFormat.Json;


                request.AddObject(new
                {
                    username = Config.CurrentUser.Username,
                    password = Config.CurrentUser.Password,
                    id = id
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
                        GetEntries();
                    }
                }
                catch (System.Runtime.Serialization.SerializationException)
                {
                    MessageBox.Show("Something went wrong!");
                }
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            bool needUpdate = checkUpdate();
            if (needUpdate)
            {
                if (lastClickedSearch)
                {
                    GetEntries(filterTb.Text);
                }
                else
                {
                    GetEntries();
                }
            }
        }

        private bool checkUpdate()
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = updateClient.Execute(request);
            if (response.ErrorException != null)
            {
                return false;
            }
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }
            try
            {
                Response res = new JsonSerializer().Deserialize<Response>(response);
                if (res.Error == 0)
                {
                    if (res.Id != changeId)
                    {
                        changeId = res.Id;
                        return true;
                    }
                }
            }
            catch (System.Runtime.Serialization.SerializationException)
            {  }
            return false;
        }

        private void userManagementBtn_Click(object sender, EventArgs e)
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddObject(new
            {
                username = Config.CurrentUser.Username,
                password = Config.CurrentUser.Password
            });

            var response = isAdminClient.Execute(request);
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
                if (res.Error == 0)
                {
                    if (res.IsAdmin == 1)
                    {
                        UsersForm uf = new UsersForm();
                        uf.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Only admins can use this feature!");
                    }
                }
                else
                {
                    MessageBox.Show(res.Message);
                }
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                MessageBox.Show("Something went wrong!");
            }
        }
    }
}
