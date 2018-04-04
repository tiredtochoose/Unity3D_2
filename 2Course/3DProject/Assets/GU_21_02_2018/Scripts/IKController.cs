using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class IKController : MonoBehaviour {

    private Animator _animator;
    private Transform _footR;
    private Transform _footL;

    private float _weightFootR;
    private float _weightFootL;

    private Vector3 _rFootPos;
    private Vector3 _lFootPos;

    private Quaternion _rFootRot;
    private Quaternion _lFootRot;

    [SerializeField] private float _rayLength;
    [SerializeField] private LayerMask _rayLayer;

    private float _smoothness = 0.5f;



    //private Animator _animator;
    //[SerializeField] private bool _isActive;
    //[SerializeField] private Transform _obj1;
    //[SerializeField] private Transform _obj2;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();

        _footR = _animator.GetBoneTransform(HumanBodyBones.RightFoot);
        _footL = _animator.GetBoneTransform(HumanBodyBones.LeftFoot);

    }

    private void Update()
    {
        RaycastHit rightHit;
        RaycastHit leftHit;

        var rPos = _footR.TransformPoint(Vector3.zero);
        var lPos = _footL.TransformPoint(Vector3.zero);

        if (Physics.Raycast(rPos, Vector3.down, out rightHit,
            _rayLength, _rayLayer))
        {
            _rFootPos = Vector3.Lerp(_footR.position,
                rightHit.point, _smoothness);
        }
    }


    private void OnAnimatorIK()
    {
        //if (!_isActive) return; 
        //if (_obj1)
        //{
        //    _animator.SetLookAtWeight(1);
        //    _animator.SetLookAtPosition(_obj1.position);
        //}

        //if (_obj2)
        //{
        //    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        //    _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

        //    _animator.SetIKPosition(AvatarIKGoal.LeftHand, _obj2.position);
        //    _animator.SetIKRotation(AvatarIKGoal.LeftHand, _obj2.rotation);


        //}
    }

   


}
