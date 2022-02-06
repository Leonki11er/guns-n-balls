using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private  GameMaster GM;
    private Rigidbody _rigidbody;
    void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
       
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = gameObject.transform.position +transform.forward*GM.BulletSpeed;
       
    }
}
