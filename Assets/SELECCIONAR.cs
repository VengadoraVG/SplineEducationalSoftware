using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SELECCIONAR : MonoBehaviour {
	Image imagen;
	public void resaltar()
	{
		int cont = 0;
		if (cont == 0) {
			imagen.color = new Color (0.99f, 1, 0.38f);
			cont = 1;
		}
		else
		{
		imagen.color =new Color(1,1,1);
			cont =0;
		}
		
	}
	void Start () 
	{
		imagen = GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
