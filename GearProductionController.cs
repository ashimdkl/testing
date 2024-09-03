using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearProductionController : MonoBehaviour
{
    public MachineControllerContext MachineControllerContext;
    bool pause;
    public float randomRange;
    public float creationTime;
    public GameObject gear;

    private void Start()
    {
        MachineControllerContext.GearCreatedEvent += CreateGear;
    }
    private void OnDestroy()
    {
        MachineControllerContext.GearCreatedEvent -= CreateGear;
    }
    public void CreateGear()
    {
        Instantiate(gear,transform.position+new Vector3(0,0,Random.Range(-randomRange,randomRange)),transform.rotation);
    }
    private void Update()
    {
/*        creationTime += Time.deltaTime;

        if(creationTime > 1f && !pause)
        {
            CreateGear();
            creationTime = 0;
        }*/
    }
    public void Pause()
    {
        Pause(true);
    }
    public void UnPause()
    {
        Pause(false);
    }
    public void Pause(bool paused)
    {
        pause = paused;
    }
    public void SetParent(Transform parent)
    {
        transform.parent = parent;
    }
    public void RemoveParent()
    {
        if (transform.parent == null)
            return;

        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        transform.parent = null;

        //GetComponent<Rigidbody>().velocity = velocity;
    }

}
