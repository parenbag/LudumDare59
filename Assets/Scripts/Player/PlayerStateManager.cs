using UnityEngine;

public class PlayerStateManager : MonoBehaviour  // Состояния персонажа и его анимации
{
    public static PlayerStateManager Instance { get; set; }


    //===== Обращение к скриптам 

    [SerializeField] private MouseLock _mouseLock;
    [SerializeField] Movement _movement;



    [SerializeField] Animator anim;



    //===== - Состояния

    public bool _aWalk { get;  set; }
    public bool _isRunning { get; set; }

    public bool _IsUse { get; private set; }

    //===== - Значения

    void Awake()
    {
        Instance = this;
    }
    

    void Start()
    {
        
    }
    void Update()
    {
        
    }





    public void PlayerUseObj(bool active)
    {
        _IsUse = active;
        _aWalk = !active;   
    }

    public void AWalk(bool active)
    {
        if (!_IsUse)
        {
            _movement.speedPublic = 8f;
           
            _aWalk = active;

            if (anim != null)
            {
                anim.SetBool("IsWalk", active);
            }
        }
        if (_IsUse)
        {
            if (anim != null)
                anim.SetBool("IsWalk", false);
        }
        
    }

    public void ClosetUP(bool active, GameObject targetOBJ)
    {
        _IsUse = active;
        _mouseLock._isUse_Camera = active;
        
        _movement.speedPublic = 2f;



    }

    public void ItemUse(bool active)
    {
        _IsUse = active;
    }


    void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }
}
