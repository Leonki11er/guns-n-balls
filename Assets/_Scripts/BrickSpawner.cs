using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameMaster GM;
    
    public GameObject Brick;


    private void Start()
    {
        StartCoroutine(SpawnBricks());
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnLine();
        }
    }
    private void SpawnLine()
    {
        for (int i =0; i < 8; i++)
        {
            Instantiate(Brick, new Vector3(-2.4f + 0.8f * i, transform.position.y, transform.position.z), transform.rotation);
        }
    }

    private IEnumerator SpawnBricks()
    {
        while (GM.ActiveSpawner)
        {
            for (int i = 0; i < 8; i++)
            {
                Instantiate(Brick, new Vector3(-2.4f + 0.8f * i, transform.position.y-GM.YspawnOffset, transform.position.z), transform.rotation);
            }
            yield return new WaitForSeconds(GM.SpawnCD);
        }
    }



}
