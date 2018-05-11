


namespace Enjoy.Core
{
    using Enjoy.Core;
    using Enjoy.Core.Models;
    using Org.Joey.Common;
    public interface IWxSessionService : IDependency
    {
        WxSession CreateWxSession(IWxLoginUser loginUseer);
        IWxAuthorization GetWxAuth(IWxLoginUser loginUser);

        string GetOpenId(IWxLoginUser loginUser);

        IWxAccessToken GetWxAccessToken(string appid, string secret);

        void CreatedCoupon(string token);
    }
}
