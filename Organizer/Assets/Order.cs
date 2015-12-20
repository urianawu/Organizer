using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Order : MonoBehaviour, IHasChanged
{
	[SerializeField]
	Transform slots;
	// Use this for initialization
	void Start ()
	{
		HasChanged ();
	}
	

	#region IHasChanged implementation
	public void HasChanged ()
	{
		string printInfo = "";
		foreach (Transform slotTransform in slots) {
			GameObject item = slotTransform.GetComponent<SlotHandler> ().item;
			if (item) {
				printInfo += item.GetComponent<Image>().color;
				printInfo += " - ";
			}
		}
		print (printInfo);
	}
	#endregion
}

namespace UnityEngine.EventSystems
{
	public interface IHasChanged: IEventSystemHandler
	{ 
		void HasChanged ();
	}
}