using System;

namespace DotnetAssessment.Exceptions
{
    public class PolicyNumberNotFoundException : ApplicationException
    {
       

        public PolicyNumberNotFoundException(int policyNumber)
            : base($"Policy with number '{policyNumber}' not found.")
        {
            PolicyNumber = policyNumber;
        }

        public int PolicyNumber { get; }
    }
}
