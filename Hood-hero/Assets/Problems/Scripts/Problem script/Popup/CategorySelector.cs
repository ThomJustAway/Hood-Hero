using Assets.Scripts.Problem_script;
using Problem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class CategorySelector : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Color backgroundColor = Color.blue;
    [SerializeField] private Color startingColor;
    [SerializeField] private Color buttonStartingColor;
    [SerializeField] private float colorFadeSpeed = 1.0f;
    private bool isActivated = false;

    private OneServiceApp app;

    #region for value referencing

    #region category
    [Header("Logo for Main Category (if exist)")]
    [SerializeField] private Image logo;
    private OneServiceProblemSelectorScriptableObject targetProblem;
    private GameObject[] subCategoryButtons;
    #endregion

    #region subcategory
    private bool isSubCategory;
    private Problem.SubProblem targetSubProblem;
    #endregion

    #endregion

    // Start is called before the first frame update

    private void Update()
    {
        switch (isSubCategory)
        {
            case true:
                SubCategoryBehaviour();
                break;
            case false:
                MainCategoryBehaviour();
                break;
            default:
                MainCategoryBehaviour();
                break;
        }
    }

    private void SubCategoryBehaviour()
    {
        if(app.selectedSubCategory != targetSubProblem)
        {
            DisabledUI();
        }
    }

    private void MainCategoryBehaviour()
    {
        //print(app.selectedMainCategory.ToString()); 
        if(app.selectedMainCategory != targetProblem.mainCategory)
        {
            //disabled the button if another category is selected
            DisabledUI();
            ChangeActiveForAllSubCatButtons(false); //set everything to false
        }
    }

    private void ChangeActiveForAllSubCatButtons(bool value)
    {
        foreach(var button in subCategoryButtons)
        {
            button.SetActive(value);
        }
    }

    #region Setting up methods
    public void Init(OneServiceProblemSelectorScriptableObject targetProblem , 
        bool isSubCat = false , 
        Problem.SubProblem subCatSelected = Problem.SubProblem.None ,
        GameObject[] subCategoryButtons = null
        )
    { // for initializing the main problem
        this.targetProblem = targetProblem;
        if (isSubCat)
        { // is sub category
            text.text = convertEnumToString(subCatSelected);
            targetSubProblem = subCatSelected;
            gameObject.SetActive(false);
        }
        else
        { // is main category
            text.text = targetProblem.MainproblemText;
            logo.sprite = targetProblem.picture;
        }

        app = OneServiceApp.instance;
        isSubCategory = isSubCat;
        this.subCategoryButtons = subCategoryButtons;
    }
    private string convertEnumToString(Problem.SubProblem subProblem)
    {
        string subProblemName = Enum.GetName(typeof(Problem.SubProblem), subProblem);
        return RetrieveSentenceFromConatenation(subProblemName);
    }

    private string RetrieveSentenceFromConatenation(string  conatName)
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
    #endregion

    //for both button
    //public void ToggleBackgroundColor()
    //{
    //    float t = 0;
    //    isActivated = !isActivated;
    //    if (isActivated == true)
    //    {
    //        t = ActivateUI(t);
    //    }
    //    else if (isActivated == false)
    //    {
    //        t = DisabledUI(t);

    //    }
    //}

    private void ChangeMainCategoryInOneServiceApp()
    {
        app.ChangeMainCategory(targetProblem.mainCategory);
        app.ChangeSubCategory(SubProblem.None);
    }

    private void ChangeSubCategoryInOneServiceApp()
    {
        app.ChangeSubCategory(targetSubProblem);
    }

    #region UI behaviour
    private void DisabledUI()
    {
        if (isSubCategory == true)
        {
            // add the t here but I wont add it in for now
            background.color = buttonStartingColor; /*Color.Lerp(backgroundColor, buttonStartingColor, t += Time.deltaTime);*/
            text.color = Color.black; /*Color.Lerp(Color.white, Color.black, t += Time.deltaTime);*/
        }
        else
        {
            background.color = startingColor; /*Color.Lerp(backgroundColor, startingColor, t += Time.deltaTime);*/
            text.color = Color.black; /*Color.Lerp(Color.white, Color.black, t += Time.deltaTime);*/
        }

    }

    public void ActivateUI()
    {
        //float t = 0f; //ian change this if u want
        if (isSubCategory == true)
        {
            background.color = backgroundColor; /*Color.Lerp(buttonStartingColor, backgroundColor, t += Time.deltaTime);*/
            text.color = Color.white; /*Color.Lerp(Color.black, Color.white, t += Time.deltaTime);*/
            ChangeSubCategoryInOneServiceApp();
        }
        else
        {
            print("hello world");
            background.color = backgroundColor; /*Color.Lerp(startingColor, backgroundColor, t += Time.deltaTime);*/
            text.color = Color.white; /*Color.Lerp(Color.black, Color.white, t += Time.deltaTime);*/
            ChangeMainCategoryInOneServiceApp();
            ChangeActiveForAllSubCatButtons(true);
        }

    }
    #endregion
}