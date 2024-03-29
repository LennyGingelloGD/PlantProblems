﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouseLook : MonoBehaviour
{


    //Thank you: https://www.youtube.com/watch?v=blO039OzUZc

    Vector2 mouselook;
    Vector2 smoothV;
    public float sensitivity = 5f;
    public float smoothing = 2f;

    GameObject playerCharacter;


    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = this.transform.parent.gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouselook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouselook.y, Vector3.right);

        playerCharacter.transform.localRotation = Quaternion.AngleAxis(mouselook.x, playerCharacter.transform.up);


    }
}
