using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnergyTotal.WinForm.Forms.Dialogs
{
    public partial class Input : Form
    {
        internal Func<Input, string, bool>? OnCancelCallback = null;
        internal Func<Input, string, bool>? OnConfirmCallback = null;

        public Input(
            string? content = null,
            string title = "Input",
            string defaultInput = "",
            Func<Input, string, bool>? cancelCallback = null,
            Func<Input, string, bool>? confirmCallback = null)
        {
            InitializeComponent();

            Text = title;
            if (content is not null) contentLabel.Text = content;
            else contentLabel.Visible = false;
            inputBox.Text = defaultInput;

            OnCancelCallback = cancelCallback;
            OnConfirmCallback = confirmCallback;
        }

        #region Private Events

        private void OnConfirmClick(object sender, EventArgs e)
        {
            if (OnConfirmCallback?.Invoke(this, inputBox.Text) ?? true)
                Close();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            if (OnCancelCallback?.Invoke(this, inputBox.Text) ?? true)
                Close();
        }

        #endregion
    }
}
