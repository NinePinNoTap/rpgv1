using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RotateCharacter : MonoBehaviour
{
    public GameObject TargetObj;
    public Slider RotationSlider;
	
    public void Rotate()
	{
        Vector3 rotation = new Vector3(0,0,0);
        rotation.y = RotationSlider.value;
        TargetObj.transform.rotation = Quaternion.Euler(rotation);
	}
}
