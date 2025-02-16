using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace EventEaseApp.Services
{
    public class SessionManager : ISessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession? _session => _httpContextAccessor.HttpContext?.Session;
        private readonly ProtectedBrowserStorage _browserStorage;

        public SessionManager(IHttpContextAccessor httpContextAccessor, ProtectedBrowserStorage browserStorage)
        {
            _httpContextAccessor = httpContextAccessor;
            _browserStorage = browserStorage;
        }

        public SessionState? GetSession()
        {
            var sessionData = _session?.GetString("SessionState");
            return sessionData == null ? new SessionState() : JsonConvert.DeserializeObject<SessionState>(sessionData);
        }

        public void SetSession(SessionState sessionState)
        {
            _session?.SetString("SessionState", JsonConvert.SerializeObject(sessionState));
        }

        public void ClearSession()
        {
            _session?.Remove("SessionState");
        }

        public int? GetUserId()
        {
            var session = GetSession();
            return session?.UserId;
        }

        public void SetUserId(int userId)
        {
            var session = GetSession();
            if (session != null)
            {
                session.UserId = userId;
                SetSession(session);
            }
        }

        public void ClearUserId()
        {
            var session = GetSession();
            if (session != null)
            {
                session.UserId = null;
                SetSession(session);
            }
        }

        public async Task SetValueAsync(string key, string value)
        {
            await _browserStorage.SetAsync(key, value);
        }

        public async Task<string?> GetValueAsync(string key)
        {
            var result = await _browserStorage.GetAsync<string>(key);
            return result.Success ? result.Value : null;
        }
    }

    public interface ISessionManager
    {
    }
}
