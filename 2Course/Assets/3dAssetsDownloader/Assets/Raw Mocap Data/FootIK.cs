﻿using System;
using UnityEngine;

public class FootIK : MonoBehaviour {
    //To access the Animator class
    protected Animator avatar;

    //To control whether to use the FootIK
    public bool ikActive = false;

    //To control how much will affect the transform of the IK
    public float transformWeigth = 1.0f;

    //To make change the value smoothly
    public float smooth = 10;

    //The position of my left foot
    public Transform footL;

    //A Offset to the foot not jam on the floor
    public Vector3 footLoffset;

    //I will use to control when affect the position during animation
    public float weightFootL;

    //The position of my right foot
    public Transform footR;

    //A Offset to the foot not jam on the floor
    public Vector3 footRoffset;

    //I will use to control when affect the position during animation
    public float weightFootR;

    //I'll save the Raycast hit position of the feet
    private Vector3 footPosL;
    private Vector3 footPosR;

    //To access my Collider
    private CapsuleCollider myCollider;

    //Default [center] of my collider
    private Vector3 defCenter;

    //Default [Height] of my collider
    private float defHeight;

    //[LayerMask] to define with layer my foot [RayCast] will collide
    public LayerMask rayLayer;

    // Use this for initialization
    void Start()
    {
        //Set the component
        avatar = GetComponent<Animator>();
        myCollider = GetComponent<CapsuleCollider>();

        //Save the values
        defCenter = myCollider.center;
        defHeight = myCollider.height;
    }

