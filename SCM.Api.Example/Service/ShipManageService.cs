using SCM.Api.Example.Common;
using SCM.Api.Example.Interface;
using SCM.Api.Example.Model.Product;
using SCM.Api.Example.Model.ShipManage;
using SCM.Api.Example.Model.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Service
{
    public class ShipManageService : IWorkflow
    {

        private GetUserByUserInfo getUserByUserInfo;
        private HttpHelper httpHelper = new HttpHelper();
        private string targetUrl = "https://redapi.etzone.net/o/";
        private GetTokenResponse getTokenResponse;
        private Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        private string userName = "使用者帳號";
        private string password = "使用者密碼";
        /// <summary>
        /// 出貨
        /// </summary>
        public ShipManageService()
        {
        }
        public void DoFlow()
        {
            //1	  取得Token	            https://redapi.etzone.net/o/Token
            //2   變更出貨狀態          https://redapi.etzone.net/o/api/ShipManage/ChangeShipStatus
            //3   查詢出貨狀態(檢查)    https://redapi.etzone.net/o/api/ShipManage/Search

            getUserByUserInfo = new GetUserByUserInfo() { password = password, userName = userName };
            getTokenResponse = GetToken();
            GetChangeShipStatus();
            GetSearch();
        }
        /// <summary>
        /// 取得Token
        /// </summary>
        /// <returns></returns>
        private GetTokenResponse GetToken()
        {
            ///設定Token
            keyValuePairs.Add(CommonStr.Header.auth, "1");
            ///打API
            return httpHelper.PostData<GetTokenResponse, GetUserByUserInfo>($"{targetUrl}{CommonStr.Token}", getUserByUserInfo, keyValuePairs);
        }
        /// <summary>
        /// 變更出貨狀態
        /// </summary>
        /// <returns></returns>
        private ChangeShipStatusResponse GetChangeShipStatus()
        {
            ///設定Token
            keyValuePairs[CommonStr.Header.auth] = $"{getTokenResponse.data.token_type} {getTokenResponse.data.access_token}";
            ///塞入資料
            ChangeShipStatusRequest  changeShipStatusRequest = new ChangeShipStatusRequest();
            ///打API
            return httpHelper.PostData<ChangeShipStatusResponse, ChangeShipStatusRequest>
                ($"{targetUrl}{CommonStr.ShipManage.ChangeShipStatus}"
                , changeShipStatusRequest
                , keyValuePairs);
        }
        /// <summary>
        /// 查詢出貨狀態(檢查)
        /// </summary>
        /// <returns></returns>
        private SearchResponse GetSearch()
        {
            ///設定Token
            keyValuePairs[CommonStr.Header.auth] = $"{getTokenResponse.data.token_type} {getTokenResponse.data.access_token}";
            ///塞入資料
            SearchRequest searchRequest = new SearchRequest();
            ///打API
            return httpHelper.PostData<SearchResponse, SearchRequest>
                ($"{targetUrl}{CommonStr.ShipManage.Search}"
                , searchRequest
                , keyValuePairs);
        }
    }
}
