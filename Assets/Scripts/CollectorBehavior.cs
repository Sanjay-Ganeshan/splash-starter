using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorBehavior : MonoBehaviour {

    bool particlesOn;

    float timeOn = 0;
    public float timeToDisplayParticlesOnCollect = 5f;
    public GameObject particles;

	// Use this for initialization
	void Start () {
        particlesOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(particlesOn)
        {
            timeOn += Time.deltaTime;
            if(timeOn > timeToDisplayParticlesOnCollect)
            {
                EndCollectEffect();
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Entity botAI = other.gameObject.GetComponent<Entity>();
            Destroy(botAI.gameObject);
            
            PlayCollectEffect();
            Debug.Log("Call me maybe?");
            GameValues.numLives--;   
        }
    }

    void PlayCollectEffect()
    {
        particles.SetActive(true);
        timeOn = 0;
        particlesOn = true;
    }

    void EndCollectEffect()
    {
        this.GetComponentInChildren<ParticleSystem>().gameObject.SetActive(false);
        timeOn = 0;
        particlesOn = false;
    }
}
