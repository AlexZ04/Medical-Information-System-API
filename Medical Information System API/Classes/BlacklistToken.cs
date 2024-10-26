namespace Medical_Information_System_API.Classes
{
    public class BlacklistToken
    {
        public string Token { get; set; }
        public DateTime AddTime { get; set; }
        public BlacklistToken() {
            AddTime = DateTime.Now.ToUniversalTime();
        }

        public BlacklistToken(string token)
        {
            Token = token;
            AddTime = DateTime.Now.ToUniversalTime();
        }
    }
}
