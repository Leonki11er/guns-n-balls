using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private  GameMaster GM;
    void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
       
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = gameObject.transform.position +transform.forward*GM.BulletSpeed;
       
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
