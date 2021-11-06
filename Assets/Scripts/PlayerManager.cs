using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status
    {
        get;
        private set;
    }

    public int health
    {
        get;
        private set;
    }

    public int maxHealth
    {
        get;
        private set;
    }

    public void Startup(NetworkService service)
    {
        Debug.Log("Player manager starting...");

        UpdateData(50, 100);

        status = ManagerStatus.Started;
    }

    public void UpdateData(int v1, int v2)
    {
        this.health = v1;
        this.maxHealth = v2;
    }

    public void ChangeHealth(int value)
    {
        health += value;

        health = Mathf.Min(maxHealth, Mathf.Max(health, 0));

        Debug.Log($"{health} / {maxHealth}");

        if (health == 0)
        {
            Messenger.Boardcast(GameEvent.LEVEL_FAILED);
        }
        Messenger.Boardcast(GameEvent.HEALTH_UPDATED);
    }

    public void Respawn()
    {
        UpdateData(50, 100);
    }
}
