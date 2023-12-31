﻿using DotnetAssessment.Entity;
using DotnetAssessment.Exceptions;
using DotnetAssessment.Repository;
#region GetAllEmployees
  
//IPolicyServiceRepository policyServiceRepository = new PolicyServiceRepository();
//List<Policies> policies = policyServiceRepository.GetAllPolicies();
//foreach (var policy in policies)
//{
//    Console.WriteLine(policy.ToString());
//}


#endregion

#region Create Policy
//Console.WriteLine("Existing Policies:");
//List<Policies> existingPolicies = policyServiceRepository.GetAllPolicies();
//DisplayPolicies(existingPolicies);
//Policies newPolicy = GetUserInputForNewPolicy();
//bool isPolicyCreated = policyServiceRepository.CreatePolicy(newPolicy);
//if (isPolicyCreated)
//{
//    Console.WriteLine("New Policy Created");
//    DisplayPolicies(new List<Policies> { newPolicy });
//}
//else
//{
//    Console.WriteLine("Failed to create the new policy.");
//}

//static void DisplayPolicies(List<Policies> policies)
//{
//    foreach (var policy in policies)
//    {
//        Console.WriteLine(policy.ToString());
//    }
//}

//static Policies GetUserInputForNewPolicy()
//{
//    Console.WriteLine("Enter details");

//    Console.Write("Policy Number:");
//    string policyNumber = Console.ReadLine();

//    Console.Write("Policy Type:");
//    string policyType = Console.ReadLine();

//    Console.Write("Coverage Amount:");
//    decimal coverageAmount = decimal.Parse(Console.ReadLine());


//    Console.Write("Premium Amount: ");
//    decimal premiumAmount = decimal.Parse(Console.ReadLine());


//    Console.Write("Start Date(yyyy-mm-dd): ");
//    DateTime startDate = DateTime.Parse(Console.ReadLine());


//    Console.Write("End Date");
//    DateTime endDate = DateTime.Parse(Console.ReadLine());


//    return new Policies
//    {
//        policy_number = policyNumber,
//        policy_type = policyType,
//        coverage_amount = coverageAmount,
//        premium_amount = premiumAmount,
//        start_date = startDate,
//        end_date = endDate
//    };
//}




#endregion


#region Get PolicyById
//try
//{
//    Console.Write("Enter Policy ID: ");
//    if (int.TryParse(Console.ReadLine(), out int policyId))
//    {
//        Policies policy = policyServiceRepository.GetPolicy(policyId);

//        if (policy != null)
//        {
//            DisplayPolicies(new List<Policies> { policy });
//        }
//    }
//    else
//    {
//        Console.WriteLine("Invalid input id");
//    }
//}
//catch (PolicyNumberNotFoundException ex)
//{
//    Console.WriteLine($"Policy not found with ID: {ex.PolicyNumber}");

//}

//static void DisplayPolicies(List<Policies> policies)
//{
//    foreach (var policy in policies)
//    {
//        Console.WriteLine(policy);
//    }
//}

#endregion

#region Update Policy

//try
//{
//    Console.Write("Enter Policy ID: ");
//    if (int.TryParse(Console.ReadLine(), out int policyId))
//    {
//        Policies existingPolicy = policyServiceRepository.GetPolicy(policyId);

//        if (existingPolicy != null)
//        {
//            Policies updatedPolicy = GetInputForUpdatedPolicy(existingPolicy);
//            bool isPolicyUpdated = policyServiceRepository.UpdatePolicy(updatedPolicy);

//            if (isPolicyUpdated)
//            {
//                Console.WriteLine("Policy updated.");
//            }
//            else
//            {
//                Console.WriteLine("Failed to update the policy.");
//            }
//        }

//    }
//}
//catch (PolicyNumberNotFoundException ex)
//{
//    Console.WriteLine($"Policy not found with ID: {ex.PolicyNumber}");

//}


//static Policies GetInputForUpdatedPolicy(Policies existingPolicy)
//{
//    Console.WriteLine("Enter updated details for the policy:");

//    Console.Write($"Policy Number ({existingPolicy.policy_number}): ");
//    string policyNumber = Console.ReadLine();
//    if (string.IsNullOrWhiteSpace(policyNumber))
//    {
//        policyNumber = existingPolicy.policy_number;
//    }

