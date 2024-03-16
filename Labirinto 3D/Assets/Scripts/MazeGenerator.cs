using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {
    [Range(5, 500)]
    public int mazeWidth = 5, mazeHeigth = 5; //Dimensoes do labirinto 
}

public class MazeCell {
    public bool visited;
    public int x, y;
    
    public bool topWall;
    public bool leftWall;
    
    public Vector2Int position {
        get {
            return new Vector2Int(x, y);
        }
    }

    public MazeCell (int x, int y) {
        
        // Coordenadas da celula no labirinto
        this.x = x;
        this.y = y;

        //Verifica se o algoritmo ja visitou ou não a celula
        visited = false;

        //Todas as paredes são adicionadas ate que o algoritmo as remova
        topWall = leftWall = true;
    }

}