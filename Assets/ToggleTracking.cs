using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTracking : MonoBehaviour
{
    // Start is called before the first frame update
	bool flag_pos;
    bool flag_rotate;
	public GameObject mainCamera;
	public GameObject mainCameraParent;
	public Vector3 prevParentPos;
	//public Vector3 prevChildPos;
	public GameObject centerEyeAnchor;
	
    void Start()
    {
        flag_pos = false;
		flag_rotate = false;
		prevParentPos = mainCameraParent.transform.position;
		//prevChildPos = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            flag_pos = !flag_pos;
            if (flag_pos)
            {
				prevParentPos = mainCameraParent.transform.position;
                disablePosTracking();
            }
            else
            {
                enablePosTracking();
            }
        }
		
		if (Input.GetKeyDown("h"))
        {
            flag_rotate = !flag_rotate;
            if (flag_rotate)
            {
                //disableRotateTracking();
            }
            else
            {
                //enableRotateTracking();
            }
        }
    }
	
	void disablePosTracking(){
		Vector3 currChildPos = centerEyeAnchor.transform.localPosition;
		mainCameraParent.transform.position =  new Vector3(prevParentPos.x-currChildPos.x, prevParentPos.y-currChildPos.y,prevParentPos.z-currChildPos.z);
		
		//prevParentPos = mainCameraParent.transform.position;
	}
	
	void enablePosTracking(){
		//mainCameraParent.transform.position =  centerEyeAnchor.localPosition;
	}
	
	void disableRotateTracking(){
		Vector3 mainCameraPos = mainCamera.transform.position;
		mainCameraParent.transform.position =  new Vector3(mainCameraPos.x, mainCameraPos.y, -mainCameraPos.z);
	}
	
	void enableRotateTracking(){
		Vector3 mainCameraPos = mainCamera.transform.position;
		mainCameraParent.transform.position =  new Vector3(mainCameraPos.x, mainCameraPos.y, mainCameraPos.z);
	}
}
