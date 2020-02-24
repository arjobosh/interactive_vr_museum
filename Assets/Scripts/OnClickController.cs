using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickController : MonoBehaviour
{
    public Quaternion next_rotation;
    public GameObject selector;
    public GameObject album_gallery;
    public GameObject game_gallery;
    public GameObject geo_gallery;
    public GameObject left_arrow;
    public GameObject right_arrow;
    public GameObject walls;
    public Text description;
    string curr_gallery;
    bool is_suspended;

    void Start()
    {
        next_rotation = selector.GetComponent<Transform>().rotation;
        is_suspended = false;
    }

    void Update()
    {
        if (selector.transform.position.y > 45.0f)
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

    private void SetPlateText(string plateText)
    {
        description.text = plateText;
    }

    public void OnEnter()
    {

        if ((selector.transform.eulerAngles.y > -2.0f && selector.transform.eulerAngles.y < 2.0f) ||
            (selector.transform.eulerAngles.y > 357.0f && selector.transform.eulerAngles.y < 360.0f))
        {
            SetPlateText("See Album Art gallery");
        }

        if ((selector.transform.eulerAngles.y > 88.0f && selector.transform.eulerAngles.y < 92.0f))
        {
            SetPlateText("See Game Art gallery");
        }

        if ((selector.transform.eulerAngles.y > 178.0f && selector.transform.eulerAngles.y < 182.0f))
        {
            SetPlateText("See Geometry gallery");
        }

        if ((selector.transform.eulerAngles.y > 268.0f && selector.transform.eulerAngles.y < 272.0f))
        {
            SetPlateText("Exit Museum");
        }   

        if (is_suspended)
        {
            SetPlateText("Click to see another gallery");
        }
    }

    public void OnExit()
    {
        SetPlateText("");
    }

    public void OnClick()
    {
        if (gameObject.CompareTag("LeftArrow") || gameObject.CompareTag("RightArrow"))
            StartCoroutine(ClickLerpRotation());

        if (gameObject.CompareTag("Selected"))
        {
            //Debug.Log(selector.transform.eulerAngles.y);
            if ((selector.transform.eulerAngles.y > -2.0f && selector.transform.eulerAngles.y < 2.0f) ||
                (selector.transform.eulerAngles.y > 357.0f && selector.transform.eulerAngles.y < 360.0f))
            {
                // set album_gallery active
                album_gallery.SetActive(true);
                game_gallery.SetActive(false);
                geo_gallery.SetActive(false);
            }

            if ((selector.transform.eulerAngles.y > 88.0f && selector.transform.eulerAngles.y < 92.0f))
            {
                // set game_gallery active
                album_gallery.SetActive(false);
                game_gallery.SetActive(true);
                geo_gallery.SetActive(false);
            }

            if ((selector.transform.eulerAngles.y > 178.0f && selector.transform.eulerAngles.y < 182.0f))
            {
                // set geometry_gallery active
                album_gallery.SetActive(false);
                game_gallery.SetActive(false);
                geo_gallery.SetActive(true);
            }

            if ((selector.transform.eulerAngles.y > 268.0f && selector.transform.eulerAngles.y < 272.0f))
            {
                // quit game
                album_gallery.SetActive(false);
                game_gallery.SetActive(false);
                geo_gallery.SetActive(false);
                walls.SetActive(false);
                Application.Quit();
            }

            walls.SetActive(true);
            StartCoroutine(ClickLerpTranslate());

        }
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
            next_pos = new Vector3(selector.transform.position.x, 50.0f, selector.transform.position.z);
            left_arrow.SetActive(false);
            right_arrow.SetActive(false);
        }
        else
        {
            next_pos = new Vector3(selector.transform.position.x, original_y, selector.transform.position.z);
            left_arrow.SetActive(true);
            right_arrow.SetActive(true);
        }

        //print(next_pos);

        while (elapsed_time < move_time)
        {
            selector.transform.position = Vector3.Lerp(selector.transform.position, next_pos, Time.deltaTime);

            elapsed_time += Time.deltaTime;

            yield return null;
        }
    }

    IEnumerator ClickLerpRotation()
    {
        float elapsed_time = 0f;
        float move_time = 5.0f;

        if (gameObject.CompareTag("LeftArrow"))
        {
            next_rotation *= Quaternion.AngleAxis(-90f, Vector3.up);
        }

        if (gameObject.CompareTag("RightArrow"))
        {
            next_rotation *= Quaternion.AngleAxis(90f, Vector3.up);
        }

        while (elapsed_time < move_time)
        {
            selector.GetComponent<Transform>().rotation = Quaternion.Lerp(
                selector.GetComponent<Transform>().rotation, next_rotation, Time.deltaTime);
            elapsed_time += Time.deltaTime;

            yield return null;
        }
    }
}
