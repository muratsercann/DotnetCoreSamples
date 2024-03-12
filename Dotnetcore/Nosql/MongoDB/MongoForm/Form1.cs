using MongoDBSample1.Models;
using MongoDBSample1.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MongoForm
{
    public partial class Form1 : Form
    {
        private readonly BlogService _blogService = new BlogService();
        private List<Blog> AllBlogs;
        public Form1()
        {
            InitializeComponent();
            GetData();//Danger !

        }

        private async void GetData()
        {
            DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn();
            updateButtonColumn.Name = "UpdateButtonColumn";
            updateButtonColumn.HeaderText = "Update";
            updateButtonColumn.Text = "Update";
            updateButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(updateButtonColumn);


            AllBlogs = await _blogService.GetAllAsync();
            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = AllBlogs;
        }

        public void RefreshData()
        {
            GetData();
            LoadData();
        }

        private void btnAddNewBlog_Click(object sender, EventArgs e)
        {
            NewBlogForm form = new NewBlogForm(this);
            form.ShowDialog();
        }

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // DataGridView'de güncelleme butonuna týklanýp týklanmadýðýný kontrol et
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["UpdateButtonColumn"].Index)
            {
                // Güncelleme butonuna týklanýldýðýnda yapýlacak iþlemler
                int rowIndex = e.RowIndex;
                // DataGridView'deki seçili satýrdaki verileri kullanarak güncelleme iþlemlerini gerçekleþtir
                var selectedID = dataGridView1.Rows[rowIndex].Cells["BlogId"].Value.ToString();

                MessageBox.Show($"selected Id : {selectedID}");

                //if (!string.IsNullOrWhiteSpace(selectedID))
                //{
                //    var blog = await _blogService.GetBlogAsync(selectedID);
                //    if (blog is not null)
                //    {
                //        NewBlogForm f1 = new NewBlogForm(this, blog);
                //        f1.ShowDialog();
                //    }
                //}


            }
        }
    }
}
