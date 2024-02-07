using System.Diagnostics;
using System.Drawing.Printing;
using System.Numerics;
using System.Text;
using System.Xml;

namespace WinFormsApp1
{
    //Source : https://www.youtube.com/watch?v=5d6YoHuSvoI


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGetMessage_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Starting call..");
            ReportThread("Before GetMessageAsync()");
            var formattedMessage = await GetMessageAndFormat();
            ReportThread("After GetMessageAsync()");
            listBox1.Items.Add(formattedMessage);
        }

        private void ReportThread(string message)
        {
            string log = $"\n(Thread {Thread.CurrentThread.ManagedThreadId}) {message}";
            listBox1.Items.Add(log);
        }

        private async Task<string> GetMessageAndFormat()
        {
            ReportThread("GetMessageAndFormat is getting response from remote server..");
            var response = await MyLibrary.GetMessageAsync().ConfigureAwait(false);
            ReportThread("Please wait for the message formatting..");
            return GetFormattedMessage(response);

            /// ConfigureAwait(false) ifadesi :
            /// Bundan sonra farklý context üzerinden devam et.
            /// Yani await kelimesinden sonraki satýrlarý
            /// baþka bir thread üzerinden yürüt demek oluyor.

        }

        private string GetFormattedMessage(string message)
        {
            Thread.Sleep(3000);
            return $"(Thread {Thread.CurrentThread.ManagedThreadId}) Formatted Message : " + message;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }

    public class MyLibrary()
    {
        public static async Task<string> GetMessageAsync()
        {
            await Task.Delay(3000);
            return $"Hi :) (from Thread {Thread.CurrentThread.ManagedThreadId})";
        }
    }
}
