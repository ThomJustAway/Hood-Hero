using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonMove : MonoBehaviour
{
    public Button Forward;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<GameObject>();
        Button btn = Forward.GetComponent<Button>();
        btn.onClick.AddListener(ForwardOnClick);
    }
    public void ForwardOnClick()
    {

        //Vector2 move = new Vector2(5,0);
        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
