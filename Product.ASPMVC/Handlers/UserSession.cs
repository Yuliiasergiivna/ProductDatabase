using System.Text.Json;

namespace ProductLibrary.ASPMVC.Handlers
{
    public class UserSession
    {
        private readonly ISession _session;
        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext?.Session ?? throw new Exception("Session n'a pas valable");
        }
        public Guid? UserId
        {
            get
            {
                string? data = _session.GetString(nameof(UserId));
                if (Guid.TryParse(data, out Guid guid))
                {
                    return guid;
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    _session.Remove(nameof(UserId));
                }
                else
                {
                    _session.SetString(nameof(UserId), JsonSerializer.Serialize(value));
                }
            }
        }
        public string? Email
        {
            get => _session.GetString(nameof(Email));
            set
            {
                if (value == null)
                {
                    _session.Remove(nameof(Email));
                }
                else
                {
                    _session.SetString(nameof(Email), value);
                }
            }
        }
    }
}

