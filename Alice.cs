using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    class Alice
    {
        public List<Action> actionList { get; } = new List<Action>();

        private State GoalState;

        private ActionProvider ActionProvider;

        public Alice(State GoalState)
        {
            this.GoalState = GoalState;
            ActionProvider = new ActionProvider(GoalState);
        }

        public bool learn(State currentState)
        {
            if (isGoalState(currentState))
            {
                return true;
            }
            bool isSuccess = false;
            List<Action> availableActions = ActionProvider.selectAvailableAction(currentState);
            foreach (Action action in availableActions)
            {
                State newCurrentState = action.Apply(currentState);
                isSuccess = learn(newCurrentState);
                if (isSuccess)
                {
                    actionList.Insert(0, action);
                    return true;
                }
            }
            return false;

        }

        private bool isGoalState(State currentState)
        {
            return GoalState.Equals(currentState);
        }
    }
}
