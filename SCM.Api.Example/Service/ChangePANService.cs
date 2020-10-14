﻿using SCM.Api.Example.Common;
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
    public class ChangePANService : IWorkflow
    {

        private GetUserByUserInfo getUserByUserInfo;
        private HttpHelper httpHelper = new HttpHelper();
        private string targetUrl = "https://redapi.etzone.net/o/";
        private GetTokenResponse getTokenResponse;
        private Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        private string userName = "使用者帳號";
        private string password = "使用者密碼";
        public void DoFlow()
        {
            //1	  取得Token	        https://redapi.etzone.net/o/Token
            //2   商品變量          https://redapi.etzone.net/o/api/Product/AccessedNum
            //3   商品查詢(檢查)    https://redapi.etzone.net/o/api/Product/ProductQuery

            getUserByUserInfo = new GetUserByUserInfo() { password = password, userName = userName };
            getTokenResponse = GetToken();
            GetAccessedNum();
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
       
         private ChangeApiToServiceResponse GetAccessedNum()
        {
            ///設定Token
            keyValuePairs[CommonStr.Header.auth] = $"{getTokenResponse.data.token_type} {getTokenResponse.data.access_token}";
            ///塞入資料
            AccessNum accessNum = new AccessNum();
            ///打API
            return httpHelper.PostData<ChangeApiToServiceResponse, AccessNum>
                ($"{targetUrl}{CommonStr.Product.AccessedNum}"
                , accessNum
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
            ProductQuery productQuyery = new ProductQuery();
            ///打API
            return httpHelper.PostData<ProductQueryResponse, ProductQuery>
                ($"{targetUrl}{CommonStr.Product.ProductSpecCacheLookup}"
                , productQuyery
                , keyValuePairs);
        }
    }
}