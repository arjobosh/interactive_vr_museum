using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour
{
    Renderer padRender;
    Color enteredColor;
    Color exitColor;
    GameObject player;
    Vector3 padPos;

    // Start is called before the first frame update
    void Start()
    {
        padRender = GetComponent<Renderer>();
        
        enteredColor = new Color(1.0f, 0.6f, 0.6f);     //255, 141, 141
        exitColor = new Color(1.0f, 0.3f, 0.3f);        //255, 76, 76
        player = GameObject.FindWithTag("Player");
        padPos = transform.position;
        padPos.y = 8.0f;
    }

    public void PadClick()
    {
        StartCoroutine(MoveToTarget());
    }

    public void PadEnter()
    {
        padRender.material.color = enteredColor;
    }

    public void PadExit()
    {
        padRender.material.color = exitColor;
    }
    
    IEnumerator MoveToTarget()
    {
        float elapsedTime = 0f;
        float moveTime = 2.0f;
        float temp = padPos.y;

        while(elapsedTime < moveTime)
        {
            if (gameObject.CompareTag("Platform"))
            {
                padPos.y = temp + gameObject.transform.position.y;
            }
            else
            {
                padPos.y = 8.0f;
            }
            player.transform.position = Vector3.Lerp(player.transform.position, padPos, (elapsedTime / moveTime));

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        yield return null;
    }
}
