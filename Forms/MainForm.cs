using TestingSystem.Forms;

namespace TestingSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
