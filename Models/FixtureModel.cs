namespace ResultadosBackend.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Assist
    {
        public int? id { get; set; }
        public string name { get; set; }
    }

    public class Away
    {
        public int id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public bool? winner { get; set; }
    }

    public class Event
    {
        public Time time { get; set; }
        public Team team { get; set; }
        public Player player { get; set; }
        public Assist assist { get; set; }
        public string type { get; set; }
        public string detail { get; set; }
        public string comments { get; set; }
    }

    public class Extratime
    {
        public object home { get; set; }
        public object away { get; set; }
    }

    public class Fixture
    {
        public int id { get; set; }
        public string referee { get; set; }
        public string timezone { get; set; }
        public DateTime date { get; set; }
        public int timestamp { get; set; }
        public Periods periods { get; set; }
        public Venue venue { get; set; }
        public Status status { get; set; }
    }

    public class Fulltime
    {
        public object home { get; set; }
        public object away { get; set; }
    }

    public class Goals
    {
        public int home { get; set; }
        public int away { get; set; }
    }

    public class Halftime
    {
        public int home { get; set; }
        public int away { get; set; }
    }

    public class Home
    {
        public int id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public bool? winner { get; set; }
    }

    public class League
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string logo { get; set; }
        public string flag { get; set; }
        public int season { get; set; }
        public string round { get; set; }
    }

    public class Paging
    {
        public int current { get; set; }
        public int total { get; set; }
    }

    public class Parameters
    {
        public string live { get; set; }
    }

    public class Penalty
    {
        public object home { get; set; }
        public object away { get; set; }
    }

    public class Periods
    {
        public int first { get; set; }
        public int? second { get; set; }
    }

    public class Player
    {
        public int? id { get; set; }
        public string name { get; set; }
    }

    public class Response
    {
        public Fixture fixture { get; set; }
        public League league { get; set; }
        public Teams teams { get; set; }
        public Goals goals { get; set; }
        public Score score { get; set; }
        public List<Event> events { get; set; }
    }

    public class Root
    {
        public string get { get; set; }
        public Parameters parameters { get; set; }
        public List<object> errors { get; set; }
        public int results { get; set; }
        public Paging paging { get; set; }
        public List<Response> response { get; set; }
    }

    public class Score
    {
        public Halftime halftime { get; set; }
        public Fulltime fulltime { get; set; }
        public Extratime extratime { get; set; }
        public Penalty penalty { get; set; }
    }

    public class Status
    {
        public string @long { get; set; }
        public string @short { get; set; }
        public int elapsed { get; set; }
    }

    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
    }

    public class Teams
    {
        public Home home { get; set; }
        public Away away { get; set; }
    }

    public class Time
    {
        public int elapsed { get; set; }
        public int? extra { get; set; }
    }

    public class Venue
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
    }




}

