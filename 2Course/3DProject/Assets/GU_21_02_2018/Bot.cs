
using UnityEngine;
using UnityEngine.AI;

namespace My3DProject
{
    public class Bot : BaseObjectScene, ISetHp
    {
        private NavMeshAgent _agent;
        [SerializeField] private Transform _target;
        private bool _isTarget;
        private float _hp = 100;
        private bool _isDeath;

        private Patrole _patrol;
        private float _curTime;
        private const float TIMEWAIT = 5;

        [SerializeField] private Vision _vision;

        [SerializeField] private BaseWeapon _weapon;


        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _patrol = new Patrole();
        }

        private void Update()
        {
            if (_isDeath) return;

            if (_isTarget)
            {
                _agent.SetDestination(_target.position);
                _agent.stoppingDistance = 3;
                if (_vision.VisionMath(Transform, _target))
                {
                    if (_weapon != null) _weapon.Fire(_weapon.Ammunition);
                    //else
                    //{


                    //}
                }
                else
                {
                    _isTarget = false;
                    _patrol.GenericPoint(_agent, false);
                }
            }
            else
            {
                if (!_agent.hasPath)
                {
                    _curTime += Time.deltaTime;
                    if (_curTime >= TIMEWAIT)
                    {
                        _curTime = 0;
                        _patrol.GenericPoint(_agent, false);
                    }
                }

                if (_vision.VisionMath(Transform, _target))
                {
                    _isTarget = true;                    
                }
            }
        }

        public float Hp
        {
            get { return _hp; }
            private set { _hp = value; }
        }

        public void SetHp(InfoOfCollision info)
        {
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                _isDeath = true;
                _agent.enabled = false;

                foreach (var child in GetComponentsInChildren<Transform>())
                {
                    child.parent = null;
                    var tempRigidbody = child.GetComponent<Rigidbody>();
                    if (!tempRigidbody)
                    {
                        tempRigidbody = child.gameObject.AddComponent<Rigidbody>();
                    }
                    tempRigidbody.AddForce(transform.forward * Random.Range(50, 100));
                }
            }
        }
    }
}
