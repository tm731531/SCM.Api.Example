using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{
    public class ProductQueryResponse
    {
        public int totalCount { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public string success { get; set; }
        public string desc { get; set; }
        public List<ProductQueryResultModel> data { get; set; }
    }

    public class ProductQueryResultModel
    {
        public string formerSaleCode { get; set; }
        public string fugoSaleNo { get; set; }
        public string saleCode { get; set; }
        public string saleName { get; set; }
        public string salesSubtitle { get; set; }
        public DateTime onShelf { get; set; }
        public int eType { get; set; }
        public string productProperty { get; set; }
        public int marketPrice { get; set; }
        public int salePrice { get; set; }
        public int costPrice { get; set; }
        public string showMdName { get; set; }
        public int id_SaleStatus { get; set; }
        public string saleStatus { get; set; }
        public string deliveryWay { get; set; }
        public bool fetchFromSupermarket { get; set; }
        public bool isPreorder { get; set; }
        public DateTime preorderShipDate { get; set; }
        public int preorderShipDays { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public string fugoItemType { get; set; }
        public string fugoItemTypeName { get; set; }
        public int eCategoryID { get; set; }
        public string eCategory { get; set; }
        public int uCategoryID { get; set; }
        public string uCategory { get; set; }
        public string ageRating { get; set; }
        public string prdDesPlanner { get; set; }
        public string productContent { get; set; }
        public string presentDescription { get; set; }
        public string productSpec { get; set; }
        public string accessory { get; set; }
        public string useMethod { get; set; }
        public string attentionItem { get; set; }
        public string auditState_E { get; set; }
        public string auditRejectReason_E { get; set; }
        public List<ProductQueryAccessedNumModel> productAccessedNums { get; set; }
        public ProducQuerySpecResultModel productSpecForm { get; set; }
    }

    public class ProducQuerySpecResultModel
    {
        public int productSpecFormID { get; set; }
        public string productSpecFormName { get; set; }
        public List<ProductQuerySpec> specs { get; set; }
    }

    public class ProductQuerySpec
    {
        public int specID { get; set; }
        public string specName { get; set; }
        public string specValue { get; set; }
        public string selectedOption { get; set; }
    }

    public class ProductQueryAccessedNumModel
    {
        public int panID { get; set; }
        public string productSpec { get; set; }
        public int num_E { get; set; }
        public int stockQty_E { get; set; }
        public int alertNum { get; set; }
        public string fugoProductPN { get; set; }
        public string eaNcode { get; set; }
        public string auditState_E { get; set; }
        public string auditRejectReason_E { get; set; }
    }

}
