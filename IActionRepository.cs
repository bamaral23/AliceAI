using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    abstract class IActionRepository
    {
        public Dictionary<Predicate<State>, List<Action>> availableActions { get; } = new Dictionary<Predicate<State>, List<Action>>();

        public IActionRepository(State GoalState)
        {
            registerActions(GoalState);
        }

        protected abstract void registerActions(State GoalState);
        
        protected void register(Predicate<State> predicate, Action action)
        {
            List<Action> actionList = new List<Action>();
            actionList.Add(action);
            this.availableActions.Add(predicate, actionList);
        }

        protected void register(Predicate<State> predicate, List<Action> action)
        {
            this.availableActions.Add(predicate, action);
        }
    }
}
