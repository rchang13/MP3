using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTracking : MonoBehaviour
{
    // Start is called before the first frame update
	bool flag_pos;
    bool flag_rotate;
	public Vector3 prevChildPos;
	public Quaternion prevParentAngle;
	public GameObject centerEyeAnchor;
	
    void Start()
    {
        flag_pos = false;
		flag_rotate = false;
		prevChildPos = centerEyeAnchor.transform.position;
		prevParentAngle = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
		if(flag_pos){
			disablePosTracking();
		}
		
		if(flag_rotate){
			disableRotateTracking();
		}
		
        if (Input.GetKeyDown(KeyCode.G))
        {
            flag_pos = !flag_pos;            
			prevChildPos = centerEyeAnchor.transform.position;
        }
		
		if (Input.GetKeyDown(KeyCode.H))
        {
            flag_rotate = !flag_rotate;
            prevParentAngle = centerEyeAnchor.transform.rotation;
        }
    }
	
	void disablePosTracking(){
		Vector3 currChildPos = centerEyeAnchor.transform.position;
		transform.position +=  (prevChildPos - currChildPos);
	}
	
	void disableRotateTracking(){
		Quaternion currChildAngle = centerEyeAnchor.transform.localRotation;
		transform.rotation = prevParentAngle * Quaternion.Inverse(currChildAngle);
	}
}
