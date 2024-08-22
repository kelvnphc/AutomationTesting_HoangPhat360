using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
// Định nghĩa hai phương thức
using MAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using MTestConText = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;
namespace LuuVanPhuc_53_KTHP360_BTL
{
    /// <summary>
    /// Summary description for Task1_Login_53_LuuVanPhuc
    /// </summary>
    [TestClass]
    public class Task1_Login_53_Phuc
    {
        private static PhuongThucDungChung_53_Phuc method_53_Phuc = new PhuongThucDungChung_53_Phuc();
        //Tạo đối tượng TestContext và khai báo phương thức get, set
        public MTestConText TestContext   {get; set; }
        // TestCase 1.1: Đăng nhập thành công với username và password đúng
        // Khai báo DataSource, file input data .csv
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
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Login_Data_53_Phuc\DataTestPassLogin_53_Phuc.csv",
                    "DataTestPassLogin_53_Phuc#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(1)]
        public void Login_Success_53_Phuc()
        {
            //đọc dữ liệu đầu vào từ file .csv
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();
            //thực hiện đăng nhập và điền tự động username, password mới đọc
            method_53_Phuc.LoginWithNoAds_53_Phuc(username, password);
            //Lấy URL thực tế là URL khi click button đăng nhập
            string actualurl = method_53_Phuc.driver_53_Phuc.Url;
            // Đặt URL mong muốn theo đặc tả
            string expectedurl = "https://hoangphat360.vn/account";
            // So sánh URL kì vọng so với thực tế
            MAssert.AreEqual(expectedurl, actualurl);
            // Kiểm tra xem có tồn tại user tên là "Lưu Văn Phúc" hay không
            MAssert.IsTrue(method_53_Phuc.GetUser_53_Phuc().Contains("Lưu Văn Phúc"));
            // Dừng 10 giây rồi đóng Chrome
            Thread.Sleep(10000);
            // Đóng trình duyệt sau khi thực hiện xong testcase
            //method_53_Phuc.driver_53_Phuc.Quit();
        }

        // TestCase 1.2: Đăng nhập không thành công vì username chưa đăng ký
        // Khai báo DataSource, file input data .csv
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Login_Data_53_Phuc\DataFail_UserName_ChuaDangKy_53_Phuc.csv",
                    "DataFail_UserName_ChuaDangKy_53_Phuc#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(2)]
        public void Login_Fail_UserName_ChuaDangKy_53_Phuc()
        {
            //đọc dữ liệu đầu vào từ file .csv
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();
            //thực hiện đăng nhập và điền tự động username, password mới đọc
            method_53_Phuc.LoginWithNoAds_53_Phuc(username, password);
            //Cảnh báo thực tế: Sau khi nhấn button login
            string actualalert_53_Phuc = method_53_Phuc.GetAlertMessage_53_Phuc();
            //Cảnh báo mong muốn
            string expectedalert_53_Phuc = "Thông tin đăng nhập không hợp lệ.";
            //Tiến hành so sánh cảnh báo thực tế và mong muốn
            MAssert.AreEqual(expectedalert_53_Phuc, actualalert_53_Phuc);
            //Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);
            //Đóng trình duyệt sau khi thực hiện xong test case
            //method_53_Phuc.driver_53_Phuc.Quit();
        }
        // TestCase 1.3: Đăng nhập không thành công vì sai password
        // Khai báo DataSource, file input data .csv
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Login_Data_53_Phuc\DataDungUser_SaiPassWord.csv",
                    "DataDungUser_SaiPassWord#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(3)]
        public void Login_Fail_UserNameDung_PassWordSai_53_Phuc()
        {
            //đọc dữ liệu đầu vào từ file .csv
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();
            //thực hiện đăng nhập và điền tự động username, password mới đọc
            method_53_Phuc.LoginWithNoAds_53_Phuc(username, password);
            //Cảnh báo thực tế: Sau khi nhấn button login
            string actualalert_53_Phuc = method_53_Phuc.GetAlertMessage_53_Phuc();
            //Cảnh báo mong muốn
            string expectedalert_53_Phuc = "Thông tin đăng nhập không hợp lệ.";
            //Tiến hành so sánh cảnh báo thực tế và mong muốn
            MAssert.AreEqual(expectedalert_53_Phuc, actualalert_53_Phuc);
            //Dừng 5 giây rồi đóng Chrome
            Thread.Sleep(5000);
            //Đóng trình duyệt sau khi thực hiện xong test case
            //method_53_Phuc.driver_53_Phuc.Quit();
        }

        //TestCase 1.4: Đăng nhập không thành công vì nhập sai cả username và password
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Login_Data_53_Phuc\DataFail_53_Phuc.csv",
                    "DataFail_53_Phuc#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(4)]
        public void Login_Fail_User_SaiUs_SaiPass_53_Phuc()
        {
            //đọc dữ liệu đầu vào từ file .csv
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();
            //thực hiện đăng nhập và điền tự động username, password mới đọc
            method_53_Phuc.LoginWithNoAds_53_Phuc(username, password);
            //Cảnh báo thực tế: Sau khi nhấn button login
            string actualalert_53_Phuc = method_53_Phuc.GetAlertMessage_53_Phuc();
            //Cảnh báo mong muốn
            string expectedalert_53_Phuc = "Thông tin đăng nhập không hợp lệ.";
            //Tiến hành so sánh cảnh báo thực tế và mong muốn
            MAssert.AreEqual(expectedalert_53_Phuc, actualalert_53_Phuc);
            //Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);
            //Đóng trình duyệt sau khi thực hiện xong test case
            //method_53_Phuc.driver_53_Phuc.Quit();
        }
        
    }


}
