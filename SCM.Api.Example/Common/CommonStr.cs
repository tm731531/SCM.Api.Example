﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Common
{
    public class CommonStr
    {
        /// <summary>
        /// 取得Token
        /// </summary>
        public static string Token = "Token";
        /// <summary>
        /// Header setting
        /// </summary>
        public struct Header {
            public static string auth = "Authorization";
        }
        public struct Product
        {
            /// <summary>
            /// 查詢前台分類
            /// </summary>
            public static string FrontendProductCategoryOfFormIDsQuery = "api/Product/FrontendProductCategoryOfFormIDsQuery";
            /// <summary>
            /// 查詢規格表
            /// </summary>
            public static string ProductSpecCacheLookup = "api/Product/ProductSpecCacheLookup";
            /// <summary>
            /// 新增 V2
            /// </summary>
            public static string SaleSKUV2 = "api/Product/SaleSKU/v2";
            /// <summary>
            /// 商品查詢(檢查)
            /// </summary>
            public static string ProductQuery = "api/Product/ProductQuery";
            /// <summary>
            /// 填寫規格表內容
            /// </summary>
            public static string InsertProductFormSpec = "api/Product/InsertProductFormSpec";
            /// <summary>
            /// 商品變量
            /// </summary>
            public static string AccessedNum = "api/Product/AccessedNum";
            /// <summary>
            /// 商品變價
            /// </summary>
            public static string ChangeProductPrice = "api/Product/ChangeProductPrice";
            /// <summary>
            /// 變更商品銷售狀態
            /// </summary>
            public static string ChangeSaleStatus = "api/Product/ChangeSaleStatus";
        }
        public struct ShipManage
        {
            /// <summary>
            /// 變更出貨狀態
            /// </summary>
            public static string ChangeShipStatus = "api/ShipManage/ChangeShipStatus";
            /// <summary>
            /// 查詢出貨狀態(檢查)
            /// </summary>
            public static string Search = "api/ShipManage/Search";
        }



    }
}