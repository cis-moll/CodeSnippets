using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

public class RunningOrgan : MonoBehaviour
{
    int speed;
    float detectionRange = 0.5f;
    Rigidbody2D rb;
    [SerializeField] Collider2D klatka;
    bool isInCage;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        rb = GetComponent<Rigidbody2D>();
        isInCage = false;
        GetComponent<DragAndDrop>().enabled = false;
    }

    private void Update()
    {
        if (!isInCage)
        {
            RunAway();
        }
    }

    private void RunAway()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 moveDirection = (Vector2)transform.position - MousePos;
        rb.velocity = moveDirection.normalized * speed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == klatka && (transform.position - klatka.transform.position).magnitude < detectionRange)
        {
            isInCage = true;
            speed = 0;
            transform.position = collision.transform.position;
            GetComponent<DragAndDrop>().enabled = true;
            klatka.transform.SetParent(transform);
            this.enabled = false;
        }
    }

    // Dodatkowy pomysł - jeśli naciśnie się na robaka za dużo razy wybucha i zabija pacjenta odrazu

}
    
