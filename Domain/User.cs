namespace Splity.Domain
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }

        public string BasicAuthString
        {
            get
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(Email + ":" + Password);
                return System.Convert.ToBase64String(plainTextBytes);
            }
        }
    }
}