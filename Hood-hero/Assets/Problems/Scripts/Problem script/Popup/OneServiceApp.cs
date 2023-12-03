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
    [SerializeField] private CategorySelector mainCategoryPrefab;
    [SerializeField] private CategorySelector subCategoryPrefab;
    #endregion

    #region selected choice
    public MainProblem selectedMainCategory { get; private set; }
    public SubProblem selectedSubCategory { get; private set; }

    public void ChangeMainCategory(MainProblem mainCategory)
    {
        selectedMainCategory = mainCategory;
    }

    public void ChangeSubCategory(SubProblem subCategory)
    {
        selectedSubCategory = subCategory;
    }

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
            
            List<GameObject> subCats = new List<GameObject>();
            foreach(var subCategory in problem.subProblems)
            {
                GameObject subcat = Instantiate(subCategoryPrefab.gameObject, subCategoryContainer.transform);
                subcat.GetComponent<CategorySelector>().Init(problem , true , subCategory);
                subCats.Add(subcat);
            }
            GameObject mainCat = Instantiate(mainCategoryPrefab.gameObject, mainCategoryContainer.transform);
            mainCat.GetComponent<CategorySelector>().Init(problem,
                false,
                SubProblem.None,
                subCats.ToArray());

        }
    }



    // Update is called once per frame
    void Update()
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

    public void RetrieveInformation()
    {

    }

    
    private void ResetValues()
    {
        selectedMainCategory = MainProblem.None;
        selectedSubCategory = SubProblem.None;
    }
}
