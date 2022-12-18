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
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
            client = new RestClient($"http://{Config.Ip}:{Config.Port}/users");
            updateClient = new RestClient($"http://{Config.Ip}:{Config.Port}/userChangeId");
            UpdateTimer.Start();
        }
        private RestClient client;
        private RestClient updateClient;
        private int changeId = 0;

        private void updateUsersDgv()
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            
            request.AddObject(new
            {
                username = Config.CurrentUser.Username,
                password = Config.CurrentUser.Password
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
                if (res.Error == 0)
                {

                    UsersDgv.DataSource = res.Users;
                    UsersDgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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

        private void addNewBtn_Click(object sender, EventArgs e)
        {
            AddUserForm auf = new AddUserForm(this.client);
            auf.ShowDialog();
            if (auf.added)
            {
                updateUsersDgv();
            }
            if (!auf.authorized)
            {
                this.Close();
            }
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            int currentRow = GetCurrentRow();
            if (currentRow != -1)
            {
                User u = new User();
                u.Id = int.Parse(UsersDgv.Rows[currentRow].Cells[0].Value.ToString());
                u.Username = UsersDgv.Rows[currentRow].Cells[1].Value.ToString();
                u.IsAdmin = int.Parse(UsersDgv.Rows[currentRow].Cells[3].Value.ToString());
                ModifyUserForm muf = new ModifyUserForm(u, client);
                muf.ShowDialog();
                if (muf.edited)
                {
                    updateUsersDgv();
                }
                if (!muf.authorized)
                {
                    this.Close();
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure you want to delete the selected user?", "Delete user", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                int rowId = GetCurrentRow();
                if (rowId < 0)
                {
                    return;
                }
                int id = int.Parse(UsersDgv.Rows[rowId].Cells[0].Value.ToString());
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
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
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
                        updateUsersDgv();
                    }
                }
                catch (System.Runtime.Serialization.SerializationException)
                {
                    MessageBox.Show("Something went wrong!");
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            updateUsersDgv();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            updateUsersDgv();
        }

        private int GetCurrentRow()
        {
            try
            {
                return UsersDgv.SelectedCells[0].RowIndex;
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a row!");
                return -1;
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
            { }
            return false;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            bool needUpdate = checkUpdate();
            if (needUpdate)
            {
                updateUsersDgv();
            }
        }

        private void UsersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateTimer.Stop();
        }
    }
}
