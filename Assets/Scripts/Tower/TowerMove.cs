using System.Collections;
using System.Collections.Generic;
using ThirdBridge.Events;
using UnityEngine;

public class TowerMove : MonoBehaviour
{
    public SimpleStateEvent StartedLifting;
    public SimpleStateEvent EndedLifting;
    
    [SerializeField] private GameObject targetGameObject;
    [SerializeField] private float timeToMove;
    [SerializeField] float targetPosY;

    public void LiftTower()
    {
        StartCoroutine(MoveToTarget());
    }
    
    private IEnumerator MoveToTarget()
    {
        float elapsedTime = 0;
        Vector3 startPos = targetGameObject.transform.position;
        StartedLifting?.Invoke();
        while (elapsedTime < timeToMove)
        {
            elapsedTime += Time.deltaTime;
            
            targetGameObject.transform.localPosition = Vector3.Lerp(startPos, new Vector3(targetGameObject.transform.position.x,targetPosY,targetGameObject.transform.position.z), elapsedTime/timeToMove);
                
            yield return null;
        } 
        EndedLifting?.Invoke();
    }
}
