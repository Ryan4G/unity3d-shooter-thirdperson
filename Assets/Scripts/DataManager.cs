using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status
    {
        get;
        private set;
    }

    private string _filename;

    public void Startup(NetworkService service)
    {
        Debug.Log("Data manager starting...");

        _filename = Path.Combine(Application.persistentDataPath, "game.dat");

        status = ManagerStatus.Started;
    }

    public void SaveGameState()
    {
        Dictionary<string, object> gamestate = new Dictionary<string, object>();

        gamestate.Add("inventory", Manager.Inventory.GetData());
        gamestate.Add("health", Manager.Player.health);
        gamestate.Add("maxHealth", Manager.Player.maxHealth);
        gamestate.Add("currLevel", Manager.Mission.currLevel);
        gamestate.Add("maxLevel", Manager.Mission.maxLevel);

        FileStream stream = File.Create(_filename);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, gamestate);
        stream.Close();
    }

    public void LoadGameState()
    {
        if (!File.Exists(_filename))
        {
            Debug.Log("No saved game");
            return;
        }

        Dictionary<string, object> gamestate;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(_filename, FileMode.Open);
        gamestate = formatter.Deserialize(stream) as Dictionary<string, object>;
        stream.Close();

        Manager.Inventory.UpdateData((Dictionary<string, int>)gamestate["inventory"]);
        Manager.Player.UpdateData((int)gamestate["health"], (int)gamestate["maxHealth"]);
        Manager.Mission.UpdateData((int)gamestate["currLevel"], (int)gamestate["maxLevel"]);

        Manager.Mission.RestartCurrent();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
