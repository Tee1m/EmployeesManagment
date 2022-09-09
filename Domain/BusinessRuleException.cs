using System;

namespace Domain
{
    public class BusinessRuleException : Exception
    {
        public IBusinessRule BusinessRule { get; private set; }
        public string Details { get; private set; }

        public BusinessRuleException(IBusinessRule brokenRule) : base(brokenRule.Message)
        {
            this.BusinessRule = brokenRule;
            this.Details = brokenRule.Message;
        }
    }
}
