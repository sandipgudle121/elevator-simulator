using UnityEngine;
using UnityEngine.InputSystem;

public class ElevatorWorking : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private float targetY;

    void Start()
    {
        targetY = transform.position.y;
    }

    void Update()
    {
        GetFloorInput();
        MoveElevator();
    }

    void GetFloorInput()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.gKey.wasPressedThisFrame)
            targetY = 3f;

        else if (Keyboard.current.digit1Key.wasPressedThisFrame)
            targetY = 19f;

        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
            targetY = 35f;

        else if (Keyboard.current.digit3Key.wasPressedThisFrame)
            targetY = 51f;

        else if (Keyboard.current.digit4Key.wasPressedThisFrame)
            targetY = 67f;

        else if (Keyboard.current.digit5Key.wasPressedThisFrame)
            targetY = 83f;

        else if (Keyboard.current.digit6Key.wasPressedThisFrame)
            targetY = 99f;

        else if (Keyboard.current.digit7Key.wasPressedThisFrame)
            targetY = 115f;

        else if (Keyboard.current.digit8Key.wasPressedThisFrame)
            targetY = 131f;

        else if (Keyboard.current.digit9Key.wasPressedThisFrame)
            targetY = 147f;

        else if (Keyboard.current.digit0Key.wasPressedThisFrame)
            targetY = 163f;
    }

    void MoveElevator()
    {
        Vector3 targetPosition = new Vector3(
            transform.position.x,
            targetY,
            transform.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );
    }
}
