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
    public class InsertFormSpecService : IWorkflow
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
            //2   查詢規格表        https://redapi.etzone.net/o/api/Product/ProductSpecCacheLookup
            //3   填寫規格表內容    https://redapi.etzone.net/o/api/Product/InsertProductFormSpec
            //4   商品查詢(檢查)    https://redapi.etzone.net/o/api/Product/ProductQuery

            getUserByUserInfo = new GetUserByUserInfo() { password = password, userName = userName };
            getTokenResponse = GetToken();
            GetProductSpecCacheLookup();
            GetInsertProductFormSpec();
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
        /// 查詢規格表
        /// </summary>
        /// <returns></returns>
        private ProductSpecResponse GetProductSpecCacheLookup()
        {
            ///設定Token
            keyValuePairs[CommonStr.Header.auth] = $"{getTokenResponse.data.token_type} {getTokenResponse.data.access_token}";
            ///塞入資料
            ProductSpecQuyery productSpecQuyery = new ProductSpecQuyery();
            ///打API
            return httpHelper.PostData<ProductSpecResponse, ProductSpecQuyery>
                ($"{targetUrl}{CommonStr.Product.ProductSpecCacheLookup}"
                , productSpecQuyery
                , keyValuePairs);
        }
        /// <summary>
        /// 填寫規格表內容 
        /// </summary>
        /// <returns></returns>
        private ProductFormSpecResponse GetInsertProductFormSpec()
        {
            ///設定Token
            keyValuePairs[CommonStr.Header.auth] = $"{getTokenResponse.data.token_type} {getTokenResponse.data.access_token}";
            ///塞入資料
            ProductFormSpecRequest productFormSpecRequest = new ProductFormSpecRequest();
            ///打API
            return httpHelper.PostData<ProductFormSpecResponse, ProductFormSpecRequest>
                ($"{targetUrl}{CommonStr.Product.InsertProductFormSpec}"
                , productFormSpecRequest
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