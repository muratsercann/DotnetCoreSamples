using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCSample.Data;
using MVCSample.Models;
using System.Globalization;
using System.Text.Encodings.Web;
using System.Threading;

namespace MVCSample.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly ILogger<HelloWorldController> _logger;
        private readonly MVCSampleContext _context;

        public HelloWorldController(ILogger<HelloWorldController> logger, MVCSampleContext context)
        {
            _logger = logger;
            _context = context;
        }

        // 
        // GET: /HelloWorld/
        public IActionResult Index(CancellationToken cancellationToken)
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }

        public async Task<IActionResult> GetData(CancellationToken cancellationToken)
        {
            //Cancellation'ı test etmek için oluşturuldu.
            //Burada veritabanından döngü içerisinde sürekli veri çekiyoruz.
            //Bu Action çağrıldıktan sonra bu isteği yapan sekme kapatıldığında exception fırlatılacak
            //MiddleWareWithInterface içerisinde handle edilip loglanıyor.
            //Exception Type : OperationCanceledException

            List<Movie> result = new List<Movie>();
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(500);
                result = await _context.Movie.ToListAsync(cancellationToken);
                Console.WriteLine($"i = {i}");
            }

            return View();
        }

        public IActionResult Error()
        {
            throw new Exception("msercan : Test Error at Error() in HelloWorldController");
        }

        public IActionResult Logging()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            _logger.LogCritical(6001, $"msercan: This is an LogCritical message at Logging Action in HelloWorldController(ThreadId : {threadId}) {DateTime.Now.ToString()}");
            _logger.LogError(5001, $"msercan: This is an LogError message at Logging Action in HelloWorldController(ThreadId : {threadId}) {DateTime.Now.ToString()}");
            _logger.LogWarning(4001, $"msercan: This is an LogWarning message at Logging Action in HelloWorldController(ThreadId : {threadId}) {DateTime.Now.ToString()}");
            _logger.LogInformation(3001, $"msercan: This is an LogInformation message at Logging Action in HelloWorldController(ThreadId : {threadId}) {DateTime.Now.ToString()}");
            _logger.LogDebug(2001, $"msercan: This is an LogDebug message at Logging Action in HelloWorldController(ThreadId : {threadId}) {DateTime.Now.ToString()}");
            _logger.LogTrace(1001, $"msercan: This is an LogTrace message at Logging Action in HelloWorldController(ThreadId : {threadId}) {DateTime.Now.ToString()}");

            return Ok("msercan : Logs have been succesfully created..");
        }
    }
}
