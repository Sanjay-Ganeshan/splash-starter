using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour {

    public GameObject toFollow = null;

    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = this.transform.position - toFollow.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(toFollow != null)
        {
            this.transform.position = toFollow.transform.position + offset;
        }
	}
}
