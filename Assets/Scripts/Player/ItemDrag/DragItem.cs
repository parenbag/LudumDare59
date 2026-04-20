using UnityEngine;

public class DragItem : MonoBehaviour
{
    [SerializeField] private float pickUpRadius = 0.5f;
    [SerializeField] private LayerMask playerLayer = 1;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private float pickUpSmoothTime = 0.2f;

    [SerializeField] private SpecificMaterialChanger _VXMaterial;
    


    private bool isDragged = false;
    private Transform playerTransform;
    private Rigidbody rb;
    private Vector3 dragVelocity = Vector3.zero;

    // Таймер
    private bool isTimerActive = false;
    private float timer = 0f;
    private const float RELEASE_DELAY = 10f;

    // Наведения
    private bool isHovered = false;
    private Collider[] hoverResults = new Collider[1];

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckForHover(); 
        CheckForPickUpInput();

        if (isDragged)
        {
            UpdateDragPosition();

            if (Input.GetMouseButtonUp(0))
            {
                ReleaseItem();
            }
        }

        if (isTimerActive)
        {
            timer += Time.deltaTime;
            if (timer >= RELEASE_DELAY)
            {
                DisablePhysics();
            }
        }
    }

    void CheckForHover()
    {
        bool wasHovered = isHovered;

        int playersCount = Physics.OverlapSphereNonAlloc(transform.position, pickUpRadius, hoverResults, playerLayer);
        isHovered = playersCount > 0;

        if (isHovered && !wasHovered)
        {
            OnHoverEnter();
        }
        else if (!isHovered && wasHovered)
        {
            OnHoverExit();
        }
    }

    void OnHoverEnter() // Визуальная VX наведение
    {
        
        _VXMaterial.SetOutLine(true);



    }

    void OnHoverExit() // Убираем визуальные VX эффекты
    {
        
        _VXMaterial.SetOutLine(false);
    }

    void CheckForPickUpInput()
    {
        if (Input.GetMouseButtonDown(0) && !isDragged && isHovered)
        {
            TryPickUpItem();
        }
    }

    void TryPickUpItem()
    {
        if (isHovered && hoverResults[0] != null)
        {
            playerTransform = hoverResults[0].transform;

            HoldPoint holder = playerTransform.GetComponentInChildren<HoldPoint>();
            if (holder != null && holder.holdPoint != null)
            {
                holdPoint = holder.holdPoint;
                StartDragging();
            }
        }
    }

    void StartDragging()
    {
        isDragged = true;

        if (isTimerActive)
        {
            CancelTimer();
        }

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
        OnPickUp();
    }

    void UpdateDragPosition()
    {
        if (holdPoint == null) return;

        if (Vector3.Distance(transform.position, holdPoint.position) > 0.1f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, holdPoint.position,
                ref dragVelocity, pickUpSmoothTime);
        }
        else
        {
            transform.position = holdPoint.position;
            dragVelocity = Vector3.zero;
        }
        transform.rotation = holdPoint.rotation;
    }

    void ReleaseItem()
    {
        isDragged = false;

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.linearVelocity = dragVelocity;
        }

        playerTransform = null;
        holdPoint = null;
        OnRelease();
    }
    public void StopDraggingImmediately()
    {
        if (!isDragged) return;

        isDragged = false;

        if (rb != null)
        {
            rb.isKinematic = true;   // сразу "заморозить"
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;
        }

        playerTransform = null;
        holdPoint = null;

        CancelTimer(); // если не нужен таймер
    }

    void OnPickUp()
    {
        CancelTimer();
    }

    void OnRelease()
    {
        StartTimer();
    }

    void StartTimer()
    {
        isTimerActive = true;
        timer = 0f;
    }

    void CancelTimer()
    {
        isTimerActive = false;
        timer = 0f;
    }

    void DisablePhysics()
    {
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
        CancelTimer();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);
    }
}