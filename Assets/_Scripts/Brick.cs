using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameMaster GM;
    private float _health;

    [SerializeField]    
    private Material _material;

    private void Awake()
    {
        var renderer = GetComponent<MeshRenderer>();
        _material = Instantiate(renderer.sharedMaterial);
        renderer.material = _material;
        
    }

    void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        _health = Random.Range(GM.BrickMinHealth, GM.BrickMaxHealth);
        SetBrickColor(_health);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            BrickDeath();
        }else if(collision.gameObject.tag == "Bullet")
        {
            TakeDamage(GM.BulletDamage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(GM.BulletDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            BrickDeath();
        }else
        SetBrickColor(_health);
        

    }

    private void BrickDeath()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = gameObject.transform.position - new Vector3(0, GM.BrickSpeed, 0);
    }

    public void SetBrickColor(float health)
    {
        
        float brickhealth = Mathf.InverseLerp(0f, GM.BrickMaxHealth, health);
        _material.SetFloat("_brickHealth", brickhealth);
    }
}
