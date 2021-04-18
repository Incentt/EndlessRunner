using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    [Header("Position")]
    public Transform player;
    public float horizontalOffset;

    private void Update()
    {
        gameObject.transform.position = new Vector2(player.transform.position.x + horizontalOffset, gameObject.transform.position.y);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
