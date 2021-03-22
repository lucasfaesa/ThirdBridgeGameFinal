using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSwitchState : MonoBehaviour
{
     #pragma warning disable CS0649
        [SerializeField] private GameObject targetGameObject;
        [SerializeField] private Image targetImage;
        [Space] 
        [SerializeField] private Vector3 targetPosition;
        [SerializeField] private Quaternion targetRotation;
        [SerializeField] private Vector3 targetScale;
        [SerializeField] private Color targetColor;
        [Space] 
        [SerializeField] private float timeToMove = 0.3f;
        [Space] 
        [SerializeField] private bool canMove;
        [SerializeField] private bool canRotate;
        [Space]
        [SerializeField] private bool canScale;
        [SerializeField] private bool zeroXScaleOnAwake;
        [SerializeField] private bool zeroYScaleOnAwake;
        [SerializeField] private bool zeroZScaleOnAwake;
        [Space]
        [SerializeField] private bool canChangeColor;
        [Space]
#pragma warning restore CS0649
        
        private bool isOn;
        
        private Vector3 startPosition;
        private Quaternion startRotation;
        private Vector3 startScale;
        private Color startColor;
    
        private Coroutine moveRoutine;
        private Coroutine returnRoutine;
    
        private void Awake()
        {
    
            if (zeroXScaleOnAwake)
            {
                targetGameObject.transform.localScale = new Vector3(0,targetGameObject.transform.localScale.y,targetGameObject.transform.localScale.z);
            }
    
            if (zeroYScaleOnAwake)
            {
                targetGameObject.transform.localScale = new Vector3(targetGameObject.transform.localScale.x,0,targetGameObject.transform.localScale.z);
            }
    
            if (zeroZScaleOnAwake)
            {
                targetGameObject.transform.localScale = new Vector3(targetGameObject.transform.localScale.x,targetGameObject.transform.localScale.y,0);
            }
    
            if (canMove)
            {
                startPosition = targetGameObject.transform.localPosition;
            }
    
            if (canRotate)
            {
                startRotation = targetGameObject.transform.localRotation; 
            }
    
            if (canScale)
            {
                startScale = targetGameObject.transform.localScale;
            }
    
            if (canChangeColor)
            {
                startColor = targetImage.color;
            }
        }
    
        public void ChangeStateBool(bool change)
        {
            if (change)
            {
                if (canMove || canRotate|| canScale)
                {
                    if (targetGameObject.transform.position != targetPosition ||
                        targetGameObject.transform.rotation != targetRotation ||
                        targetGameObject.transform.localScale != targetScale)
                    {
                        MoveToTargetPosition();
                        
                    }
                }
    
                if (canChangeColor)
                {
                    if (targetImage.color != targetColor)
                    {
                        ChangeColor(targetColor, true);
                         
                    }
                }
                
            }
            else
            {
                if (canMove || canRotate || canScale)
                {
                    if (targetGameObject.transform.position != startPosition ||
                        targetGameObject.transform.rotation != startRotation ||
                        targetGameObject.transform.localScale != startScale)
                    {
                        ReturnToPosition();
                        
                    }
                }
    
                if (canChangeColor)
                {
                    if (targetImage.color != startColor)
                    {
                        ChangeColor(startColor, false);
                        
                    }
                }
            }
        }
    
        public void ChangeState()
        {
            if (!isOn)
            {
                MoveToTargetPosition();
                ChangeColor(targetColor, true);
                
                
            }
            else
            {
                ReturnToPosition();
                ChangeColor(startColor, false);
                
            }
            
            isOn = !isOn;
        }
        
        public void MoveToTargetPosition()
        {
            if (returnRoutine != null)
            {
                StopCoroutine(returnRoutine);
            }
    
            moveRoutine = StartCoroutine(MoveToTarget(startPosition,startRotation,startScale, targetPosition,targetRotation, targetScale));
        }
    
        public void ReturnToPosition()
        {
            if (moveRoutine != null)
            {
                StopCoroutine(moveRoutine);
            }
            
            Vector3 actualPosition = targetGameObject.transform.localPosition;
            Quaternion actualRotation = targetGameObject.transform.localRotation;
            Vector3 actualScale = targetGameObject.transform.localScale;
            
            returnRoutine = StartCoroutine(MoveToTarget(actualPosition,actualRotation,actualScale, startPosition,startRotation,startScale));
        }
    
        private void ChangeColor(Color color, bool newColor)
        {
            if (canChangeColor)
            {
                targetImage.color = newColor ? color : startColor;
            }
        }
    
        private IEnumerator MoveToTarget(Vector3 initialPosition, Quaternion initialRotation, Vector3 initialScale, Vector3 finalPosition,
            Quaternion finalRotation, Vector3 finalScale)
        {
            float elapsedTime = 0;
    
            while (elapsedTime < timeToMove)
            {
                elapsedTime += Time.deltaTime;
    
                if (canMove)
                {
                    targetGameObject.transform.localPosition =
                        Vector3.Lerp(initialPosition, finalPosition, elapsedTime / timeToMove);
                }
    
                if (canRotate)
                {
                    targetGameObject.transform.localRotation =
                        Quaternion.Lerp(initialRotation, finalRotation, elapsedTime / timeToMove);
                }
    
                if (canScale)
                {
                    targetGameObject.transform.localScale =
                        Vector3.Lerp(initialScale, finalScale, elapsedTime / timeToMove);
                }
    
                yield return null;
            }
        }
}
