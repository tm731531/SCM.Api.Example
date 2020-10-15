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
    public class ModifyProductService : IWorkflow
    {

        private GetUserByUserInfo getUserByUserInfo;
        private HttpHelper httpHelper = new HttpHelper();
        private string targetUrl = CommonStr.TargetUrl;
        private GetTokenResponse getTokenResponse;
        private Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        private string userName = CommonStr.UserInfo.userName;
        private string password = CommonStr.UserInfo.password;
        /// <summary>
        /// 商品修改
        /// </summary>
        public ModifyProductService()
        {
        }
        public void DoFlow()
        {
            //1	  取得Token	        Token
            //2   查詢規格表        api/Product/ProductSpecCacheLookup
            //3   修改 V2           api/Product/SaleSKU/v2
            //4   商品查詢(檢查)    api/Product/ProductQuery

            getUserByUserInfo = new GetUserByUserInfo() { password = password, userName = userName };
            getTokenResponse = GetToken();
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
        /// 查詢規格表
        /// </summary>
        /// <returns></returns>
        private ProductSpecResponse GetProductSpecCacheLookup()
        {
            ///設定Token
            keyValuePairs[CommonStr.Header.auth] = $"{getTokenResponse.data.token_type} {getTokenResponse.data.access_token}";
            ///塞入資料
            ProductSpecQuyery productSpecQuyery = new ProductSpecQuyery()
            {
                specType = 1,
                productSpecFormID = new List<int>() { 14 },
                formerSaleCode = new List<string>()
            };
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
            List<ProductV2> lp = new List<ProductV2>();
            lp.Add(new ProductV2()
            {
                productSpecFormID = 14,
                productProperty = 1,
                type = 1,
                formerSaleCode = "20180409099",
                fugoItemType = "1001",
                saleName = "111111",
                prdDesPlanner = "1111111111111",
                marketPrice = 1000,
                costPrice = 900,
                salePrice = 950,
                taxType = 0,
                deliveryWay = "2",
                mainImgUrls = new List<string>() {
                    "http://www.mohist.com.tw/images/new191025/goodpay1.jpg" ,
                "https://img.ltn.com.tw/Upload/3c/page/2019/08/08/190808-37645-1.jpg" ,
                "https://img.ltn.com.tw/Upload/3c/page/2019/08/08/190808-37645-1.jpg" ,
                "https://img.ltn.com.tw/Upload/3c/page/2019/08/08/190808-37645-1.jpg" },
                contentData = "12345",
                productSpec = "13431",
                attentionItem = "12121",
                useMethod = "12331",
                uFrontendID = 5718,
                etFrontendID = 22878,

                packageLength = 1,
                packageWidth = 1,
                packageHeight = 1,
                weight = 1,
                isPreorder = 0,
                eType = 1,
                isFragile = 0,
                accessedNum = new List<ProductV2Accessednum>() {
                    new ProductV2Accessednum() { colorName="共同", styleName="共同"
                } },
                expirationDate = DateTime.Now.AddDays(30),
                onShelf = DateTime.Now.AddDays(1),
                specs = new List<ProductV2Spec>() {
                    new ProductV2Spec() { specID = "543", specValue = "3470" } ,
                    new ProductV2Spec() { specID = "544", specValue = "1028" } ,
                    new ProductV2Spec() { specID = "546", specValue = "3509" } ,
                    new ProductV2Spec() { specID = "545", specValue = "3118" } ,
                    new ProductV2Spec() { specID = "547", specValue = "2649" } ,
                    new ProductV2Spec() { specID = "569", specValue = "5397" } ,
                    new ProductV2Spec() { specID = "219", specValue = "3L" } ,
                    new ProductV2Spec() { specID = "218", specValue = "3" } ,},

            }); ;
            ///打API
            return httpHelper.PostData<ProductResponse, List<ProductV2>>
                ($"{targetUrl}{CommonStr.Product.SaleSKUV2}"
                , lp
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
                ($"{targetUrl}{CommonStr.Product.ProductQuery}"
                , productQuyery
                , keyValuePairs);
        }
    }
}
