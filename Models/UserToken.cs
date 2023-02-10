namespace ResultadosBackend.Models
{
    public class UserToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }

        public TimeSpan Validity { get; set; }
        public string Email { get; set; }
        public Guid GuidId { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
