using System;
using System.Collections;
using System.Collections.Generic;
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
        }

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
            foreach (var action in list)
            {
                action.Invoke();
            }
        }

        public void ResetEventManager()
        {
            dictionaryOfEvents.Clear();
            Init();
        }

    }

    public enum TypeOfEvent
    {//add the relevant events here
        ScoreEvent,
        MistakeEvent,
        LoseEvent,
        WinEvent,
    }
}
