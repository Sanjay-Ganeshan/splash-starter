using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public struct EntityEntry
{
    public float movementSpeed;
    public int maxHP;
    public int currentHP;
    public float rotationalSpeed;
    public Team owner;
    public EntityType eType;
    public bool canJump;
}
