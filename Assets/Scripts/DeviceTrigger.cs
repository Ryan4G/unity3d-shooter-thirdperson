using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject[] targets;

    public bool requireKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (requireKey && Manager.Inventory.equippedItem != "Key")
        {
            return;
        }

        foreach(GameObject target in targets)
        {
            target.SendMessage("Activate");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (requireKey && Manager.Inventory.equippedItem != "Key")
        {
            return;
        }

        foreach (GameObject target in targets)
        {
            target.SendMessage("Deactivate");
        }
    }
}
