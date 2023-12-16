using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAssessment.Entity
{
    public enum UserRole { admin,agent,client}
    public class Users
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public UserRole role { get; set; }

        public override string ToString()
        {
            return $"User id:{user_id}\tUserName:{username}\tPassword:{password}\trole:{role}";
        }


    }
}
