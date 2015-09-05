using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Logging.Viewer
{
    public delegate void OnFilterChangedHandler(Event eventFilter, DateTime endDate);

    public partial class Filter : UserControl
    {
        bool cmbType_init = true;
        public event OnFilterChangedHandler OnFilterChanged;
        public Filter()
        {
            InitializeComponent();

            cmbType.SelectedIndex = 0;
        }

        bool Validate()
        {
            //Fecha desde > fecha fin
            if (dtStartDate.Value.CompareTo(dtEndDate.Value) > 0)
            {
                errorProvider1.SetError(dtEndDate, "Fecha desde debe ser menor a fecha hasta");
                return false;
            }

            return true;
        }

        void SetFilter()
        {
            errorProvider1.Clear();
            DateTime wEndDate = Fwk.HelperFunctions.DateFunctions.NullDateTime;
            Event wEventFilter =null;
            GetFilter(out wEventFilter, out wEndDate);
            if (OnFilterChanged != null)
                OnFilterChanged(wEventFilter, wEndDate);
        }

        /// <summary>
        /// Get filter
        /// </summary>
        /// <returns></returns>
        public void GetFilter(out Event eventFilter,out DateTime endDate)
        {
             eventFilter = new Event();

             endDate = Fwk.HelperFunctions.DateFunctions.NullDateTime;

            if (cmbType.SelectedIndex == 0)
                eventFilter.LogType = EventType.None;
            else
                eventFilter.LogType = (EventType)Enum.Parse(typeof(EventType), cmbType.Text);

            if (chDates.Checked)
            {
                if ((dtStartDate.Value.CompareTo(dtEndDate.Value)) != 0)
                {
                    endDate = dtEndDate.Value;
                }
                eventFilter.LogDate = dtStartDate.Value;
            }
            if (!string.IsNullOrEmpty(txtText.Text))
            {
                eventFilter.AppId = txtText.Text;
                eventFilter.Source = txtText.Text;
                eventFilter.Machine = txtText.Text;
                eventFilter.User = txtText.Text;
            }
        }
        public void Refresh()
        {
            cmbType.SelectedIndex = 0;
            txtText.Text = string.Empty;
            chDates.Checked = false;
        }
        private void chDates_CheckedChanged(object sender, EventArgs e)
        {
          dtStartDate.Enabled =  dtEndDate.Enabled = chDates.Checked;
          SetFilter();
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtText.Text))
            {
                SetFilter();
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType_init == false)
            {
                SetFilter();
            }
            cmbType_init = false;
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (Validate())
            {
                SetFilter();
            }
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (Validate())
            {
                SetFilter();
            }
        }
    }
}
