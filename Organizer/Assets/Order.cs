using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Order : MonoBehaviour, IHasChanged
{
	public GameObject start, end;
	[SerializeField]
	Transform slots;

	Color startCol, endCol, diffCol;
	// Use this for initialization
	void Start ()
	{
		startCol = start.GetComponent<Image> ().color;
		endCol = end.GetComponent<Image> ().color;
		diffCol = endCol - startCol;

		HasChanged ();
	}
	

	#region IHasChanged implementation
	public void HasChanged ()
	{
		bool inOrder = true;
		Color prevColor = startCol;
		Color curColor;
		foreach(Transform slotTransform in slots) {
			GameObject item = slotTransform.GetComponent<SlotHandler> ().item;
			if (!item){
				inOrder = false;
				break;
			}else {
				curColor = item.GetComponent<Image>().color;
				if (curColor != prevColor){
					//check color order
					if (!checkOrder(curColor, prevColor)){
						print ("not in order");
						inOrder = false;
						break;
					}else {
						prevColor = curColor;
					}
				}
			}
		}
		if (inOrder) {
			print ("Organized!");
		}
	}
	#endregion

	bool checkOrder(Color curColor, Color prevColor) {
		if (sameSign ((curColor - prevColor).r, diffCol.r) 
			&& sameSign ((curColor - prevColor).g, diffCol.g)
			&& sameSign ((curColor - prevColor).b, diffCol.b))
			return true;
		else 
			return false;
	}

	bool sameSign(float a, float b){
		if (a >= 0 && b >= 0)
			return true;
		else if (a <= 0 && b <= 0)
			return true;
		else
			return false;
	}
}

namespace UnityEngine.EventSystems
{
	public interface IHasChanged: IEventSystemHandler
	{ 
		void HasChanged ();
	}
}