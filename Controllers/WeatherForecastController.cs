//using Microsoft.AspNetCore.Mvc;

//namespace BackApi.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private static List<string> Summaries = new()
//        {
//            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        };

//        private readonly ILogger<WeatherForecastController> _logger;

//        public WeatherForecastController(ILogger<WeatherForecastController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet]
//        public List<string> Get()
//        {
//            return Summaries;
//        }

//        [HttpPost]
//        public IActionResult Add(string name)
//        {
//            Summaries.Add(name);
//            return Ok();
//        }

//        [HttpPut]
//        public IActionResult Update(int index, string name)
//        {
//            if (index < 0 || index >= Summaries.Count)
//            {
//                return BadRequest("Неверный индекс!");
//            }

//            Summaries[index] = name;
//            return Ok();
//        }

//        [HttpDelete]
//        public IActionResult Delete(int index)
//        {
//            if (index < 0 || index >= Summaries.Count)
//            {
//                return BadRequest("Неверный индекс!");
//            }

//            Summaries.RemoveAt(index);
//            return Ok();
//        }

//        // Задание 2
//        [HttpGet("{index}")]
//        public string Get(int index)
//        {
//            return Summaries[index];
//        }

//        // Задание 3
//        [HttpGet("find-by-name")]
//        public int Get(string name)
//        {
//            int count = 0;

//            for (int i = 0; i < Summaries.Count; i++)
//            {
//                if (name == Summaries[i])
//                {
//                    count++;
//                }
//            }

//            return count;
//        }

//        // Задание 4
//        [HttpGet("get_all")]
//        public IActionResult GetAll(int? sortStrategy)
//        {
//            List<string> s1 = new List<string>(Summaries);

//            // дефолт
//            if (sortStrategy == null)
//            {
//                return Summaries == null ? NotFound() : Ok(Summaries);
//            }

//            // возрастание
//            else if (sortStrategy == 1)
//            {
//                s1.Sort();

//                return s1 == null ? NotFound() : Ok(s1);
//            }

//            // убывание
//            else if (sortStrategy == -1)
//            {
//                s1.Sort();
//                s1.Reverse();

//                return s1 == null ? NotFound() : Ok(s1);
//            }

//            else
//            {
//                return BadRequest("Некорректное значение параметра sortStrategy");
//            }
//        }
//    }
//}
