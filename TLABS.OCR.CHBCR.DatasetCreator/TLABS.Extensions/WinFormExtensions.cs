using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TLABS.Extensions
{
    public enum AlignmentStyle
    {
        Center,
        MiddleLeft,
        MiddleCenter,
        MiddleRight
    }

    public static class WinformExtensions
    {
        /// <summary>
        /// Clears a control
        /// </summary>
        /// <param name="C"></param>
        public static void Clear(this Control C)
        {
            C.Controls.Clear();
        }      

        /// <summary>
        /// Convert the image into byte array
        /// </summary>
        /// <param name="img">The image to convert</param>
        /// <returns></returns>
        public static byte[] GetBytes(this Image img)
        {
            byte[] byteArray = new byte[0];
            if (img != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    stream.Close();

                    byteArray = stream.ToArray();
                }
            }
            return byteArray;
        }

        /// <summary>
        /// Returns if the image is same as the specified image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="image_to_compare"></param>
        /// <returns></returns>
        public static bool SameAs(this Image image, Image image_to_compare)
        {
            byte[] img1Bytes = image.GetBytes();
            byte[] img2Bytes = image_to_compare.GetBytes();
            return img1Bytes.IsEqual(img2Bytes);
        }           

        /// <summary>
        /// Show the image on a form
        /// </summary>
        /// <param name="image">The image to be shown</param>
        public static void Show(this Image image)
        {
            if (image != null)
            {
                Form f = new Form();

                int w = image.Width;
                int h = image.Height;

                f.Size = new Size(w + 50, h + 40);
                f.Text = "Showing image";

                PictureBox pic = new PictureBox();
                pic.Size = new Size(w, h);
                pic.Location = new Point(0, 0);
                pic.Image = image;
                pic.SizeMode = PictureBoxSizeMode.CenterImage;

                f.Controls.Add(pic);

                f.ShowDialog();
            }
        }

        /// <summary>
        /// Shows the control on a form
        /// </summary>
        /// <param name="C"></param>
        public static void ShowControl(this Control C)
        {
            if (C != null)
            {
                Form f = new Form();
                f.Size = new Size(C.Width + 50, C.Height + 50);
                f.StartPosition = FormStartPosition.CenterScreen;

                f.Controls.Add(C);
                C.DockCenter();
                f.ShowDialog();
            }
        }

        /// <summary>
        /// Sorts the System.Data.DataTable according to specified order
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static DataTable Sort(this DataTable dt, string order)
        {
            DataView dv = new DataView(dt);
            dv.Sort = order;
            return dv.ToTable();
        }

        /// <summary>
        /// Swap the column ordinals of a datatable 
        /// </summary>
        /// <param name="dt">Datatable</param>
        /// <param name="index1">First index</param>
        /// <param name="index2">Second index</param>
        public static void SwapColumns(this DataTable dt, int index1, int index2)
        {
            dt.Columns[index1].SetOrdinal(index2);
        }

        /// <summary>
        /// Show the datatable content on a form
        /// </summary>
        /// <param name="dt">Datatable</param>
        public static void Show(this DataTable dt)
        {
            try
            {
                DataViewerForm DVF = new DataViewerForm();
                DVF.Data = dt;
                DVF.ShowDialog();
            }
            catch
            {
            }           
        }      

        /// <summary>
        /// Returns the System.Windows.Forms.DataGridView as System.Data.DataTable
        /// </summary>
        /// <param name="DGV"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this DataGridView DGV)
        {
            DataTable DaTa = new DataTable();
            for (int j = 0; j < DGV.Columns.Count; j++)
            {
                DaTa.Columns.Add(DGV.Columns[j].HeaderText);
            }

            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                DaTa.Rows.Add();
                for (int j = 0; j < DGV.Columns.Count; j++)
                {
                    DaTa.Rows[i][j] = DGV.Rows[i].Cells[j].Value.ToString();
                }
            }
            return DaTa;
        }

        /// <summary>
        /// Returns a bool value whether the mouse is over a control  
        /// </summary>
        /// <param name="C"></param>
        /// <returns>Bool: True if mouse is over the control</returns>
        public static bool IsMouseOverMe(this Control C)
        {
            Control Parent = C.Parent;
            if (Parent != null)
            {
                Point P = Parent.PointToClient(Cursor.Position);
                if (P.X > C.Left && P.X < C.Right && P.Y > C.Top && P.Y < C.Bottom)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }   

        public static void MergeChilds(this Control Control)
        {
            Control.Paint += delegate(object sender, PaintEventArgs e)
            {
                Control.SuspendLayout();
                foreach (Control ctrl in Control.Controls)
                {
                    ctrl.Visible = true;
                    Bitmap bmp = new Bitmap(ctrl.Width, ctrl.Height);
                    ctrl.DrawToBitmap(bmp, new Rectangle(0, 0, ctrl.Width, ctrl.Height));
                    ctrl.Visible = false;
                    e.Graphics.DrawImage(bmp, new Point(ctrl.Left, ctrl.Top));
                }
                Control.ResumeLayout(false);
            };
        }

        public static void MergeChildTexts(this Control Control)
        {
            foreach (Control ctrl in Control.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.Visible = false;
                }
            }
            Control.Paint += delegate(object sender, PaintEventArgs e)
            {
                foreach (Control ctrl in Control.Controls)
                {
                    if (ctrl is Label)
                    {
                        Label L = (Label)ctrl;
                        e.Graphics.DrawString(L.Text, L.Font, new SolidBrush(L.ForeColor), L.Left, L.Top);
                    }
                }

            };

        }
     
        /// <summary>
        /// Returns the point for which the control will be in vertical mid point of its container.
        /// </summary>
        /// <param name="Control"></param>
        /// <returns></returns>
        public static int MidH(this Control Control)
        {
            if (Control.Parent != null)
            {
                return (Control.Parent.Height - Control.Height) / 2;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns the point for which the control will be in horizontal mid point of its container.
        /// </summary>
        /// <param name="Control"></param>
        /// <returns></returns>
        public static int MidW(this Control Control)
        {
            if (Control.Parent != null)
            {
                return (Control.Parent.Width - Control.Width) / 2;
            }
            else
            {
                return 0;
            }
        }

        public static int yAlignPoint(this Control c, Control a)
        {
            return a.Top + (a.Height - c.Height) / 2;
        }

        public static int xAlignPoint(this Control c, Control a)
        {
            return a.Left + (a.Width - c.Width) / 2;
        }

        public static void CopyChilds(this Control C, Control CopyFrom)
        {
            Control[] Controls = new Control[CopyFrom.Controls.Count];
            CopyFrom.Controls.CopyTo(Controls, 0);
            C.Controls.AddRange(Controls);
        }

        public static void Delay(this Control C, int milisecond)
        {
            milisecond = Math.Abs(milisecond);
            if (milisecond > 0)
            {
                DateTime Start = DateTime.Now;
                while (true)
                {
                    DateTime Now = DateTime.Now;
                    TimeSpan T = Now.Subtract(Start);
                    if (T.Milliseconds >= milisecond)
                    {
                        break;
                    }
                }
            }
        }

        public static void Add(this Control C, Control c)
        {
            C.Controls.Add(c);
        }

        public static Point ActualLocation(this Control C)
        {
            Point Pos = new Point(0, 0);
            while (C != null)
            {
                Pos.X += C.Location.X;
                Pos.Y += C.Location.Y;
                C = C.Parent;
            }
            return Pos;
        }

        /// <summary>
        /// Add a text control at a specific position on the control.
        /// </summary>
        /// <param name="Control"></param>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Position"></param>
        public static Label AddText(this Control Control, string Text, Font Font, Point Location)
        {
            Label Label = new Label();
            Label.Text = Text;
            Label.AutoSize = true;
            Label.Font = Font;
            Label.BackColor = Color.Transparent;
            Control.Controls.Add(Label);
            if (Location.Y == -1000)
            {
                Label.Location = new Point(Location.X, Label.MidH());
            }
            else if (Location.X == -1000)
            {
                Label.Location = new Point(Label.MidW(), Location.Y);
            }
            else
            {
                Label.Location = Location;
            }
            Label.Refresh();
            return Label;
        }

        public static Label AddText(this Control Control, string Text, Font Font, Point Location, Color ForeColor)
        {
            Label Label = new Label();
            Label.Text = Text;
            Label.AutoSize = true;
            Label.Font = Font;
            Label.BackColor = Color.Transparent;
            Label.ForeColor = ForeColor;
            Control.Controls.Add(Label);

            Label.Location = new Point(Location.X == -1000 ? Label.MidW() : Location.X, Location.Y == -1000 ? Label.MidH() : Location.Y);

            Label.Refresh();
            return Label;
        }

        public static Label AddMultilineText(this Control Control, string Text, Font Font, Point Location, int MaxWidth, Color ForeColor)
        {
            Label Label = new Label();
            Label.MaximumSize = new Size(MaxWidth, int.MaxValue);
            Label.Text = Text;
            Label.AutoSize = true;
            Label.Font = Font;
            Label.BackColor = Color.Transparent;
            Label.ForeColor = ForeColor;
            Control.Controls.Add(Label);

            Label.Location = new Point(Location.X == -1000 ? Label.MidW() : Location.X, Location.Y == -1000 ? Label.MidH() : Location.Y);

            Label.Refresh();
            return Label;
        }

        public static LinkLabel AddLink(this Control Control, string Text, Font Font, Point Location, Color LinkColor, LinkBehavior LinkBehavior)
        {
            LinkLabel Link = new LinkLabel();
            Link.Text = Text;
            Link.AutoSize = true;
            Link.Font = Font;
            Link.LinkColor = LinkColor;
            Link.BackColor = Color.Transparent;
            Link.LinkBehavior = LinkBehavior;
            Control.Controls.Add(Link);
            if (Location.Y == -1000)
            {
                Link.Location = new Point(Location.X, Link.MidH());
            }
            else if (Location.X == -1000)
            {
                Link.Location = new Point(Link.MidW(), Location.Y);
            }
            else
            {
                Link.Location = Location;
            }
            Link.Refresh();

            return Link;
        }

        public static Button AddButton(this Control Control, string Text, Font Font, Point Location)
        {
            Button Button = new Button();
            Button.Text = Text;
            Button.AutoSize = true;
            Button.Font = Font;
            Control.Controls.Add(Button);
            Button.Location = Location;
            Button.Refresh();
            return Button;
        }

        public static Button AddButton(this Control Control, string Text, Font Font)
        {
            Button Button = new Button();
            Button.Text = Text;
            Button.AutoSize = true;
            Button.Font = Font;
            Control.Controls.Add(Button);
            Button.Refresh();
            return Button;
        }

        public static void AddHorizontrolLine(this Control Control, Color c, Point Location, int Width, int Length)
        {
            PictureBox P = new PictureBox();
            P.BorderStyle = BorderStyle.None;
            P.BackColor = c;
            P.Size = new Size(Length, Width);
            Control.Controls.Add(P);
            P.Location = Location;
            P.BringToFront();
        }

        public static Control AddGradientLine(this Control Control, Point Location, int Width, int Length)
        {
            PictureBox P = new PictureBox();
            P.BorderStyle = BorderStyle.None;
            P.Image = global::TLABS.Extensions.ExtensionResources.gradientline;
            P.SizeMode = PictureBoxSizeMode.StretchImage;
            P.Size = new Size(Length, Width);
            Control.Controls.Add(P);
            P.BackColor = Color.Transparent;
            P.Location = Location;
            P.BringToFront();
            return P;
        }

        public static void AddVerticallLine(this Control Control, Color c, Point Location, int Width, int Length)
        {
            PictureBox P = new PictureBox();
            P.BorderStyle = BorderStyle.None;
            P.BackColor = c;
            P.Size = new Size(Width, Length);
            Control.Controls.Add(P);
            P.Location = Location;
            P.BringToFront();
        }

        public static Control AddChild(this Control Parent, Control Child, string Text, Size Size, Point Location)
        {
            if (Child != null)
            {
                Child.Text = Text;
                Parent.Controls.Add(Child);
                Child.Size = Size;
                Child.Location = Location;
            }
            return Child;
        }

        public static Control AddChild(this Control Parent, Control Child, string Text, Size Size)
        {
            if (Child != null)
            {
                Child.Text = Text;
                Parent.Controls.Add(Child);
                Child.Size = Size;
            }
            return Child;
        }

        public static Control AddChild(this Control Parent, Control Child, string Text, Point Location)
        {
            if (Child != null)
            {
                Child.Text = Text;
                Parent.Controls.Add(Child);
                Child.Location = Location;
            }
            return Child;
        }

        public static Control GetChildByName(this Control C, string CName, Type ControlType)
        {
            Control control = new Control();
            foreach (Control ctrl in C.Controls)
            {
                if (!control.Name.Equals(CName) && !control.GetType().Equals(ControlType))
                {
                    if (ctrl.GetType().Equals(ControlType) && C.Name.Equals(CName))
                    {
                        control = ctrl;
                    }
                    else
                    {
                        control = ctrl.GetChildByName(CName, ControlType);
                    }
                }
            }

            return control;
        }

        public static void Align(this Control Control, AlignmentStyle Style, int Padding)
        {
            Control.Parent.SuspendLayout();

            switch (Style)
            {
                case AlignmentStyle.Center:
                    Control.Location = new Point((Control.Parent.Width - Control.Width) / 2, Control.Location.Y);
                    break;
                case AlignmentStyle.MiddleLeft:
                    Control.Location = new Point(Padding, (Control.Parent.Height - Control.Height) / 2);
                    break;
                case AlignmentStyle.MiddleRight:
                    Control.Location = new Point(Control.Parent.Width - Control.Width - Padding, (Control.Parent.Height - Control.Height) / 2);
                    break;
                case AlignmentStyle.MiddleCenter:
                    Control.Location = new Point((Control.Parent.Width - Control.Width) / 2, (Control.Parent.Height - Control.Height) / 2);
                    break;
            }

            Control.Parent.ResumeLayout(false);
        }

        public static void ShowChilds(this Control Control, bool visible)
        {
            foreach (Control ctrl in Control.Controls)
            {
                ctrl.Visible = visible;
            }
        }

        public static void DockCenter(this Control Control)
        {
            Control.Location = new Point((Control.Parent.Width - Control.Width) / 2, (Control.Parent.Height - Control.Height) / 2);


            Control.Parent.Resize += delegate(object sender, EventArgs e)
            {
                if (Control.Parent != null)
                {
                    Control.Location = new Point((Control.Parent.Width - Control.Width) / 2, (Control.Parent.Height - Control.Height) / 2);
                }
            };

        }

        public static void DrawBorderShade(this Control C)
        {
            Control Parent = C.Parent;

            PictureBox T = new PictureBox();
            PictureBox B = new PictureBox();
            PictureBox L = new PictureBox();
            PictureBox R = new PictureBox();
            PictureBox TL = new PictureBox();
            PictureBox BL = new PictureBox();
            PictureBox TR = new PictureBox();
            PictureBox BR = new PictureBox();

            T.Name = C.Name + "_Shade_Top";
            B.Name = C.Name + "_Shade_Top";
            L.Name = C.Name + "_Shade_Left";
            R.Name = C.Name + "_Shade_Right";
            TL.Name = C.Name + "_Shade_TopLeft";
            BL.Name = C.Name + "_Shade_BottomLeft";
            TR.Name = C.Name + "_Shade_TopRight";
            BR.Name = C.Name + "_Shade_BottomRight";

            Parent.Controls.Add(T);
            Parent.Controls.Add(B);
            Parent.Controls.Add(L);
            Parent.Controls.Add(R);
            Parent.Controls.Add(TL);
            Parent.Controls.Add(BL);
            Parent.Controls.Add(TR);
            Parent.Controls.Add(BR);

            T.SendToBack();
            B.SendToBack();
            L.SendToBack();
            R.SendToBack();
            TL.SendToBack();
            BL.SendToBack();
            TR.SendToBack();
            BR.SendToBack();

            T.BackgroundImage = global::TLABS.Extensions.ExtensionResources.TopShade;
            B.BackgroundImage = global::TLABS.Extensions.ExtensionResources.BottomShade;
            L.BackgroundImage = global::TLABS.Extensions.ExtensionResources.LeftShade;
            R.BackgroundImage = global::TLABS.Extensions.ExtensionResources.RightShade;
            TL.BackgroundImage = global::TLABS.Extensions.ExtensionResources.ULShade;
            BL.BackgroundImage = global::TLABS.Extensions.ExtensionResources.BLShade;
            TR.BackgroundImage = global::TLABS.Extensions.ExtensionResources.URShade;
            BR.BackgroundImage = global::TLABS.Extensions.ExtensionResources.BRShade;

            T.BackgroundImageLayout = ImageLayout.Tile;
            B.BackgroundImageLayout = ImageLayout.Tile;
            L.BackgroundImageLayout = ImageLayout.Tile;
            R.BackgroundImageLayout = ImageLayout.Tile;
            TL.BackgroundImageLayout = ImageLayout.Tile;
            TR.BackgroundImageLayout = ImageLayout.Tile;
            BL.BackgroundImageLayout = ImageLayout.Tile;
            BR.BackgroundImageLayout = ImageLayout.Tile;

            Rectangle Rec = C.Bounds;

            T.Size = new Size(Rec.Width, 10);
            T.Location = new Point(Rec.X, Rec.Y - 10);
            B.Size = new Size(Rec.Width, 10);
            B.Location = new Point(Rec.X, Rec.Bottom);
            L.Size = new Size(10, Rec.Height);
            L.Location = new Point(Rec.X - 10, Rec.Y);
            R.Size = new Size(10, Rec.Height);
            R.Location = new Point(Rec.Right, Rec.Y);
            TL.Size = new Size(10, 10);
            TL.Location = new Point(Rec.X - 10, Rec.Y - 10);
            TR.Size = new Size(10, 10);
            TR.Location = new Point(Rec.Right, Rec.Y - 10);
            BL.Size = new Size(10, 10);
            BL.Location = new Point(Rec.X - 10, Rec.Bottom);
            BR.Size = new Size(10, 10);
            BR.Location = new Point(Rec.Right, Rec.Bottom);

            C.Resize += delegate(object sender, EventArgs e)
            {
                Rec = C.Bounds;

                T.Size = new Size(Rec.Width, 10);
                T.Location = new Point(Rec.X, Rec.Y - 10);
                B.Size = new Size(Rec.Width, 10);
                B.Location = new Point(Rec.X, Rec.Bottom);
                L.Size = new Size(10, Rec.Height);
                L.Location = new Point(Rec.X - 10, Rec.Y);
                R.Size = new Size(10, Rec.Height);
                R.Location = new Point(Rec.Right, Rec.Y);
                TL.Size = new Size(10, 10);
                TL.Location = new Point(Rec.X - 10, Rec.Y - 10);
                TR.Size = new Size(10, 10);
                TR.Location = new Point(Rec.Right, Rec.Y - 10);
                BL.Size = new Size(10, 10);
                BL.Location = new Point(Rec.X - 10, Rec.Bottom);
                BR.Size = new Size(10, 10);
                BR.Location = new Point(Rec.Right, Rec.Bottom);
            };

            C.LocationChanged += delegate(object sender, EventArgs e)
            {
                Rec = C.Bounds;

                T.Size = new Size(Rec.Width, 10);
                T.Location = new Point(Rec.X, Rec.Y - 10);
                B.Size = new Size(Rec.Width, 10);
                B.Location = new Point(Rec.X, Rec.Bottom);
                L.Size = new Size(10, Rec.Height);
                L.Location = new Point(Rec.X - 10, Rec.Y);
                R.Size = new Size(10, Rec.Height);
                R.Location = new Point(Rec.Right, Rec.Y);
                TL.Size = new Size(10, 10);
                TL.Location = new Point(Rec.X - 10, Rec.Y - 10);
                TR.Size = new Size(10, 10);
                TR.Location = new Point(Rec.Right, Rec.Y - 10);
                BL.Size = new Size(10, 10);
                BL.Location = new Point(Rec.X - 10, Rec.Bottom);
                BR.Size = new Size(10, 10);
                BR.Location = new Point(Rec.Right, Rec.Bottom);
            };
        }   

        public static void FadeIn(this PictureBox Pic, Image img, int Speed)
        {
            Pic.Image = null;
            Graphics g = Pic.CreateGraphics();

            Bitmap bmp = new Bitmap(img);
            Bitmap tmpbmp;
            for (int alpha = 0; alpha <= 255; alpha++)
            {
                tmpbmp = new Bitmap(bmp.Width, bmp.Height);
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        Color c = bmp.GetPixel(i, j);
                        Color nc = Color.FromArgb((int)((float)alpha * (((float)c.A) / 255)), c);

                        tmpbmp.SetPixel(i, j, nc);
                    }
                }
                g.DrawImage(bmp, Pic.ClientRectangle);
                Pic.Delay(100 - Speed);
            }
            Pic.Image = img;
        }

        public static void FadeOut(this PictureBox Pic, Image img, int Speed)
        {
            Pic.Image = null;
            Graphics g = Pic.CreateGraphics();

            Bitmap bmp = new Bitmap(img);
            Bitmap tmpbmp;
            for (int alpha = 255; alpha >= 0; alpha--)
            {
                tmpbmp = new Bitmap(bmp.Width, bmp.Height);
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        Color c = bmp.GetPixel(i, j);
                        Color nc = Color.FromArgb((int)((float)alpha * (((float)c.A) / 255)), c);

                        tmpbmp.SetPixel(i, j, nc);
                    }
                }
                g.DrawImage(bmp, Pic.ClientRectangle);
                Pic.Delay(100 - Speed);
            }
            Pic.Image = img;
        }

        public static void ChangeTo(this PictureBox Pic, Image img, int Speed)
        {
        }      
    }
}
