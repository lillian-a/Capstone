using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
// using Google.Apis.Pagespeedonline.v1;
// using Google.Apis.Pagespeedonline.v2;
using Google.Apis.Pagespeedonline.v4;
using Google.Apis.Services;

namespace PageSpeedAnalyticsApplication
{
    class PageSpeedService
    {
        //public static void ShowStatusMsg(string msg)
        //{
        //    var result = MessageBox.Show(msg, "Status Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
        //}

        /// RunProcessUrl
        /// <summary>Runs request on url and returns the response</summary>
        /// <param name="url">string to run the api process on</param>
        /// <returns>List of PageSpeedEntity objects with results</returns>
        public List<PageSpeedEntity> RunProcessUrl(string url)
        {
            List<PageSpeedEntity> resultList = new List<PageSpeedEntity>(2);
            try
            {
                PageSpeedService p1 = new PageSpeedService();
                Task<Google.Apis.Pagespeedonline.v4.Data.PagespeedApiPagespeedResponseV4> r = p1.RunPageSpeedServiceProcess(0, url, 0);
                PageSpeedEntity pEntity = CreatePageSpeedEntity(url, r.Result, 1);
                resultList.Add(pEntity);
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("Desktop Run ERROR: " + e.Message);
                }
            }

            try
            {
                PageSpeedService p2 = new PageSpeedService();
                Task<Google.Apis.Pagespeedonline.v4.Data.PagespeedApiPagespeedResponseV4> r2 = p2.RunPageSpeedServiceProcess(1, url, 1);
                PageSpeedEntity pEntity2 = CreatePageSpeedEntity(url, r2.Result, 1);
                resultList.Add(pEntity2);
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("Mobile Run ERROR: " + e.Message);
                }
            }
            return resultList;
        }

        /// RunPageSpeedServiceProcess
        /// <summary>Task to request api and </summary>
        /// <param name="strategy">sets whether to run desktop or mobile</param>
        /// <param name="url">url to run</param>
        /// <param name="index"></param>
        public async Task<Google.Apis.Pagespeedonline.v4.Data.PagespeedApiPagespeedResponseV4> RunPageSpeedServiceProcess(int strategy, 
            string url, int index)
        {
            var service = new PagespeedonlineService(new BaseClientService.Initializer()
            {
                ApiKey = APIKeyStorage.API_KEY,
                ApplicationName = APIKeyStorage.APP_NAME,
            });
            // create request
            var req = new PagespeedapiResource.RunpagespeedRequest(service, url);

            // set the strategy for request
            if (strategy == 0)
                req.Strategy = PagespeedapiResource.RunpagespeedRequest.StrategyEnum.Desktop;
            else
                req.Strategy = PagespeedapiResource.RunpagespeedRequest.StrategyEnum.Mobile;
            var results = req.Execute();
            return results;
        }

        /// CreatePageSpeedEntity
        /// <summary>create the page speed entity object</summary>
        /// <param name="strURL">url for object</param>
        /// <param name="result">response result to store in object</param>
        /// <param name="strategy">desktop or mobile</param>
        /// <returns>PageSpeedEntity object that was created</returns>
        public static PageSpeedEntity CreatePageSpeedEntity(string strURL,
            Google.Apis.Pagespeedonline.v4.Data.PagespeedApiPagespeedResponseV4 result,
            int strategy)
        {
            PageSpeedEntity resultPageStore = new PageSpeedEntity();
            resultPageStore.Date = DateTime.Today;
            resultPageStore.Strategy = strategy;
            resultPageStore.Base_URL = strURL;
            resultPageStore.Result = result;
            resultPageStore.Score = result.RuleGroups["SPEED"].Score.GetValueOrDefault(0);
            return resultPageStore;
        }
    }
}
