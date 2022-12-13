using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Httptrigger1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            string name = req.Query["name"];
            string fileName = "RequestBody.txt";
            string jsonString = File.ReadAllText(fileName);
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            //string responseMessage = string.IsNullOrEmpty(name)
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //    : $"Hello, {name}. This HTTP triggered function executed successfully.";
            Root weatherForecast = JsonConvert.DeserializeObject<Root>(jsonString)!;
            string responseMessage = "";// weatherForecast.ToString();

            //log.LogInformation("C# HTTP trigger function processed a request." + weatherForecast);

            //string responseMessage = "";// weatherForecast.();
            List<DataToDisplay> DataList = new List<DataToDisplay> { };

            List<Result> R = weatherForecast.results;

            for (int i = 0; i < R.Count; i++)
            {
                Result R1 = R[i];
                DataToDisplay D1 = new DataToDisplay();
                D1.gamedateend = R1.gamedateend;
                D1.gamedate = R1.gamedate;
                D1.id = R1.id;
                responseMessage += "  " + R1.gamedate.ToString();

                DataList.Add(D1);

            }
            log.LogInformation("C# HTTP trigger function processed a request." + responseMessage);
            return new OkObjectResult(DataList);
        }
    }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Awteam
{
    public int id { get; set; }
    public string name { get; set; }
    public string delegation { get; set; }
}

public class Elimformatgame
{
    public int id { get; set; }
    public string name { get; set; }
}

public class Hmteam
{
    public int id { get; set; }
    public string name { get; set; }
    public string delegation { get; set; }
}

public class Result
{
    public int id { get; set; }
    public string gamename { get; set; }
    public Round round { get; set; }
    public object pool { get; set; }
    public Hmteam hmteam { get; set; }
    public Awteam awteam { get; set; }
    public int hmscore { get; set; }
    public int awscore { get; set; }
    public DateTime gamedate { get; set; }
    public int location { get; set; }
    public int competition { get; set; }
    public DateTime gamedateend { get; set; }
    public Elimformatgame elimformatgame { get; set; }
    public string status { get; set; }
}

public class Root
{
    public int count { get; set; }
    public object next { get; set; }
    public object previous { get; set; }
    public List<Result> results { get; set; }
}

public class Round
{
    public int id { get; set; }
    public string name { get; set; }
    public int roundnumber { get; set; }
    public bool elimround { get; set; }
}
public class DataToDisplay
{
    public int id { get; set; }
    public DateTime gamedate { get; set; }
    public DateTime gamedateend { get; set; }
}


