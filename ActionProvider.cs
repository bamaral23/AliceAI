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
            availableActions.Add(Not(IsFieldSelected()), new Action("Select Field", (state) => new State(new Field("23"))));
            availableActions.Add(And(IsFieldSelected(),Not(IsStateFull())), new Action("Add 2", (state) => new State(state.stateContext + "2", state.selectedField)));
            availableActions.Add(And(IsFieldSelected(), Not(IsStateFull())), new Action("Add 3", (state) => new State(state.stateContext + "3", state.selectedField)));
        }


        private Predicate<State> IsFieldSelected()
        {
            return currentState => currentState.selectedField != null;
        }

        private Predicate<State> IsStateFull()
        {
            return currentState => (currentState.stateContext.Length >= this.GoalState.stateContext.Length);
        }

        public static Predicate<State> Not(Predicate<State> predicate)
        {
            return x => !predicate(x);
        }

        public static Predicate<State> And(Predicate<State> predicate1, Predicate<State> predicate2)
        {
            return x => predicate1(x) && predicate2(x);
        }

        public static Predicate<State> Or(Predicate<State> predicate1, Predicate<State> predicate2)
        {
            return x => predicate1(x) || predicate2(x);
        }
    }
}
