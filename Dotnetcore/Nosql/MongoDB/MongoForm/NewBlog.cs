using MongoDBSample1.Models;
using MongoDBSample1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoForm
{
    public partial class NewBlogForm : Form
    {
        private readonly BlogService _blogService;
        private readonly Form1 _form1;
        public NewBlogForm(Form1 form1)
        {
            _blogService = new BlogService();
            _form1 = form1;

            BlogForm_UC blogForm = new BlogForm_UC();

            blogForm.Save = async () =>
            {
                await this.AddNew(blogForm);                
            };

            this.Controls.Add(blogForm);

            InitializeComponent();
        }

        private async Task AddNew(BlogForm_UC userControl)
        {
            Blog b = new Blog();
            b.Title = userControl.txtTitle.Text.Trim();
            b.Rating = Convert.ToInt32(userControl.cBoxRating.SelectedItem);
            b.Url = userControl.txtUrl.Text;


            await _blogService.InsertBlogAsync(b);
            _form1.RefreshData();
            MessageBox.Show("Operation has been handled successfully.");
            await Task.Delay(300);
            this.Close();
        }
    }
}
