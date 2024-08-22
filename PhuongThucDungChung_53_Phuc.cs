using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace LuuVanPhuc_53_KTHP360_BTL
{
    class PhuongThucDungChung_53_Phuc
    {
        //Khai báo thuộc tính là public để dùng chung cho UnitTest
        public IWebDriver driver_53_Phuc = new ChromeDriver();
        public PhuongThucDungChung_53_Phuc() { }

        //Phương thức truy cập vào trang web hoangphat360.vn
        public void TruyCapTrangChu_53_Phuc()
        {
            //Thực hiện truy cập tới Url Trang chủ trang web HoangPhat360
            driver_53_Phuc.Navigate().GoToUrl("https://hoangphat360.vn/");
        }

        //Phương thức thực hiện truy cập vào trang login và thực hiện đăng nhập khi ở trang chủ
        public void Login_53_Phuc(string username, string password)
        {
            //Gọi phương thức TruyCapTrangChu_53_Phuc() để truy cập vào trang chủ web
            TruyCapTrangChu_53_Phuc();
            // Tạo đối tượng để nhấn vào LinkText Đăng nhập
            IWebElement e_login_53_Phuc = driver_53_Phuc.FindElement(By.LinkText("Đăng nhập"));
            e_login_53_Phuc.Click();
            // Tạo thời gian chờ để có chuyển hướng sẽ không fail
            Thread.Sleep(10000);
            //Nhập username(Email)
            IWebElement e_user_53_Phuc = driver_53_Phuc.FindElement(By.CssSelector("#customer_email"));
            e_user_53_Phuc.SendKeys(username);
            //Nhập password
            IWebElement e_pass_53_Phuc = driver_53_Phuc.FindElement(By.CssSelector("#customer_password"));
            e_pass_53_Phuc.SendKeys(password);
            //Click button đăng nhập
            IWebElement e_btnLogin_53_Phuc = driver_53_Phuc.FindElement(By.CssSelector(".btn-login"));
            e_btnLogin_53_Phuc.Click();
        }
        // Phương thức login tránh các điều hướng và quảng cáo
        public void LoginWithNoAds_53_Phuc(string username, string password)
        {
            try
            {
                Login_53_Phuc(username, password);
            }
            catch (NoSuchElementException)
            {
                Login_53_Phuc(username, password);
            }
        }
        public string GetUser_53_Phuc()
        {
            // Bắt element của tên tài khoản bằng CssSelector
            IWebElement e_user_53_Phuc = driver_53_Phuc.FindElement(By.CssSelector("strong[style='line-height: 20px;']"));
            // Ép chuỗi để lấy tên user
            string user = e_user_53_Phuc.Text;
            // Trả về tên user để Equal bên Nunit
            return user;
        }

        //Phương thức trả về lỗi khi đăng nhập không thành công
        public string GetAlertMessage_53_Phuc()
        {
            //bắt element của alert bằng CssSelector
            IWebElement e_alert_53_Phuc = driver_53_Phuc.FindElement(By.CssSelector(".form-signup"));
            //Trả về lời cảnh báo được bắt
            return e_alert_53_Phuc.Text;
        }
        //Phương  thức tự động truy cập chức năng Quên mật khẩu và tự động điền email
        public void ForgotPassword_53_Phuc(string username)
        {
            //Truy cập trang login của HoangPhat360
            driver_53_Phuc.Navigate().GoToUrl("https://hoangphat360.vn/account/login");
            Thread.Sleep(10000);
            // Tạo đối tượng để nhấn vào LinkText Quên mật khẩu, nhấn vào đây
            IWebElement e_forgotpass_53_Phuc = driver_53_Phuc.FindElement(By.LinkText("đây"));
            e_forgotpass_53_Phuc.Click();
            //Nhập email khôi phục
            IWebElement e_emailuser_53_Phuc = driver_53_Phuc.FindElement(By.CssSelector("#recover-email"));
            e_emailuser_53_Phuc.SendKeys(username);
            //Click button lấy lại mật khẩu
            IWebElement e_submit_53_Phuc = driver_53_Phuc.FindElement(By.CssSelector("input.btn.btn-style.btn-recover.btn-block[type='submit']"));
            e_submit_53_Phuc.Click();
        }

        public string Alert_53_Phuc()
        {
            //bắt element bằng XPath của câu cảnh báo alert
            IWebElement e_alert_53_Phuc = driver_53_Phuc.FindElement(By.XPath("//*[@id='recover-password']/form/div[1]"));
            //trả về câu lệnh cảnh báo dạng Text
            return e_alert_53_Phuc.Text;
        }
    
    }
}
