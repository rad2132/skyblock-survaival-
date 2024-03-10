using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private Transform Head;
    [SerializeField]
    private LayerMask Obstacles;

    private CharacterController characterController;

    [SerializeField]
    private float standingHeight = 1.7f;
    [SerializeField]
    private float bendingHeight = 1.0f;
    [SerializeField]
    private float cameraSensitivityMobile;
    [SerializeField]
    private float cameraSensitivityPC;
    [SerializeField]
    private float moveInputDeadZone;

    [SerializeField]
    private float bendMoveSpeed = 1f;
    [SerializeField]
    private float standingMoveSpeed = 3f;
    private float moveSpeed;

    private int leftFingerId, rightFingerId;
    private float halfScreenWidth;


    private Vector2 lookInput;
    private float cameraPitch;
    private float transformPitch;

    private Vector2 moveTouchStartPosition;

    private bool isBending = false;
    private Vector3 velocity;

    [SerializeField]
    private float gravityValue;
    [SerializeField]
    private float JumpHeight;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.height = standingHeight;
        moveSpeed = standingMoveSpeed;
        leftFingerId = -1;
        rightFingerId = -1;

        halfScreenWidth = Screen.width / 2;

        moveInputDeadZone = Mathf.Pow(Screen.height / moveInputDeadZone, 2);
    }

    private void Update()
    {
        
            Debug.DrawRay(Head.position, transform.right * velocity.x * 200 + transform.up * -0.5f + transform.forward * velocity.z * 200, Color.green);
            GetTouchInput();
    }

    void FixedUpdate()
    {
        if (rightFingerId != -1)
        {
            LookAround(lookInput);
        }
        ApplyYMovement();
    }

    void GetTouchInput()
    {
        // Iterate through all the detected touches
        for (int i = 0; i < Input.touchCount; i++)
        {

            Touch t = Input.GetTouch(i);

            // Check each touch's phase
            switch (t.phase)
            {
                case TouchPhase.Began:

                    if (t.position.x < halfScreenWidth && leftFingerId == -1)
                    {
                        // Start tracking the left finger if it was not previously being tracked
                        // leftFingerId = t.fingerId;

                        // Set the start position for the movement control finger
                        moveTouchStartPosition = t.position;
                    }
                    else if (t.position.x > halfScreenWidth && rightFingerId == -1)
                    {
                        // Start tracking the rightfinger if it was not previously being tracked
                        rightFingerId = t.fingerId;
                    }

                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:

                    if (t.fingerId == leftFingerId)
                    {
                        // Stop tracking the left finger
                        leftFingerId = -1;
                    }
                    else if (t.fingerId == rightFingerId)
                    {
                        // Stop tracking the right finger
                        rightFingerId = -1;
                    }

                    break;
                case TouchPhase.Moved:

                    // Get input for looking around
                    if (t.fingerId == rightFingerId)
                    {
                        lookInput = t.deltaPosition.normalized * cameraSensitivityMobile * Time.deltaTime;
                    }

                    break;
                case TouchPhase.Stationary:
                    // Set the look input to zero if the finger is still
                    if (t.fingerId == rightFingerId)
                    {
                        lookInput = Vector2.zero;
                    }
                    break;
            }
        }
    }

    public void LookAround(Vector2 input)
    {
        cameraPitch = Mathf.Clamp(cameraPitch - input.y, -90f, 90f);
        Quaternion originalCameraRotation = cameraTransform.localRotation;
        Quaternion originalTransformRotation = transform.rotation;
        transformPitch = transformPitch - input.x;
        cameraTransform.localRotation = Quaternion.Lerp(originalCameraRotation, Quaternion.Euler(-cameraPitch, 0, 0), 0.3f);
        transform.rotation = Quaternion.Lerp(originalTransformRotation, Quaternion.Euler(0, transformPitch, 0), 0.3f);
    }

    public void LookAroundPC(Vector2 input)
    {
        LookAround(-input * cameraSensitivityPC);
    }
    public void Move(Vector2 input)
    {
        
        input *= moveSpeed * Time.deltaTime;
        velocity.x = input.x;
        velocity.z = input.y;

        if (!IsAbleToMove())
        {
            return;
        }

        characterController.Move(transform.right * velocity.x + transform.forward * velocity.z);
    }

    public void Jump()
    {
        if (!characterController.isGrounded) return;

        velocity.y = Mathf.Sqrt(JumpHeight * -2.0f * gravityValue);
    }

    private void ApplyYMovement()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
            return;
        }
        velocity.y += gravityValue * Time.deltaTime;
        characterController.Move(Vector3.up * velocity.y);
    }

    public void Bend()
    {
        isBending = !isBending;
        if (isBending)
        {
            characterController.height = bendingHeight;
            moveSpeed = bendMoveSpeed;
        }
        else
        {
            moveSpeed = standingMoveSpeed;
            characterController.height = standingHeight;
        }
    }

    private bool IsAbleToMove()
    {
        if ( !characterController.isGrounded || !isBending)
        {
            return true;
        }
        RaycastHit hit;
        if (Physics.Raycast(Head.position, transform.right * velocity.x+transform.up * -0.5f + transform.forward * velocity.z,out hit , bendingHeight+0.5f, Obstacles))
        {
            Debug.Log(hit.collider.name);
            return true;
        }
        else 
        { 
            return false;
        }
    }
}
