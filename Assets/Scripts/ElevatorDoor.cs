using UnityEngine;
using UnityEngine.InputSystem;

public class ElevatorDoor : MonoBehaviour
{
    [Header("Door Panels")]
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;

    [Header("Door Settings")]
    [SerializeField] private float doorSpeed = 5f;

    private Vector3 leftClosedPosition;
    private Vector3 rightClosedPosition;

    private Vector3 leftOpenPosition;
    private Vector3 rightOpenPosition;

    private bool isOpen = false;

    void Start()
    {
        // Current positions = closed positions
        leftClosedPosition = leftDoor.localPosition;
        rightClosedPosition = rightDoor.localPosition;

        // Open positions
        leftOpenPosition = leftClosedPosition + Vector3.forward * 7f;
        rightOpenPosition = rightClosedPosition + Vector3.back * 7f;
    }

    void Update()
    {
        HandleInput();
        MoveDoors();
    }

    void HandleInput()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            isOpen = true;
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isOpen = false;
        }
    }

    void MoveDoors()
    {
        Vector3 leftTarget = isOpen ? leftOpenPosition : leftClosedPosition;
        Vector3 rightTarget = isOpen ? rightOpenPosition : rightClosedPosition;

        leftDoor.localPosition = Vector3.MoveTowards(
            leftDoor.localPosition,
            leftTarget,
            doorSpeed * Time.deltaTime
        );

        rightDoor.localPosition = Vector3.MoveTowards(
            rightDoor.localPosition,
            rightTarget,
            doorSpeed * Time.deltaTime
        );
    }
}
