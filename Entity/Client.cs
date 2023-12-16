using System;

namespace DotnetAssessment.Entity
{
    public class Client
    {
        int clientId;
        string clientName;
        string contactInfo;
        Policies policy;
        public Client(int clientId, string clientName, string contactInfo, Policies policy)
        {
            this.ClientId = clientId;
            this.ClientName = clientName;
            this.ContactInfo = contactInfo;
            this.Policy = policy;
        }  
        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }

        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }

        public string ContactInfo
        {
            get { return contactInfo; }
            set { contactInfo = value; }
        }

        public Policies Policy
        {
            get { return policy; }
            set { policy = value; }
        }

        
        public override string ToString()
        {
            return $"Client ID: {ClientId}\tClient Name: {ClientName}\tContact Info: {ContactInfo}\tPolicy Details: {Policy}";
        }
    }
}
