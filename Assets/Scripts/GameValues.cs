using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class GameValues
{
    public static int score = 0;
    public static int numLives = 3;
    public static float waveSpawnTime = 2;

    public static EntityType NextSpawn()
    {
        return EntityType.ENEMY1;
    }
}
