using System;
using System.Windows.Forms;
using Unity;

namespace ToDoList.Applications.ApplicationWinForms
{
    public partial class Form1 : Form
    {
        public static bool IsLoggedIn { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Account account = DependencyResolver.Container.Resolve<Account>();
            string user = username.Text;
            string pass = password.Text;

            if (user == "" || pass == "")
                MessageBox.Show("You didn't fill username or password");
            else
                account.LogIn(user, pass);

            if (IsLoggedIn == true)
            {
                this.Hide();
                var form2 = DependencyResolver.Container.Resolve<FrmMain>();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Account account = DependencyResolver.Container.Resolve<Account>();
            string user = username.Text;
            string pass = password.Text;
            if (user == "" || pass == "")
                MessageBox.Show("You didn't fill username or password");
            else
                account.Register(user, pass);
        }
    }
}
