using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text healthLabel;
    [SerializeField]
    private InventoryPopup popup;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }

    private void OnHealthUpdated()
    {
        string message = $"Health: {Manager.Player.health} / {Manager.Player.maxHealth}";
        healthLabel.text = message;
    }

    // Start is called before the first frame update
    void Start()
    {
        OnHealthUpdated();

        popup.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool isShowing = popup.gameObject.activeSelf;
            popup.gameObject.SetActive(!isShowing);
            popup.Refresh();
        }
    }
}
