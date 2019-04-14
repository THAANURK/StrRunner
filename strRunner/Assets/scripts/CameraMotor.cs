using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
 private Transform lookAt;
 private Vector3 StartOffset;
 private Vector3 moveVector;

 private float transition = 0.0f;
 private float animationDuration = 3.0f;
 private Vector3 animationOffset = new Vector3(0,5,5);

    // Start is called before the first frame update
    void Start()
    {
       lookAt =  GameObject.FindGameObjectWithTag ("Player").transform; 
       StartOffset = transform.position - lookAt.position;
    }
    // Update is called once per frame
    void Update()
    {
      moveVector = lookAt.position + StartOffset;

      moveVector.x = 0;
      moveVector.y = Mathf.Clamp(moveVector.y,3,5);
    
     if (transition > 1.0f)
       {
         transform.position = moveVector;    
       }
        else {
            // start animation
    transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
    transition += Time.deltaTime * 1 / animationDuration;
   //  transform.lookAt (lookAt.position + Vector3.up);
}
      
    }

}