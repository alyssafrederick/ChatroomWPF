using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatRoomAlyssa
{
    public partial class CustomTextBox : UserControl
    {
        public int BorderWidth { get; set; }
        public Color BorderColor { get; set; }

        public char PasswordCharacter { get; set; }
        public bool IsPassword { get; set; }

        public int BlinkTime
        {
            get
            {
                return cursorBlink.Interval;
            }
            set
            {
                cursorBlink.Interval = value;
            }
        }

        public new string Text
        {
            get
            {
                return hiddenTextBox.Text;
            }
            set
            {
                hiddenTextBox.Text = value;
            }
        }

        public bool MultiLine
        {
            get
            {
                return hiddenTextBox.Multiline;
            }
            set
            {
                hiddenTextBox.Multiline = value;
            }
        }

        public new Font Font
        {
            get
            {
                return hiddenTextBox.Font;
            }
            set
            {
                hiddenTextBox.Font = value;
            }
        }

        public CustomTextBox()
        {
            InitializeComponent();
            this.Click += new EventHandler(CustomTextBox_Click);
            this.TabStop = true;
            BorderWidth = 1;
            hiddenTextBox.TextChanged += new EventHandler(hiddenTextBox_TextChanged);
            hiddenTextBox.LostFocus += new EventHandler(hiddenTextBox_LostFocus);
            hiddenTextBox.SelectionChanged += new EventHandler(hiddenTextBox_SelectionChanged);
            PasswordCharacter = '*';
        }

        void hiddenTextBox_SelectionChanged(object sender, EventArgs e)
        {
            isBlinked = true;
            this.Invalidate();
        }

        void hiddenTextBox_LostFocus(object sender, EventArgs e)
        {
            isBlinked = false;
            this.Invalidate();
        }

        void hiddenTextBox_TextChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        void CustomTextBox_Click(object sender, EventArgs e)
        {
            hiddenTextBox.Focus();
        }

        float x = 2;

        protected override void OnPaint(PaintEventArgs e)
        {
            float cursorMeasurement = e.Graphics.MeasureString(hiddenTextBox.Text.Substring(0, hiddenTextBox.SelectionStart), hiddenTextBox.Font).Width;
            SizeF selectionSize = e.Graphics.MeasureString(hiddenTextBox.Text.Substring(hiddenTextBox.SelectionStart, hiddenTextBox.SelectionLength), hiddenTextBox.Font);
            if (cursorMeasurement + x > Width - BorderWidth)
            {
                x -= e.Graphics.MeasureString(" ", hiddenTextBox.Font).Width;
            }
            if (cursorMeasurement + x < BorderWidth)
            {
                x += e.Graphics.MeasureString(" ", hiddenTextBox.Font).Width;
            }

            e.Graphics.FillRectangle(new SolidBrush(BorderColor), 0, 0, Width, BorderWidth);
            e.Graphics.FillRectangle(new SolidBrush(BorderColor), 0, 0, BorderWidth, Height);
            e.Graphics.FillRectangle(new SolidBrush(BorderColor), Width - BorderWidth, 0, BorderWidth, Height);
            e.Graphics.FillRectangle(new SolidBrush(BorderColor), 0, Height - BorderWidth, Width, BorderWidth);
            if (IsPassword)
            {
                string password = "";
                for (int i = 0; i < hiddenTextBox.Text.Length; i++)
                {
                    password += PasswordCharacter;
                }
                e.Graphics.DrawString(password, hiddenTextBox.Font, new SolidBrush(ForeColor), new PointF(x, 2));
            }
            else
            {
                e.Graphics.DrawString(hiddenTextBox.Text, hiddenTextBox.Font, new SolidBrush(ForeColor), new PointF(x, 2));
            }
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(127, hiddenTextBox.SelectionColor)), cursorMeasurement + 10 + x, 0, selectionSize.Width - 10, selectionSize.Height);
            if (isBlinked)
            {
                e.Graphics.DrawString("|", hiddenTextBox.Font, new SolidBrush(ForeColor), new PointF(cursorMeasurement + x - 5, 0));
            }
            //base.OnPaint(e);
        }

        bool isBlinked = false;

        private void cursorBlink_Tick(object sender, EventArgs e)
        {
            if (hiddenTextBox.Focused)
            {
                isBlinked = !isBlinked;
                this.Invalidate();
            }
        }
    }
}
