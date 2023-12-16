using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetAssessment.Entity;
using DotnetAssessment.Exceptions;
using DotnetAssessment.Utility;
using Microsoft.Data.SqlClient;

namespace DotnetAssessment.Repository
{
    public class PolicyServiceRepository:IPolicyServiceRepository
    {
        public string connectionString;
        SqlCommand cmd = null;
        public PolicyServiceRepository()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }


        public List<Policies> GetAllPolicies()
        {
            List<Policies> policies = new List<Policies>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "SELECT * FROM Policies";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Policies policy = new Policies();
                        policy.policy_id = (int)reader["policy_id"];
                        policy.policy_number = (string)reader["policy_number"];
                        policy.policy_type = (string)reader["policy_type"];
                        policy.coverage_amount = (decimal)reader["coverage_amount"];
                        policy.premium_amount = (decimal)reader["premium_amount"];
                        policy.start_date = (DateTime)reader["start_date"];
                        policy.end_date = (DateTime)reader["end_date"];
                        policies.Add(policy);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return policies;
        }
        public bool CreatePolicy(Policies policy)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = @"
                INSERT INTO Policies 
                (policy_number, policy_type, coverage_amount, premium_amount, start_date, end_date)
                VALUES 
                (@PolicyNumber, @PolicyType, @CoverageAmount, @PremiumAmount, @StartDate, @EndDate);
                SELECT SCOPE_IDENTITY();"; 

                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@PolicyNumber", policy.policy_number);
                    cmd.Parameters.AddWithValue("@PolicyType", policy.policy_type);
                    cmd.Parameters.AddWithValue("@CoverageAmount", policy.coverage_amount);
                    cmd.Parameters.AddWithValue("@PremiumAmount", policy.premium_amount);
                    cmd.Parameters.AddWithValue("@StartDate", policy.start_date);
                    cmd.Parameters.AddWithValue("@EndDate", policy.end_date);
                    int generatedPolicyId = Convert.ToInt32(cmd.ExecuteScalar());
                     policy.policy_id = generatedPolicyId;
                    return true; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; 
            }
        }

        public Policies GetPolicy(int policyId)
        {
            Policies policy = null;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "SELECT * FROM Policies WHERE policy_id = @PolicyId";
                    cmd.Parameters.Clear();
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@PolicyId", policyId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        policy = new Policies
                        {
                            policy_id = (int)reader["policy_id"],
                            policy_number = (string)reader["policy_number"],
                            policy_type = (string)reader["policy_type"],
                            coverage_amount = (decimal)reader["coverage_amount"],
                            premium_amount = (decimal)reader["premium_amount"],
                            start_date = (DateTime)reader["start_date"],
                            end_date = (DateTime)reader["end_date"]
                        };
                    }
                    else
                    {

                        throw new PolicyNumberNotFoundException(policyId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return policy;
        }
        public bool UpdatePolicy(Policies policy)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = @"
                UPDATE Policies
                SET policy_number = @PolicyNumber,
                    policy_type = @PolicyType,
                    coverage_amount = @CoverageAmount,
                    premium_amount = @PremiumAmount,
                    start_date = @StartDate,
                    end_date = @EndDate
                WHERE policy_id = @PolicyId";
                    cmd.Parameters.Clear();

                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    
                    cmd.Parameters.AddWithValue("@PolicyId", policy.policy_id);
                    cmd.Parameters.AddWithValue("@PolicyNumber", policy.policy_number);
                    cmd.Parameters.AddWithValue("@PolicyType", policy.policy_type);
                    cmd.Parameters.AddWithValue("@CoverageAmount", policy.coverage_amount);
                    cmd.Parameters.AddWithValue("@PremiumAmount", policy.premium_amount);
                    cmd.Parameters.AddWithValue("@StartDate", policy.start_date);
                    cmd.Parameters.AddWithValue("@EndDate", policy.end_date);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; 
            }
        }

        public bool DeletePolicy(int policyId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "DELETE FROM Policies WHERE policy_id = @PolicyId";
                    cmd.Parameters.AddWithValue("@PolicyId", policyId);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new PolicyNumberNotFoundException(policyId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }






    }
}
