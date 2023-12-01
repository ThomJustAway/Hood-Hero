using Assets.Problems.Scripts.Problem_script.Popup.buttons;
using Assets.Scripts;
using Assets.Scripts.Problem_script;
using Problem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class OneServiceApp : MonoBehaviour
{
    public static OneServiceApp instance;
    [Header("problems")]
    [SerializeField] private OneServiceProblemSelectorScriptableObject[] avaliableProblems;

    #region container
    [Header("Targeted container")]
    [SerializeField] private GameObject mainCategoryContainer;
    [SerializeField] private GameObject subCategoryContainer;
    #endregion

    #region prefabs
    [Header("prefabs")]
    [SerializeField] private MainCategoryButton mainCategoryPrefab;
    [SerializeField] private SubCategoryButton subCategoryPrefab;
    List<GameObject> subCatsButtons = new List<GameObject>();

    #endregion

    #region selected choice
    public MainProblem selectedMainCategory { get; private set; }
    public SubProblem selectedSubCategory { get; private set; }

    [Header("Referencing gameobject in game scene")]
    [SerializeField] private GameObject SubmitCaseButton;
    [SerializeField] private GameObject parent;
    #endregion


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            ResetValues();
            Init();
        }
        else
        {
            print("cant have more than one instance of one service app");
            Destroy(instance);
        }
    }

    private void Init()
    {
        foreach(var problem in avaliableProblems)
        {
            //setting up the main category

            foreach(var subCategory in problem.subProblems)
            {
                GameObject subcat = Instantiate(subCategoryPrefab.gameObject, subCategoryContainer.transform);
                subcat.GetComponent<SubCategoryButton>().Init(subCategory);
                subCatsButtons.Add(subcat);
            }
            GameObject mainCat = Instantiate(mainCategoryPrefab.gameObject, mainCategoryContainer.transform);
            mainCat.GetComponent<MainCategoryButton>().Init(problem);

        }
    }

    private void Update()
    {
        CheckIfConditionsForCorrect();
    }

    private void CheckIfConditionsForCorrect()
    {
        if(selectedMainCategory != MainProblem.None && 
            selectedSubCategory != SubProblem.None)
        {
            SubmitCaseButton.SetActive(true);
        }
        else
        {
            SubmitCaseButton.SetActive(false);
        }
    }

    //called in the close button event caller

    #region app related
    public void CloseApp()
    {
        ResetValues();
        var buttons = subCategoryContainer.GetComponentsInChildren<Transform>().Where(value =>
        {
            return value != subCategoryContainer.transform &&
            transform.name == "sub category button(Clone)";
        });
        foreach(var button in buttons)
        {
            print(button);
            button.gameObject.SetActive(false);
        }
        parent.SetActive(false);
        
    }

    public void SubmitCase()
    {
        var ProblemFound = ProblemFinder.Instance.selectedProblem;
        if(ProblemFound.MainProblem == selectedMainCategory &&
            ProblemFound.SubProblem == selectedSubCategory
            )
        {//if the player selected the problem correctly
            ProblemFound.IsSolve();
        }
        else
        {
            //send error mistake
        }
        CloseApp();
    }
    private void ResetValues()
    {
        selectedMainCategory = MainProblem.None;
        selectedSubCategory = SubProblem.None;
    }
    #endregion

    #region changing value
    public void ChangeMainCategory(MainProblem mainCategory)
    {
        selectedMainCategory = mainCategory;
        foreach(var problem in avaliableProblems)
        {
            if(problem.mainCategory == mainCategory)
            {
                SetSubProblemButton(problem);
                return;
            }
        }
        selectedSubCategory = SubProblem.None;
    }

    private void SetSubProblemButton(OneServiceProblemSelectorScriptableObject problem)
    {
        foreach (var subCatButton in subCatsButtons)
        {
            var component = subCatButton.GetComponent<SubCategoryButton>();
            if (problem.subProblems.Contains(component.subProblemAssign))
            {
                subCatButton.gameObject.SetActive(true);
            }
            else
            {
                subCatButton.gameObject.SetActive(false);
            }
        }
    }

    public void ChangeSubCategory(SubProblem subCategory)
    {
        selectedSubCategory = subCategory;
    }
    #endregion
}
