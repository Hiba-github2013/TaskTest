using System;
using System.Collections.Generic;

namespace WebAPI1
{
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
    public class PdfResult
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
        public string gamedateend { get; set; }
        public Elimformatgame elimformatgame { get; set; }
        public string status { get; set; }
        public string Time { get; set; }
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



}
