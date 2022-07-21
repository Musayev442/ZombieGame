using UnityEngine;

public class PlayerMovmentController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimController;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float turnSpeed = 20f;
    [SerializeField] private float playerSpeed = 3f;
    [SerializeField] Health health;
   
    
    private Quaternion m_Rotation = Quaternion.identity;
    private Vector3 _movement = Vector3.zero;
    private  float _horizontal;
    private float _vertical;
    

    private void Update()
    {
        _horizontal = Input.GetAxis ("Horizontal");
        _vertical = Input.GetAxis ("Vertical");
        
    }

   
    void FixedUpdate ()
    {
        
        _movement.Set(-_horizontal, 0f, 0);
        _movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (_horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (_vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        playerAnimController.SetBool ("IsWalking", isWalking);
        
        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, _movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);

        OnAnimatorMove();
    }
    
    public Quaternion GetFacing()
    {
        return m_Rotation;
    }
    private void OnAnimatorMove ()
    {
        playerRb.MovePosition (playerRb.position + _movement * Time.deltaTime * playerSpeed);
        playerRb.MoveRotation (m_Rotation);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            health.Damage(enemyController.ZombieDamage);
            GameManager.instance.uiManager.SetHealthBarSlider((float)health.GetHealth/100f);
            Destroy(other.gameObject);
            if(health.GetHealth<=0)
            {
                GameManager.instance.uiManager.GameOver();
            }
        }
    }

    
}
