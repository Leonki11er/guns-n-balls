using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private GameMaster GM;
    void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();

    }

    private void FixedUpdate()
    {
        gameObject.transform.position = gameObject.transform.position + transform.forward * GM.VoidSpeed;

    }
}
