using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private float range = 10f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private LineRenderer gunLine;
    

    private Ray shootRay;
    private RaycastHit shootHit;
    private int shootableMask;

    private void Start()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        GameObject bulletLineTransform = GameObject.FindGameObjectWithTag("BulletLine");
        shootRay.origin = bulletLineTransform.transform.position;
        shootRay.direction = bulletLineTransform.transform.forward;
        gunLine.SetPosition(0,transform.position);

        if(Physics.Raycast(shootRay,out shootHit, range, shootableMask))
        {
            gunLine.SetPosition(1,shootHit.point);

            if(shootHit.collider.CompareTag("Enemy"))
            {
                shootHit.collider.GetComponent<Health>().Damage(23);
            }
        }else
        {
            gunLine.SetPosition(1,shootRay.origin+shootRay.direction*range);
        }
    }

}
