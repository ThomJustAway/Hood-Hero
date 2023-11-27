using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem instance { get; private set; }
    private Dictionary<string, Action> listOfEvents = new Dictionary<string, Action>();
    [SerializeField] private string[] eventName;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            print("instance");
            Destroy(instance);
        }
    }

    //private void Start()
    //{
    //    for(int i = 0; i < eventName.Length; i++)
    //    {
    //        listOfEvents.Add(eventName[i], new Action<>());
    //    }
    //}
}
