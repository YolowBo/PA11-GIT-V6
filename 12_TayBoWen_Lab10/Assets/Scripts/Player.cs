using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Camera MainCamera;
    private Vector3 screenbound;
    private float ObjectW;
    private float ObjectH;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        screenbound = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        ObjectW = transform.GetComponent<MeshRenderer>().bounds.extents.x;
        ObjectH = transform.GetComponent<MeshRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, screenbound.y * -1 + ObjectH, screenbound.y - ObjectH);

        transform.position = viewPos;


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
