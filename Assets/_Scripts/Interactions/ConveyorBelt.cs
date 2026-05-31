using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Animations;
using System.Linq;

public class ConveyorBelt : MonoBehaviour
{
    private List<Transform> luggages;
    private Transform container;
    public Transform luggageParking;
    public Transform luggageRemoval;
    public Transform luggageSpawn;
    private bool EngineOn;
    public float speed;
    private int topIndex;
    public List<GameObject> spawnLuggageList;
    public List<GameObject> BountyCases;
    [SerializeField] public Animator animator;
    //private List<Luggage> spawnLuggages;

    private void Start()
    {
        InitializeLuggageContainer();
        /*
        foreach (GameObject l in spawnLuggageList)
        {
            spawnLuggages.Add(l.GetComponent<Luggage>());
        }
        */

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

    public void Pop()
    {
        if (luggages != null)
            if (topIndex < luggages.Count - 1)
            {
                Top().GetComponent<Rotateable>().enabled = false;
                Top().GetComponent<Luggage>().setActive(false);
                Top().GetComponent<Luggage>().IsLuggageBad();
                topIndex++;
                Top().GetComponent<Rotateable>().enabled = true;
                Top().GetComponent<Luggage>().setActive(true);
                if (Top().GetComponent<Luggage>().isBounty)
                    GameManager.Instance.ChangeState(GameState.EndRound);
                StartEngine();
            }
    }

    private void StartEngine()
    {
        EngineOn = true;
        if (animator != null)
        {
            animator.Play("ConveyerBeltMove");
        }
    }

    private void StopEngine()
    {
        EngineOn = false;
        if (animator != null)
        {
            animator.Play("Static");
        }
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
        /*if (Vector3.Distance(luggages.First().position, luggageRemoval.position) < .01f)
        {
            luggages.Remove(luggages.First());
            Destroy(luggages.First().gameObject);
            SpawnObject();
        }*/
    }

    public void SpawnObject()
    {

        /*int i = Random.Range(0, 100);
        for (int j = 0; j < spawnLuggageList.Count; j++)
        {
            if (i >= spawnLuggageList[j].GetComponent<Luggage>().minProbabilityRange && i <= spawnLuggageList[j].GetComponent<Luggage>().maxProbabilityRange)
            {
                GameObject lug = Instantiate(spawnLuggageList[i], luggageSpawn.position, luggageSpawn.rotation);
                luggages.Add(lug.transform);
                break;
            }

        }*/
    }
    public void SpawnBountyCase()
    {

    }
}
