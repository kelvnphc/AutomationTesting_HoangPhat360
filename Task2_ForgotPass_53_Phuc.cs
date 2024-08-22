using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Threading;
// Định nghĩa 2 phương thức
using MAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using MTestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;


namespace LuuVanPhuc_53_KTHP360_BTL
{
    /// <summary>
    /// Summary description for Task2_ForgotPassword_53_Phuc
    /// </summary>
    [TestClass]
    public class Task2_ForgotPass_53_Phuc
    {
        private static PhuongThucDungChung_53_Phuc method_53_Phuc = new PhuongThucDungChung_53_Phuc();
        // Tạo đối tượng TestContext và khai báo get; set
        public MTestContext TestContext { get; set; }


        // TestCase 2.1: Khôi phục thành công với username(email) đúng
        // Khai báo DataSource, file input data .csv
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\ForgotPassword_Data_53_Phuc\KhoiPhuc_Success_53_Phuc.csv",
                    "KhoiPhuc_Success_53_Phuc#csv", DataAccessMethod.Sequential)]
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod, Order(1)]
        public void KhoiPhucSuccess_53_Phuc()
        {
            //đọc dữ liệu đầu vào từ file .csv
            string username = TestContext.DataRow[0].ToString();
            //thực hiện Quên mật khẩu đăng nhập và khôi phục và điền tự động username mới đọc
            method_53_Phuc.ForgotPassword_53_Phuc(username);
            //Lấy URL thực tế là URL khi click button đăng nhập
            string urlactual_53_Phuc = method_53_Phuc.driver_53_Phuc.Url;
            // Đặt URL mong muốn theo đặc tả
            string urlexpected_53_Phuc = "https://hoangphat360.vn/account/login";
            // So sánh URL kì vọng so với thực tế
            MAssert.AreEqual(urlexpected_53_Phuc, urlactual_53_Phuc);
            // Dừng 5 giây rồi đóng Chrome
            Thread.Sleep(5000);
            // Đóng trình duyệt sau khi thực hiện xong testcase
            //method_53_Phuc.driver_53_Phuc.Quit();
        }

        // TestCase 2.2: Khôi phục thất bại với username(email) sai
        // Khai báo DataSource, file input data .csv
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\ForgotPassword_Data_53_Phuc\ForgotPassword_Fail_SaiUsername_53_Phuc.csv",
                    "ForgotPassword_Fail_SaiUsername_53_Phuc#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(2)]
        public void KhoiPhucFail_SaiEmail_53_Phuc()
        {
            // đọc dữ liệu đầu vào từ file .csv
            string username = TestContext.DataRow[0].ToString();
            //thực hiện Quên mật khẩu đăng nhập và khôi phục và điền tự động username mới đọc
            method_53_Phuc.ForgotPassword_53_Phuc(username);
            //Lấy URL thực tế là URL khi click button đăng nhập
            string urlactual_53_Phuc = method_53_Phuc.driver_53_Phuc.Url;
            // Đặt URL mong muốn theo đặc tả
            string urlexpected_53_Phuc = "https://hoangphat360.vn/account/login#recover";
            // Lấy Cảnh báo thực tế: Sau khi nhấn button login
            string alertactual_53_Phuc = method_53_Phuc.Alert_53_Phuc();
            // Cảnh báo mong muốn
            string alertexpected_53_Phuc = "Không tìm thấy tài khoản nào với email này.";
            // So sánh URL kì vọng so với thực tế
            MAssert.AreEqual(urlexpected_53_Phuc, urlactual_53_Phuc);
            MAssert.AreEqual(alertexpected_53_Phuc, alertactual_53_Phuc);
            // Dừng 10 giây rồi đóng Chrome
            Thread.Sleep(10000);
            // Đóng trình duyệt sau khi thực hiện xong testcase
            //method_53_Phuc.driver_53_Phuc.Quit();
        }
    }
}
