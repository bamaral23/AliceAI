using AliceAI.Fields.FieldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AliceAI.PredicateUtils;

namespace AliceAI
{
    class ActionRepository : IActionRepository
    {
        public ActionRepository(State GoalState) : base(GoalState)
        {
        }

        protected override void registerActions(State GoalState)
        {
            {
                register(Not(IsFieldSelected()), generateFieldSelectionActions(FieldLoader.loadFields()));
                register(And(IsFieldSelected(), IsFieldFormat(FieldFormat.String), IsGoalLesser(GoalState), IsContextGreaterThanZero()), generateSplitStringActions(GoalState));
                register(And(IsFieldSelected(), Not(IsStateFull(GoalState))), new Action("Add 2", (state) => new State(state.stateContext + "2", state.selectedField)));
                register(And(IsFieldSelected(), Not(IsStateFull(GoalState))), new Action("Add 3", (state) => new State(state.stateContext + "3", state.selectedField)));
            }
        }

        private List<Action> generateSplitStringActions(State goalState)
        {
            List<Action> response = new List<Action>();
            response.Add(new Action("remove First", (state) => new State(state.stateContext.Substring(1), state.selectedField)));
            response.Add(new Action("remove Last", (state) => new State(state.stateContext.Substring(0, state.stateContext.Length - 1), state.selectedField)));
            return response;
        }

        //private List<Action> generateSplitStringActions(State goalState)
        //{
        //    List<Action> response = new List<Action>();
        //    for (int i = 0; i < goalState.stateContext.Length; i++)
        //    {
        //        response.Add(new Action("", (state) => substringAction(state, goalState, i)));
        //    }
        //    return response;
        //}

        //private State substringAction(State current, State goal, int i)
        //{
        //    int currentLength = current.stateContext.Length;
        //    int goalLength = goal.stateContext.Length;
        //    String newStateContext = current.stateContext;
        //    if (i + goalLength <= currentLength)
        //    {
        //        newStateContext = current.stateContext.Substring(i, goalLength);
        //    }
        //    return new State(newStateContext, current.selectedField);
        //}

        private List<Action> generateFieldSelectionActions(List<Field> fields)
        {
            List<Action> generatedActions = new List<Action>();
            foreach (Field field in fields)
            {
                if (field is SingleValueField)
                {
                    generatedActions.Add(new Action("Select Field " + field.Name, (state) => new State((SingleValueField)field)));
                }
                else if (field is MultiValueField)
                {
                    MultiValueField mutliField = (MultiValueField)field;
                    for (int i = 0; i < mutliField.AvailabletValue.Length; i++)
                    {
                        int j = i;
                        generatedActions.Add(new Action("Select Field " + field.Name + " with option number " + i, (state) => new State((MultiValueField)field, j)));
                    }
                }
            }
            return generatedActions;
        }
    }
}
