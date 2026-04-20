using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] PlayerStateManager _playerStateManager;


    public CharacterController controller;

    [SerializeField] private float speed;
    [SerializeField] public float speedPublic = 8f;   //публ скорость, менять
    private float _gravity = -19.62f;
    [SerializeField] private float jumpHeight = 2f;

    [SerializeField] private Transform groundCheck;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;


    float speedPercent;


    Vector3 velocity;
    bool isGrounded;

    //SFX ===

    [SerializeField] private LayerMask groundMaskStone;
    bool isGroundedStone;
    [SerializeField] private LayerMask groundMaskWood;
    bool isGroundedWood;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] StoneWalkSoundsClips;
    [SerializeField] AudioClip[] WoodWalkSoundsClips;

    float stepTimer = 0;



    //SmothTo ===

    private Vector3 _moveTarget;
    

    void Update()
    {
       

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        isGroundedStone = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskStone);
        isGroundedWood = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskWood);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        _playerStateManager.AWalk((Mathf.Abs(x) > 0.4f || Mathf.Abs(z) > 0.4f));

        if (x == 1 && Input.GetKey(KeyCode.LeftShift) && !_playerStateManager._IsUse || z == 1 && Input.GetKey(KeyCode.LeftShift) && !_playerStateManager._IsUse || x == -1 && Input.GetKey(KeyCode.LeftShift) && !_playerStateManager._IsUse)
        {
            
            if (isGrounded)
            {
                speed = speedPublic + Percent(speedPublic, 15f, speedPercent);

                _playerStateManager._isRunning = true;
            }
            else
            {
                speed = speedPublic - Percent(speedPublic, 20f, speedPercent);
            }


        }
        else
        {
            if (isGrounded)
            {
                speed = speedPublic;
            }
            else
            {
                speed = speedPublic - Percent(speedPublic, 50f, speedPercent);
            }
            _playerStateManager._isRunning = false;

        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) && _playerStateManager._aWalk)
        {
            speed = speedPublic / 1.3f ;
        }


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded && !_playerStateManager._IsUse)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * _gravity);

        }

        velocity.y += _gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);




        if (_playerStateManager._aWalk && isGrounded)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= 0.45f && isGroundedStone)
            {
                PlayStoneFootstep();
                stepTimer = 0; 

            }
            if (stepTimer >= 0.5f && isGroundedWood)
            {
                PlayWoodFootstep();
                stepTimer = 0;

            }
        }

    }

    

    // SFX

    void PlayStoneFootstep()
    {
        if (StoneWalkSoundsClips.Length > 0)
        {
            AudioClip randomClip = StoneWalkSoundsClips[Random.Range(0, StoneWalkSoundsClips.Length)];
            audioSource.PlayOneShot(randomClip, 0.3f);
        }
    }

    void PlayWoodFootstep()
    {
        if (WoodWalkSoundsClips.Length > 0)
        {
            AudioClip randomClip = WoodWalkSoundsClips[Random.Range(0, WoodWalkSoundsClips.Length)];
            audioSource.PlayOneShot(randomClip, 0.35f);
        }
    }


    float Percent(float n, float percent, float outparam)
    {
        outparam = n / 100 * percent;

        return outparam;
    }
}
