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

        protected readonly string cbProgramAllValuesName = "Visos programos";

        public UcBase()
        {
            InitializeComponent();
        }

        private void UcBase_Load(object sender, EventArgs e)
        {
            UcBaceLoad();
        }

        protected virtual void UcBaceLoad()
        {
            //to do: cia kazka pakeisti, nes neleidzia programint
            //if (this.ParentForm.GetType() != typeof(MainForm))
            //    throw new NotSupportedException("Netinkamai kviečiama klasė. Klasė gali būti iškviesta tik iš MainForm klasės");
            //else
            MF = (MainForm)this.ParentForm;

            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);

            LoadComboBoxValues();

            RefreshData(true);
        }

        protected virtual void LoadComboBoxValues()
        {
            try
            {
                var lst = DBHelper.GetDataTableDb($@"
SELECT
	--record_id,
	IFNULL(proc_name, '') as 'proc_name'
FROM KP_WINDOWS
ORDER BY proc_name
").AsEnumerable().Select(x=>x.Field<string>("proc_name")).ToList();

                lst.AddRange(MF.Kpt.MouseEvents.Select(x => x.ActiveWindowName).Distinct().ToArray());
                
                lst = lst.Distinct().OrderBy(x=>x).ToList();

                var dt = new DataTable();
                dt.Columns.Add("value_member", typeof(string));
                dt.Columns.Add("display_member", typeof(string));
                dt.Rows.Add(cbProgramAllValuesName, cbProgramAllValuesName);
                foreach(var s in lst)
                {
                    //dt.Rows.Add(s, String.IsNullOrEmpty(s) ? "" : s.First().ToString().ToUpper() + s.Substring(1));
                    dt.Rows.Add(s, s);
                }
                cbMainFilter.DataSource = dt;
                cbMainFilter.DisplayMember = "display_member";
                cbMainFilter.ValueMember = "value_member";
            }
            catch (Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog("Klaida bandant gauti galimų langų sąrašą", ex);
            }
        }

        protected virtual void CheckBoxAutoRefresh_StatusChanged()
        {
            try
            {
                if (checkBoxAutoRefresh.Checked)
                {
                    timerRefresh.Interval = (int)numericUpDownRefreshSeconds.Value * 1000;
                    timerRefresh.Enabled = true;
                    numericUpDownRefreshSeconds.Enabled = false;
                }
                else
                {
                    timerRefresh.Enabled = false;
                    numericUpDownRefreshSeconds.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog("Klaida apdorojant automatinį duomenų atnaujinimą", ex);
            }
        }

        protected virtual void RefreshData(bool firstLoad = false)
        {

        }

        private void checkBoxAutoRefresh_Click(object sender, EventArgs e)
        {
            CheckBoxAutoRefresh_StatusChanged();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if(MF.WindowState != FormWindowState.Minimized)
                RefreshData(false);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData(false);
        }

        
    }
}
