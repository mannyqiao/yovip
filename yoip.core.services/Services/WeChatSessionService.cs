
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Enjoy.Core.Services
{
    using System;
    using System.Text;
    using Newtonsoft.Json;
    using Org.Joey.Common;
    using System.Security.Cryptography;
    using Enjoy.Core;
    using Enjoy.Core.Models;
    using System.IO;
    using System.Net;

    public class WxSessionService : IWxSessionService
    {
        //https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1451025062

        public WxSession CreateWxSession(IWxLoginUser loginUser)
        {
            IMiniprogram program = WxUtil.Miniprogram;
            var request = WxUtil.GenerateWxAuthRequestUrl(program.AppId, loginUser.Code, program.AppSecrect);

            var auth = request.GetResponseForJson<WeChatAuthorization>();
            var wechatUser = Decrypt(loginUser.Data, loginUser.IV, auth.SessionKey);
            return new WxSession() { LoginUser = loginUser, Miniprogram = program, WeCharUser = wechatUser, Authorization = auth };
        }
        public IWxAuthorization GetWxAuth(IWxLoginUser loginUser)
        {
            IMiniprogram program = WxUtil.Miniprogram;
            var request = WxUtil.GenerateWxAuthRequestUrl(program.AppId, loginUser.Code, program.AppSecrect);
            var auth = request.GetResponseForJson<WeChatAuthorization>();
            return auth;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawData">公开的用户资料</param>
        /// <param name="signature"></param>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        private bool VaildateSignature(string rawData, string signature, string sessionKey)
        {
            //创建SHA1签名类  
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            //编码用于SHA1验证的源数据  
            byte[] source = Encoding.UTF8.GetBytes(rawData + sessionKey);
            //生成签名  
            byte[] target = sha1.ComputeHash(source);
            //转化为string类型，注意此处转化后是中间带短横杠的大写字母，需要剔除横杠转小写字母  
            string result = BitConverter.ToString(target).Replace("-", "").ToLower();
            //比对，输出验证结果  
            return signature == result;
        }
        private WxUser Decrypt(string encryptedData, string iv, string sessionKey)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
#pragma warning restore IDE0017 // Simplify object initialization
            //设置解密器参数  
            aes.Mode = CipherMode.CBC;
            aes.BlockSize = 128;
            aes.Padding = PaddingMode.PKCS7;
            //格式化待处理字符串  
            byte[] byte_encryptedData = Convert.FromBase64String(encryptedData);
            byte[] byte_iv = Convert.FromBase64String(iv);
            byte[] byte_sessionKey = Convert.FromBase64String(sessionKey);

            aes.IV = byte_iv;
            aes.Key = byte_sessionKey;
            //根据设置好的数据生成解密器实例  
            ICryptoTransform transform = aes.CreateDecryptor();

            //解密  
            byte[] final = transform.TransformFinalBlock(byte_encryptedData, 0, byte_encryptedData.Length);

            //生成结果  
            string result = Encoding.UTF8.GetString(final);

            //反序列化结果，生成用户信息实例  
            return result.DeserializeToObject<WxUser>();
        }
        public string GetOpenId(IWxLoginUser loginUser)
        {
            return this.CreateWxSession(loginUser).WeCharUser.OpenId;
        }
        public IWxAccessToken GetWxAccessToken(string appid, string secret)
        {
            var request = WxUtil.GenerateWxTokenRequestUrl(appid, secret);
            return request.GetResponseForJson<WxAccessToken>();
        }
        public void CreatedCoupon(string token)
        {
            var request = WxUtil.GenerateWxCreateCardUrl(token);
            var context = request.GetResponse((http) =>
             {
                 http.Method = "POST";
                 http.ContentType = "application/json; encoding=utf-8";
                 var data = new
                 {
                     card = new
                     {
                         card_type = "GROUPON",// GROUPON： 团购券类型 CASH:代金券 DISCOUNT:折扣券 GIFT:兑换券 GENERAL_COUPON:优惠券 MEMBER_CARD:会员卡

                         groupon = new
                         {
                             base_info = new
                             {
                                 logo_url = @"http://mmbiz.qpic.cn\mmbiz_jpg\EEMV7pCMmetWLAjhFtj2K5kdy5sK8z6hdlQbTe0ibtfIlZhibuKoAibe5dhA1VReGWPzz7vHcQExQSicKWrMicicND0A\0",
                                 brand_name = "Joey's shop",
                                 code_type = "CODE_TYPE_TEXT",
                                 title = "132元双人火锅套餐",
                                 sub_title = "周末狂欢必备",
                                 color = "Color010",
                                 notice = "使用时向服务员出示此券",
                                 service_phone = "13961576298",
                                 description = "不可与其他优惠同享如需团购券发票，请在消费时向商户提出店内均可使用，仅限堂食",
                                 date_info = new
                                 {
                                     type = "DATE_TYPE_FIX_TERM",
                                     fixed_term = 15,
                                     fixed_begin_term = 0
                                 },
                                 sku = new
                                 {
                                     quantity = 10000
                                 },
                                 get_limit = 3,
                                 use_custom_code = false,
                                 bind_openid = false,
                                 can_share = true,
                                 can_give_friend = true,
                                 location_id_list = new[]
                                 {
                                     123,
                                     12321,
                                     345345
                                 },
                                 custom_url_name = "立即使用",
                                 custom_url = "https://www.baidu.com",
                                 custom_url_sub_title = "6个汉字",
                                 promotion_url_name = "更多优惠",
                                 promotion_url = "https://www.163.com"
                             },
                             deal_detail = "dddddddd"
                         }
                     }
                 };
                 using (var stream = http.GetRequestStream())
                 {
                     var buffers = UTF8Encoding.UTF8.GetBytes(data.ToJson());
                     stream.Write(buffers, 0, buffers.Length);
                     stream.Flush();
                 }
                 return http;
             });
        }
        public void PostLogImage(string token)
        {
            var request = WxUtil.GenerateWxUploaMediaUrl(token);
            var context = request.GetResponse((http) =>
            {
                http.Method = "POST";
                http.ContentType = "application/x-www-form-urlencoded";
                CookieContainer cookieContainer = new CookieContainer();
                http.CookieContainer = cookieContainer;
                http.AllowAutoRedirect = true;
                http.Method = "POST";
                string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
                http.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
                byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
                byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                StringBuilder sbHeader =
                new StringBuilder(
                    string.Format(
                        "Content-Disposition:form-data;name=\"media\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n",
                        @"Enjoy.jpg"));
                byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());

                FileStream fs = new FileStream(@"D:\Workspaces\Enjoy\portals\Enjoy.api\Content\images\Enjoy.jpg", FileMode.Open, FileAccess.Read);
                byte[] bArr = new byte[fs.Length];
                fs.Read(bArr, 0, bArr.Length);
                fs.Close();

                using (Stream postStream = http.GetRequestStream())
                {
                    postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                    postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                    postStream.Write(bArr, 0, bArr.Length);
                    postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
                    postStream.Flush();
                }
                return http;
            });
        }
        public void CreateTestwhiteList(string token)
        {

            var request = WxUtil.GenerateWxtestwhitelist(token);
            var context = request.GetResponse((http) =>
            {
                http.Method = "POST";
                http.ContentType = "application/json; encoding=utf-8";
                var data = new
                {
                    openid = new string[] { },
                    username = new string[] { "s66822351", "ebyinglw" }
                };
                using (var stream = http.GetRequestStream())
                {
                    var buffers = UTF8Encoding.UTF8.GetBytes(data.ToJson());
                    stream.Write(buffers, 0, buffers.Length);
                    stream.Flush();
                }
                return http;
            });
        }
        public QRCodeWxResponse CreateWxQRCode(string token, string cardid)
        {
            var request = WxUtil.GenerateWxQRCodeUrl(token);

            var qrcode = request.GetResponseForJson<QRCodeWxResponse>((http) =>
            {
                http.Method = "POST";
                http.ContentType = "application/json; encoding=utf-8";
                var data = new
                {
                    action_name = "QR_CARD",
                    expire_seconds = 1800,
                    action_info = new
                    {
                        card = new
                        {
                            card_id = cardid,
                            code = "",
                            openid = "",
                            is_unique_code = false,
                            outer_str = "13b",
                        }
                    }

                };
                using (var stream = http.GetRequestStream())
                {
                    var buffers = UTF8Encoding.UTF8.GetBytes(data.ToJson());
                    stream.Write(buffers, 0, buffers.Length);
                    stream.Flush();
                }
                return http;
            });
            //{ "errcode":0,"errmsg":"ok","ticket":"gQGX7zwAAAAAAAAAAS5odHRwOi8vd2VpeGluLnFxLmNvbS9xLzAyMkZNbVVqeHlkb2oxU1dfRWhxNGwAAgSyeOhaAwQIBwAA","expire_seconds":1800,"url":"http:\/\/weixin.qq.com\/q\/022FMmUjxydoj1SW_Ehq4l","show_qrcode_url":"https:\/\/mp.weixin.qq.com\/cgi-bin\/showqrcode?ticket=gQGX7zwAAAAAAAAAAS5odHRwOi8vd2VpeGluLnFxLmNvbS9xLzAyMkZNbVVqeHlkb2oxU1dfRWhxNGwAAgSyeOhaAwQIBwAA"}
            return qrcode;
        }
        public void CreatedMemberCard(string token)
        {

            var request = WxUtil.GenerateWxCreateCardUrl(token);
            var context = request.GetResponse((http) =>
            {
                http.Method = "POST";
                http.ContentType = "application/json; encoding=utf-8";
                var data = File.ReadAllText("/bin/json/MemberCard.json");
                using (var stream = http.GetRequestStream())
                {
                    var buffers = UTF8Encoding.UTF8.GetBytes(data);
                    stream.Write(buffers, 0, buffers.Length);
                    stream.Flush();
                }
                return http;
            });
        }
    }
}
