using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{
    public class ProductV2
    {
        public int? productSpecFormID { get; set; }
        public int productProperty { get; set; }
        public List<ProductV2Spec> specs { get; set; }
        public int type { get; set; }
        public string formerSaleCode { get; set; }
        public string fugoItemType { get; set; }
        public string saleName { get; set; }
        public string salesSubtitle { get; set; }
        public string prdDesPlanner { get; set; }
        public int marketPrice { get; set; }
        public int salePrice { get; set; }
        public int costPrice { get; set; }
        public int taxType { get; set; }
        public DateTime expirationDate { get; set; }
        public string deliveryWay { get; set; }
        public DateTime onShelf { get; set; }
        public DateTime offShelf { get; set; }
        public int brandFactor { get; set; }
        public List<string> mainImgUrls { get; set; }
        public string contentData { get; set; }
        public string productSpec { get; set; }
        public string attentionItem { get; set; }
        public string useMethod { get; set; }
        public string presentDescription { get; set; }
        public int uFrontendID { get; set; }
        public int etFrontendID { get; set; }
        public int packageLength { get; set; }
        public int packageWidth { get; set; }
        public int packageHeight { get; set; }
        public int weight { get; set; }
        public int isPreorder { get; set; }
        public DateTime preorderShipDate { get; set; }
        public int preorderShipDays { get; set; }
        public string productType { get; set; }
        public int eType { get; set; }
        public List<ProductV2Accessednum> accessedNum { get; set; }
        public int isFragile { get; set; }
    }

    public class ProductV2Spec
    {
        public string specID { get; set; }
        public string specValue { get; set; }
    }

    public class ProductV2Accessednum
    {
        public string colorName { get; set; }
        public string styleName { get; set; }
        public string fugoProductPN { get; set; }
        public string eanCode { get; set; }
        public int num_e { get; set; }
        public int alertNum { get; set; }
    }

}
