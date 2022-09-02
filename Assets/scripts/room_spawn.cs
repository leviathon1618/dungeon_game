using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class room_spawn : MonoBehaviour
{
    
    private List<string> room_points = new List<string>();
    private List<GameObject> room_obj = new List<GameObject>();
    private int x_coordinate;
    private int y_coordinate;
    public int room_count;
    public LineRenderer linerend;
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        room_points.Add("0,0");
        for (int i = 0; i < room_count; i++)
        {
            bool tryagain = true;
            
            while (tryagain == true)
            {
                string attempt = spawn_next();
                int count = 0;
                foreach (var item in room_points)
                {
                    if (item == attempt)
                    {
                        
                        count++;
                    }
                }
                if (count == 3)
                {
                    tryagain = false;
                    Debug.LogWarning("no more spaces available");
                }
                if (count == 0)
                {
                    int x_pos = Convert.ToInt32(attempt.Split(',')[0]);
                    int y_pos = Convert.ToInt32(attempt.Split(',')[1]);
                    GameObject room_object = Instantiate(point, new Vector2(x_pos, y_pos), Quaternion.identity);
                    room_object.name = $"{x_pos},{y_pos}";
                    room_points.Add(room_object.name);
                    room_obj.Add(room_object);
                    tryagain = false;
                }
            }

        }
        linerend.positionCount = room_points.Count-1;
        for (int i = 0; i < linerend.positionCount; i++)
        {
            linerend.SetPosition(i, room_obj[i].transform.position);
        }
    }

    public string spawn_next()
    {
        int direction = UnityEngine.Random.Range(0, 4);

        switch (direction)
        {
            //up
            case 0:
                x_coordinate = Convert.ToInt32(room_points[room_points.Count - 1].Split(',')[0]);
                y_coordinate = Convert.ToInt32(room_points[room_points.Count - 1].Split(',')[1]);
                return $"{x_coordinate},{y_coordinate + 1}";

            //down
            case 1:
                x_coordinate = Convert.ToInt32(room_points[room_points.Count - 1].Split(',')[0]);
                y_coordinate = Convert.ToInt32(room_points[room_points.Count - 1].Split(',')[1]);
                return $"{x_coordinate},{y_coordinate - 1}";

            //left
            case 2:
                x_coordinate = Convert.ToInt32(room_points[room_points.Count - 1].Split(',')[0]);
                y_coordinate = Convert.ToInt32(room_points[room_points.Count - 1].Split(',')[1]);
                return $"{x_coordinate-1},{y_coordinate}";

            //right
            case 3:
                x_coordinate = Convert.ToInt32(room_points[room_points.Count - 1].Split(',')[0]);
                y_coordinate = Convert.ToInt32(room_points[room_points.Count - 1].Split(',')[1]);
                return $"{x_coordinate+1},{y_coordinate}";

            default:
                return "";
        }

    }
}
