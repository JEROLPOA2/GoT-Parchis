using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        HandleMenu();
    }

    public void configuration()
    {
        HandleConfigure();
    }


    public void HandleMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("MainMenu");
    }

    public void HandleInstruction()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("Instruction");
    }

    public void HandleConfigure()
    {
        Debug.Log("Loading Configure...");
        SceneManager.LoadScene("Configuration");
    }

    public void HandleGameplay()
    {
        Debug.Log("Loading Gameplay...");
        StartCoroutine(LoadGameplayAsyncScene("Gameplay"));
    }


    IEnumerator LoadGameplayAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);

    }

}
