using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gui : MonoBehaviour
{
    public int vida;
    public Texture corazon;
    public int puntos = 0;
    public Texture municion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        for (int i = 0; i < vida; i++)
        {
            Rect poscora = new Rect(i * 40 + 200, 0, 50, 50);
            GUI.DrawTexture(poscora, corazon);
        }
        Rect poscanvida = new Rect(70, 0, 150, 150);
        GUI.skin.label.fontSize = 25;
        GUI.Label(poscanvida, "Vidas:" + vida);
        Rect poscanmun = new Rect(70, 0, 150, 150);
        GUI.skin.label.fontSize = 25;
        GUI.Label(poscanmun, "Munición:" + municion);
    }
}
