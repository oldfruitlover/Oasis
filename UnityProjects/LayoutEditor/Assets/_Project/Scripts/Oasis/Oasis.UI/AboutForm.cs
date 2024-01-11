using Oasis.UI.ViewModels;
using System.Drawing;
using System.Windows.Forms;

namespace Oasis.UI
{
    public class AboutForm : Form
    {
        public ViewModelAbout ViewModelAbout
        {
            get;
            private set;
        } = null;

        public UIController UIController
        {
            get;
            private set;
        } = null;


        public AboutForm(UIController uiController)
        {
            UIController = uiController;

            InitialiseWinFormsUI();
        }

        private void InitialiseWinFormsUI()
        {
            InitialiseForm();
            ViewModelAbout = new ViewModelAbout(UIController.RootUI, this);
        }

        private void InitialiseForm()
        {
            //uwfHeaderHeight = 0;
            //uwfShadowBox = false;

            // TODO need to figure this size stuff out once the 'rebuild ui on window resize'
            // stuff is underway - user may have their taskbar to the side for instance.

            Text = "About";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimumSize = new Size(480, 320);
            Size = MinimumSize;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            

            //MaximizeBox = false;
            //ControlBox = false;
            //AutoScroll = true;
            //BackColor = Color.Transparent;

            //uwfBorderColor = BackColor;

            //SetWindowState(FormWindowState.Maximized);
        }


    }
}
