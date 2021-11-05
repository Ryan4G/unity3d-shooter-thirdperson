using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status
    {
        get;
        private set;
    }

    public int currLevel { get; private set; }
    public int maxLevel { get; private set; }

    private NetworkService _network;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Startup(NetworkService service)
    {
        Debug.Log("Mission manager starting...");

        _network = service;
        currLevel = 0;
        maxLevel = 1;

        status = ManagerStatus.Started;
    }

    public void GoToNext()
    {
        if (currLevel < maxLevel)
        {
            currLevel++;
            string name = $"Level {currLevel}";
            Debug.Log($"Loading {name}");
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.Log("Last level");
        }
    }
}
