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
    public class NewProductService : IWorkflow
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
            //2   查詢前台分類      https://redapi.etzone.net/o/api/Product/FrontendProductCategoryOfFormIDsQuery
            //3   查詢規格表        https://redapi.etzone.net/o/api/Product/ProductSpecCacheLookup
            //4   新增 V2           https://redapi.etzone.net/o/api/Product/SaleSKU/v2
            //5   商品查詢(檢查)    https://redapi.etzone.net/o/api/Product/ProductQuery

            getUserByUserInfo = new GetUserByUserInfo() { password = password, userName = userName };
            getTokenResponse = GetToken();
            GetFrontendProductCategoryOfFormIDsQuery();
            GetProductSpecCacheLookup();
            GetProductV2();
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
        /// 查詢前台分類
        /// </summary>
        /// <returns></returns>
        private FrontendProductCategoryOfFormIDsResponseModel GetFrontendProductCategoryOfFormIDsQuery()
        {
            ///設定Token
            keyValuePairs[CommonStr.Header.auth] = $"{getTokenResponse.data.token_type} {getTokenResponse.data.access_token}";
            ///塞入資料
            FrontendProductCategoryOfFormIDsRequestModel frontendProductCategoryOfFormIDsRequestModel = new FrontendProductCategoryOfFormIDsRequestModel();
            ///打API
            return httpHelper.PostData<FrontendProductCategoryOfFormIDsResponseModel, FrontendProductCategoryOfFormIDsRequestModel>
                ($"{targetUrl}{CommonStr.Product.FrontendProductCategoryOfFormIDsQuery}"
                , frontendProductCategoryOfFormIDsRequestModel
                , keyValuePairs);
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
        /// 新增 V2 
        /// </summary>
        /// <returns></returns>
        private ProductResponse GetProductV2()
        {
            ///設定Token
            keyValuePairs[CommonStr.Header.auth] = $"{getTokenResponse.data.token_type} {getTokenResponse.data.access_token}";
            ///塞入資料
            ProductV2 productV2 = new ProductV2();
            ///打API
            return httpHelper.PostData<ProductResponse, ProductV2>
                ($"{targetUrl}{CommonStr.Product.ProductSpecCacheLookup}"
                , productV2
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
