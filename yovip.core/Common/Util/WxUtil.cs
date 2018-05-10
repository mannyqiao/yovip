

namespace Enjoy.Core
{
    using Enjoy.Core.Models;
    public static class WxUtil
    {
        //public static IMiniprogram Miniprogram = new Miniprogram("wx6647cb456db305dd", "b060d7cc013ee9ba7f2a6e893cb5c306");//个人小程序
        public static IMiniprogram Miniprogram = new Miniprogram("wx0c644f8027d78c74", "f1681068dfcd75ef2d7dff14cb3b5fae");//Debug 小程序
        public static string GenerateWxAuthRequestUrl(string appid, string js_code, string secret)
        {
            return string.Format("https://api.weixin.qq.com/sns/jscode2session?appid={0}&js_code={1}&secret={2}&grant_type=authorization_code",
                appid, js_code, secret);
        }

        public static string GenerateWxCreateCardRequestUrl(string token)
        {
            //https://api.weixin.qq.com/card/create?access_token=9_NcJsPSCCBM1wnwi2vBX5oRWrmsFrExrEFH2yzG5Hy6EZFIk548Z20Y7-05lKtCHEt92qXpnVS6TLhcGjOr4mB8ZFHxKAh2JRbhYtV-fpIJby-H417KTwMWtgE03TFgivVCpeu0xqgZHSwFEDIKXdAFAPRE
            return string.Format("https://api.weixin.qq.com/card/create?access_token={0}",
                token);
            
        }
        public static string GenerateWxTokenRequestUrl(string appid, string secret)
        {
            return string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}",
                appid, secret);
        }
        public static string GenerateWxCreateCardUrl(string token)
        {
            return string.Format("https://api.weixin.qq.com/card/create?access_token={0}", token);
        }
        public static string GenerateWxUploaMediaUrl(string token)
        {
            return string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}&type=image", token);
        }
        public static string GenerateWxtestwhitelist(string token)
        {
            return string.Format("https://api.weixin.qq.com/card/testwhitelist/set?access_token={0}", token);
        }
        public static string GenerateWxQRCodeUrl(string token)
        {
            return string.Format("https://api.weixin.qq.com/card/qrcode/create?access_token={0}", token);
        }
   
    }
}
