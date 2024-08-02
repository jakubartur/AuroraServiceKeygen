using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace aurora_service_keygen
{
    public partial class Form1 : Form
    {
        private Label lblSerialNumber;
        private TextBox txbSerialNumber;
        private Button btnGenerate;
        private Label lblPassword;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Ustawienia formularza
            this.Text = "Aurora Inverter Serwisowy Generator Kluczy";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Etykieta dla numeru seryjnego
            lblSerialNumber = new Label()
            {
                Text = "Wprowadź numer seryjny:",
                Location = new Point(20, 80),
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            // Pole tekstowe dla numeru seryjnego
            txbSerialNumber = new TextBox()
            {
                Location = new Point(250, 80),
                Width = 300,
                Font = new Font("Arial", 12)
            };

            // Przycisk do generowania hasła
            btnGenerate = new Button()
            {
                Text = "Generuj hasło Serwisowe",
                Location = new Point(20, 140),
                Width = 530,
                Height = 40,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            btnGenerate.Click += BtnGenerate_Click;

            // Etykieta do wyświetlania wygenerowanego hasła
            lblPassword = new Label()
            {
                Text = "",
                Location = new Point(20, 220),
                Size = new Size(550, 40),
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Dodanie kontrolek do formularza
            this.Controls.Add(lblSerialNumber);
            this.Controls.Add(txbSerialNumber);
            this.Controls.Add(btnGenerate);
            this.Controls.Add(lblPassword);
        }

private void BtnGenerate_Click(object sender, EventArgs e)
{
    int parsedValue;
    if ((txbSerialNumber.Text.Length != 6) || (!int.TryParse(txbSerialNumber.Text, out parsedValue)))
    {
        using (var errorForm = new ErrorForm("Wprowadź SN 6-cyfrowy numer seryjny z Aurory - ostanie 6-cyfr! jesli numer jest dłuszy"))
        {
            errorForm.ShowDialog(this);
        }
        return;
    }

    string password = GenerateServicePassword(txbSerialNumber.Text);
    lblPassword.Text = "Hasło serwisowe: " + password;
}


        private string GenerateServicePassword(string serialNumber)
        {
            byte[] result = new byte[6];
            string seed = "919510";
            for (int index = 0; index < 6; index++)
            {
                byte b = (byte)(serialNumber[index] - '0');
                byte c = (byte)(seed[index] - '0');
                if (index % 2 == 0)
                {
                    result[index] = (byte)((((uint)b + (uint)c) % 10) + '0');
                }
                else
                {
                    result[index] = (byte)((((uint)b - (uint)c + 10) % 10) + '0');
                }
            }
            return Encoding.UTF8.GetString(result);
        }
    }
}
