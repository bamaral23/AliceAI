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
            registerActions();
        }

        private State GoalState { get; }

        private Dictionary<Predicate<State>, List<Action>> availableActions = new Dictionary<Predicate<State>, List<Action>>();


        public List<Action> selectAvailableAction(State currentState)
        {
            List<Action> availableActions = new List<Action>();

            foreach (KeyValuePair<Predicate<State>, List<Action>> entry in this.availableActions){
                if (entry.Key(currentState))
                {
                    availableActions = availableActions.Union(entry.Value).ToList();
                }
            }
            return availableActions;
        }

        private void registerActions()
        {
            register(PredicateUtils.Not(PredicateUtils.IsFieldSelected()), generateFieldSelectionActions(FieldLoader.loadFields()));
            register(PredicateUtils.And(PredicateUtils.IsFieldSelected(), PredicateUtils.Not(PredicateUtils.IsStateFull(GoalState))), new Action("Add 2", (state) => new State(state.stateContext + "2", state.selectedField)));
            register(PredicateUtils.And(PredicateUtils.IsFieldSelected(), PredicateUtils.Not(PredicateUtils.IsStateFull(GoalState))), new Action("Add 3", (state) => new State(state.stateContext + "3", state.selectedField)));
        }

        private List<Action> generateFieldSelectionActions(List<Field> fields)
        {
            List<Action> generatedActions = new List<Action>();
            foreach (Field field in fields)
            {
                generatedActions.Add(new Action("Select Field", (state) => new State(field)));
            }
            return generatedActions;
        }

        private void register(Predicate<State> predicate, Action action)
        {
            List<Action> actionList = new List<Action>();
            actionList.Add(action);
            this.availableActions.Add(predicate, actionList);
        }

        private void register(Predicate<State> predicate, List<Action> action)
        {
            this.availableActions.Add(predicate, action);
        }

    }
}
