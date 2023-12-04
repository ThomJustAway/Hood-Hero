using Assets.Scripts.Problem_script;
using Problem;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Problems.Scripts.Problem_script.Popup.buttons
{
    public class MainCategoryButton : ButtonAbstractClass
    {
        [Header("Logo")]
        [SerializeField] private Image logo;

        private MainProblem problemAssigned;
        public void Init(OneServiceProblemSelectorScriptableObject problem )
        {
            problemAssigned = problem.mainCategory;
            logo.sprite = problem.picture;
            text.text = problem.MainproblemText;
        }

        protected override bool ConditionForDisabled()
        {
            if(app.selectedMainCategory != problemAssigned)
            {//if the selected main cat is not this problem deactivate it
                return true;
            }
            return false;
        }

        protected override void OnClick()
        {
            app.ChangeMainCategory(problemAssigned);
        }


    }
}