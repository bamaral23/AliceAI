using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    class ActionProvider
    {

        public ActionProvider(State GoalState) => this.GoalState = GoalState;

        public State GoalState { get; }

        public List<Action> selectAvailableAction(State currentState)
        {
            List<Action> availableActions = new List<Action>();
            if (currentState.getStateContext().Length < this.GoalState.getStateContext().Length)
            {
                availableActions.Add(new Action("Add 2", (state) => new State(state.getStateContext() + "2")));
                availableActions.Add(new Action("Add 3", (state) => new State(state.getStateContext() + "3")));
            }
            return availableActions;
        }

    }
}
