using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace CriminalDB.WcfServiceHoster
{
    public class Hoster
    {
        private ServiceHost host;

        public Uri BaseAddress { get; set; }

        public Hoster()
        {
            BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);

            host = new ServiceHost(typeof(CriminalDBServiceReference.));
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            host.Description.Behaviors.Add(smb);
        }

        public void Host()
        {
            try
            {
                host.Open();
            }
            catch
            {
                Terminate();
            }
        }

        public void Terminate()
        {
            if (host.State == CommunicationState.Opened)
            {
                host.Close();
            }
        }

    }
}
