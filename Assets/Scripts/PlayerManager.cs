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

    public void Startup()
    {
        Debug.Log("Player manager starting...");

        health = 50;
        maxHealth = 100;

        status = ManagerStatus.Started;
    }

    public void ChangeHealth(int value)
    {
        health += value;

        health = Mathf.Min(maxHealth, Mathf.Max(health, 0));

        Debug.Log($"{health} / {maxHealth}");
    }
}
