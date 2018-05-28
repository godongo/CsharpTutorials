using System.ServiceModel;

namespace ImplementDataAccess.Demos
{
    // Attributes mean that we want to expose this class as a service.
    [ServiceContract]
    public class WcfService
    {
        [OperationContract]
        public string DoWork(string left, string right)
        {
            return left + right;
        }
    }

    // A WCF service consists of both an .svc file and a code-behind file that contains the actual service code.
}
