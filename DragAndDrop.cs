using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;

public class DragAndDrop : MonoBehaviour
{
    public Rigidbody2D rb;
    public HingeJoint2D joint;
    public bool drag;
    public float rotationAmount = 2f;


    public UnityAction OnDrag;
    public UnityAction OnDrop;

    private Vector2 lastMousePos;
    private Vector2 lastlastMousePos;
    private Vector2 mouseDir;

    public bool dontDisable;

    public SpriteRenderer renderer;

    private void OnMouseDown()
    {
        //if (!renderer.isVisible) return;
        AudioManager.instance.PlaySound("organ_pickup 1");
        drag = true;
        rb.velocity = Vector3.zero;
        OnDrag?.Invoke();
    }


    private void OnMouseUp()
    {
        if (!drag) return;
        rb.AddForce(mouseDir * 5 * rb.mass, ForceMode2D.Impulse);
        drag = false;

        OnDrop?.Invoke();

    }

    private void FixedUpdate()
    {
        if (drag )
        {
            mouseDir = (lastMousePos - lastlastMousePos);

            lastlastMousePos = lastMousePos;
            lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Vein>() &&  (MousePos - rb.position).magnitude > 2)
            {
                OnMouseUp();
            }

            rb.MovePosition(MousePos);
            if (Input.GetKey(KeyCode.Z))
            {
                transform.Rotate(0, 0, rotationAmount);
            }
            else if (Input.GetKey(KeyCode.C))
            {
                transform.Rotate(0, 0, -rotationAmount);
            }
            rb.angularVelocity = 0;
        }
    }


    public void OnJointBreak2D(Joint2D joint)
    {
        //GetComponent<SpriteRenderer>().color = Color.green;
        joint.enabled = false;
    }

    private void OnDisable()
    {
        if (dontDisable) return;
        drag = false;
    }
}
