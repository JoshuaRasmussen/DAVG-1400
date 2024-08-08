using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveDown : MonoBehaviour
{
    public float speedOfObj = 5.0f;
    private PlayerController playerController;


    // Update is called once per frame
    void Update()
    {
        // Continues to move the object down during gameplay
        transform.Translate(Vector3.forward * -speedOfObj * Time.deltaTime);
    
    }


}
