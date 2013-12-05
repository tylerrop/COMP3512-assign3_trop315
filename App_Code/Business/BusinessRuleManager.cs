using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;

namespace Content.Business
{
    /// <summary>
    /// Encapsulates the management logic for the business rules for a business object
    /// </summary>
    public class BusinessRuleManager
    {
        // collection of descriptions of all broken rules
        private Dictionary<string, SingleRule> _brokenRules = new Dictionary<string, SingleRule>();

        public BusinessRuleManager() { }

        /// <summary>
        /// Clear the rules from the internal collection
        /// </summary>
        public void Clear()
        {
            _brokenRules.Clear();
        }

        /// <summary>
        /// The main method for the business rule manager. We provide a name and description for
        /// the rule and a boolean expression of the rule.
        /// </summary>
        public void Assert(string name, string description, bool isBroken)
        {
            if (isBroken)
            {
                if (! _brokenRules.ContainsKey(name))
                    _brokenRules.Add(name, new SingleRule(name, description));
            }
            else
                _brokenRules.Remove(name);
        }

        /// <summary>
        /// Are there any broken rules?
        /// </summary>
        public bool AreNoBrokenRules
        {
            get
            {
                if (_brokenRules.Count > 0)
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// Return a deep copy of the internal collection
        /// </summary>
        public List<string> BrokenRules
        {
            get
            {
                List<string> rules = new List<string>();
                foreach (KeyValuePair<string, SingleRule> pair in _brokenRules)
                {
                    SingleRule rule = pair.Value;
                    rules.Add(rule.Description);
                }
                return rules;
            }
        }

        /// <summary>
        /// Return any broken rules as a list of items separated by line breaks
        /// </summary>
        public override string ToString()
        {
            string s = "";
            foreach (KeyValuePair<string, SingleRule> pair in _brokenRules)
            {
                SingleRule rule = pair.Value;
                s += rule.Description + "<br>";
            }
            return s;
        }
    }
}