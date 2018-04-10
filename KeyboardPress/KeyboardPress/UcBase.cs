using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyboardPress_Analyzer.Helper;

namespace KeyboardPress
{
    public partial class UcBase : UserControl
    {
        protected MainForm MF = null;
        
        public UcBase()
        {
            InitializeComponent();
        }

        private void UcBase_Load(object sender, EventArgs e)
        {
            //to do: cia kazka pakeisti, nes neleidzia programint
            //if (this.ParentForm.GetType() != typeof(MainForm))
            //    throw new NotSupportedException("Netinkamai kviečiama klasė. Klasė gali būti iškviesta tik iš MainForm klasės");
            //else
                MF = (MainForm)this.ParentForm;

            LoadComboBoxValues();
            SetDateTimePickersValues();
        }

        protected virtual void LoadComboBoxValues()
        {
            
        }

        protected virtual void SetDateTimePickersValues()
        {
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
        }


    }
}
