using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Dapper;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int blogId = 598277;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnTask1_Click(object sender, EventArgs e)
        {
            await UpdateSequenceWithSP(2003);
            //await UpdateSequence(2000);
            //await Task1_WithoutTransaction();
            //await Task1_rojda();
        }

        private async void btnTask2_Click(object sender, EventArgs e)
        {
            //await UpdateSequence(2000);
            //await Task_Serializable();
            //await Task2_rojda();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //await ReadAllBlogs();
        }

        private async Task Task1_rojda()
        {
            //log($"Task1_rojda started");
            using (var _dbContext = new BloggingContext())
            {
                using (var transaction = await _dbContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
                {
                    var blog = new Blog
                    {
                        Title = "Blog_rojda",
                        Url = "url_rojda",
                        Rating = 0
                    };

                    await _dbContext.AddAsync(blog);
                    log("Task1 - Rojda added a blog..");

                    await _dbContext.SaveChangesAsync();
                    log("Task1 - Rojda SaveChangesAsync..");

                    await Task.Delay(3000);
                    await transaction.CommitAsync();
                    log("Task1 - Rojda RollbackAsync.. ");
                }
            }
        }

        private async Task Task2_rojda()
        {
            //log($"Task2_rojda started");
            using (var _dbContext = new BloggingContext())
            {
                using (var transaction = await _dbContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadUncommitted))
                {
                    var blog = await _dbContext.Blogs.Where(b => b.Title == "Blog_rojda").FirstAsync();
                    blog.Rating++;

                    await _dbContext.SaveChangesAsync();
                    //log($"Task_2 Rojda SavedChanges for update to blogid: {blog.BlogId}, rating : {blog.Rating}..");

                    await transaction.CommitAsync();
                    log("Task_2 Rojda CommitAsync.. ");
                }
            }
        }

        private async Task Task1_WithoutTransaction()
        {
            using (var _dbContext = new BloggingContext())
            {
                //log($"Task 1- Updating blogid : {blogId} .. (No Transaction)");
                using (var transaction = await _dbContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadUncommitted))
                {
                    var blog = await _dbContext.Blogs.Where(b => b.BlogId == blogId).FirstAsync();
                    blog.Url = "Task 1- url_Write";
                    blog.Rating++;

                    log("Delay 3sn..");
                    await Task.Delay(3000);
                    await _dbContext.SaveChangesAsync();
                    //log($"Task 1- After SaveChangesAsync();");
                    await transaction.CommitAsync();
                    log("Task 1- Committed");
                    //log($"Task 1- Blog updated, Url : {blog.Url} - Rating : {blog.Rating}");
                }
            }
        }

        private async Task Task1()
        {
            //log($"Updating blogid : {blogId} ..");
            using (var _dbContext = new BloggingContext())
            {
                using (var transaction = await _dbContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadUncommitted))
                {
                    var blog = await _dbContext.Blogs.Where(b => b.BlogId == blogId).FirstAsync();
                    blog.Url = "Task 1- url_Write";
                    blog.Rating++;


                    await _dbContext.SaveChangesAsync();
                    log("Task 1- after SaveChangesAsync();");

                    await Task.Delay(3000);
                    await transaction.CommitAsync();
                    log("Task 1- After Commit ");
                    //log($"Task 1- Blog updated, Url : {blog.Url} - Rating : {blog.Rating}");
                }
            }
        }

        private async Task Task_Serializable()
        {
            //log($"Task.Serializable Updating blogid : {blogId} ..");
            using (var _dbContext = new BloggingContext())
            {
                using (var transaction = await _dbContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable))
                {
                    var blog = await _dbContext.Blogs.Where(b => b.BlogId == blogId).FirstAsync();
                    blog.Rating += 10;
                    blog.Url = "Serializable";

                    await _dbContext.SaveChangesAsync();
                    log("Task.Serializable - After SaveChangesAsync()");
                    await transaction.CommitAsync();
                    log("Task.Serializable - After CommitAsync()");
                }
            }
        }

        private void log(string message)
        {
            richTextBox1.AppendText($"> {message}\n");
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private async void btnTransactionTest_Click(object sender, EventArgs e)
        {
            // await UpdateSequence(2000);
        }

        private async Task UpdateSequence(int year, BloggingContext _dbContext)
        {
            log("\n#####################################\n");
            var pId = Random.Shared.Next(1, int.MaxValue);
            await _dbContext.Database.Transactional(async () =>
            {
                var seq = await _dbContext.Sequences.Where(s => s.Year == year).FirstOrDefaultAsync();

                if (seq == null)
                {
                    var newSeq = new Sequence
                    {
                        SequenceNo = 1,
                        Year = year,
                    };
                    await _dbContext.Sequences.AddAsync(newSeq);
                    log($"pId : {pId} - [INSERT] newSequence : {DateTime.Now.ToLongTimeString()}");
                }

                else
                {
                    seq.SequenceNo++;
                    log($"pId : {pId} - [UPDATE] New sequence no : {seq.SequenceNo} - {DateTime.Now.ToLongTimeString()}");
                }

                await _dbContext.SaveChangesAsync();
                log($"pId : {pId} - SaveChangesAsync  - {DateTime.Now.ToLongTimeString()}");

                bool randomBool = new Random().Next(2) == 0;
                if (randomBool)
                {
                    var delay = 1000;
                    log($"pId : {pId} - Delay {delay}ms... - {DateTime.Now.ToLongTimeString()}");
                    await Task.Delay(delay);
                    log($"pId : {pId} - Committing... - {DateTime.Now.ToLongTimeString()}");
                }
            }, IsolationLevel.Serializable);
        }

        private async Task UpdateSequenceWithSP(int year)
        {
            using (var _dbContext = new BloggingContext())
            {
                await _dbContext.Database.Transactional(async () =>
                {

                    //await _dbContext.Database.ExecuteSqlRawAsync("EXEC dbo.UpdateSequence @Year = {0}", year);

                    //using (var _otherContext = new BloggingContext())
                    //{
                    //    //farklı dbcontext kullanırsak ana transaction üzerinde hata verse bile bunu commit eder.
                    //    await _otherContext.Database.ExecuteSqlRawAsync("EXEC dbo.UpdateSequence @Year = {0}", year);
                    //}


                    //using (var _otherContext = new BloggingContext())
                    //{
                    //        //farklı dbcontext kullanırsak ana transaction üzerinde hata verse bile bunu commit eder.
                    //        await UpdateSequence(2003, _otherContext);
                    //}


                    //await UpdateSequence(2003, _dbContext);

                    //using (var otherContext = new BloggingContext())
                    //{
                    //    await otherContext.Database.Transactional(async () =>
                    //    {
                    //        string spName = "UpdateSequence_WithoutTransaction";
                    //        log($"Transaction Started. [Isolation Level :  {otherContext.Database.CurrentTransaction!.GetDbTransaction().IsolationLevel.ToString()}]");
                    //        log($"Calling Sp : {spName}");
                    //        await otherContext.Database.GetDbConnection().ExecuteAsync(spName,
                    //        new
                    //        {
                    //            Year = year
                    //        },
                    //        transaction: otherContext.Database.CurrentTransaction.GetDbTransaction(),
                    //        commandType: CommandType.StoredProcedure);
                    //    });

                    //    log("Transaction finished..");
                    //}



                    string spName = "UpdateSequence";
                    //log($"Transaction Started. [Isolation Level :  {otherContext.Database.CurrentTransaction!.GetDbTransaction().IsolationLevel.ToString()}]");
                    log($"Calling Sp : {spName}");
                    await _dbContext.Database.GetDbConnection().ExecuteAsync(spName,
                    new
                    {
                        Year = year
                    },
                    transaction: _dbContext.Database.CurrentTransaction.GetDbTransaction(),
                    commandType: CommandType.StoredProcedure);
                    log("Transaction finished..");

                    throw new Exception("Test Exception !");


                    //using (var otherContext = new BloggingContext())
                    //{
                    //    await otherContext.Database.Transactional(async () =>
                    //    {
                    //        log($"Transaction Started. [Isolation Level :  {otherContext.Database.CurrentTransaction!.GetDbTransaction().IsolationLevel.ToString()}]");
                    //        var seq = await otherContext.Sequences.Where(s => s.Year == year).FirstAsync();
                    //        log($"Current Sequence No : {seq.SequenceNo}");
                    //        seq.SequenceNo++;
                    //        log($"New Sequence No : {seq.SequenceNo}");
                    //        await otherContext.SaveChangesAsync();
                    //        await Task.Delay(2000);
                    //        log($"After SaveChangesAsync()");
                    //    }, IsolationLevel.Serializable);

                    //    log("Transaction finished..");
                    //}




                    //Bu şekilde hata veriyor :
                    /*
                     System.InvalidOperationException: The connection is already in a transaction and cannot participate in another transaction.
                     */
                    //await _dbContext.Database.Transactional(async () =>
                    //{
                    //    await _dbContext.Database.GetDbConnection().ExecuteAsync("UpdateSequence",
                    //    new
                    //    {
                    //        Year = year
                    //    },
                    //    transaction: _dbContext.Database.CurrentTransaction.GetDbTransaction(),
                    //    commandType: CommandType.StoredProcedure);
                    //});

                    //Bu şekilde hata veriyor.
                    //await _dbContext.Database.GetDbConnection().ExecuteAsync("UpdateSequence",
                    //new
                    //{
                    //    Year = year
                    //},
                    //commandType: CommandType.StoredProcedure);

                    //bool randomBool = new Random().Next(2) == 0;
                    //if (randomBool)
                    //throw new Exception("Test Exception");

                });
            }
        }
    }
}
