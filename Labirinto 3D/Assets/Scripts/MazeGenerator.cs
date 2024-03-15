using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
        this.x = x;
        this.y = y;
    }

}