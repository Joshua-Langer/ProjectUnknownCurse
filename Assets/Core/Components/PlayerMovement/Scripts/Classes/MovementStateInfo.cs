using UnityEngine;

namespace LangerNetwork
{
    public partial struct MovementStateInfo
    {
        public Vector3 position;
        public Quaternion rotation;

        public float verticalMovementInput;
        public float horizontalMovementInput;
        public bool movementRunning;

        public bool movementStrafeLeft;
        public bool movementStrafeRight;

        public MovementStateInfo(Vector3 _position, Quaternion _rotation, float _verticalMovementInput, float _horizontalMovementInput, bool _movementRunning, bool _movementStrafeLeft, bool _movementStrafeRight)
        {
            position = _position;
            rotation = _rotation;
            verticalMovementInput = _verticalMovementInput;
            horizontalMovementInput = _horizontalMovementInput;
            movementRunning = _movementRunning;
            movementStrafeLeft = _movementStrafeLeft;
            movementStrafeRight = _movementStrafeRight;
        }
    }

}