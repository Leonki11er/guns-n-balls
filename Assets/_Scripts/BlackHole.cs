using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private GameMaster GM;
    public GameObject Swirl;
    private bool _isMoving;
    private bool _isVoid;

    void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        _isMoving = true;
        _isVoid = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Brick") return;
        _isMoving = false;
        ActivateVoid();
        StartCoroutine(VoidFireDelay());
        Destroy(gameObject, GM.VoidActiveTime+0.2f);
    }
    private void FixedUpdate()
    {
        MoveVoid();
    }

    private IEnumerator VoidFireDelay()
    {
        yield return new WaitForSeconds(GM.VoidActiveTime);
        GM.Firing = true;
    }

    private void MoveVoid()
    {
        if (!_isMoving) return;
        gameObject.transform.position = gameObject.transform.position + transform.forward * GM.VoidSpeed;
    }

    private void ActivateVoid()
    {
        if (!_isVoid) return;
        Debug.Log("Void");
        _isVoid = false;
        Swirl.SetActive(true);
        Collider[] hit = Physics.OverlapSphere(transform.position, GM.VoidRadius);
        if (hit.Length == 0) return;

        for (int i = 0; i < hit.Length; i++)
        {
            Brick brick = hit[i].GetComponent<Brick>();
            if (brick != null)
            {
                hit[i].GetComponent<BoxCollider>().enabled = false;
                brick.VoidContact(transform.position);
            }
        }
    }
}
