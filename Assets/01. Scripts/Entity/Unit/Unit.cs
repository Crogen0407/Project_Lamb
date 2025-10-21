using Project_Lamb.Entities.FSM;
using UnityEngine;
using UnityEngine.AI;

namespace Project_Lamb.Entities.Unit
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Unit : Entity
    {
        public EntityStateListSO playerFSM;
        [HideInInspector] public Transform target;
        private EntityMover _mover;
        private StateMachine _stateMachine;

        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine(playerFSM, this);
        }

        protected override void AfterInitComponents()
        {
            base.AfterInitComponents();
            _mover = GetCompo<EntityMover>();
        }

        private void Start()
        {
            _stateMachine.Initialize(FSMState.Idle);
        }

        protected virtual void Update()
        {
            _stateMachine.UpdateStateMachine();
        }

        public void ChangeState(FSMState stateName)
        {
            _stateMachine.ChangeState(stateName);
        }
    }
}
