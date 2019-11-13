using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class LegControl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float moveDistance;
    Collider c;
    // Start is called before the first frame update
    void Start()
    {
        moveDistance *= Camera.main.orthographicSize;
        c = transform.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
           if(hit.collider.Equals(c))
            {

            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("dsfjdsj");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 currentPos = this.transform.position;
        this.transform.localPosition = new Vector3(currentPos.x, mousePos.y, currentPos.z);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dsfjdsj");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 currentPos = this.transform.localPosition;
        this.transform.localPosition = new Vector3(currentPos.x, mousePos.y, currentPos.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("dsfjdsj");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 currentPos = this.transform.position;
        this.transform.localPosition = new Vector3(currentPos.x, mousePos.y, currentPos.z);
    }
}
