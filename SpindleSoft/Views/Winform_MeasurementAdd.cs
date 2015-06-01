using System.ComponentModel;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_MeasurementAdd : Winform_DetailsFormat
    {
        public Winform_MeasurementAdd()
        {
            InitializeComponent();
        }

        private void Winform_MeasurementAdd_Load(object sender, System.EventArgs e)
        {

        }

        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
      //      if (e..Text == System.String.Empty)
      //          return;

      //      string errorMsg = "";
      //      Match _match = Regex.Match(txtEmailID.Text, "^[A-Za-z0-9._%+-]+@[A-Za-z0-9._%+-]+\\.[A-Za-z]{2,6}$");
      //      errorMsg = _match.Success ? "" : "e-mail address must be valid e-mail address format.\n" +
      //"For example 'someone@example.com' ";
      //      errorProvider1.SetError(txtEmailID, errorMsg);

      //      if (errorMsg != "")
      //      {
      //          // Cancel the event and select the text to be corrected by the user.
      //          e.Cancel = true;
      //          txtName.Select(0, txtEmailID.TextLength);
      //      }
        }
    }
}