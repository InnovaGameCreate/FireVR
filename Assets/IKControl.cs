using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{

    protected Animator animator;

    public bool ikActive = false;   //ikが有効かどうか
    private Transform rightHandObj = null;  //持つべき右手の位置
    private Transform leftHandObj = null;   //持つべき左手の位置 
    private Transform removefire;   //持つべき本体
    private bool once;

    void Start()
    {
        animator = GetComponent<Animator>();
    
    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (animator)
        {

            //if the IK is active, set the position and rotation directly to the goal. 
            if (ikActive)
            {
                //本体と持つべき右手と左手の位置を格納
                if (!once)
                {
                    removefire = GetComponent<TakeRemoveFire>().get_nearobj().transform;
                    rightHandObj = removefire.transform.Find("right");
                    leftHandObj = removefire.transform.Find("left");
                    once = true;
                }
                // Set the look target position, if one has been assigned
                if (removefire != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(removefire.position);
                }

                // 右手の位置固定
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }
                //左手の位置固定
                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                }

            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }
}


