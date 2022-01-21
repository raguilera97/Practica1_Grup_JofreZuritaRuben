using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public bool itsActive = false;
    

    private void Update()
    {
        Click();


    }
    private void Click()
    {
        if(Input.GetMouseButton(0) && itsActive == true)
        {
            StartCoroutine(WaitToClose());
            
        }
        
    }

    public void ChangeActive()
    {
        if (!itsActive)
        {
            gameObject.SetActive(true);
            itsActive = true;
        }
        
    }
    
    IEnumerator WaitToClose()
    {

        yield return new WaitForSeconds(.2f);
        gameObject.SetActive(false);
        itsActive = false;
    }

}
