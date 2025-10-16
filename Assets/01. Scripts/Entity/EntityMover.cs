using UnityEngine;
using UnityEngine.AI;

namespace Project_Lamb.Entities
{
    public class EntityMover : MonoBehaviour, IEntityComponent
    {
        public Vector3 Velocity => _velocity;
        private Vector3 _velocity;
        private NavMeshAgent _navAgent;
        public NavMeshAgent Agent => _navAgent;
        public bool IsStopped => _navAgent.isStopped;
        public void Initialize(Entity entity)
        {
            _navAgent = entity.GetComponent<NavMeshAgent>();
        }

        public void SetDestination(Vector3 location)
        {
            _navAgent.SetDestination(location);
        }

        public void StopImmediately()
        {
            if (_navAgent.enabled == false) return;
            _navAgent.isStopped = true;
            _navAgent.ResetPath();
        }
        public void SetStoppingDistance(float distance)
        {
            _navAgent.stoppingDistance = distance;
        }
    }
}
