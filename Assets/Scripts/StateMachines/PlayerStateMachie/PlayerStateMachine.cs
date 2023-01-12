using UnityEngine;

namespace StateMachines.PlayerStateMachie
{
    public class PlayerStateMachine : StateMachine
    {
        [SerializeField] public float turnSmoothVelocity = 0;
        [SerializeField] public float smoothTurnTime = 0.03f;
        [SerializeField] public float movementSpeed = 10f;
        
        public InputReader InputReader { get; private set; }
        public CharacterController Controller { get; private set; }
        public Transform MainCameraTransform { get; private set; }
        public Animator Animator { get; private set; }
        public JumpPhysics JumpPhysics { get; private set; }
        public GameObject CharacterMesh { get; private set; }
        private void Awake()
        {
            Controller = GetComponent<CharacterController>();
            InputReader = GetComponent<InputReader>();
            if (Camera.main != null) MainCameraTransform = Camera.main.transform;
            JumpPhysics = GetComponent<JumpPhysics>();
            Animator = GetComponent<Animator>();
            CharacterMesh = transform.GetChild(0).gameObject;

        }
        
        private void Start()
        {
            SwitchState(new PlayerThirdPersonState(this));
        }
    }
}
