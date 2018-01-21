using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    class ActionProvider
    {
        private State GoalState { get; }

        private IActionRepository ActionRepository;

        public ActionProvider(State goalState)
        {
            GoalState = goalState;
            ActionRepository = new ActionRepository(goalState);
        }

        public List<Action> selectAvailableAction(State currentState)
        {
            List<Action> availableActions = new List<Action>();

            foreach (KeyValuePair<Predicate<State>, List<Action>> entry in ActionRepository.availableActions)
            {
                if (entry.Key(currentState))
                {
                    availableActions = availableActions.Union(entry.Value).ToList();
                }
            }
            return availableActions;
        }
        
    }
}
