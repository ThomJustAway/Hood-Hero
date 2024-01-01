using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;

    private void Awake()
    {
        instance = this;
    }

    public enum Scene
    {
        startMenu,
        SampleScene
    }
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNew()
    {
        SceneManager.LoadScene(Scene.SampleScene.ToString());
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(Scene.startMenu.ToString());
    }

}
