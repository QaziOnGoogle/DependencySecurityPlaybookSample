using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public sealed class MainForm : Form
    {
        public MainForm()
        {
            Text = "WinFormsApp1 - Dependency Security Sample";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(560, 240);

            var label = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12),
                Text = "Sample WinForms application\n.NET Framework 4.8"
            };

            Controls.Add(label);
        }
    }
}
