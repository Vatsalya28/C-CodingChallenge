using DotnetAssessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAssessment.Repository
{
    public interface IPolicyServiceRepository
    {
        List<Policies> GetAllPolicies();
       bool CreatePolicy(Policies policy);
        Policies GetPolicy(int policyId);

        bool UpdatePolicy(Policies policy);
        bool DeletePolicy(int policyId);
    }
}
