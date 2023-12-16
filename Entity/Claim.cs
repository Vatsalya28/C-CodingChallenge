using System;

namespace DotnetAssessment.Entity
{
    public enum ClaimStatus
    { Pending,Approved,Rejected}
    public class Claim
    {
         int claimId;
         string claimNumber;
         DateTime dateFiled;
        double claimAmount;
        ClaimStatus status;
        Policies policy; 
        Client client;
        public Claim(int claimId, string claimNumber, DateTime dateFiled, double claimAmount, ClaimStatus status, Policies policy, Client client)
        {
            this.ClaimId = claimId;
            this.ClaimNumber = claimNumber;
            this.DateFiled = dateFiled;
            this.ClaimAmount = claimAmount;
            this.Status = status;
            this.Policy = policy;
            this.Client = client;
        }
        public int ClaimId
        {
            get { return claimId; }
            set { claimId = value; }
        }

        public string ClaimNumber
        {
            get { return claimNumber; }
            set { claimNumber = value; }
        }

        public DateTime DateFiled
        {
            get { return dateFiled; }
            set { dateFiled = value; }
        }

        public double ClaimAmount
        {
            get { return claimAmount; }
            set { claimAmount = value; }
        }

        public ClaimStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public Policies Policy
        {
            get { return policy; }
            set { policy = value; }
        }

        public Client Client
        {
            get { return client; }
            set { client = value; }
        }
        public override string ToString()
        {
            return $"Claim ID: {ClaimId}\tClaim Number: {ClaimNumber}\tDate: {DateFiled}\tClaim Amount: {ClaimAmount}\tStatus: {Status}\tPolicy: {Policy}\tClient: {Client}";
        }
    }

    
}
