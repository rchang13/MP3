using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStimuli : MonoBehaviour
{
    bool flag = false;
    bool flag_scale = false;
    // Start is called before the first frame update
    public GameObject red_sphere;
    public GameObject blue_one_sphere;
    public GameObject blue_two_sphere;
    public Vector3 red_position;
    public Vector3 blue_one_position;
    public Vector3 blue_two_position;
    public Vector3 red_scale;
    public Vector3 camera_position;
    public GameObject m_MainCamera;

    void Start()
    {

        red_sphere.SetActive(false);
        blue_one_sphere.SetActive(false);
        blue_two_sphere.SetActive(false);
        red_position = red_sphere.transform.position;
        blue_one_position = blue_one_sphere.transform.position;
        blue_two_position = blue_two_sphere.transform.position;
        red_scale = red_sphere.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            flag_scale = true;
            if (!flag)
            {
                red_sphere.SetActive(true);
                StartCoroutine(AppearCoroutine());
                flag = !flag;
            }
            else
            {
                red_sphere.SetActive(false);
                StartCoroutine(DisappearCoroutine());
                flag = !flag;

            }
        }

        if (flag_scale)
        {
            ScaleBlueBalls();
        }

    }
    void ScaleBlueBalls()
    {
        camera_position = m_MainCamera.transform.position;
        float distance_to_blue_one_sphere = Vector3.Distance(camera_position, blue_one_position);
        float distance_to_red_sphere = Vector3.Distance(camera_position, red_position);
        float distance_to_blue_two_sphere = Vector3.Distance(camera_position, blue_two_position);

        float ratio_blue_one = distance_to_blue_one_sphere / distance_to_red_sphere;
        float ratio_blue_two = distance_to_blue_two_sphere / distance_to_red_sphere;

        blue_one_sphere.transform.localScale = red_scale * ratio_blue_one;
        blue_two_sphere.transform.localScale = red_scale * ratio_blue_two;
    }
    IEnumerator AppearCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        blue_one_sphere.SetActive(true);
        blue_two_sphere.SetActive(true);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    IEnumerator DisappearCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        blue_one_sphere.SetActive(false);
        blue_two_sphere.SetActive(false);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
