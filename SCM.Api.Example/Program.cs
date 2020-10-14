using SCM.Api.Example.Interface;
using SCM.Api.Example.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IWorkflow> workflows = new List<IWorkflow>();
            workflows.Add(new ChangePANService());  
            workflows.Add(new ChangeProductPriceService());  
            workflows.Add(new ChangeSaleStatusService());    
            workflows.Add(new InsertFormSpecService());
            workflows.Add(new ModifyProductService());
            workflows.Add(new NewProductService());
            workflows.Add(new ShipManageService());

            foreach (var work in workflows) {
                work.DoFlow();
            }
            Console.Read();
        }
    }
}
