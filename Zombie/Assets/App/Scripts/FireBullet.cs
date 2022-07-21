using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private float timeBetweenBullets = 0.15f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private PlayerMovmentController playerMovmentController;
    
    private float nextBullet = 0;


    [SerializeField] private AudioSource gunMuzzle;
    [SerializeField] private AudioClip shootSound;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && nextBullet < Time.time)
        {
            nextBullet = Time.time + timeBetweenBullets;
           
            var bullet = Instantiate(bulletPrefab,transform.position,playerMovmentController.GetFacing());
            gunMuzzle.clip = shootSound;
            gunMuzzle.Play();
        }
    }
}