//    Console.Write($"Policy Type ({existingPolicy.policy_type}): ");
//    string policyType = Console.ReadLine();
//    if (string.IsNullOrWhiteSpace(policyType))
//    {
//        policyType = existingPolicy.policy_type;
//    }

//    Console.Write($"Coverage Amount ({existingPolicy.coverage_amount}): ");
//    decimal coverageAmount;
//    while (!decimal.TryParse(Console.ReadLine(), out coverageAmount))
//    {
//        Console.WriteLine("Invalid input. Please enter a valid decimal value for Coverage Amount.");
//    }

//    Console.Write($"Premium Amount ({existingPolicy.premium_amount}): ");
//    decimal premiumAmount;
//    while (!decimal.TryParse(Console.ReadLine(), out premiumAmount))
//    {
//        Console.WriteLine("Invalid input. Please enter a valid decimal value for Premium Amount.");
//    }

//    Console.Write($"Start Date ({existingPolicy.start_date:yyyy-MM-dd}): ");
//    DateTime startDate;
//    while (!DateTime.TryParse(Console.ReadLine(), out startDate))
//    {
//        Console.WriteLine("Invalid input. Please enter a valid date in the format yyyy-MM-dd.");
//    }

//    Console.Write($"End Date ({existingPolicy.end_date:yyyy-MM-dd}): ");
//    DateTime endDate;
//    while (!DateTime.TryParse(Console.ReadLine(), out endDate))
//    {
//        Console.WriteLine("Invalid input. Please enter a valid date in the format yyyy-MM-dd.");
//    }

//    return new Policies
//    {
//        policy_id = existingPolicy.policy_id,
//        policy_number = policyNumber,
//        policy_type = policyType,
//        coverage_amount = coverageAmount,
//        premium_amount = premiumAmount,
//        start_date = startDate,
//        end_date = endDate
//    };
//}





#endregion

#region Delete Policy
//try
//{
//    Console.Write("Enter Policy ID to delete ");
//    if (int.TryParse(Console.ReadLine(), out int policyId))
//    {


//        bool isPolicyDeleted = policyServiceRepository.DeletePolicy(policyId);

//        if (isPolicyDeleted)
//        {
//            Console.WriteLine("Policy deleted successfully.");

//        }
//    }
//}
//catch (PolicyNumberNotFoundException ex)
//{
//    Console.WriteLine($"Policy Number Not Found: {ex.PolicyNumber}");
//}


#endregion



