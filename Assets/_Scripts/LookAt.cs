using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Target;
    new Vector3 target;

    private void Update()
    {
        target = new Vector3(Target.position.x, Target.position.y, transform.position.z);
        transform.LookAt(target);
    }
}
