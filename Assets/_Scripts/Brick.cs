using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameMaster GM;
    private float _health;
    public float ScaleModifier = 1;
    public float TargetScale;
    public float TimeToLerp = 0.25f;
    public ParticleSystem DmgEffect;

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
            Destroy(other.gameObject);
        }else if(other.gameObject.tag == "Floor")
        {
            GM.OnPlayerDied();
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        DmgEffect.Play();
        if (_health < 0)
        {
            BrickDeath();
        }else
        SetBrickColor(_health);
    }

    IEnumerator LerpFunction(float endValue, float duration)
    {
        float time = 0;
        float startValue = ScaleModifier;
        Vector3 startScale = transform.localScale;
        while (time < duration)
        {
            ScaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * ScaleModifier;
            time += Time.deltaTime;
            transform.Rotate(1f, 1f, 1f);
            yield return null;
        }
        transform.localScale = startScale * TargetScale;
        ScaleModifier = TargetScale;
        BrickDeath();
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time*3f / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    public void VoidContact(Vector3 voidCenter)
    {
        StartCoroutine(LerpPosition(voidCenter, 5));
        StartCoroutine(LerpFunction(TargetScale, TimeToLerp));
    }

    private void BrickDeath()
    {
        GM.IncrementScore();
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
