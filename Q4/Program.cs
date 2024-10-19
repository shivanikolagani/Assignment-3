using System.Security.Cryptography.X509Certificates;

namespace Q4
{
    interface IBroadbandPlan
    {
        int GetBroadPlanAmount();
    }
    class Black : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private const int PlanAmount = 3000;
        private int _discountPercentage;

        public Black(bool isSubscriptionValid, int discountPercentage)
        {
            _isSubscriptionValid = isSubscriptionValid;
            _discountPercentage = discountPercentage;
        }
        public int GetBroadPlanAmount()
        {
            if (_isSubscriptionValid)
            {
                return PlanAmount - (PlanAmount * _discountPercentage / 100);
            }
            return PlanAmount;
        }
    }


    class Gold : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 1500;

        public Gold(bool isSubscriptionValid, int discountPercentage)
        {
            _isSubscriptionValid = isSubscriptionValid;
            _discountPercentage = discountPercentage;
        }
        public int GetBroadPlanAmount()
        {
            if (_isSubscriptionValid)
            {
                return PlanAmount - (PlanAmount * _discountPercentage / 100);
            }
            return PlanAmount;
        }

    }
    class SubscribePlan
    {
        private readonly IList<IBroadbandPlan> _broadbandPlans;
        public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
        {
            _broadbandPlans = broadbandPlans;
        }
        public IList<Tuple<string, int>> GetSubscriptionPlan()
        {
            var result = new List<Tuple<string, int>>();
            foreach(var plan in _broadbandPlans)
            {
                var planType = plan.GetType().Name;
                var amount = plan.GetBroadPlanAmount();
                result.Add(Tuple.Create(planType, amount));
            }
            return result;
        }
    }

    
    public class Program
    {
        static void Main(string[] args)
        {
            var plans = new List<IBroadbandPlan>
            {
                new Black(true, 50),
                new Black(false, 10),
                new Gold (true, 30),
                new Black(true, 20),
                new Gold(true, 20),
            };
            var subscriptionPlans = new SubscribePlan(plans);
            var result = subscriptionPlans.GetSubscriptionPlan();
            foreach (var plan in result)
            {
                Console.WriteLine($"{plan.Item1},{plan.Item2}");
            }
        }
    }
}
