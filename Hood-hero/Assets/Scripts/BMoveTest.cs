using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMoveTest : MonoBehaviour
{
    public void MoveUp()
    {
        transform.Translate(0f, 0f, 1f);
    }

    public void MoveDown()
    {
        transform.Translate(0f, 0f, -1f);
    }

    public void MoveLeft()
    {
        transform.Translate(-1f, 0f, 0f);
    }

    public void MoveRight()
    {
        transform.Translate(1f, 0f, 0f);
    }

}
