using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliRaza
{
    public static class Locators
    {
        // Login Page Locators
        public const string UserName = "#loginusername";
        public const string Password = "#loginpassword";
        public const string LoginButton = "#login2";
        public const string loginButtonSubmit = "body.modal-open:nth-child(2) div.modal.fade.show:nth-child(3) div.modal-dialog div.modal-content div.modal-footer > button.btn.btn-primary:nth-child(2)";
        public const string logoutInHeaderText = "#logout2";

        // Signup Page Locators
        public const string SignupUserName = "#sign-username";
        public const string SignupPassword = "#sign-password";
        public const string SignupButton = "#signin2";
        public const string SignupButtonSubmit = "body.modal-open:nth-child(2) div.modal.fade.show:nth-child(2) div.modal-dialog div.modal-content div.modal-footer > button.btn.btn-primary:nth-child(2)";

        // Product Page Locators
        public const string ProductLink = "div.container:nth-child(6) div.row div.col-lg-9 div.row:nth-child(1) div.col-lg-4.col-md-6.mb-4:nth-child(1) div.card.h-100 div.card-block:nth-child(2) h4.card-title:nth-child(1) > a.hrefch";
        public const string AddToCartButton = "div.product-content.product-wrap.clearfix.product-deatil:nth-child(6) div.row div.col-md-7.col-sm-12.col-xs-12 div.row:nth-child(7) div.col-sm-12.col-md-6.col-lg-6 > a.btn.btn-success.btn-lg";

        // Cart Page Locators
        public const string CartLink = "#cartur";
        public const string CartTotalText = "#totalp";
        public const string ExpectedProdcutTextLocator = "//span[@class='title']";

        // Checkout Page Locators
        public const string PlaceOrderButton = "body:nth-child(2) div:nth-child(7) div.row div.col-lg-1 > button.btn.btn-success:nth-child(3)";
        public const string PurchaseButton = "body.modal-open:nth-child(2) div.modal.fade.show:nth-child(3) div.modal-dialog div.modal-content div.modal-footer > button.btn.btn-primary:nth-child(2)";
        public const string OrderConfirmationText = "/html[1]/body[1]/div[10]/h2[1]";


        //CheckOut Popup Locators
        public const string Name = "#name";
        public const string Country = "#country";
        public const string City = "#city";
        public const string CreditCard = "#card";
        public const string Month = "#month";
        public const string Year = "#year";
    }
}
