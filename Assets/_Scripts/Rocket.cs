using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private GameMaster GM;

    void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, GM.RocketSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Brick") return;
            RocketBlast();
            Destroy(gameObject);
    }
    private void RocketBlast()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, GM.RocketBlastRadius);
        if (hit.Length == 0) return;

        for (int i = 0; i < hit.Length; i++)
        {
            Brick brick = hit[i].GetComponent<Brick>();
            if (brick != null)
            {
                brick.TakeDamage(GM.RocketDamage);
            }
        }
    }
}
