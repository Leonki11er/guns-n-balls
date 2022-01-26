using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody BallRB;
    public GameMaster GM;
    void Start()
    {
        BallRB.velocity = Vector2.up * GM.BallSpeed;
       

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            float x = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Debug.Log(x);
            Vector2 direction = new Vector2(x, 1).normalized;
            BallRB.velocity = direction * GM.BallSpeed;
        }else if (collision.gameObject.tag == "Brick")
        {

        }
    }
    private float hitFactor(Vector2 ballPos, Vector2 platformPos, float platformWidth)
    {
        return (ballPos.x - platformPos.x) / platformWidth;
    }
}
