using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameMaster GM;
    


    void Start()
    {
        GM = GameObject.Find("Roof").GetComponent<GameMaster>();
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, GM.BulletSpeed, 0);
    }
}
