using UnityEngine;
using UnityEngine.UI;
public class InputManger : MonoBehaviour
{
    public Text phaseDisplayText; 
    private Touch theTouch; 
    private float timeTouchEnded; 
    private float displayTime = 0.5f;

    
    
   void Update() 
   {

        if(Input.touchCount > 0 )        
        {            
            theTouch = Input.GetTouch(0);            
            if(theTouch.phase == TouchPhase.Ended)            
            {                
                print("Touched");
                
            }                      
        }  

   
   }
}
