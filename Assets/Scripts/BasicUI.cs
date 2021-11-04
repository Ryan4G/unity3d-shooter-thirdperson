using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        int posX = 10;
        int posY = 10;
        int width = 100;
        int height = 30;
        int buffer = 10;

        List<string> itemList = Manager.Inventory.GetItemList();

        if (itemList.Count == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No Items");
        }

        foreach(string item in itemList)
        {
            int count = Manager.Inventory.GetItemCount(item);
            Texture2D image = Resources.Load<Texture2D>($"Icons/{item}");

            GUI.Box(new Rect(posX, posY, width, height),
                new GUIContent($"({count})", image));

            posX += width + buffer;
        }

        string equipped = Manager.Inventory.equippedItem;

        if (equipped != null)
        {
            posX = Screen.width - (width + buffer);
            Texture2D image = Resources.Load<Texture2D>($"Icons/{equipped}");

            GUI.Box(new Rect(posX, posY, width, height),
                new GUIContent($"Equipped", image));
        }

        posX = 10;
        posY += height + buffer;

        foreach (string item in itemList)
        {
            if (GUI.Button(new Rect(posX, posY, width, height), $"Equip {item}"))
            {
                Manager.Inventory.EquipItem(item);
            }

            if (item == "Health")
            {
                if (GUI.Button(new Rect(posX, posY + height + buffer, width, height), $"Use {item}"))
                {
                    Manager.Inventory.CounsumeItem(item);
                    Manager.Player.ChangeHealth(25);
                }
            }

            posX += width + buffer;
        }
    }
}
