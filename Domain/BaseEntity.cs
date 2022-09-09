using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEntity
    {
        public int Id { get; private set; }

        protected static void CheckRule(IBusinessRule rule)
        {
            if(rule.IsBroken())
            {
                throw new BusinessRuleException(rule);
            }
        }
    }
}
