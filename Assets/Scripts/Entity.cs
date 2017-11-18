using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour {

    public EntityType myType;
    public EntityModel data;
    public bool playerControlled;
    NavMeshAgent agent;

    public float timeSinceReroute = 0;

    Tailor god;

	// Use this for initialization
	void Start () {
        god = GameObject.FindGameObjectWithTag("God").GetComponent<Tailor>();
        if(god == null)
        {
            Debug.Log("I can't find God.");
        }
        this.data = god.GetModelForType(myType);
        agent = GetComponent<NavMeshAgent>();
        if(agent != null)
        {
            agent.speed = this.data.movementSpeed;
            agent.angularSpeed = this.data.rotationalSpeed;
        }
        this.playerControlled = false;
	}
	
	// Update is called once per frame
	void Update () {
        Move();   	
	}

    void Move()
    {
        if(playerControlled)
        {
            Input.GetAxis("Horizontal");
            Input.GetAxis("Vertical");
        }
        else
        {
            this.timeSinceReroute += Time.deltaTime;
            if(this.timeSinceReroute > 20.0f)
            {
                ChooseNearestCollector();
            }
        }
    }

    void ChooseNearestCollector()
    {
        GameObject[] collectors = GameObject.FindGameObjectsWithTag("Collector");
        float minimumDistance = float.MaxValue;
        float tempDistance = 0;
        Transform nearestCollector = this.transform;
        foreach (GameObject col in collectors)
        {
            tempDistance = (col.transform.position - this.transform.position).magnitude;
            if (tempDistance < minimumDistance)
            {
                nearestCollector = col.transform;
                minimumDistance = tempDistance;
            }
        }
        timeSinceReroute = 0;
        agent.SetDestination(nearestCollector.position);
    }

    void OnTriggerEnter(Collider other)
    {
        BulletScript bs = other.gameObject.GetComponent<BulletScript>();
        if(bs != null)
        {
            this.data.currentHP -= bs.damage;
            if(this.data.currentHP < 0)
            {
                god.KillMe(this.gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
