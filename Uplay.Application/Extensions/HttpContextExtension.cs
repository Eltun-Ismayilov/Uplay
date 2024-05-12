using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Uplay.Application.Extensions
{
    public static class HttpContextExtension
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        private static string baseUrl;
        public const string Getphoto = Base + "/File?cyrptedPhoto={cyrptedPhoto}";
        private static string? GetLanguageHeader(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor?.HttpContext?.Request.Headers[HeaderNames.AcceptLanguage].ToString();
        }

        public static string GeneratePhotoUrl(this IHttpContextAccessor httpContextAccessor, int photoId)
        {
            baseUrl = $"{httpContextAccessor.HttpContext?.Request.Scheme}://{httpContextAccessor.HttpContext?.Request.Host.ToUriComponent()}";
            if (photoId == 0)
            {
                return string.Empty;
            }
            return baseUrl + "/" + Getphoto.Replace("{cyrptedPhoto}", HttpUtility.UrlEncode(CryptHelper.Encrypt($"{photoId}")));
        }
    }
}
