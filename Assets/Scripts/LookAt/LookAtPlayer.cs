using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float speed = 0.5f;

    private bool canLook;
    
    void Update()
    {
        if (canLook)
        {
            
            Quaternion OriginalRot = transform.rotation;
            transform.LookAt(target);
            Quaternion NewRot = transform.rotation;
            transform.rotation = OriginalRot;
            transform.rotation = Quaternion.Slerp(transform.rotation, NewRot, speed * Time.deltaTime);
            
        }
    }

    public void LookAtThePlayer()
    {
        canLook = true;

        StartCoroutine(lerpToTargetPosition());
    }

    private IEnumerator lerpToTargetPosition()
    {
        yield return new WaitForSeconds(7f);
        
        canLook = false;
    }
}
