using System;
using UnityEngine;

public class BagController : MonoBehaviour
{
    public float speed = 8f;
    public float screenPadding = 0.1f;
    
    private float _xMin, _xMax, _horizontalInput;
    private Camera _mainCamera;
    
    void Start()
    {
        _mainCamera = Camera.main;
        CalculateBounds();
    }

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        //keep bag position within screen
        var targetPosition = Mathf.Clamp(transform.position.x + _horizontalInput * speed * Time.deltaTime, _xMin, _xMax);
        var newPosition = Mathf.Lerp(transform.position.x, targetPosition, 1);
        transform.position = new Vector2(newPosition, transform.position.y);
    }

    private void CalculateBounds()
    {
        //considering the entire width of the bag, not just its center
        var halfBag = GetComponent<SpriteRenderer>().bounds.size.x / 2f;
        //get the screen bounds
        _xMin = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + halfBag + screenPadding;
        _xMax = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfBag - screenPadding;
    }
}
