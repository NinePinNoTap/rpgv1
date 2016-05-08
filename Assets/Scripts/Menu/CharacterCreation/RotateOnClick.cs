using UnityEngine;
using System.Collections;

public class RotateOnClick : MonoBehaviour
{
    public GameObject Target;
    public float RotationSpeed = 10;
    private bool IsClicked = false;
	
	void Update ()
	{
        if(IsClicked)
        {
            Target.transform.Rotate(new Vector3(0, RotationSpeed, 0));
        }
	}

    void OnMouseDown()
    {
        IsClicked = true;
    }
   
    void OnMouseUp()
    {
        IsClicked = false;
    }
}
