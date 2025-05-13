using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingSystem.Forms
{
    public partial class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;

        public bool IsAuthenticated { get; private set; }
        public bool IsAdmin { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Авторизация";
            this.Width = 300;
            this.Height = 200;

            // Поле для логина
            txtUsername = new TextBox
            {
                PlaceholderText = "Логин",
                Width = 200,
                Top = 20,
                Left = 50
            };

            // Поле для пароля
            txtPassword = new TextBox
            {
                PlaceholderText = "Пароль",
                Width = 200,
                Top = 50,
                Left = 50,
                PasswordChar = '*'
            };

            // Кнопка входа
            btnLogin = new Button
            {
                Text = "Войти",
                Width = 100,
                Top = 90,
                Left = 100
            };
            btnLogin.Click += BtnLogin_Click;

            this.Controls.Add(txtUsername);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "admin123")
            {
                IsAuthenticated = true;
                IsAdmin = true;
                this.Close();
            }
            else if (username == "user" && password == "user123")
            {
                IsAuthenticated = true;
                IsAdmin = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
