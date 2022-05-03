using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace core
{
    public class Helper
    {
        public static int GetUserId(string token)
        {
            token = token.Replace("Bearer ", string.Empty);
            var tokenHandler = new JwtSecurityTokenHandler();
            var data = (JwtSecurityToken) tokenHandler.ReadToken(token);
            var userId = data.Claims.FirstOrDefault(c => c.Type == "unique_name").Value;

            if (userId is null)
            {
                return 0;
            }
            else
            {
                int parsedUserId;
                var isParsed = int.TryParse(userId, out parsedUserId);
                return isParsed ? parsedUserId : 0;
            }

        }
    }
}
