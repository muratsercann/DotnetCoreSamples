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

            //Bundan sonraki senkron iþlemlerin uygulamayý bloklamasýný istemiyorsak ConfigureAwait(False) yapmamýz lazým.
            var message = await RemoteServer.GetMessageAsync().ConfigureAwait(false);

            ReportThread("After GetMessageAsync()");

            var formattedMessage = GetFormattedMessage(message);


            listBox1.Items.Add(formattedMessage);


            /// ConfigureAwait(false) ifadesi :
            /// Bundan sonra iþlemlere farklý context (farklý thread) üzerinden devam et.
            /// Yani await kelimesinden sonraki satýrlarý
            /// baþka bir thread üzerinden yürüt demek oluyor.
            /// böylelikle uygulama donmuyor.
            /// 
            /// ConfigureAwait(true) ifadesi  :
            /// Ayný context yani ayný thread üzerinden devam et demek oluyor

        }

        private void ReportThread(string message)
        {
            string log = $"\n(Thread {Thread.CurrentThread.ManagedThreadId}) {message}";
            listBox1.Items.Add(log);
        }

        private async Task<string> GetMessageAndFormat()
        {
            ReportThread("GetMessageAndFormat is getting response from remote server..");
            var response = await RemoteServer.GetMessageAsync().ConfigureAwait(false);
            ReportThread("Please wait for the message formatting..");
            return GetFormattedMessage(response);

        }


        private string GetFormattedMessage(string message)
        {
            ReportThread("Message came and Formatting started.");

            Thread.Sleep(3000);

            return $"(Thread {Thread.CurrentThread.ManagedThreadId}) Formatted Message : " + message;
        }

        private async Task<string> GetFormattedMessageAsync(string message)
        {
            await Task.Delay(2000);
            return $"(Thread {Thread.CurrentThread.ManagedThreadId}) Formatted Message : " + message;
        }
        private void btnClean_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }

    public class RemoteServer
    {
        public static async Task<string> GetMessageAsync()
        {
            await Task.Delay(2000);
            return $"Hi :) (this message from remote server)";
        }
    }

}

