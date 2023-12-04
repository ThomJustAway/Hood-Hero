using System.Collections;
using UnityEngine;

namespace Assets.Problems.Scripts.Problem_script.Popup.buttons
{
    public class DetailCategoryButton : ButtonAbstractClass
    {
        private DetailOfTheProblem detailAssigned;
        public void Init(DetailOfTheProblem detail)
        {
            detailAssigned = detail;
            text.text = detail.detail.Trim();

        }

        protected override bool ConditionForDisabled()
        {
            //check the string if the button requires to be disabled
            return app.selectedDetail.detail != detailAssigned.detail;
        }

        protected override void OnClick()
        {
            app.ChangeDetail(detailAssigned);
        }
    }
}