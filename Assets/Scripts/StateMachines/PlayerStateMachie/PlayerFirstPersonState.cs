using Managers;
using UnityEngine;

namespace StateMachines.PlayerStateMachie
{
    public class PlayerFirstPersonState:PlayerBaseState
    {
        private Vector3 _direction;
        private static readonly int Running = Animator.StringToHash("Running");

        public PlayerFirstPersonState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override void Enter()
        {
            StateMachine.InputReader.OnJump += Jumping;
            StateMachine.InputReader.OnChangeCamera+=CameraChange;
            CameraManager.Instance.OpenCamera("FirstPerson");
            StateMachine.CharacterMesh.SetActive(false);

        }

        private void CameraChange()
        {
           StateMachine.SwitchState(new PlayerThirdPersonState(StateMachine));
        }

        private void Jumping()
        {
            StateMachine.SwitchState(new PlayerJumpState(StateMachine));
        }

        public override void Tick(float deltaTime)
        {
            _direction = CalculateMovement();
            StateMachine.Animator.SetFloat(Running,_direction.magnitude);
           
            if (_direction.magnitude > 0.01f)
            {
                SoundManager.Instance.Play(SoundNames.Run);
                float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(StateMachine.transform.eulerAngles.y, targetAngle,
                    ref StateMachine.turnSmoothVelocity, StateMachine.smoothTurnTime);

                StateMachine.transform.rotation = Quaternion.Euler(0, angle, 0);

                Move(_direction * StateMachine.movementSpeed, deltaTime);
            }
            else
            {
                SoundManager.Instance.Stop(SoundNames.Run);
            }

        }

        public override void Exit()
        {
            StateMachine.InputReader.OnJump -= Jumping;
            StateMachine.InputReader.OnChangeCamera-=CameraChange;
            StateMachine.CharacterMesh.SetActive(true);


        }
    }
}