    void OnAnimatorIK(int layerIndex)
    {

        //If the [avatar] value is set
        if (avatar)
        {
            //If [ikActive] is [true]
            if (ikActive)
            {
                //Change the [transformWeigth] value to 1 smoothly
                if (transformWeigth != 1.0f)
                {
                    transformWeigth = Mathf.Lerp(transformWeigth, 1.0f, Time.deltaTime * smooth);

                    //If the value [transformWeigth] be greater than 0.99 it will be 1
                    if (transformWeigth >= 0.99)
                    {
                        transformWeigth = 1.0f;
                    }
                }

                //If the situation of the player is [Idle]
                if (avatar.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle") && myCollider.attachedRigidbody.velocity.magnitude < 0.1f)
                {

                    //Set how much will affect the IK [transform]
                    avatar.SetIKPositionWeight(AvatarIKGoal.LeftFoot, transformWeigth);
                    avatar.SetIKRotationWeight(AvatarIKGoal.LeftFoot, transformWeigth);
                    avatar.SetIKPositionWeight(AvatarIKGoal.RightFoot, transformWeigth);
                    avatar.SetIKRotationWeight(AvatarIKGoal.RightFoot, transformWeigth);

                    IdleIK();
                }

                //If the situation of the player is [Walk] or [Run]
                else if (avatar.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Walk") || avatar.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Run"))
                {

                    //Set how much will affect the IK [transform]
                    avatar.SetIKPositionWeight(AvatarIKGoal.LeftFoot, transformWeigth * weightFootL);
                    avatar.SetIKRotationWeight(AvatarIKGoal.LeftFoot, transformWeigth * weightFootL);
                    avatar.SetIKPositionWeight(AvatarIKGoal.RightFoot, transformWeigth * weightFootR);
                    avatar.SetIKRotationWeight(AvatarIKGoal.RightFoot, transformWeigth * weightFootR);

                    WalkRunIK();
                }
            }

            //If [ikActive] is not [true]
            else
            {

                //Change the [transformWeigth] value to 0 smoothly
                if (transformWeigth != 0.0f)
                {
                    transformWeigth = Mathf.Lerp(transformWeigth, 0.0f, Time.deltaTime * smooth);

                    //If the value [transformWeigth] be less than 0.01 it will be 0
                    if (transformWeigth <= 0.01)
                    {
                        transformWeigth = 0.0f;
                    }
                }

                //Set how much will affect the IK [transform]
                avatar.SetIKPositionWeight(AvatarIKGoal.LeftFoot, transformWeigth);
                avatar.SetIKRotationWeight(AvatarIKGoal.LeftFoot, transformWeigth);
                avatar.SetIKPositionWeight(AvatarIKGoal.RightFoot, transformWeigth);
                avatar.SetIKRotationWeight(AvatarIKGoal.RightFoot, transformWeigth);
            }
        }
    }
    void IdleIK()
    {
        //Create this value to use the [RaycastHit]
        RaycastHit hit;
        //Get the current position of the left foot
        footPosL = avatar.GetIKPosition(AvatarIKGoal.LeftFoot);
        //[RayCast] to the ground, to know the distance
        if (Physics.Raycast(footPosL + Vector3.up, Vector3.down, out hit, 2.0f, rayLayer))
        {
            //Show [Ray]
            Debug.DrawLine(hit.point, hit.point + hit.normal, Color.yellow);
            //Set the new position of IK
            avatar.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + footLoffset);
            //Set the new rotation of IK
            avatar.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(Vector3.Exclude(hit.normal, footL.forward), hit.normal));
            //Save the collision position
            footPosL = hit.point;
        }
        //Get the current position of the right foot
        footPosR = avatar.GetIKPosition(AvatarIKGoal.RightFoot);

        //[RayCast] to the ground, to know the distance
        if (Physics.Raycast(footPosR + Vector3.up, Vector3.down, out hit, 2.0f, rayLayer))
        {
            //Show [Ray]
            Debug.DrawLine(hit.point, hit.point + hit.normal, Color.green);
            //Set the new position of IK
            avatar.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + footRoffset);
            //Set the new rotation of IK
            avatar.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(Vector3.Exclude(hit.normal, footR.forward), hit.normal));
            //Save the collision position
            footPosR = hit.point;
        }
    }
    void WalkRunIK()
    {

        //Create this value to use the [RaycastHit]
        RaycastHit hit;
        //Get the current position of the left foot
        footPosL = avatar.GetIKPosition(AvatarIKGoal.LeftFoot);
        //[RayCast] to the ground, to know the distance
        if (Physics.Raycast(footPosL + Vector3.up, Vector3.down, out hit, 2.0f, rayLayer))
        {
            //Show [Ray]
            Debug.DrawLine(hit.point, hit.point + hit.normal, Color.yellow);

            //Set the new position of IK
            avatar.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + footLoffset);

            //Set the new rotation of IK
            avatar.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(Vector3.Exclude(hit.normal, footL.forward), hit.normal));

            //Save the collision position
            footPosL = hit.point;


        }

        //Get the current position of the right foot
        footPosR = avatar.GetIKPosition(AvatarIKGoal.RightFoot);

        //[RayCast] to the ground, to know the distance
        if (Physics.Raycast(footPosR + Vector3.up, Vector3.down, out hit, 2.0f, rayLayer))
        {
            //Show [Ray]
            Debug.DrawLine(hit.point, hit.point + hit.normal, Color.green);

            //Set the new position of IK
            avatar.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + footRoffset);
            //Set the new rotation of IK
            avatar.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(Vector3.Exclude(hit.normal, footR.forward), hit.normal));
            //Save the collision position
            footPosR = hit.point;
        }
    }
    void Update()
    {
        //If [ikActive] is [true]
        if (ikActive)
        {

            //If the situation of the player is [Idle] and [ikActive] is [true]
            if (avatar.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle"))
            {
                IdleUpdateCollider();
            }
            //If the situation of the player is [Walk] or [Run]
            else if (avatar.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Walk") || avatar.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Run"))
            {
                WalkRunUpdateCollider();
            }

            //If [ikActive] is not [true]
        }
        else
        {

            //Reset the values of my Collider
            myCollider.center = new Vector3(0, Mathf.Lerp(myCollider.center.y, defCenter.y, Time.deltaTime * smooth), 0);
            myCollider.height = Mathf.Lerp(myCollider.height, defHeight, Time.deltaTime * smooth);
        }
    }
    void IdleUpdateCollider()
    {
        //Create this value to calculate the height difference of the feet
        float dif;

        //Calculate the height difference of the feet
        dif = footPosL.y - footPosR.y;
        //Do not let the value be less than 0
        if (dif < 0) { dif *= -1; }

        //Change the Collider values depending on the value [dif]
        myCollider.center = new Vector3(0, Mathf.Lerp(myCollider.center.y, defCenter.y + dif, Time.deltaTime), 0);
        myCollider.height = Mathf.Lerp(myCollider.height, defHeight - (dif / 2), Time.deltaTime);
    }
    void WalkRunUpdateCollider()
    {
        //Create this value to use the [RaycastHit]
        RaycastHit hit;
        //Creating this value to save the height of the floor of the position I am
        Vector3 myGround = Vector3.zero;

        //Create this value to calculate the height difference
        Vector3 dif = Vector3.zero;

        //Check the height of the floor of the position I am
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, 3.0f, rayLayer))
        {
            //Save the value
            myGround = hit.point;
        }
        //RayCast to check the height of the position where I'm going
        if (Physics.Raycast(transform.position + (((transform.forward * (myCollider.radius))) + (myCollider.attachedRigidbody.velocity * Time.deltaTime)) + Vector3.up, Vector3.down, out hit, 2.0f, rayLayer))
        {
            //Show [Ray]
            Debug.DrawLine(transform.position + (((transform.forward * (myCollider.radius))) + (myCollider.attachedRigidbody.velocity * Time.deltaTime)) + Vector3.up, hit.point, Color.red);

            //Calculate the height difference between the height of the position I'm with the height of the position where I'm going
            dif = hit.point - myGround;

            //Do not let the value be less than 0
            if (dif.y < 0) { dif *= -1; }
        }

        //If the [dif] is less than 0.5
        if (dif.y < 0.5f)
        {
            //Change the Collider values depending on the value [dif]
            myCollider.center = new Vector3(0, Mathf.Lerp(myCollider.center.y, defCenter.y + dif.y, Time.deltaTime * smooth), 0);
            myCollider.height = Mathf.Lerp(myCollider.height, defHeight - (dif.y / 2), Time.deltaTime * smooth);
            //If the [dif] is not less than 0.5
        }
        else
        {
            //Reset the values of my Collider
            myCollider.center = new Vector3(0, Mathf.Lerp(myCollider.center.y, defCenter.y, Time.deltaTime * smooth), 0);
            myCollider.height = Mathf.Lerp(myCollider.height, defHeight, Time.deltaTime * smooth);
        }
    }
}
