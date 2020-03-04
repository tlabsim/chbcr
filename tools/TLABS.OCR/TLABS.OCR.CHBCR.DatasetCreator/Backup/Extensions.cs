using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TLABS.Extensions
{   
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Show error message along with stack trace and inner exception
        /// </summary>
        /// <param name="ex">Exception: The exception instance</param>
        public static void ShowFullMessage(this Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace + "\r\n" + ex.InnerException); 
        }

        /// <summary>
        /// Show error message while in debug mode
        /// </summary>
        /// <param name="ex">Exception: The exception instance</param>
        public static void ShowOnDebug(this Exception ex)
        {
#if _DEBUG_
            System.Windows.Forms.MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace + "\r\n" + ex.InnerException);         
#endif
        }        
    }

    public static class CastingExtensions
    {
        /// <summary>
        /// Returns ToString() if object is not null otherwise returns string.Empty 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString(this object obj)
        {
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetString(this object obj, string DefaulValue)
        {
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return DefaulValue;
            }
        }

        /// <summary>
        /// Returns the integer as a fixed field string
        /// </summary>
        /// <param name="i"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static string ToString(this int i, int fields)
        {
            string s = string.Empty;
            int l = i.ToString().Length;
            for (int j = 0; j < (fields - l); j++) s += "0";
            s += i.ToString().Substring((fields < l) ? (l - fields) : 0);
            return s;

        }

        public static bool ToBool(this string str, bool ValueIfNotParsable = false)
        {
            if(str.Equals("0")) return false;
            else if(str.Equals("1")) return true;

            bool b = false;
            if (!bool.TryParse(str, out b))
            {
                b = ValueIfNotParsable;
            }
            return b;
        }

        /// <summary>
        /// Converts the string to 32 bit integer
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ValueIfNotParsable"></param>
        /// <returns></returns>
        public static int ToInt(this string str, int ValueIfNotParsable = 0)
        {
            int i = 0;

            if (!int.TryParse(str, out i))
            {
                i = ValueIfNotParsable;
            }

            return i;
        }

        /// <summary>
        /// Converts the string to long value
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ValueIfNotParsable"></param>
        /// <returns></returns>
        public static long ToLong(this string str, long ValueIfNotParsable = 0)
        {
            long l = 0;

            if (!long.TryParse(str, out l))
            {
                l = ValueIfNotParsable;
            }

            return l;
        }

        public static float ToFloat(this string str, float ValueIfNotParsable=0)
        {
            float f = 0;

            if (!float.TryParse(str, out f))
            {
                f = ValueIfNotParsable;
            }

            return f;
        }    

        public static double ToDouble(this string str, double ValueIfNotParsable = 0.0)
        {
            double d = 0.0;

            if (!double.TryParse(str, out d))
            {
                d = ValueIfNotParsable;
            }

            return d;
        }

        public static DateTime? ToDateTime(this string str)
        {
            DateTime DT = new DateTime();

            if (!DateTime.TryParse(str, out DT))
            {
                return null;
            }

            return DT;
        }

        public static string ToOrdinal(this int i)
        {
            string s = string.Empty;
            s += i;
            int h = i % 100;

            if (h == 11 || h == 12 || h == 13) //Exceptions
            {
                s += "th";
            }
            else
            {
                int d = i % 10;

                switch (d)
                {
                    case 1:
                        s += "st";
                        break;
                    case 2:
                        s += "nd";
                        break;
                    case 3:
                        s += "rd";
                        break;
                    default:
                        s += "th";
                        break;
                }
            }

            return s;
        }

        static char[] BaseChars = new char[] { '0','1','2','3','4','5','6','7','8','9',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x'}; 

        public static string ToBase(this int value, int target_base)
        {
            int i = 32; 

            char[] buffer = new char[i];
            //target_base = BaseChars.Length;

            do
            {
                buffer[--i] = BaseChars[value % target_base];
                value = value / target_base;
            }
            while (value > 0);

            char[] result = new char[32 - i];
            Array.Copy(buffer, i, result, 0, 32 - i);

            return new string(result);
        }
    }

    public static class StringExtensions
    {
        public static bool Contains(this string str, string substr, bool case_sensative = true)
        {
            str = str.Trim('\\');
            substr = substr.Trim('\\');

            if (case_sensative)
            {
                return str.Contains(substr);
            }
            else
            {
                return Regex.IsMatch(str, substr, RegexOptions.IgnoreCase);
            }
        }

        /// <summary>
        /// Converts the current instance of string to sentence case
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSentenceCase(this string str)
        {
            string strl = str.ToLower();
            var r = new Regex(@"(^[a-z])|\.\s+(.)", RegexOptions.ExplicitCapture);
            var result = r.Replace(strl, s => s.Value.ToUpper());
            return result;
        }

        public static string ToTitleCase(this string str)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        /// <summary>
        /// Shows the current instance of string on a form as copyable
        /// </summary>
        /// <param name="s"></param>
        public static void ShowCopyable(this string s)
        {
            Form F = new Form();
            F.Text = "Message";
            F.BackColor = Color.WhiteSmoke;

            TextBox T = new TextBox();
            T.BackColor = Color.WhiteSmoke;
            T.BorderStyle = BorderStyle.None;
            T.Multiline = true;
            T.ReadOnly = true;

            Label L = new Label();
            L.Font = T.Font;
            L.AutoSize = true;
            L.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width - 50, Screen.PrimaryScreen.WorkingArea.Height - 100);
            L.Text = s;
            F.Controls.Add(L);
            L.Refresh();

            T.Size = new Size(L.Width + 10, L.Height + 10);
            T.Text = L.Text;
            F.Size = new Size(T.Width + 40, T.Height + 90);
            F.Controls.Add(T);
            T.Location = new Point(10, 10);
            T.SelectionLength = 0;
            T.SelectionStart = T.Text.Length;

            Panel P = new Panel();
            P.Size = new Size(100, 40);
            P.Dock = DockStyle.Bottom;
            P.BackColor = Color.Gainsboro;

            F.Controls.Add(P);

            Button btnClose = new Button();
            btnClose.AutoSize = true;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Text = "&Close";
            btnClose.Anchor = AnchorStyles.Right;
            btnClose.Click += delegate(object sender, EventArgs e)
            {
                F.Close();
            };
            P.Controls.Add(btnClose);
            btnClose.Location = new Point(P.Width - btnClose.Width - 20, (P.Height - btnClose.Height) / 2);


            L.Visible = false;
            F.StartPosition = FormStartPosition.CenterScreen;
            F.Load += delegate(object sender, EventArgs e)
            {
                btnClose.Focus();
            };
            F.ShowDialog();

        }

        /// <summary>
        /// Returns a new string in which all occurences of a specified string in the current instance are replaces with another specified string case insensitively
        /// </summary>
        /// <param name="s"></param>
        /// <param name="s2r"></param>
        /// <param name="s2rw"></param>
        /// <returns></returns>
        public static string ReplaceCaseInsensitive(this string original, string pattern, string replacement)
        {
            int count, position0, position1;
            count = position0 = position1 = 0;
            string upperString = original.ToUpper();
            string upperPattern = pattern.ToUpper();
            int inc = (original.Length / pattern.Length) *
                      (replacement.Length - pattern.Length);
            char[] chars = new char[original.Length + Math.Max(0, inc)];
            while ((position1 = upperString.IndexOf(upperPattern,
                                              position0)) != -1)
            {
                for (int i = position0; i < position1; ++i)
                    chars[count++] = original[i];
                for (int i = 0; i < replacement.Length; ++i)
                    chars[count++] = replacement[i];
                position0 = position1 + pattern.Length;
            }
            if (position0 == 0) return original;
            for (int i = position0; i < original.Length; ++i)
                chars[count++] = original[i];
            return new string(chars, 0, count);
        }

        public static string ReplaceFirstChar(this string s, char c2r, char c2rw)
        {
            int ci = s.IndexOf(c2r);
            if (ci >= 0)
            {
                return s.Substring(0, ci) + c2rw + s.Substring(ci + 1, s.Length - ci - 1);
            }
            else
            {
                return s;
            }
        }

        public static string ReplaceFirstChar(this string s, char c2r, string s2rw)
        {
            int ci = s.IndexOf(c2r);
            if (ci >= 0)
            {
                return s.Substring(0, ci) + s2rw + s.Substring(ci + 1, s.Length - ci - 1);
            }
            else
            {
                return s;
            }
        }

        public static string ReplaceLastChar(this string s, char c2r, char c2rw)
        {            
            int ci = s.LastIndexOf(c2r);
            if (ci >= 0)
            {
                return s.Substring(0, ci) + c2rw + s.Substring(ci + 1, s.Length - ci - 1);
            }
            else
            {
                return s;
            }
        }

        public static string ReplaceLastChar(this string s, char c2r, string s2rw)
        {
            int ci = s.LastIndexOf(c2r);
            if (ci >= 0)
            {
                return s.Substring(0, ci) + s2rw + s.Substring(ci + 1, s.Length - ci - 1);
            }
            else
            {
                return s;
            }
        }

        public static string Abbreviate(this string s)
        {
            string abbr_str = string.Empty;
            s = s.ReplaceCaseInsensitive(" & ", " "); 
            s = s.ReplaceCaseInsensitive(" and ", " ");           
            s = s.ReplaceCaseInsensitive(" for ", " ");
            s = s.ReplaceCaseInsensitive(" of ", " ");
            s = s.ReplaceCaseInsensitive("the ", " ");
            s = s.ReplaceCaseInsensitive(" in ", " ");
            s = s.ReplaceCaseInsensitive(" to ", " ");
            s = s.Trim();
            bool cap = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (cap && s[i] != ' ') { abbr_str += s[i].ToString().ToUpper(); cap = false; }
                else if (s[i] == ' ') { cap = true; }                
            }
            return abbr_str;
        }

        public static void AppendLines(this StringBuilder sb, params string[] lines)
        {
            if (lines.Length > 0)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    sb.AppendLine(lines[i]);
                }
            }
            else
            {
                sb.AppendLine();
            }
        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime? GetNistTime()
        {
            DateTime? dateTime = null;
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://nist.time.gov/actualtime.cgi?lzbc=siqm9b");
                request.Method = "GET";
                request.Timeout = 3000;
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
                request.ContentType = "application/x-www-form-urlencoded";
                request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore); //No caching

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    StreamReader stream = new StreamReader(response.GetResponseStream());
                    string html = stream.ReadToEnd();//<timestamp time=\"1395772696469995\" delay=\"1395772696469995\"/>
                    string time = Regex.Match(html, @"(?<=\btime="")[^""]*").Value;
                    double milliseconds = Convert.ToInt64(time) / 1000.0;
                    dateTime = new DateTime(1970, 1, 1).AddMilliseconds(milliseconds).ToLocalTime();
                }
            }
            catch { }

            return dateTime;
        }

        public static DateTime? GetInternetTime()
        {
            try
            {
                var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
                myHttpWebRequest.Timeout = 5000;
                using (var response = myHttpWebRequest.GetResponse())
                {
                    string todaysDates = response.Headers["date"];
                    DateTime dateTime = DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
                    return dateTime;
                }
            }
            catch
            {
                return null;
            }
        }

        public static int ToUnixTimestamp(this DateTime dt)
        {
            return (int)(dt.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        }

        public static int UnixTimestamp()
        {
            return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        }

        /// <summary>
        /// Get the numeric value of the date of week specified in Datetime instance
        /// </summary>
        /// <param name="DT"></param>
        /// <returns>Integer: Numeric value of the date of week specified in Datetime instance</returns>
        /// 

        public static DateTime EarliestHour(this DateTime DT)
        {
            return new DateTime(DT.Year, DT.Month, DT.Day, 0, 0, 0);
        }

        public static DateTime LatestHour(this DateTime DT)
        {
            return new DateTime(DT.Year, DT.Month, DT.Day, 23, 59, 59, 999);
        }

        public static int DateOfWeek(this DateTime DT)
        {
            int dow = 0;
            switch (DT.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    dow = 1;
                    break;
                case DayOfWeek.Sunday:
                    dow = 2;
                    break;
                case DayOfWeek.Monday:
                    dow = 3;
                    break;
                case DayOfWeek.Tuesday:
                    dow = 4;
                    break;
                case DayOfWeek.Wednesday:
                    dow = 5;
                    break;
                case DayOfWeek.Thursday:
                    dow = 6;
                    break;
                case DayOfWeek.Friday:
                    dow = 7;
                    break;
            }
            return dow;
        }

        public static DateTime NextMonth(this DateTime DT)
        {
            int D = DT.Day;
            int M = DT.Month;
            int Y = DT.Year;

            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };            

            if (M == 12)
            {
                M = 1;
                Y++;
            }
            else
            {
                M++;
            }

            if (Y % 4 == 0)
            {
                days[1] = 29;
            }

            if (D > days[M - 1]) //0 based index
            {
                D = days[M - 1];
            }

            return new DateTime(Y, M, D);
        }

        public static DateTime PreviousMonth(this DateTime DT)
        {
            int D = DT.Day;
            int M = DT.Month;
            int Y = DT.Year;

            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };


            if (M == 1)
            {
                M = 12;
                Y--;
            }
            else
            {
                M--;
            }

            if (Y % 4 == 0)
            {
                days[1] = 29;
            }
            if (D > days[M - 1])
            {
                D = days[M - 1];
            }

            return new DateTime(Y, M, D);
        }

        public static DateTime LastDateOfMonth(this DateTime DT)
        {
            int Year = DT.Year;
            int Month = DT.Month;
            int Day = 0;
            switch (Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Day = 31;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    Day = 30;
                    break;
                case 2:
                    Day = Year % 4 == 0 ? 29 : 28;
                    break;
            }
            return new DateTime(Year, Month, Day);
        }

        public static DateTime FirstDateOfMonth(this DateTime DT)
        {
            return new DateTime(DT.Year, DT.Month, 1);
        }

        public static DateTime FirstDateOfWeek(this DateTime DT)
        {
            return DT.Subtract(new TimeSpan(DT.DateOfWeek() - 1, 0, 0, 0));
        }

        public static void GetAge(this DateTime Birthday, out int years, out int days)
        {
            years = 0;
            days = 0;

            if (Birthday.Month == 2 && Birthday.Day == 29)
            {
                DateTime today = DateTime.Now.Date;
                DateTime this_year_birthday;
                if (today.IsLeapYear())
                {
                    this_year_birthday = new DateTime(today.Year, 2, 29 );
                }
                else
                {
                    this_year_birthday = new DateTime(today.Year, 2, 28);
                }

                if (today >= this_year_birthday)
                {
                    years = this_year_birthday.Year - Birthday.Year;
                    days = (today - this_year_birthday).Days;
                }
                else
                {
                    DateTime last_year = new DateTime(today.Year - 1, 1, 1);
                    DateTime last_year_birthday;
                    if(last_year.IsLeapYear())
                    {
                        last_year_birthday = new DateTime(this_year_birthday.Year - 1, 2, 29);
                    }
                    else
                    {
                        last_year_birthday = new DateTime(this_year_birthday.Year - 1, 2, 28);
                    }                    
                    years = last_year_birthday.Year - Birthday.Year;
                    days = (today - last_year_birthday).Days;
                }
            }
            else
            {
                DateTime today = DateTime.Now.Date;
                DateTime this_year_birthday = new DateTime(today.Year, Birthday.Month, Birthday.Day);
                if (today >= this_year_birthday)
                {
                    years = this_year_birthday.Year - Birthday.Year;
                    days = (today - this_year_birthday).Days;
                }
                else
                {
                    DateTime last_year_birthday = new DateTime(this_year_birthday.Year - 1, this_year_birthday.Month, this_year_birthday.Day);
                    years = last_year_birthday.Year - Birthday.Year;
                    days = (today - last_year_birthday).Days;
                }
            }
        }

        public static bool IsLeapYear(this DateTime DT)
        {
            int y = DT.Year;
            return ((y % 4 == 0) && (y % 100 != 0)) || (y % 400 == 0);
        }

        public static bool IsInSameWeek(this DateTime DT1, DateTime DT2)
        {
            return DT1.FirstDateOfWeek().Date.Equals(DT2.FirstDateOfWeek().Date);
        }

        public static int TotalMonths(this DateTime DT)
        {
            return DT.Year * 12 + DT.Month;
        }
    }

    public static class ViewExtensions
    {
        /// <summary>
        /// Show the specified string in a messagebox
        /// </summary>
        /// <param name="s">The string to be shown</param>
        public static void show(this string s)
        {
            MessageBox.Show(s);
        }

        /// <summary>
        /// Show the specified string on console
        /// </summary>
        /// <param name="s">The string to be shown</param>
        public static void write(this string s)
        {
            Console.WriteLine(s);
        }

        public static void write(this object obj)
        {
            Console.WriteLine(obj.ToString());
        }
       
        public static void View(this object obj)
        {
            try
            {
                Image img = Image.FromStream(new MemoryStream((byte[])obj));
                if (img != null)
                {
                    img.Show();
                }
                else
                {
                    MessageBox.Show(obj.ToString());
                }
            }
            catch
            {
                if (obj != null)
                {
                    MessageBox.Show(obj.ToString(), "Object viewer");
                }
                else
                {
                    MessageBox.Show("Object is null", "Object viewer");
                }
            }
        }     
    }

    public static class StreamExtensions
    {
        public static bool IsEqual(this byte[] a, byte[] b)
        {
            bool equal = true;
            int l1 = a.Length;
            int l2 = b.Length;

            if (l1 == l2)
            {
                for (int i = 0; i < l1; i++)
                {
                    if (a[i] != b[i])
                    {
                        equal = false;
                        break;
                    }
                }
            }
            else
            {
                equal = false;
            }

            return equal;
        }          
    }

    public static class CollectionExtensions
    {
       
    }
}
