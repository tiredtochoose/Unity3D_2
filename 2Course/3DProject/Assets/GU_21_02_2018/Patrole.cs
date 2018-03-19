using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace My3DProject
{
    public class Patrole
    {
        private List<Vector3> _points;
        private int _indexPoint;

        public Patrole()
        {
            var tempPoints = GameObject.FindGameObjectsWithTag("WayPoint");

            _points = tempPoints.Select(point => point.transform.position).ToList();
        }

        public void GenericPoint(NavMeshAgent agent, bool isRandom = true)
        {
            if (!agent) return;
            Vector3 resulPoint;

            if (isRandom)
            {
                int dis = Random.Range(25, 100);
                var randomPoint = Random.insideUnitSphere * dis;

                NavMeshHit hit;
                NavMesh.SamplePosition(agent.transform.position + randomPoint,
                    out hit, dis, NavMesh.AllAreas);

                resulPoint = hit.position;
            }
            else
            {
                if (_indexPoint < _points.Count - 1)
                {
                    _indexPoint++;
                }
                else
                {
                    _indexPoint = 0;
                }

                resulPoint = _points[_indexPoint];
            }

            agent.SetDestination(resulPoint);
            agent.stoppingDistance = 0.5f;
        }
    }
}

