using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public float speed = 4.0f;
    public float rotationSpeed = 180;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.Self);
        this.transform.Translate(Vector3.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime, Space.Self);
        
	}
}
