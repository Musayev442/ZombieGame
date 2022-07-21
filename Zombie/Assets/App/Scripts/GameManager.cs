using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UiManager uiManager;

    

    private void Awake()
    {
        if(instance==this)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

   

  

}

