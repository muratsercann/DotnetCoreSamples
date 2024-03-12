using System.Diagnostics;
using System.Drawing.Printing;
using System.Net;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
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

        private bool _configureAwait = false;
        private async void btnGetMessage_Click(object sender, EventArgs e)
        {
            _configureAwait = !cb_ConfigureAwaitFalse.Checked;
            ReportThread("Starting call..");
           
            ReportThread($"Before GetMessageAsync().ConfigureAwait({_configureAwait})");

            //Bundan sonraki senkron iþlemlerin uygulamayý bloklamasýný istemiyorsak ConfigureAwait(False) kullanabiliriz.
            var message = await RemoteServer.GetMessageAsync().ConfigureAwait(_configureAwait);
            ReportThread($"After GetMessageAsync().ConfigureAwait({_configureAwait})");


            var formattedMessage = FormatMessage(message);

            rtb_output.AppendText(formattedMessage);

           
            /// ConfigureAwait(false) ifadesi :
            /// Bundan sonra iþlemlere farklý context (farklý thread) üzerinden devam et.
            /// Yani await kelimesinden sonraki satýrlarý
            /// baþka bir thread üzerinden yürüt demek oluyor.
            /// böylelikle uygulama donmuyor.
            /// 
            /// ConfigureAwait(true) ifadesi  :
            /// Ayný context yani ayný thread üzerinden devam et demek oluyor

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            rtb_output.Clear();
        }

        static int taskNumber1 = 0;
        private async void btnTask1_Click(object sender, EventArgs e)
        {
            int num = ++taskNumber1;
            ReportThread($"Task 1/{num} started..");
            await Task.Delay(3000);
            ReportThread($"Task 1/{num} finished.");
            
            string threadId = await RemoteServer.Task1();
            rtb_output.AppendText($"GetNameAsync runs on thread id : {threadId}");


        }

        static int taskNumber2 = 0;
        private async void btnTask2_Click(object sender, EventArgs e)
        {
            int num = ++taskNumber2;
            ReportThread($"Task 2/{num} started..");
            await Task.Delay(1000);
            ReportThread($"Task 2/{num} finished.");
        }



        private void ReportThread(string message)
        {
            string output = $"\n(Thread {Thread.CurrentThread.ManagedThreadId}) {message}";
            rtb_output.AppendText(output);
            BoldSelectedText($"ConfigureAwait");
            BoldSelectedText($"{_configureAwait.ToString()}");
        }

        private string FormatMessage(string message)
        {
            ReportThread("Message came and Formatting started.");

            Thread.Sleep(3000);

            return $"(Thread {Thread.CurrentThread.ManagedThreadId}) Formatted Message : " + message;
        }

        private async Task<string> FormatMessageAsync(string message)
        {
            await Task.Delay(2000);
            return $"(Thread {Thread.CurrentThread.ManagedThreadId}) Formatted Message : " + message;
        }

        private void BoldSelectedText(string searchText)
        {
            int startIndex = 0;
            while (startIndex < rtb_output.TextLength)
            {
                int index = rtb_output.Find(searchText, startIndex, RichTextBoxFinds.None);
                if (index == -1)
                    break;

                rtb_output.Select(index, searchText.Length);
                rtb_output.SelectionFont = new Font(rtb_output.Font, FontStyle.Bold);
                rtb_output.SelectionColor = Color.Green;
                startIndex = index + searchText.Length;
            }
        }















    }

  

    public class RemoteServer
    {
        public static async Task<string> GetMessageAsync()
        {
            await Task.Delay(2000);
            return $"Hi :) (this message from remote server)";
        }

        public static async Task<string> Task1()
        {
            await Task.Delay(1500);

            return Thread.CurrentThread.ManagedThreadId.ToString();
        }
    }

}

