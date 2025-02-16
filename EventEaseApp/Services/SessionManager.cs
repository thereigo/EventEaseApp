using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EventEaseApp.Services
{
    public class SessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public SessionState GetSession()
        {
            var sessionData = _session.GetString("SessionState");
            return sessionData == null ? new SessionState() : JsonConvert.DeserializeObject<SessionState>(sessionData);
        }

        public void SetSession(SessionState sessionState)
        {
            _session.SetString("SessionState", JsonConvert.SerializeObject(sessionState));
        }

        public void ClearSession()
        {
            _session.Remove("SessionState");
        }

        public int? GetUserId()
        {
            return GetSession().UserId;
        }

        public void SetUserId(int userId)
        {
            var session = GetSession();
            session.UserId = userId;
            SetSession(session);
        }

        public void ClearUserId()
        {
            var session = GetSession();
            session.UserId = null;
            SetSession(session);
        }
    }
}
