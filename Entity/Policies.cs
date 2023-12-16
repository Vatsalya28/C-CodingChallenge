using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAssessment.Entity
{
    public class Policies
    {
        public int policy_id { get; set; }
        public string policy_number { get; set; }
        public string policy_type { get; set; }
        public decimal coverage_amount { get; set; }
        public decimal premium_amount { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }

        public override string ToString()
        {
            return $"Policy id:{policy_id}\tPolicy Number:{policy_number}\tPolicy Type:{policy_type}\tCoverage Amount:{coverage_amount}\tPremium Amount:{premium_amount}\tStart Date:{start_date}\tEnd Date:{end_date}";
        }
    }
}
