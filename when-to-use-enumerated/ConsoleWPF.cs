using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace IVSoftware
{
    public class Console : TextBox, IConsole
    {
        public Console()
        {
            _textBoxBase = this;
        }
        private static TextBoxBase _textBoxBase { get; set; }
        public static void ReadKey()
        {
            _waiting = true;
            _textBoxBase.AppendText("Press any key to continue..." + Environment.NewLine);
            while (_waiting)
            {
                Thread.Sleep(0);        // Pump Message Queue
                Task.Delay(100).Wait();
            }
            _textBoxBase.AppendText("Execution has resumed.");
        }
        public static void WriteLine(object text = null)
        {
            if (text == null)
            {
                _textBoxBase.AppendText(Environment.NewLine);
            }
            else
            {
                _textBoxBase.AppendText(text.ToString() + Environment.NewLine);
            }
        }
        public static void Write(object text = null)
        {
            if (text != null)
            {
                _textBoxBase.AppendText(text.ToString());
            }
        }
        protected override void OnKeyDown(
           KeyEventArgs e
        )
        {
            if (_waiting) _waiting = false;
        }
        static bool _waiting = false;
        void IConsole.ReadKey()
        {
            ReadKey();
        }

        void IConsole.Write(object text)
        {
            Write(text);
        }

        void IConsole.WriteLine(object text)
        {
            WriteLine(text);
        }
    }
    public interface IConsole
    {
        void Write(object text = null);
        void WriteLine(object text = null);
        void ReadKey();
    }
}
