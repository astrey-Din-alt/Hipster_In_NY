using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

    public Transform[] backgrounds;     // A list of all backgrouns to be parralax
    private float[] parallaxScales;     // Thу proportion of the camera`s movement to move the background by 
    public float smoothing = 1f;       // How smooth the paralax is going to be. Make shure to set this above 0.

    private Transform cam;              // Reference to the main cameras transform.
    private Vector3 previousCamPos;     // The position of the camera of the previous frame.

    // Is called before start. Great for References. 
    void Awake() { 
        // set up the reference
        cam = Camera.main.transform;
    }


	// Use this for initialization
	void Start () {
	    // The previous frame had the current frame`s camera position.
        previousCamPos = cam.position;
        // Asining corespnding parallaxScales
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        // For each background
        for (int i = 0; i < backgrounds.Length; i++) { 
            // The parallax is the opposite of the camera movement because the previouse frame multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // set a target x position which the current position plus parralax.
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //crate a target position which is backgrouds position is x position.
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            
            //fade between current position and the current position using lerp.
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
                     
        }

        //set the previousCamPos to the cameras`s position at the end of the frame
        previousCamPos = cam.position;
	}
}
