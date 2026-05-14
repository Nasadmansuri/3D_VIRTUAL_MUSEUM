using UnityEngine;

public class AutoGate : MonoBehaviour
{
    public Transform gate;

    public float openAngle = 90f;
    public float speed = 2f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private bool openGate;

    void Start()
    {
        closedRotation = gate.rotation;

        openRotation = Quaternion.Euler(
            gate.eulerAngles + new Vector3(0, openAngle, 0)
        );
    }

    void Update()
    {
        Quaternion targetRotation =
            openGate ? openRotation : closedRotation;

        gate.rotation = Quaternion.Slerp(
            gate.rotation,
            targetRotation,
            Time.deltaTime * speed
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openGate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openGate = false;
        }
    }
}