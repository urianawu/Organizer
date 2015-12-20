using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public bool isDraggable = true;

	public static GameObject itemBeingDragged;
	Vector3 startPos;
	Transform startParent;
	Transform canvas;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPos = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		canvas = GameObject.FindGameObjectWithTag("UI Canvas").transform;
		transform.SetParent(canvas);
	}
	
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		if (isDraggable)
		transform.position = Input.mousePosition; 

	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;

		if (transform.parent == startParent) {
			transform.position = startPos;

		}
		if (transform.parent == canvas) {
			transform.position = startPos;
		}
	}
	
	#endregion



}
