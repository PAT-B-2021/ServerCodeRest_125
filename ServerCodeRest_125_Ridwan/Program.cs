using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using ServiceRest_125_Ridwan;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace ServerCodeRest_125_Ridwan
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObjek = null;
            Uri address = new Uri("http://localhost:1907/Mahasiswa");
            WebHttpBinding binding = new WebHttpBinding();

            try
            {
                hostObjek = new ServiceHost(typeof(TI_UMY), address);
                hostObjek.AddServiceEndpoint(typeof(ITI_UMY), binding, "");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                hostObjek.Description.Behaviors.Add(smb);
                Binding mexbinding = MetadataExchangeBindings.CreateMexHttpBinding();
                hostObjek.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "mex");

                WebHttpBehavior whb = new WebHttpBehavior();
                whb.HelpEnabled = true;
                hostObjek.Description.Endpoints[0].EndpointBehaviors.Add(whb);

                hostObjek.Open();
                Console.WriteLine("Server ready ..");
                Console.ReadLine();
                hostObjek.Close();
            }
            catch (Exception ex)
            {
                hostObjek = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
