﻿namespace HoloCart.Data.Responses
{
    public class JwtAuthResponse
    {
        public string AccessToken { get; set; }
        public RefreshToken refreshToken { get; set; }

    }
    public class RefreshToken
    {

        public string UserName { get; set; }
        public string TokenString { get; set; }
        public DateTime ExpireAt { get; set; }


    }
}
