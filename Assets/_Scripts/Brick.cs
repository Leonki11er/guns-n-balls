using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameMaster GM;
   

    void Start()
    {
        GM = GameObject.Find("Roof").GetComponent<GameMaster>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            BrickDeath();
        }
    }

    private void BrickDeath()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = gameObject.transform.position - new Vector3(0, GM.BrickSpeed, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
