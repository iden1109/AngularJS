using DAO;
/* 此範本是由NuGet自動產生的 */
using Dummies.Core;
using Dummies.ServerComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BmiLibrary
{
    public class Service : ServerComponentBase
    {
        //請在Login Method裡面撰寫Login邏輯，此名稱與參數不可更改。
        /// <summary>
        /// Login邏輯
        /// </summary>
        /// <param name="UserInfo">使用者相關資訊</param>
        /// <returns></returns>
        [WriteLog(UseLogType.ToFileSystem)]
        [WriteExceptionLog(UseLogType.ToEventLog)]
        [ErrorLevel(LevelType.Fatal)]
        [EnabledAnonymous(false)]
        [ExposeWebAPI(true)]
        public bool Login(UserInfo param)
        {
            return true;
        }

        /// <summary>
        /// 基本範例，取得目前時間
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [WriteLog(UseLogType.ToFileSystem)]
        [WriteExceptionLog(UseLogType.ToEventLog)]
        [ErrorLevel(LevelType.Fatal)]
        [EnabledAnonymous(false), ExposeWebAPI(true)]
        public DateTime GetDateTime(decimal param)
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 計算Calu BMI
        /// </summary>
        /// <param name="WeightAndHeight">"60,160"</param>
        /// <returns></returns>
        [WriteLog(UseLogType.ToFileSystem)]
        [WriteExceptionLog(UseLogType.ToEventLog)]
        [ErrorLevel(LevelType.Fatal)]
        [EnabledAnonymous(true), ExposeWebAPI(true)]
        public string CalcBMI(string WeightAndHeight)
        {
            string[] paras = WeightAndHeight.Split(',');
            if (paras.Length <= 1)
                return "0";
            double height = double.Parse(paras[1]) / 100;
            double weight = double.Parse(paras[0]);
            double result = weight / (height * height);
            return result.ToString("##.##");
        }

        /// <summary>
        /// Add a customer
        /// </summary>
        /// <param name="cust">Customer object</param>
        /// <returns></returns>
        [WriteLog(UseLogType.ToFileSystem)]
        [WriteExceptionLog(UseLogType.ToEventLog)]
        [ErrorLevel(LevelType.Fatal)]
        [EnabledAnonymous(true), ExposeWebAPI(true)]
        public int AddCustomer(Customer cust)
        {
            var db = new cmsContext();
            db.Customers.Add(cust);
            db.SaveChanges();
            return cust.Id;
        }

        /// <summary>
        /// Get a customer
        /// </summary>
        /// <returns>List of CustDTO</returns>
        [WriteLog(UseLogType.ToFileSystem)]
        [WriteExceptionLog(UseLogType.ToEventLog)]
        [ErrorLevel(LevelType.Fatal)]
        [EnabledAnonymous(true), ExposeWebAPI(true)]
        public List<CustDTO> GetCustomers()
        {
            var db = new cmsContext();
            return db.Customers.Select(item =>
                new CustDTO
                {
                    Id = item.Id,
                    Name = item.Name
                }).ToList();
        }

        /// <summary>
        /// Get a customer
        /// </summary>
        /// <param name="id">customer Id</param>
        /// <returns>Customer object</returns>
        public Customer GetCustomer(string id)
        {
            cmsContext db = new cmsContext();
            Customer c = db.Customers.Where(x => x.Id == 1 && x.Name == "sky").First();
            return c;
        }

        /// <summary>
        /// Customer for View 
        /// </summary>
        public class CustDTO
        {
            public int Id { get; set; }   //Id is a key word, default PK  or using [Key] notation
            public string Name { get; set; }
            public string Weight { get; set; }
            public string Height { get; set; }
        }
    }
}