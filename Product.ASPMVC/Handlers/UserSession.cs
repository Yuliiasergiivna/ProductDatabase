using System.Text.Json;

namespace ProductLibrary.ASPMVC.Handlers
{
    public class UserSession
    {
        private readonly ISession _session;
        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext!.Session;
        }
        public Guid? UserId
        {
            get
            {
                return JsonSerializer.Deserialize<Guid?>(_session.GetString(nameof(UserId)) ?? "null") ;
            }
            set
            {
                if (value is null)
                {
                    _session.Remove(nameof(UserId));
                }
                else 
                {  
                    _session.SetString(nameof(UserId), JsonSerializer.Serialize(value));
                }
            }
        }
        public string Email { get; set; }
    }
}
