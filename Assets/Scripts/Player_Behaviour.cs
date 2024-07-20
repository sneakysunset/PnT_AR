using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : MonoBehaviour
{
    public void OnTouch()
    {
        print(1);
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red, 1);
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if(hit.collider.TryGetComponent(typeof(Ennemi_Behaviour), out Component ennemi)) 
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
