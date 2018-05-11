

namespace Enjoy.Portal.Dashboard
{
    using System.Web.UI.WebControls;
    using System.Collections.Generic;
    public class NavigationManagement
    {

        public static IEnumerable<MenuItem> Menus
        {
            get
            {
                yield return new MenuItem("商户概况", "MerchantSummary", "fa fa-dashboard fa-fw", "/");


                var merchant = new MenuItem("商户管理", "Merchants", "fa fa-magic fa-fw", "/Merchent/Index");
                merchant.ChildItems.Add(new MenuItem("新建商户", "CreateMerchant", "", "/Merchent/Create") { Enabled = false });
                merchant.ChildItems.Add(new MenuItem("新建门店", "CreateMerchantShop", "", "/Merchent/CreateShop"));
                merchant.ChildItems.Add(new MenuItem("门店列表", "CreateMerchantShop", "", "/Merchent/CreateShop"));
                merchant.ChildItems.Add(new MenuItem("我的账户", "CreateMerchantShop", "", "/Merchent/CreateShop"));
                yield return merchant;

                var cards = new MenuItem("卡券管理", "Cards", "fa fa-exchange fa-fw", "/Merchent/Index");
                cards.ChildItems.Add(new MenuItem("会员卡", "Card", "", "/Cards/Create") { Enabled = false });
                cards.ChildItems.Add(new MenuItem("优惠券", "Coupon", "", "/Cards/CreateShop"));
                cards.ChildItems.Add(new MenuItem("使用报告", "CCReport", "", "/Cards/Report"));
                yield return cards;

                var marketings = new MenuItem("营销中心", "Marketings", "fa fa-money fa-fw", "");
                marketings.ChildItems.Add(new MenuItem("消息推送", "MessagePush", "Marketings/PushMessage"));
                marketings.ChildItems.Add(new MenuItem("推广裂变", "MessagePush", "Marketings/Fission"));
                yield return marketings;

            }
        }
    }
}