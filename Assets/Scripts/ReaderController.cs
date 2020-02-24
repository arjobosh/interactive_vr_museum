using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReaderController : MonoBehaviour
{
    public Text description;
    RectTransform descTransform;
    AudioSource song;

    // Start is called before the first frame update
    void Start()
    {
        description.text = "";
        descTransform = description.GetComponent<RectTransform>();
        song = GetComponent<AudioSource>();

    }

    public void PlateEnter()
    {
        string readerName = transform.parent.gameObject.name;

        switch (readerName)
        {
            case "Reader1":
                SetPlateText("Album art of Slauson Malone's\n<i>A Quiet Farwell, 2016-2018</i> (2019)" +
                    "\nClick to play a song! Click again to stop.");
                break;
            case "Reader2":
                SetPlateText("Album art of Lupe Fiasco's\n<i>Tetsuo & Youth</i> (2015)" +
                    "\nClick to play a song! Click again to stop.");
                break;
            case "Reader3":
                SetPlateText("Album art of Milo's\n<i>So The Flies Don't Come</i> (2015)" +
                    "\nClick to play a song! Click again to stop.");
                break;
            case "Reader4":
                SetPlateText("Album art of Lorde's\n<i>Melodrama</i> (2017)" +
                    "\nClick to play a song! Click again to stop.");
                break;
            case "Reader5":
                SetPlateText("Album art of Mavi's\n<i>Let The Sun Talk</i> (2019)" +
                    "\nClick to play a song! Click again to stop.");
                break;
            case "Reader6":
                SetPlateText("Album art of FKA Twigs'\n<i>LP1</i> (2014)" +
                    "\nClick to play a song! Click again to stop.");
                break;
            case "Reader7":
                SetPlateText("Album art of Open Mike Eagle's\n<i>Brick Body Kids Still Daydream</i> (2017)" +
                    "\nClick to play a song! Click again to stop.");
                break;
            case "Reader8":
                SetPlateText("Album art of Earl Sweatshirt's\n<i>Feet of Clay</i> (2019)" +
                    "\nClick to play a song! Click again to stop.");
                break;
            case "Reader9":
                SetPlateText("Album art of Armand Hammer's\n<i>Rome</i> (2017)" +
                    "\nClick to play a song! Click again to stop.");
                break;
            case "GameReader1":
                SetPlateText("Hollow Knight (2017)");
                break;
            case "GameReader2":
                SetPlateText("Bastion (2011)");
                break;
            case "GameReader3":
                SetPlateText("Gris (2018)");
                break;
            case "GameReader4":
                SetPlateText("Pokemon Emerald (2004)");
                break;
            case "GeoReader1":
                SetPlateText("The Mandelbrot Set");
                break;
            case "GeoReader2":
                SetPlateText("A Julia Set");
                break;
            case "GeoReader3":
                SetPlateText("The Fibonacci Sequence");
                break;
            case "GeoReader4":
                SetPlateText("The Sierpinski Gasket");
                break;
            default:    
                description.text = "";
                break;
        }
    }
    
    private void SetPlateText(string plateText)
    {
        description.text = plateText;
    }

    public void PlateClick()
    {
        if (song.isPlaying)
        {
            song.Stop();
        }
        else
        {
            song.Play();
        }
    }

    public void PlateExit()
    {
        description.text = "";
    }
}
