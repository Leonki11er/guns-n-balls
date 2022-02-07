using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public float BrickSpeed;
    public float BrickMinHealth;
    public float BrickMaxHealth;
    public bool ActiveSpawner;
    public float SpawnCD;
    public float YspawnOffset;

    public bool Firing;

    public float BulletSpeed;
    public float BulletDamage;
    public float BulletCount;
    public float BulletFireRate;

    public float RocketSpeed;
    public float RocketDamage;
    public float RocketCount;
    public float RocketFireRate;
    public float RocketBlastRadius;

    public float VoidSpeed;
    public float VoidRadius;
    public float VoidCD;


    public float BallSpeed;

    private void Start()
    {
       
        Firing = true;
    }


}
