using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                register(PredicateUtils.Not(PredicateUtils.IsFieldSelected()), generateFieldSelectionActions(FieldLoader.loadFields()));
                register(PredicateUtils.And(PredicateUtils.IsFieldSelected(), PredicateUtils.Not(PredicateUtils.IsStateFull(GoalState))), new Action("Add 2", (state) => new State(state.stateContext + "2", state.selectedField)));
                register(PredicateUtils.And(PredicateUtils.IsFieldSelected(), PredicateUtils.Not(PredicateUtils.IsStateFull(GoalState))), new Action("Add 3", (state) => new State(state.stateContext + "3", state.selectedField)));
            }
        }

        private List<Action> generateFieldSelectionActions(List<Field> fields)
        {
            List<Action> generatedActions = new List<Action>();
            foreach (Field field in fields)
            {
                generatedActions.Add(new Action("Select Field " + field.Name, (state) => new State(field)));
            }
            return generatedActions;
        }

    }
}
