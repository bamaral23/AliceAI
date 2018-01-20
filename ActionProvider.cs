using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    class ActionProvider
    {

        public ActionProvider(State GoalState)
        {
            this.GoalState = GoalState;
            register();
        }

        private State GoalState { get; }

        private Dictionary<Predicate<State>, Action> availableActions = new Dictionary<Predicate<State>, Action>();


        public List<Action> selectAvailableAction(State currentState)
        {
            List<Action> availableActions = new List<Action>();

            foreach (KeyValuePair<Predicate<State>, Action> entry in this.availableActions){
                if (entry.Key(currentState))
                {
                    availableActions.Add(entry.Value);
                }
            }
            return availableActions;
        }

        private void register()
        {
            availableActions.Add(Not(IsStateFull()), new Action("Add 2", (state) => new State(state.getStateContext() + "2")));
            availableActions.Add(Not(IsStateFull()), new Action("Add 3", (state) => new State(state.getStateContext() + "3")));
        }


        private Predicate<State> IsStateFull()
        {
            return currentState => (currentState.getStateContext().Length >= this.GoalState.getStateContext().Length);
        }

        public static Predicate<State> Not(Predicate<State> predicate)
        {
            return x => !predicate(x);
        }
    }
}
