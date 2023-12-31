using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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

        #region timing event

        private List<Action<int>> timingEvent = new List<Action<int>>(); //for time

        //what is pass in the int is the amount of time that has pass after the game starts
        public void AddTimingListener(Action<int> callback)
        {
            timingEvent.Add(callback);
        }

        public void RemoveTimingListener(Action<int> callback)
        {
            timingEvent.Remove(callback);
        }

        public void AlertTimingListener(int timePass)
        {
            var copyList = new List<Action<int>>(timingEvent) ;

            foreach (var action in copyList)
            {
                
                action.Invoke(timePass);
            }
        }

        public void RemoveAllTimingListener()
        {
            timingEvent = new List<Action<int>>();
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

        //void OnGUI()
        //{
        //    if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
        //    {
        //        print("You clicked the button!");
        //    }
        //}

    }

    public enum TypeOfEvent
    {//add the relevant events here
        //special event here!
        MistakeEvent,
        LoseEvent,
        WinEvent,
        GameEnd,

        //dialog
        DialogEndEvent,
        //walking
        walking
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(EventManager))]
    public class EventManagerInspector : Editor
    {
        private EventManager manager;
        private void OnEnable()
        {
            manager = serializedObject.targetObject as EventManager;
        }

        public override void OnInspectorGUI()
        {
            GUILayout.Label("only use during runtime");
            if(GUILayout.Button("Win event"))
            {
                manager.AlertListeners(TypeOfEvent.WinEvent);
            }
            if (GUILayout.Button("Lose event"))
            {
                manager.AlertListeners(TypeOfEvent.LoseEvent);
            }
            if (GUILayout.Button("Score event"))
            {
                manager.AlertScoringListener(null);
            }
            if (GUILayout.Button("mistake event"))
            {
                manager.AlertListeners(TypeOfEvent.MistakeEvent);
            }
        }

        
    }
#endif

}
