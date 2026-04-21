using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Animator animator;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            animator.SetBool("Open", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Open", false);
        }
    }
}
