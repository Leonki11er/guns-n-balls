using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private GameMaster GM;
    public GameObject Blast;

    void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = gameObject.transform.position + transform.forward * GM.RocketSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Brick") return;
            RocketBlast();
            Destroy(gameObject);
    }
    private void RocketBlast()
    {
        GM.RocketBlastSound();
        Collider[] hit = Physics.OverlapSphere(transform.position, GM.RocketBlastRadius);
        if (hit.Length == 0) return;
        Instantiate(Blast, transform.position, transform.rotation);

        for (int i = 0; i < hit.Length; i++)
        {
            Brick brick = hit[i].GetComponent<Brick>();
            if (brick != null)
            {
                brick.TakeDamage(GM.RocketDamage);
            }
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
