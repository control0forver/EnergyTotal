namespace EnergyTotal.WinForm.Forms.Dialogs
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            richTextBox.Rtf = Resources.About.Resource.AboutEnergyTotal;
        }
    }
}
