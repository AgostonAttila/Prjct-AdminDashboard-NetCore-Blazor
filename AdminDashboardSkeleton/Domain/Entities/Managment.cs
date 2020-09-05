using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Management
    {
        //[Key]
        public string Name { get; set; }
        public string FundISINNumberString { get; set; }
        //[NotMapped]
        public HashSet<string> FundISINNumberHashSet
        {
            get;// { return this.FundISINNumberString.Split(';').Distinct().ToHashSet(); }
            set;//{ }
        }
    }
}
