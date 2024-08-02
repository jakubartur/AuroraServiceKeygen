using System;
using System.Drawing;
using System.Windows.Forms;

namespace aurora_service_keygen
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string message)
        {
            InitializeComponent();
            lblErrorMessage.Text = message;
        }

        private void InitializeComponent()
        {
            this.lblErrorMessage = new Label();
            this.SuspendLayout();
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = false;
            this.lblErrorMessage.Text = "Error message goes here";
            this.lblErrorMessage.Font = new Font("Arial", 10, FontStyle.Bold);
            this.lblErrorMessage.ForeColor = Color.Red;
            this.lblErrorMessage.Location = new Point(20, 20);
            this.lblErrorMessage.Size = new Size(360, 80); // Increase height to accommodate text
            this.lblErrorMessage.TextAlign = ContentAlignment.MiddleCenter;
            this.lblErrorMessage.Padding = new Padding(10); // Padding to ensure text is not too close to the edges
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 120); // Adjust height as needed
            this.Controls.Add(this.lblErrorMessage);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Błąd Generowania Hasła Serwisowego";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblErrorMessage;
    }
}
