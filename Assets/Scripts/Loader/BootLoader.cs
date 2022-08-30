using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoader : MonoBehaviour
{
    public static BootLoader Instance { get; private set; }
    private List<string> _sceneNames;
    private Dictionary<string, Scene> _scenes;
    private string _currentScene = "";

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        _sceneNames = new List<string>
        {
            "Boot",
            "MainMenu",
            "Gameplay",
        };

        _scenes = new Dictionary<string, Scene>();

        foreach (var sceneName in _sceneNames)
        {
            _scenes.Add(sceneName, SceneManager.GetSceneByName(sceneName));
        }
    }

    void Start()
    {
        Load("MainMenu");
    }

    public async void Load(string sceneName)
    {
        SceneManager.SetActiveScene(_scenes["Boot"]);
        if (_currentScene != "")
        {
            await UnloadScene(_currentScene);
        }
        
        await LoadScene(sceneName);
        _currentScene = sceneName;
    }

    private UniTask LoadScene(string sceneName)
    {
        var handle = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        try
        {
            return UniTask.WaitUntil(() => handle.isDone);
        }
        catch (Exception e)
        {
            Debug.Log($"Could not load {sceneName}: {e.Message}");
            throw;
        }
    }
    
    private UniTask UnloadScene(string sceneName)
    {
        var handle = SceneManager.UnloadSceneAsync(sceneName);
        try
        {
            return UniTask.WaitUntil(() => handle.isDone);
        }
        catch (Exception e)
        {
            Debug.Log($"Could not unload {sceneName}: {e.Message}");
            throw;
        }
    }
}
