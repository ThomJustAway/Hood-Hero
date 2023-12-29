using System.Collections;
using UnityEngine;

namespace Assets.Scripts.one_service_Scripts.pattern
{
    public class PrefabManager : MonoBehaviour
    {
        public static PrefabManager instance;
        public GameObject clockPrefab;
        public GameObject speechBubblePrefab;
        // Use this for initialization

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                print("cant have more than one instance");
                Destroy(gameObject);
            }
        }
    }
}