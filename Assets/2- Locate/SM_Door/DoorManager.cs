using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Animator animator;
    public bool IsOpen;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && IsOpen) 
        {
            animator.SetBool("Open", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && IsOpen)
        {
            animator.SetBool("Open", false);
        }
    }
}
