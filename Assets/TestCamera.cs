using UnityEngine;
using System.Collections;

public class TestCamera : MonoBehaviour {

    private Quaternion baseRotation;
    private int rotationAngle;
    private WebCamTexture webcamTexture;

    public IEnumerator Start() 
    {
        webcamTexture = new WebCamTexture();
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play(); 
        baseRotation = transform.rotation;
        while(true) 
        {
            yield return new WaitForSeconds(1);
            //Debug.Log(webcamTexture.videoRotationAngle + " degrees");
            Debug.Log(webcamTexture.width);
            Debug.Log(webcamTexture.height);
        }
    }

    public void Update()
    {
        if(rotationAngle != webcamTexture.videoRotationAngle)
        {
            rotationAngle = webcamTexture.videoRotationAngle;
            transform.rotation = baseRotation * 
                    Quaternion.AngleAxis(-rotationAngle, 
                    Vector3.forward);
        }
    }

    public IEnumerator Shoot() 
    {
        yield return new WaitForEndOfFrame();

    }
}
