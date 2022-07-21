using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private Animator enemyAnimatorController;
    [SerializeField] private Rigidbody enemyRb;
	[SerializeField] private Transform target;
    [SerializeField] private float playerSpeed = 3f;
    [SerializeField] private int zombieDamage = 13;


    private Quaternion m_Rotation = Quaternion.identity;
    private Vector3 _movement = Vector3.zero;
	float accuracy = 1.5f;

     public int ZombieDamage { get => zombieDamage; set => zombieDamage = value; }

     void LateUpdate () 
	{
        if(target !=null)
        {
		    Vector3 lookAtGoal = new Vector3(target.position.x, this.transform.position.y, 0);
		    this.transform.LookAt(lookAtGoal);
       

            if(Vector3.Distance(transform.position,lookAtGoal) > accuracy)
            {

                if(Vector3.Distance(transform.position,lookAtGoal) > accuracy )
                {
                    var step =  playerSpeed * Time.deltaTime; // calculate distance to move
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x,target.position.y,0), step);
                    enemyAnimatorController.SetBool ("IsWalking", true);

                }else
                {
                    enemyAnimatorController.SetBool ("IsWalking", false);

                }
            }
        }else
        {
            enemyAnimatorController.SetBool ("IsWalking", false);

        }        
        
	}

   


}




