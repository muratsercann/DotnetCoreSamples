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

            //Bundan sonraki senkron i�lemlerin uygulamay� bloklamas�n� istemiyorsak ConfigureAwait(False) yapmam�z laz�m.
            var message = await RemoteServer.GetMessageAsync().ConfigureAwait(false);

            ReportThread("After GetMessageAsync()");

            var formattedMessage = GetFormattedMessage(message);


            listBox1.Items.Add(formattedMessage);


            /// ConfigureAwait(false) ifadesi :
            /// Bundan sonra i�lemlere farkl� context (farkl� thread) �zerinden devam et.
            /// Yani await kelimesinden sonraki sat�rlar�
            /// ba�ka bir thread �zerinden y�r�t demek oluyor.
            /// b�ylelikle uygulama donmuyor.
            /// 
            /// ConfigureAwait(true) ifadesi  :
            /// Ayn� context yani ayn� thread �zerinden devam et demek oluyor

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

