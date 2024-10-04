using System.Configuration;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace WikiViewer
{
    public partial class Form1 : Form
    {
        string url = "https://wiki.humaxdigital.com/login.action";
        public Form1()
        {
            InitializeComponent();            
        }

        public void Form1_Load(object sender, EventArgs e) {       
            if (ConfigurationManager.AppSettings["Username"].Length == 0)
            {
                webView21.Visible = false;
                panel1.Visible = true;
            } else
            {
                webView21.Visible = true;
                webView21.Source = new Uri(url);
                webView21.NavigationCompleted += WebView21_NavigationCompleted;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ModifierKeys == Keys.Control && e.KeyCode == Keys.P)
            {
                // Show the login panel
                webView21.Visible = false;
                panel1.Visible = true;
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_KEYDOWN = 0x0100;

            if (m.Msg == WM_KEYDOWN)
            {
                // Check if Ctrl + Z is pressed
                if (ModifierKeys == Keys.Control && (Keys)m.WParam == Keys.P)
                {
                    // Show the login panel
                    webView21.Visible = false;
                    panel1.Visible = true;
                }
            }
            base.WndProc(ref m);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveAccount(textBoxUsername.Text, textBoxPassword.Text);
            panel1.Visible = false;
            webView21.Visible = true;
            webView21.Source = new Uri(url);
            webView21.NavigationCompleted += WebView21_NavigationCompleted;
        }

        private async void WebView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            // Only execute the script when the login page is fully loaded
            if (e.IsSuccess && webView21.Source.ToString().Contains("login"))
            {
                string encryptedUsername = ConfigurationManager.AppSettings["Username"];
                string encryptedPassword = ConfigurationManager.AppSettings["Password"];

                string username = DecryptString(encryptedUsername);
                string password = DecryptString(encryptedPassword);

                string script = $@"
            document.getElementById('os_username').value = '{username}'; // Replace 'usernameFieldId' with the actual ID of the username field
            document.getElementById('os_password').value = '{password}'; // Replace 'passwordFieldId' with the actual ID of the password field
            document.getElementById('loginButton').click(); // Replace 'loginFormId' with the actual ID of the form if needed
            ";

                await webView21.ExecuteScriptAsync(script);                                
            } else if (e.IsSuccess && webView21.Source.ToString().Contains("/pages/viewpage.action?pageId=52430556"))
            {
                webView21.Source = new Uri("https://wiki.humaxdigital.com/pages/viewpage.action?pageId=52430556");
            }
            panel1.Visible = false;                        
        }

        private void saveAccount(string username, string password)
        {            
            string encryptedUsername = EncryptString(username);
            string encryptedPassword = EncryptString(password);

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Username"].Value = encryptedUsername;
            config.AppSettings.Settings["Password"].Value = encryptedPassword;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");            
        }

        // Method to encrypt the string
        private string EncryptString(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes("12345#$#@$DDĐShtF123456"); // Use a secure key and keep it safe
                aes.IV = Encoding.UTF8.GetBytes("12345htF12345678"); // Use a secure IV and keep it safe

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        // Method to decrypt the string
        private string DecryptString(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes("12345#$#@$DDĐShtF123456"); // Use a secure key and keep it safe
                aes.IV = Encoding.UTF8.GetBytes("12345htF12345678"); // Use a secure IV and keep it safe

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
