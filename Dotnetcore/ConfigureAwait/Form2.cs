using System.Diagnostics;


namespace ConfigureAwait
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            try
            {
                CustomAsync();
                listBoxThreads.Items.Add("Helloo :)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred in CustomAsync");
            }
            
        }

        async void CustomAsync()
        {
            await Task.Delay(3000);
            checked
            {
                listBoxThreads.Items.Add("Murat !!");
                int a = int.MaxValue;
                //a++;
            }
            //throw new ArgumentNullException("custom error : mserca.");
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde thread bilgilerini göstermeye başla
            //StartUpdatingThreadInfo();
        }

        private void StartUpdatingThreadInfo()
        {
            // Belirli aralıklarla thread bilgilerini güncelle
            //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            //timer.Interval = 1000; // Her 1 saniyede bir güncelle
            //timer.Tick += (s, e) => UpdateThreadInfo();
            //timer.Start();
        }

        private void UpdateThreadInfo()
        {
            // Aktif thread bilgilerini al ve ekranda göster
            string threadInfo = GetThreadInfo();
            UpdateUI(threadInfo);
        }

        private string GetThreadInfo()
        {
            // Aktif thread'leri Process ve Thread sınıflarıyla al
            Process currentProcess = Process.GetCurrentProcess();
            ProcessThreadCollection threads = currentProcess.Threads;

            // Thread bilgilerini string olarak formatla
            string info = $"Process ID: {currentProcess.Id}\n";
            info += "------------------------\n";

            foreach (ProcessThread thread in threads)
            {
                info += $"Thread ID: {thread.Id}, Start Time: {thread.StartTime}, Total Processor Time: {thread.TotalProcessorTime}\n";
            }

            return info;
        }

        private void UpdateUI(string threadInfo)
        {
            // Ekranda thread bilgilerini göster
            if (InvokeRequired)
            {
                // Eğer başka bir thread üzerinden çağrıldıysa Invoke kullanarak ana thread üzerinde çalıştır
                Invoke(new Action(() => listBoxThreads.Items.Add(threadInfo)));
            }
            else
            {
                // Eğer aynı thread üzerinden çağrıldıysa direkt olarak güncelle
                listBoxThreads.Items.Add(threadInfo);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //string name = await GetNameAsync();
            //MessageBox.Show($"Your name is : {name}");
            //UpdateThreadInfo(); 
            string name = await GetNameAsync().ConfigureAwait(false);
            var threadId = Thread.CurrentThread.ManagedThreadId;
            listBoxThreads.Items.Add($"(Thread({threadId}) name : {name})");
        }

        private async Task<string> GetNameAsync()
        {
            //UpdateThreadInfo();
            await Task.Delay(1500);
            return "Murat Sercan.";
        }

        private string GetName()
        {

            //UpdateThreadInfo();
            return "Murat Sercan.";
        }
    }
}
