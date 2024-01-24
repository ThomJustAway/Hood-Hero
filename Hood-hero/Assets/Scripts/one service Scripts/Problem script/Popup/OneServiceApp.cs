using Assets.Problems.Scripts.Problem_script.Popup.buttons;
using Assets.Scripts;
using Assets.Scripts.Problem_script;
using HoodHeroUI;
using pattern;
using Problem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class OneServiceApp : MonoBehaviour
{
    public static OneServiceApp instance;
    [Header("problems")]
    [SerializeField] private OneServiceProblemSelectorScriptableObject[] avaliableProblems;

    #region container
    [Header("Targeted container")]
    [SerializeField] private GameObject mainCategoryContainer;
    [SerializeField] private GameObject subCategoryContainer;
    [SerializeField] private GameObject DetailCategoryContainer;
    #endregion

    #region section
    [SerializeField] private GameObject mainProblemSection;
    [SerializeField] private GameObject subProblemSection;
    [SerializeField] private GameObject imageProblemSection;
    [SerializeField] private GameObject timingSection;
    #endregion

    #region prefabs
    [Header("prefabs")]
    [SerializeField] private MainCategoryButton mainCategoryPrefab;
    [SerializeField] private SubCategoryButton subCategoryPrefab;
    [SerializeField] private DetailCategoryButton DetailCategoryButton;
    List<GameObject> subCatsButtons = new List<GameObject>();

    #endregion

    #region values

    #region main and sub category
    public MainProblem selectedMainCategory { get; private set; }
    public SubProblem selectedSubCategory { get; private set; }
    #endregion

    #region image

    [Header("Image section details")]
    [SerializeField] private Image closeUpImage; //image component to be change later on
    [SerializeField] private Image FarShotImage;
    [SerializeField] private GameObject ImageButton;
    private bool hasTakenPhoto = false;
    #endregion

    #region extra details
    private bool HasCreatedDetailButton = false;
    public DetailOfTheProblem selectedDetail { get; private set; }

    #endregion
    [Header("Referencing gameobject in game scene")]
    [SerializeField] private GameObject SubmitCaseButton;
    [SerializeField] private GameObject parent;
    #endregion

    //[SerializeField] SliderManager mSliderManager;
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
                subcat.SetActive(false);
            }
            GameObject mainCat = Instantiate(mainCategoryPrefab.gameObject, mainCategoryContainer.transform);
            mainCat.GetComponent<MainCategoryButton>().Init(problem);

        }
    }

    private void Update()
    {
        CheckIfNeedToCreateDetailButton();
        UpdateUi();
        CheckIfConditionsForCorrect();
    }

    private void UpdateUi()
    {
        if(selectedMainCategory == MainProblem.None)
        {
            subProblemSection.SetActive(false);
        }
        else
        {
            subProblemSection.SetActive(true);
        }

        if (selectedSubCategory == SubProblem.None)//if didn't select sub cat
        {
            imageProblemSection.SetActive(false);
            timingSection.SetActive(false);
        }
        else//if got select a sub cat
        {
            imageProblemSection.SetActive(true);
            timingSection.SetActive(true);
        }
    }

    private void CheckIfNeedToCreateDetailButton()
    {
        if (!HasCreatedDetailButton)
        {//so if have not created the detail button
            try
            {
                var foundProblem = ProblemFinder.Instance.selectedProblem;
                foreach(var detail in foundProblem.Details)
                {
                    GameObject button = Instantiate(DetailCategoryButton.gameObject , DetailCategoryContainer.transform);
                    button.GetComponent<DetailCategoryButton>().Init(detail);
                    //create the button
                }
                HasCreatedDetailButton = true; //make sure to not call this function again
            }
            catch
            {
                //do nothing here 
            }
        }
    }

    private void CheckIfConditionsForCorrect()
    {
        if(selectedMainCategory != MainProblem.None && 
            selectedSubCategory != SubProblem.None &&
            hasTakenPhoto
            )
        {
            SubmitCaseButton.SetActive(true);
        }
        else
        {
            SubmitCaseButton.SetActive(false);
        }
    }

    //when the app close destroy all the detail button in the app to allow new button to come
    //this function will also make sure to call another create detail button if found again.
    private void DestroyAllDetailButton()
    {
        var detailButtons = DetailCategoryContainer.GetComponentsInChildren<DetailCategoryButton>();
        foreach(var button in detailButtons)
        {
            Destroy(button.gameObject);
        }
        HasCreatedDetailButton = false; //call back the function if all the button are destroy
        selectedDetail = new DetailOfTheProblem("" , false);
    }
    //called in the close button event caller

    #region app related
    public void CloseApp()
    {
        ResetValues(); //reset the selected value choosen
        foreach(var button in subCatsButtons)
        {
            button.gameObject.SetActive(false);
        }

        ChangingActiveOfImage(false); //for the removing all changes to the image
        DestroyAllDetailButton(); // to remove the old detail button and make new one for future use.
        parent.SetActive(false); //dont show the ui in game scene
        
    }

    //this is called when the submit button is click
    public void SubmitCase()
    {
        var ProblemFound = ProblemFinder.Instance.selectedProblem;
        if(ProblemFound.MainProblem == selectedMainCategory &&//check if the main problem is correct
            ProblemFound.SubProblem == selectedSubCategory && //check if the sub problem is correct
            hasTakenPhoto && //check if the player has taken the photo
            selectedDetail.isCorrect //check if the selectedDetail is correct
            )
        {//if the player selected the problem correctly
            //mSliderManager.CompleteTask();            
            ProblemFound.IsSolve();
        }
        else
        {
            EventManager.instance.AlertListeners(TypeOfEvent.MistakeEvent);
            if(ProblemFound.MainProblem == MainProblem.FakeProblem)
            {
                PopUpScript.instance.StartMessage(
                    "Dont report everything you see",
                    3
                    );
            }
        }
        CloseApp();
    }
    private void ResetValues()
    {
        selectedMainCategory = MainProblem.None;
        selectedSubCategory = SubProblem.None;
    }



    #endregion

    #region Image related

    public void TakePhoto()
    {
        var problemSelected = ProblemFinder.Instance.selectedProblem;
        closeUpImage.sprite = problemSelected.CloseupImage;
        FarShotImage.sprite = problemSelected.FarAwayImage;

        //show the whole aspect of the image;
        closeUpImage.preserveAspect = true;
        FarShotImage.preserveAspect = true;
        ChangingActiveOfImage(true); //show the images
    }

    private void ChangingActiveOfImage(bool value)
    {
        //if show images, dont show button, reverse is true
        ImageButton.SetActive(!value); 
        closeUpImage.gameObject.SetActive(value);
        FarShotImage.gameObject.SetActive(value);

        hasTakenPhoto = value; //show that the player has done taking the photo
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

    public void ChangeDetail(DetailOfTheProblem detail)
    {
        selectedDetail = detail;
    }

    #endregion

    public void Testing()
    {
        print("hello");
        gameObject.SetActive(true);
    }
}
