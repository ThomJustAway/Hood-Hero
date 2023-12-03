using Assets.Scripts.Problem_script;
using Problem;
using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Problems.Scripts.Problem_script.Popup.buttons
{
    public abstract class ButtonAbstractClass : MonoBehaviour
    {
        [Header("UI component")]
        [SerializeField] private Image background;
        [SerializeField] protected TextMeshProUGUI text;
        [SerializeField] private Color ActivatedbackgroundColor = Color.blue;
        [SerializeField] private Color UnactivatedbuttonColor;
        protected OneServiceApp app;


        private void Awake()
        {
            app = OneServiceApp.instance;
        }

        private void Update()
        {
            if (ConditionForDisabled())
            {
                DisableUI();
            }
        }
 

        protected abstract void OnClick();


        protected abstract bool ConditionForDisabled();


        private void DisableUI()
        {
            background.color = UnactivatedbuttonColor; 
            text.color = Color.black; 
        }

        public void ActivateUI()
        {
            background.color = ActivatedbackgroundColor; 
            text.color = Color.white;
            OnClick();
        }

    }
}