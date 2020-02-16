using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    SceneLoader sceneLoader;


    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroid()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
