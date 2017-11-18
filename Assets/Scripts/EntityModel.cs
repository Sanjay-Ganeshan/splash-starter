using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class EntityModel
{
    public float movementSpeed;
    public int maxHP;
    public int currentHP;
    public float rotationalSpeed;
    public Team owner;
    public EntityType eType;
    public bool canJump;

    public EntityModel(float movementSpeed, float rotationalSpeed, int maxHP, Team owner, EntityType eType, bool canJump)
    {
        this.movementSpeed = movementSpeed;
        this.rotationalSpeed = rotationalSpeed;
        this.maxHP = maxHP;
        this.currentHP = this.maxHP;
        this.owner = owner;
        this.eType = eType;
        this.canJump = canJump;
    }

    public EntityModel(EntityModel template): this(template.movementSpeed, template.rotationalSpeed, template.maxHP, template.owner, template.eType, template.canJump)
    {
    }



}
