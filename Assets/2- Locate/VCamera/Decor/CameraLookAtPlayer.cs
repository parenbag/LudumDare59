using UnityEngine;

public class CameraLookAtPlayer : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(player != null)
        {
            CameraLook();
        }
    }

    void CameraLook()
    {
        Vector3 direction = player.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

}
