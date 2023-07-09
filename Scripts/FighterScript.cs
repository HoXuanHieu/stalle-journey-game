using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterScript : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private Vector2 moveVectoity;
    public float speed = 5;
    float screenLeft,screenRight,screenTop,screenBottom;
    float colliderHalfHeight,colliderHalfWidth;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;
        
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Vector3 diff = collider.bounds.max - collider.bounds.min;
        colliderHalfWidth = diff.x / 2;
        colliderHalfHeight = diff.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVectoity = moveInput.normalized * speed;
        ClampInScreen();
    }
    private void FixedUpdate() {
      rigidbody.MovePosition(rigidbody.position + moveVectoity * Time.fixedDeltaTime);  
    }

    void ClampInScreen()
    {
        Vector3 position = transform.position;
        if (position.x - colliderHalfWidth < screenLeft) position.x = screenLeft + colliderHalfWidth;
        if (position.x + colliderHalfWidth > screenRight) position.x = screenRight - colliderHalfWidth;
        if (position.y + colliderHalfHeight > screenTop) position.y = screenTop - colliderHalfHeight;
        if (position.y - colliderHalfHeight < screenBottom) position.y = screenBottom + colliderHalfHeight;
        transform.position = position;
    }   
    
}
 