using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EvilCubeAI : MonoBehaviour {

    Transform nearestCollector;

    public float collectorInterestedTime = 5.0f;
    public float speed = 3.0f;
    float timeSinceChosenCollector = 10000f;

    NavMeshAgent agent;

    private bool markedForDeath;

	// Use this for initialization
	void Start () {
        markedForDeath = false;
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("My agent:");
        Debug.Log(agent);
        ChooseNearestCollector();
    }
	
	// Update is called once per frame
	void Update () {
        timeSinceChosenCollector += Time.deltaTime;
        if(timeSinceChosenCollector > collectorInterestedTime)
        {
            ChooseNearestCollector();
        }
        //MoveTowardChosenCollector();
        
	}

    void MoveTowardChosenCollector()
    {
        this.transform.position += (nearestCollector.position - this.transform.position).normalized * speed * Time.deltaTime;
    }

    void ChooseNearestCollector()
    {
        GameObject[] collectors = GameObject.FindGameObjectsWithTag("Collector");
        float minimumDistance = float.MaxValue;
        float tempDistance = 0;
        foreach(GameObject col in collectors)
        {
            tempDistance = (col.transform.position - this.transform.position).magnitude;
            if(tempDistance < minimumDistance)
            {
                this.nearestCollector = col.transform;
                minimumDistance = tempDistance;
            }
        }
        timeSinceChosenCollector = 0;
        agent.SetDestination(nearestCollector.position);
    }

    public void Collect()
    {
        /*
        this.markedForDeath = true;
        TurnInvisible();
        Debug.Log("I got called");
        */
        
    }

    void TurnInvisible()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }

    
}
