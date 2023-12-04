using Problem;
using System;
using System.Collections;
using System.Text;
using UnityEngine;

namespace Assets.Problems.Scripts.Problem_script.Popup.buttons
{
    public class SubCategoryButton : ButtonAbstractClass
    {
        public SubProblem subProblemAssign { get; private set; }

        public void Init(SubProblem subProblem)
        {
            subProblemAssign = subProblem;
            text.text = ConvertEnumToString(subProblemAssign);
        }

        private string ConvertEnumToString(Problem.SubProblem subProblem)
        {
            string subProblemName = Enum.GetName(typeof(Problem.SubProblem), subProblem);
            return RetrieveSentenceFromConatenation(subProblemName);
        }

        private string RetrieveSentenceFromConatenation(string conatName)
        {
            StringBuilder result = new StringBuilder();
            bool startingCap = false;
            foreach (char c in conatName)
            {
                if (char.IsUpper(c))
                {
                    if (startingCap)
                    {
                        result.Append(' ');
                    }
                    else
                    {
                        startingCap = true;
                    }

                }
                result.Append(c);
            }

            return result.ToString();
        }

        protected override bool ConditionForDisabled()
        {
            if(app.selectedSubCategory != subProblemAssign) return true;
            return false;
        }

        protected override void OnClick()
        {
            app.ChangeSubCategory(subProblemAssign);
        }
    }
}