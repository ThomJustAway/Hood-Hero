using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace pattern
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager instance { get; private set; }
        private Dictionary<TypeOfEvent, List<Action>> dictionaryOfEvents = new Dictionary<TypeOfEvent, List<Action>>();

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                Init();
            }
            else
            {
                Destroy(instance);
            }
        }

        private void Init()
        {
            foreach(var eventName in (TypeOfEvent[])Enum.GetValues(typeof(TypeOfEvent)))
            {//create a list for each event
                dictionaryOfEvents.Add(eventName, new List<Action>());
            }
            scoreEvents = new List<Action<ProblemSelector>>();
        }

        #region scoring special event
        private List<Action<ProblemSelector>> scoreEvents; //special already listeners who need the problem selector
        public void AddScoringListener(Action<ProblemSelector> callback)
        {
            scoreEvents.Add(callback);
        }
        public void RemovingScoringListener(Action<ProblemSelector> callback)
        {
            scoreEvents.Remove(callback); //remove the callback
            print($"score listener {scoreEvents.Count}");
        }

        public void AlertScoringListener(ProblemSelector problemSolve)
        {
            var copyListeners = new List<Action<ProblemSelector>>(scoreEvents);
            foreach(var action  in copyListeners)
            {
                action.Invoke(problemSolve);
            }
        }
        
        #endregion

        public void AddListener(TypeOfEvent eventName, Action callback)
        {
            //since list is a reference type, just reference the list and add the callback
            var list = dictionaryOfEvents[eventName];
            list.Add(callback);
        }

        public void RemoveListener(TypeOfEvent eventName , Action callback) 
        {
            var list = dictionaryOfEvents[eventName];
            list.Remove(callback); //remove the callback
        }
        public void AlertListeners(TypeOfEvent eventName)
        {
            var list = dictionaryOfEvents[eventName];
            //copy the list so that if any listener is deleted in 
            //the current list of event, it will still continue
            //calling out the listeners until the function ends
            var copyList = new List<Action>(list); 
            foreach (var action in copyList)
            {
                action.Invoke();
            }
        }

        //only call this if U think u need to reset the entire event manager
        public void ResetEventManager()
        {
            dictionaryOfEvents.Clear();
            Init();
        }

    }

    public enum TypeOfEvent
    {//add the relevant events here
        MistakeEvent,
        LoseEvent,
        WinEvent,
        DialogEndEvent,
    }
}
