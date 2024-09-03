using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(fileName = "Machine Controller Context",menuName = "Machine Contexts/Machine Controller Context")]
public class MachineControllerContext : ScriptableObject
{
    public delegate void GearCreatedDelegate();
    public GearCreatedDelegate GearCreatedEvent;

    public UnityEvent<int> TemperatureChanged;
    public int temperature;

    float cooldownTimer;
    float cooldown = .1f;
    public void CreateGear()
    {
        GearCreatedEvent.Invoke();
    }
    public void SetTemperature(float temperature)
    {
        this.temperature = (int)temperature;
        TemperatureChanged.Invoke(this.temperature);
    }
}
