using System.ComponentModel;
using System.Drawing.Drawing2D;


namespace ResumeBuilder.Controllers
{
    internal class RJToggleButton : CheckBox
    {
        //Fields
        private Color onBackColor = Color.Black;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.White;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;

        //Properties
        [Category("RJ Code Advance")]
        public Color OnBackColor
        {
            get
            {
                return onBackColor;
            }

            set
            {
                onBackColor = value;
                Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color OnToggleColor
        {
            get
            {
                return onToggleColor;
            }

            set
            {
                onToggleColor = value;
                Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color OffBackColor
        {
            get
            {
                return offBackColor;
            }

            set
            {
                offBackColor = value;
                Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color OffToggleColor
        {
            get
            {
                return offToggleColor;
            }

            set
            {
                offToggleColor = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }

#pragma warning disable CS8765 // Nullability of type of parameter 'value' doesn't match overridden member (possibly because of nullability attributes).
            set
#pragma warning restore CS8765 // Nullability of type of parameter 'value' doesn't match overridden member (possibly because of nullability attributes).
            {

            }
        }

        [Category("RJ Code Advance")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get
            {
                return solidStyle;
            }

            set
            {
                solidStyle = value;
                Invalidate();
            }
        }

        //Constructor
        public RJToggleButton()
        {
            MinimumSize = new Size(45, 22);
        }

        //Methods
        private GraphicsPath GetFigurePath()
        {
            int arcSize = Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            pevent.Graphics.Clear(Parent.BackColor);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (Checked) //ON
            {
                //Draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                    new Rectangle(Width - Height + 1, 2, toggleSize, toggleSize));
            }
            else //OFF
            {
                //Draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                    new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}
