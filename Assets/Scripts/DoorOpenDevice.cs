using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField]
    private Vector3 dPos;

    [HideInInspector]
    public bool IsOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Operate()
    {
        if (IsOpened)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
        }

        IsOpened = !IsOpened;
    }

    public void Activate()
    {
        if (!IsOpened)
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
            IsOpened = true;
        }
    }
    public void Deactivate()
    {
        if (IsOpened)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
            IsOpened = false;
        }
    }
}
