using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IDE
{
    public partial class TextEnterBox : Form
    {
        public TextEnterBox()
        {
            InitializeComponent();
        }

        public TextEnterBox(string title)
        {
            InitializeComponent();
            this.Text = title;
        }

        public TextEnterBox(string title, Color style)
        {
            InitializeComponent();
            this.Text = title;
            this.Style = style;
        }

        [Description("窗体风格")]
        private Color Style { get; set; }

        private Color BackStyle { get; set; }
        

        public string Show()
        {
            base.Show();
            return uiTextBox1.Text;
        }
    }
}
