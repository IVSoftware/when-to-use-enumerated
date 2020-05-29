using IVSoftware;
using System;
using System.IO;
using System.Windows;
using Window = IVSoftware.Window;
using Console = IVSoftware.Console;

namespace wpf_window_ex
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            ((HandleCreatedEventArgs)e).Console = ConsoleWPF;
            base.OnHandleCreated(e);

            Console.WriteLine("Native window handle has been created.");
        }
        protected override void OnLoad(RoutedEventArgs e)
        {
            base.OnLoad(e);
            Console.WriteLine("Form has loaded and ready to interact.");
            Console.WriteLine("Running Program.cs");
            Console.WriteLine();
            Program.Main(new string[0]);
        }
    }
}
