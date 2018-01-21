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
                register(And(IsFieldSelected(), Not(IsStateFull(GoalState))), new Action("Add 2", (state) => new State(state.stateContext + "2", state.selectedField)));
                register(And(IsFieldSelected(), Not(IsStateFull(GoalState))), new Action("Add 3", (state) => new State(state.stateContext + "3", state.selectedField)));
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
