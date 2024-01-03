using pattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMusicPlayer : MonoBehaviour
{
    public void playSteppingSound()
    {
        EventManager.instance.AlertListeners(TypeOfEvent.walking);
    }
}
