using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }


}
