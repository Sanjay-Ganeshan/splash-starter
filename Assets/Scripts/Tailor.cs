using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tailor : MonoBehaviour {

    public EntityEntry[] templates;

    Dictionary<EntityType, EntityModel> templateLookup;

	// Use this for initialization
	void Start () {
        templateLookup = new Dictionary<EntityType, EntityModel>();
        foreach(EntityEntry e in templates) {
            templateLookup.Add(e.eType, new EntityModel(e.movementSpeed, e.rotationalSpeed, e.maxHP, e.owner, e.eType, e.canJump));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public EntityModel GetModelForType(EntityType t)
    {
        return templateLookup[t];
    }

    public void KillMe(GameObject o)
    {
        Destroy(o);
    }

    
}
