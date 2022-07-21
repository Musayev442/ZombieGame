using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AimController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator playerAnimController;
    [SerializeField] private Rig aimRig;
    [SerializeField] private UiManager uiManager;

    private Vector3 mOffset;
    private float mZCoord;
    private bool isAim;
    void Update()
    {
        if(isAim)
        {
            transform.position = GetMouseAsWorldPoint();
            SetZCoordinate();

        }
        if (Input.GetMouseButton(1))
        {
          playerAnimController.SetBool("IsAim", true);
          aimRig.weight = 100;
        }
        else
        {
          aimRig.weight = 0;
          playerAnimController.SetBool("IsAim", false);
        }
        

    }

     private void SetZCoordinate()
     {
        Vector3 aimPos = transform.position;
        float z = playerTransform.position.z;
        transform.position = new Vector3(aimPos.x, aimPos.y, z);
     }

    //  void OnMouseDown()
    // {
    //     // Store offset = gameobject world pos - mouse world pos
    //     mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    // }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        
        //uiManager.SetCrosshairPosition(mousePoint);
        
        // z coordinate of game object on screen
        mousePoint.z = Camera.main.WorldToScreenPoint(playerTransform.position).z;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void SetAim()
    {
        isAim = !isAim;
        Vector3 p = playerTransform.position;
        print(p);
        transform.position = new Vector3(p.x+5,p.y,p.z);
    }
    
}
