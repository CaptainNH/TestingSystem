using TestingSystem.Forms;

namespace TestingSystem
{
    public partial class MainForm : Form
    {
        public MainForm(bool isAdmin)
        {
            InitializeComponent();
            if (!isAdmin)
            {
                buttonCreateTest.Visible = false;
            }
        }

        private void buttonCreateTest_Click(object sender, EventArgs e)
        {
            var createTestForm = new CreateTestForm();
            createTestForm.ShowDialog();
        }

        private void buttonPassTest_Click(object sender, EventArgs e)
        {
            var passTestForm = new PassTestForm();
            passTestForm.ShowDialog();
        }
    }
}
