using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField] private float aliveTime;

    private void Start()
    {
        Destroy(gameObject,aliveTime);
    }
}
