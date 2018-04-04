using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class IK_Controll : MonoBehaviour
{
    protected Animator animator;

    public bool ikActive = false;
    public Transform rightHandObj = null, leftHandObj = null;
    public Transform lookObj = null;

    [Header("Foot IK")]
    //Маска для Raycast'а, чтобы определять, на что мы можем ставить ноги
    public LayerMask rayLayer;

    public float WeightFoot_L, WeightFoot_R;

    //Сохраняем Raycast hit позиции ног
    private Vector3 footPosL, footPosR;

    //Позиции ног
    public Transform footR, footL;

    //Отклонение (разница) модели и контроллеров
    public Vector3 footLoffset, footRoffset;

    void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (animator)
        {
            //if the IK is active, set the position and rotation directly to the goal. 
            if (ikActive)
            {
                // Set the look target position, if one has been assigned
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                }
                else
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                    animator.SetLookAtWeight(0);
                }

                WeightFoot_R = animator.GetFloat("Right_Leg");
                WeightFoot_L = animator.GetFloat("Left_leg");

                IegsIK();
            }
        }        
    }

    void IegsIK()
    {
        // Устанавливаем вес для контроллеров IK
        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, WeightFoot_L);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, WeightFoot_L);
        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, WeightFoot_R);
        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, WeightFoot_R);
      
        RaycastHit hit;
        // Получаем текущее положение левой ноги
        footPosL = animator.GetIKPosition(AvatarIKGoal.LeftFoot);
        //[RayCast] От ноги на землю
        if (Physics.Raycast(footPosL + Vector3.up, Vector3.down, out hit, 2.0f, rayLayer))
        {
            // Чертим вспомогательные линии в редакторе
             Debug.DrawLine(hit.point, hit.point + hit.normal, Color.yellow);
            // Установка новой позиции IK
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + footLoffset);
            // Установка нового вращения IK
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(Vector3.ProjectOnPlane(footL.forward, hit.normal ), hit.normal));
            // Сохраняем точку столкновения рейкаста
            footPosL = hit.point;
        }
        
        footPosR = animator.GetIKPosition(AvatarIKGoal.RightFoot);
      
        if (Physics.Raycast(footPosR + Vector3.up, Vector3.down, out hit, 2.0f, rayLayer))
        {                      
            animator.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + footRoffset);           
            animator.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(Vector3.ProjectOnPlane(footR.forward, hit.normal ), hit.normal));
           
            footPosR = hit.point;
        }
    }
}