#region Menu Driven
namespace DotnetAssessment
{
    class Program
    {
        static IPolicyServiceRepository policyServiceRepository = new PolicyServiceRepository();

        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1.Get All Policies");
                Console.WriteLine("2.Create Policy");
                Console.WriteLine("3.Get Policy by ID");
                Console.WriteLine("4.Update Policy");
                Console.WriteLine("5.Delete Policy");
                Console.WriteLine("6.Exit");
                Console.Write("Enter: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            GetAllPolicies();
                            break;
                        case 2:
                            CreatePolicy();
                            break;
                        case 3:
                            GetPolicyById();
                            break;
                        case 4:
                            UpdatePolicy();
                            break;
                        case 5:
                            DeletePolicy();
                            break;
                        case 6:
                            Console.WriteLine("Exiting.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }

                Console.WriteLine("\nPress key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void GetAllPolicies()
        {
            List<Policies> policies = policyServiceRepository.GetAllPolicies();
            DisplayPolicies(policies);
        }

        static void CreatePolicy()
        {
            Console.WriteLine("Enter details:");
            Policies newPolicy = GetUserInputForNewPolicy();
            bool isPolicyCreated = policyServiceRepository.CreatePolicy(newPolicy);

            if (isPolicyCreated)
            {
                Console.WriteLine("New Policy Created");
                DisplayPolicies(new List<Policies> { newPolicy });
            }
            else
            {
                Console.WriteLine("Failed.");
            }
        }

        static Policies GetUserInputForNewPolicy()
        {
            Console.Write("Policy Number: ");
            string policyNumber = Console.ReadLine();

            Console.Write("Policy Type: ");
            string policyType = Console.ReadLine();

            Console.Write("Coverage Amount: ");
            decimal coverageAmount;
            while (!decimal.TryParse(Console.ReadLine(), out coverageAmount))
            {
                Console.WriteLine("Invalid input.");
            }

            Console.Write("Premium Amount: ");
            decimal premiumAmount;
            while (!decimal.TryParse(Console.ReadLine(), out premiumAmount))
            {
                Console.WriteLine("Invalid input.");
            }

            Console.Write("Start Date (yyyy-mm-dd): ");
            DateTime startDate;
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Invalid input.");
            }

            Console.Write("End Date (yyyy-mm-dd): ");
            DateTime endDate;
            while (!DateTime.TryParse(Console.ReadLine(), out endDate))
            {
                Console.WriteLine("Invalid input");
            }

            return new Policies
            {
                policy_number = policyNumber,
                policy_type = policyType,
                coverage_amount = coverageAmount,
                premium_amount = premiumAmount,
                start_date = startDate,
                end_date = endDate
            };
        }

        static void GetPolicyById()
        {
            Console.Write("Enter Policy ID: ");
            if (int.TryParse(Console.ReadLine(), out int policyId))
            {
                try
                {
                    Policies policy = policyServiceRepository.GetPolicy(policyId);

                    if (policy != null)
                    {
                        DisplayPolicies(new List<Policies> { policy });
                    }

                }
                catch (PolicyNumberNotFoundException ex)
                {
                    Console.WriteLine($"Policy not found with ID: {ex.PolicyNumber}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input id");
            }
        }

        static void UpdatePolicy()
        {
            Console.Write("Enter Policy ID: ");
            if (int.TryParse(Console.ReadLine(), out int policyId))
            {
                try
                {
                    Policies existingPolicy = policyServiceRepository.GetPolicy(policyId);

                    if (existingPolicy != null)
                    {
                        Policies updatedPolicy = GetInputForUpdatedPolicy(existingPolicy);
                        bool isPolicyUpdated = policyServiceRepository.UpdatePolicy(updatedPolicy);

                        if (isPolicyUpdated)
                        {
                            Console.WriteLine("Updated.");
                        }
                        else
                        {
                            Console.WriteLine("Failed.");
                        }
                    }

                }
                catch (PolicyNumberNotFoundException ex)
                {
                    Console.WriteLine($"Policy not found with ID: {ex.PolicyNumber}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input id");
            }
        }

        static void DeletePolicy()
        {
            Console.Write("Enter Policy ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int policyId))
            {
                try
                {
                    bool isPolicyDeleted = policyServiceRepository.DeletePolicy(policyId);

                    if (isPolicyDeleted)
                    {
                        Console.WriteLine("Policy deleted.");
                    }

                }
                catch (PolicyNumberNotFoundException ex)
                {
                    Console.WriteLine($"Policy not found with ID: {ex.PolicyNumber}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input id");
            }
        }

        static void DisplayPolicies(List<Policies> policies)
        {
            foreach (var policy in policies)
            {
                Console.WriteLine(policy.ToString());
            }
        }

        static Policies GetInputForUpdatedPolicy(Policies existingPolicy)
        {
            Console.WriteLine("Enter updated details for the policy:");

            Console.Write($"Policy Number ({existingPolicy.policy_number}): ");
            string policyNumber = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(policyNumber))
            {
                policyNumber = existingPolicy.policy_number;
            }

            Console.Write($"Policy Type ({existingPolicy.policy_type}): ");
            string policyType = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(policyType))
            {
                policyType = existingPolicy.policy_type;
            }

            Console.Write($"Coverage Amount ({existingPolicy.coverage_amount}): ");
            decimal coverageAmount;
            while (!decimal.TryParse(Console.ReadLine(), out coverageAmount))
            {
                Console.WriteLine("Invalid input.t.");
            }

            Console.Write($"Premium Amount ({existingPolicy.premium_amount}): ");
            decimal premiumAmount;
            while (!decimal.TryParse(Console.ReadLine(), out premiumAmount))
            {
                Console.WriteLine("Invalid input.");
            }

            Console.Write($"Start Date ({existingPolicy.start_date:yyyy-mm-dd}): ");
            DateTime startDate;
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Invalid input.");
            }

            Console.Write($"End Date ({existingPolicy.end_date:yyyy-mm-dd}): ");
            DateTime endDate;
            while (!DateTime.TryParse(Console.ReadLine(), out endDate))
            {
                Console.WriteLine("Invalid input.");
            }

            return new Policies
            {
                policy_id = existingPolicy.policy_id,
                policy_number = policyNumber,
                policy_type = policyType,
                coverage_amount = coverageAmount,
                premium_amount = premiumAmount,
                start_date = startDate,
                end_date = endDate
            };
        }
    }
}



#endregion

