using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    public static ServiceLocator Instance;

    public MachineController MachineController { get; private set; }
    //public TutorialManager TutorialManager { get; private set; }

    private void Awake()
    {
        Instance = this;
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        MachineController = FindObjectOfType<MachineController>();
        //TutorialManager = FindObjectOfType<TutorialManager>();
    }

}
