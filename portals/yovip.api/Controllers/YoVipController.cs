
namespace Enjoy.Portal.API.Controllers
{
    using System.Web.Http;
    using Enjoy.Core;
    using Enjoy.Core.Models;
    using Enjoy.Core.Services;
    public class EnjoyController : System.Web.Http.ApiController
    {
        //获取成功设置小程序全局session
        //https://api.weixin.qq.com/sns/jscode2session?appid=APPID&secret=SECRET&js_code=JSCODE&grant_type=authorization_code
        private readonly WxSessionService service = new WxSessionService();
        [Route("api/Enjoy/DecodeUserInfo")]
        [HttpGet]
        public WxSession DecodeUserInfo(string code, string iv, string encryptedData, string signature)
        {
            var session = service.CreateWxSession(new WeChatLoginUser(code, iv, encryptedData, signature));
            return session;
        }

        [Route("api/Enjoy/GetAuth")]
        [HttpGet]
        public IWxAuthorization GetAuth(string code, string iv)
        {
            return service.GetWxAuth(new WeChatLoginUser(code, iv, null, null));
        }
        [Route("api/Enjoy/GetAccessToken")]
        public QRCodeWxResponse GetAccessToken(string appid, string secret)
        {
            var token = service.GetWxAccessToken(appid, secret);
            //service.PostLogImage(token.Token);
            //service.CreatedCard(token.Token);
            //service.CreateTestwhiteList(token.Token);
            //poeJY0xB2HRHOTyupHrXWj5CjXRw
            var code = service.CreateWxQRCode(token.Token, "poeJY0xB2HRHOTyupHrXWj5CjXRw");
            return code;
        }
        [Route("api/Enjoy/Test")]
        [HttpGet]
        public string Test()
        {
            return "ok";
        }
    }
}
