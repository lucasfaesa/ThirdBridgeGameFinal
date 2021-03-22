using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnim : MonoBehaviour
{
    [SerializeField] private Animator sirenHeadAnim;

    public void StopAnimBool()
    {
        sirenHeadAnim.SetBool("ChangeState", true);
    }
}
