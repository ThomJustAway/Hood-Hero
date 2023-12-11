using UnityEngine;

[System.Serializable]
public class Message
{
    public string name;
    [TextArea(3,5)]
    public string message;
    public Sprite sprite;
}

