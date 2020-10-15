using SCM.Api.Example.Common;
using SCM.Api.Example.Interface;
using SCM.Api.Example.Model.Product;
using SCM.Api.Example.Model.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Service
{
    public class ChangeSaleStatusService : IWorkflow
    {

        private GetUserByUserInfo getUserByUserInfo;
        private HttpHelper httpHelper = new HttpHelper();
        private string targetUrl = CommonStr.TargetUrl;
        private GetTokenResponse getTokenResponse;
        private Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        private string userName = CommonStr.UserInfo.userName;
        private string password = CommonStr.UserInfo.password;
        /// <summary>
        /// 變更商品銷售狀態
        /// </summary>
        public ChangeSaleStatusService()
        {
        }
        public void DoFlow()
        {
            //1	  取得Token	        Token
            //2   變更商品銷售狀態  api/Product/ChangeSaleStatus
            //3   商品查詢(檢查)    api/Product/ProductQuery

            getUserByUserInfo = new GetUserByUserInfo() { password = password, userName = userName };
            getTokenResponse = GetToken();
            GetChangeSaleStatus();
            GetProductQuery();
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
        /// 變更商品銷售狀態
        /// </summary>
        /// <returns></returns>
        private ChangeSaleStatusResponse GetChangeSaleStatus()
        {
            ///設定Token
            keyValuePairs[CommonStr.Header.auth] = $"{getTokenResponse.data.token_type} {getTokenResponse.data.access_token}";
            ///塞入資料
            ChangeSaleStatus changeSaleStatus = new ChangeSaleStatus();
            ///打API
            return httpHelper.PostData<ChangeSaleStatusResponse, ChangeSaleStatus>
                ($"{targetUrl}{CommonStr.Product.ChangeSaleStatus}"
                , changeSaleStatus
                , keyValuePairs);
        }
        /// <summary>
        /// 商品查詢(檢查)
        /// </summary>
        /// <returns></returns>
        private ProductQueryResponse GetProductQuery()
        {
            ///設定Token
            keyValuePairs[CommonStr.Header.auth] = $"{getTokenResponse.data.token_type} {getTokenResponse.data.access_token}";
            ///塞入資料
            ProductQuery productQuyery = new ProductQuery()
            {
                queryType = 1,
                page = 1,
                pageSize = 500,
                deliveryWay = 2
            };
            ///打API
            return httpHelper.PostData<ProductQueryResponse, ProductQuery>
                ($"{targetUrl}{CommonStr.Product.ProductSpecCacheLookup}"
                , productQuyery
                , keyValuePairs);
        }
    }
}
