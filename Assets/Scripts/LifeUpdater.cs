using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LifeUpdater : MonoBehaviour {


    int lastValue;
	// Use this for initialization
	void Start () {
        lastValue = GameValues.numLives;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameValues.numLives != lastValue)
        {
            this.gameObject.GetComponent<Text>().text = string.Format("Lives: {0}", GameValues.numLives);
            lastValue = GameValues.numLives;
        }
	}
}
