using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeDevice : BaseDevice
{
    [SerializeField]
    private DoorOpenDevice _doorOpenDevice;

    private Color _openSwitchColor = Color.green;

    private Color _closeSwitchColor = Color.red;

    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = _closeSwitchColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Operate()
    {
        _doorOpenDevice.Operate();

        if (_doorOpenDevice.IsOpened)
        {
            _renderer.material.color = _openSwitchColor;
        }
        else
        {
            _renderer.material.color = _closeSwitchColor;
        }
    }
}
