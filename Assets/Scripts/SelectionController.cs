using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    Transform[] childTransforms;
    GameObject[] childObjects;
    bool is_suspended;
    public GameObject left_arrow;
    public GameObject right_arrow;

    void Start()
    {
        childTransforms = GetComponentsInChildren<Transform>();
        childObjects = new GameObject[childTransforms.Length];

        for (int i = 0; i < childTransforms.Length; i++)
        {
            childObjects[i] = childTransforms[i].gameObject;
        }

        is_suspended = false;
    }

    void Update()
    {
        if (transform.position.y > 45.0f)
        {
            is_suspended = true;
            //Debug.Log("is_suspended");
        }
        else
        {
            is_suspended = false;
            //Debug.Log("!is_suspended");
        }
    }

    public void SelectionClicked()
    {
        // go to selected gallery
        // get rid of selector and arrows
        // lerp selector up
        // make clickable reset object

        StartCoroutine(ClickLerpTranslate());

    }

    IEnumerator ClickLerpTranslate()
    {
        float elapsed_time = 0f;
        float move_time = 5.0f;

        Vector3 next_pos;
        float original_y = 20.0f;
        //print(original_y);

        if (!is_suspended)
        {
            next_pos = new Vector3(transform.position.x, 50.0f, transform.position.z);
            left_arrow.SetActive(false);
            right_arrow.SetActive(false);
        }
        else
        {
            next_pos = new Vector3(transform.position.x, original_y, transform.position.z);
            left_arrow.SetActive(true);
            right_arrow.SetActive(true);
        }

        //print(next_pos);

        while (elapsed_time < move_time)
        {

            transform.position = Vector3.Lerp(transform.position, next_pos, Time.deltaTime);

            elapsed_time += Time.deltaTime;

            yield return null;
        }

    }
}
