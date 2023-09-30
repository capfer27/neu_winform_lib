using System.ComponentModel;
using System.Text.RegularExpressions;

namespace NewWinFormsLib
{
    public partial class PhoneControl : UserControl
    {
        private TextBox textBox;
        private ToolTip toolTip;

        [Category("Свойства textBox"), Description("Шаблонвводимого значения")]

        public string Pattern { get; set; } = string.Empty;

        [Category("Свойства textBox"),
Description("Значение")]
        public string Value
        {
            get
            {
               return validate(textBox.Text);
            }
            set
            {
                textBox.Text = value;
            }
        }

        /// <summary>
        /// Метод установки toolTip(подсказка при наведении)
        /// </summary>
        /// <param name="prompt">Текст подсказки</param>
        public void SetToolTip(string prompt)
        {
         toolTip.SetToolTip(textBox, prompt);
        }

        private String validate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            if (!Regex.IsMatch(input, Pattern))
            {
               throw new ArgumentException();
            }
            
            return input;
        }


        public PhoneControl()
        {
            InitializeComponent();
        }
    }
}
