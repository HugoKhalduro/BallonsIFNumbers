using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finger : MonoBehaviour
{
    Rigidbody2D rig;
    CircleCollider2D CircleColl;

    public bool isBlowing;

    Camera  cam;

    Vector2 LastPos;

    public float minVelocityCut;

    public GameObject LinePrefab;
    private GameObject currentLine;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; 
        rig = GetComponent<Rigidbody2D>();
        CircleColl = GetComponent<CircleCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Comeca a Logica do Corte
            StartCut();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Para a logica do corte
            StopCut();
        }
        if(isBlowing){
            UpdateCut();
        }
    }
    void UpdateCut(){
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rig.position = newPos;

        float velocity = (newPos - LastPos).magnitude * Time.deltaTime;

        if(velocity > minVelocityCut){
            CircleColl.enabled = true;
        }else{
            CircleColl.enabled = false;
        }

        LastPos = newPos;
    }
    void StartCut(){
        isBlowing = true;

        currentLine = Instantiate(LinePrefab, transform);

        CircleColl.enabled = true;
        LastPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void StopCut(){
        isBlowing = false;
        currentLine.transform.SetParent(null);
        Destroy(currentLine, 1f);
        CircleColl.enabled = false;
    }
}
