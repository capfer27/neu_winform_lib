using System.ComponentModel;

namespace NewWinFormsLib
{
    public partial class UserControl1 : UserControl
    {
        private event EventHandler _comboBoxSelectedElementChange;
        private ComboBox comboBox;

        public ComboBox.ObjectCollection Items
        {
          get {
               return this.comboBox.Items;
          }
        }



        public UserControl1()
        {
            InitializeComponent();
            comboBox.SelectedIndexChanged += (sender, e) =>
            _comboBoxSelectedElementChange?.Invoke(sender, e);

        }

        [Category("Свойства comboBox"),
        Description("Выбранный элемент")]
        public string SelectedItem
        {
            get => comboBox.SelectedItem == null ? string.Empty :
           comboBox.SelectedItem.ToString();
            set => comboBox.SelectedItem = value;
        }

        [Category("События comboBox"), Description("Событие выбора элемента из списка")]
        public event EventHandler ComboBoxSelectedElementChange
        {
            add { _comboBoxSelectedElementChange += value; }
            remove {
                _comboBoxSelectedElementChange -= value;
            }
        }

        /// <summary>
        /// Метод очищения списка comboBox
        /// </summary>
        public void ClearItems()
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
        }
    }
}