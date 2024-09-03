using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContainerConveyorController : MonoBehaviour
{
    public bool ContainersShouldMove
    {
        get
        {
            return containersShouldMove;
        }
        set
        {
            containersShouldMove = value;
            containerReady.Invoke(!containersShouldMove);
        }
    }
    bool containersShouldMove = true;
    public Transform containerStartPosition,containerStopPosition, containerAlignPosition;

    public Transform containerPrefab;
    public int containerCount;
    public List<Transform> containers = new List<Transform>();
    public UnityEvent<bool> containerReady;

    Transform currentContainer;
    private void Awake()
    {
        CreateContainers();
    }

    private void Update()
    {
        if (ContainersShouldMove)
        {
            foreach (Transform t in containers)
            {
                MoveContainer(t);
            }
            
        }

    }
    public void CreateContainers()
    {
        Vector3 distance = containerStopPosition.position - containerStartPosition.position;

        for (int i = 0; i < containerCount; i++)
        {
            containers.Add(Instantiate(containerPrefab,distance * i/containerCount + containerStartPosition.position,Quaternion.Euler(new Vector3(-90,0,0))));
            containers[i].GetComponent<ContainerContext>().ContainerFilledEvent += StartConveyor;
        }
    }

    void MoveContainer(Transform container)
    {
        container.position += new Vector3(0, 0, 1) * Time.deltaTime;
        if (container.position.z >= containerAlignPosition.position.z - .01f && container.position.z <= containerAlignPosition.position.z + .01f && container != currentContainer)
        {
            currentContainer = container;
            ContainersShouldMove = false;
        }

        if (container.position.z >= containerStopPosition.position.z)
        {
            container.position = containerStartPosition.position;
            container.GetComponent<ContainerContext>().EmptyContainer();
        }
    }
    void StartConveyor(ContainerContext context)
    {
        StartCoroutine(StartConveyorEnumerator(context));
    }
    IEnumerator StartConveyorEnumerator(ContainerContext context)
    {
        yield return new WaitForSeconds(.4f);
        context.TurnOffPhysics();
        containersShouldMove = true;
    }
}
