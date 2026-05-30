using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ConveyorBelt : MonoBehaviour
{
    private List<Transform> luggages;
    private Transform container;
    public Transform luggageParking;
    private bool EngineOn;
    public float speed;
    private int topIndex;
    public List<Transform> spawnLuggageList;

    private void Start()
    {
        InitializeLuggageContainer();
    }

    private void InitializeLuggageContainer()
    {
        container = GameObject.Find("Luggages").transform;

        luggages = new List<Transform>();
        foreach (Transform l in container)
        {
            luggages.Add(l);
        }

        topIndex = 0;

        Top().GetComponent<Rotateable>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Pop();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            print(Top().name);
        }

        if (EngineOn)
        {
            MoveLuggages();
        }
    }

    private Transform Top()
    {
        if (topIndex < luggages.Count) 
            return luggages[topIndex];
        return null;
    }    

    private void Pop()
    {
        if (topIndex < luggages.Count - 1)
        {
            Top().GetComponent<Rotateable>().enabled = false;
            topIndex++;
            Top().GetComponent<Rotateable>().enabled = true;
            StartEngine();
        }
    }

    private void StartEngine()
    {
        EngineOn = true;
    }

    private void StopEngine()
    {
        EngineOn = false;
    }

    private void MoveLuggages()
    {
        float distance = Vector3.Distance(Top().position, luggageParking.position);

        // LERP
        //container.position = Vector3.Lerp(container.position, container.position - container.right * distance, speed);
        // LINEAR
        container.position = new Vector3(container.position.x - speed, container.position.y, container.position.z);
        if (Vector3.Distance(Top().position, luggageParking.position) < .01f)
            StopEngine();
    }
}
