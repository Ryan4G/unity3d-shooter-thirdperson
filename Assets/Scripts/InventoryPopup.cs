using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryPopup : MonoBehaviour
{
    [SerializeField]
    private Image[] itemIcons;
    [SerializeField]
    private Text[] itemLabels;

    [SerializeField]
    private Text currItemLabel;
    [SerializeField]
    private Button equipButton;
    [SerializeField]
    private Button useButton;

    private string _currItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh()
    {
        List<string> itemList = Manager.Inventory.GetItemList();

        int len = itemIcons.Length;

        for(int i = 0; i < len; i++)
        {
            if (i < itemList.Count)
            {
                itemIcons[i].gameObject.SetActive(true);
                itemLabels[i].gameObject.SetActive(true);

                string item = itemList[i];

                Sprite sprite = Resources.Load<Sprite>($"Icons/{item}");

                itemIcons[i].sprite = sprite;
                //itemIcons[i].SetNativeSize();

                int count = Manager.Inventory.GetItemCount(item);
                string message = $"x{count}";

                if (item == Manager.Inventory.equippedItem)
                {
                    message = $"Equiped\n {message}";
                }

                itemLabels[i].text = message;

                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerClick;
                entry.callback.AddListener((BaseEventData data) =>
                {
                    OnItem(item);
                });

                EventTrigger trigger = itemIcons[i].GetComponent<EventTrigger>();
                trigger.triggers.Clear();
                trigger.triggers.Add(entry);
            }
            else
            {
                itemIcons[i].gameObject.SetActive(false);
                itemLabels[i].gameObject.SetActive(false);
            }
        }

        if (!itemList.Contains(_currItem))
        {
            _currItem = null;
        }

        if (_currItem == null)
        {
            currItemLabel.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(false);
            useButton.gameObject.SetActive(false);
        }
        else
        {
            currItemLabel.gameObject.SetActive(true);
            equipButton.gameObject.SetActive(true);

            if (_currItem == "Health")
            {
                useButton.gameObject.SetActive(true);
            }
            else
            {
                useButton.gameObject.SetActive(false);
            }

            currItemLabel.text = $"{_currItem}: ";
        }
    }

    public void OnItem(string item)
    {
        _currItem = item;
        Refresh();
    }

    public void OnEquip()
    {
        Manager.Inventory.EquipItem(_currItem);
        Refresh();
    }

    public void OnUse()
    {
        Manager.Inventory.CounsumeItem(_currItem);
        if (_currItem == "Health")
        {
            Manager.Player.ChangeHealth(25);
        }
        Refresh();
    }
}
