using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class room_spawn_v2 : MonoBehaviour
{
    public GameObject point1;
    public List<string> room_points = new List<string> ();
    public List<GameObject> spawn_list = new List<GameObject>();
    public List<GameObject> rooms = new List<GameObject>();
    public List<string> optiontest = new List<string>();
    private List<GameObject> options = new List<GameObject>();
    public List<string> offset = new List<string>();
    private List<string> shape1 = new List<string> ();
    private List<string> shape2 = new List<string>();
    private List<string> shape3 = new List<string>();
    private List<string> shape4 = new List<string>();
    private List<string> shape5 = new List<string>();
    private List<string> shape6 = new List<string>();
    private int total_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //big square
        shape1.Add("-1,1");
        shape1.Add("0,1");
        shape1.Add("0,0");
        shape1.Add("-1,0");
        
        //l shape
        shape2.Add("0,1");
        shape2.Add("0,0");
        shape2.Add("1,0");
        
        //long shape
        shape3.Add("0,0");
        shape3.Add("-1,0");
        shape3.Add("1,0");
        
        //t shape
        shape4.Add("0,0");
        shape4.Add("0,-1");
        shape4.Add("-1,0");
        shape4.Add("1,0");
     
        //y shape
        shape5.Add("0,0");
        shape5.Add("-1,0");
        shape5.Add("1,0");
        shape5.Add("0,-1");
        shape5.Add("-1,1");
        shape5.Add("1,1");
     
        //z shape
        shape6.Add("0,0");
        shape6.Add("0,1");
        shape6.Add("-1,1");
        shape6.Add("1,0");
     

        //foreach (var item in shape4)
        //{
        //    int x_pos = Convert.ToInt32(item.Split(',')[0]);
        //    int y_pos = Convert.ToInt32(item.Split(',')[1]);
        //    Instantiate(point1, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
        //}
        spawn_small_room(0, 0);

        //pick a direction
        //pick a room
        //if the room fits spawn it
        //find the exit of the room
        //spawn small room next to the exit
        for (int i = 0; i < 2; i++)
        {
            //caal new room
        }
    }

    public void new_room1()
    {
        
        Vector3 base_check = rooms[rooms.Count - 1].transform.position;
        string check_up = $"{base_check.x},{base_check.y + 1}";
        string check_down = $"{base_check.x},{base_check.y - 1}";
        string check_right = $"{base_check.x + 1},{base_check.y}";
        string check_left = $"{base_check.x - 1},{base_check.y}";

        
        optiontest.Add("up");//up
        optiontest.Add("down");//down
        optiontest.Add("left");//left
        optiontest.Add("right");//right
    
        foreach (var item in room_points)
        {
            if (item == check_up)
            {
                //print("removed up " + total_count);
                optiontest.Remove("up");
            }
            if (item == check_down)
            {
                //print("removed down " + total_count);
                optiontest.Remove("down");
            }
            if (item == check_left)
            {
                //print("removed left " + total_count);
                optiontest.Remove("left");
            }
            if (item == check_right)
            {
                //print("removed right " + total_count);
                optiontest.Remove("right");
            }
        }
        int rand = UnityEngine.Random.Range(0, optiontest.Count - 1);
        //print(rand);
        //rand = 1;
        if (optiontest[rand] == "up")
        {
            //print("up " + total_count);
            spawn_up();
        }
        if (optiontest[rand] == "down")
        {
            //print("down " + total_count);
            spawn_down();
        }
        if (optiontest[rand] == "left")
        {
            //print("left " + total_count);
            spawn_left();
        }
        if (optiontest[rand] == "right")
        {
            //print("right " + total_count);
            spawn_right();
        }
        total_count++;
        //attempt_spawn();
    }


    public void spawn_up()
    {
        //square
        options.Add(spawn_list[1]);
        //t
        options.Add(spawn_list[4]);
        //y
        options.Add(spawn_list[5]);

        int room_choice = UnityEngine.Random.Range(0, 3);
        //room_choice = 2;
        //square shape
        if (room_choice == 0)
        {
            //print("square");
            Vector3 offset = new Vector3(0, 1, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset = new Vector2(0, 3);
            new_room2(offset, shape1, spawn_list[1], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
        }
        // t shape
        if (room_choice == 1)
        {
            //print("t");
            Vector3 offset = new Vector3(0, 2, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset;
            //small room spawn
            int spawn_point = UnityEngine.Random.Range(0, 2);
            if (spawn_point == 0)
            {
                small_offset = new Vector2(-2, 2);
            }
            else
            {
                small_offset = new Vector2(2, 2);
            }
            new_room2(offset, shape4, spawn_list[4], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
        }
        // y shape
        if (room_choice == 2)
        {
            //print("y");
            Vector3 offset = new Vector3(0, 2, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset;
            int spawn_point = UnityEngine.Random.Range(0, 2);
            if (spawn_point == 0)
            {
                small_offset = new Vector2(-1, 4);
            }
            else
            {
                small_offset = new Vector2(1, 4);
            }
            new_room2(offset, shape5, spawn_list[5], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);

        }
    }
    public void spawn_down()
    {
        options.Add(spawn_list[1]);
        options.Add(spawn_list[2]);
        options.Add(spawn_list[5]);

        int room_choice = UnityEngine.Random.Range(0, 3);
        //room_choice = 2;
        //square shape 1
        if (room_choice == 0)
        {
            //print("square");
            Vector3 offset = new Vector3(0, -2, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset = new Vector2(0, -3);
            new_room2(offset, shape1, spawn_list[1], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
        }
        //l shape
        if (room_choice == 1)
        {
            //print("l");
            Vector3 offset = new Vector3(0, -2, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset = new Vector2(2, -2);
            new_room2(offset, shape2, spawn_list[2], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
        }
        //y shape
        if (room_choice == 2)
        {
            //print("y");
            int spawn_point = UnityEngine.Random.Range(0, 2);
            if (spawn_point == 0)
            {
                Vector3 offset = new Vector3(-1, -2, 0) + rooms[rooms.Count - 1].transform.position;
                Vector2 small_offset = new Vector2(-1, -4);
                new_room2(offset, shape5, spawn_list[5], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
            }
            else
            {
                Vector3 offset = new Vector3(1, -2, 0) + rooms[rooms.Count - 1].transform.position;
                Vector2 small_offset = new Vector2(1, -4);
                new_room2(offset, shape5, spawn_list[5], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
            }
        }
    }
    public void spawn_left()
    {
        options.Add(spawn_list[1]);
        options.Add(spawn_list[6]);
        options.Add(spawn_list[2]);
        options.Add(spawn_list[4]);

        int room_choice = UnityEngine.Random.Range(0, 4);
        //room_choice = 3;
        //square shape 1
        if (room_choice == 0)
        {
            //print("square");
            Vector3 offset = new Vector3(-1, 0, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset = new Vector2(-3, 0);
            new_room2(offset, shape1, spawn_list[1], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
        }
        //z shape
        if (room_choice == 1)
        {
            //print("z");
            Vector3 offset = new Vector3(-2, 0, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset = new Vector2(-4, 1);
            new_room2(offset, shape6, spawn_list[6], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
        }
        //l shape
        if (room_choice == 2)
        {
            //print("l");
            Vector3 offset = new Vector3(-2, 0, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset = new Vector2(-2, 2);
            new_room2(offset, shape2, spawn_list[2], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
        }
        //t shape
        if (room_choice == 3)
        {
            //print("t");
            Vector3 offset = new Vector3(-2, 0, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset;
            int spawn_point = UnityEngine.Random.Range(0, 2);
            if (spawn_point == 0)
            {
                small_offset = new Vector2(-4, 0);
            }
            else
            {
                small_offset = new Vector2(-2, -2);
            }
            new_room2(offset, shape4, spawn_list[4], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
        }
    }
    public void spawn_right()
    {
        options.Add(spawn_list[1]);
        options.Add(spawn_list[6]);
        options.Add(spawn_list[3]);
        options.Add(spawn_list[4]);
        int room_choice = UnityEngine.Random.Range(0, 4);
        room_choice = 3;
        //square shape 1
        if (room_choice == 0)
        {
            //print("square");
            Vector3 offset = new Vector3(2, 0, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset = new Vector2(3, 0);
            new_room2(offset, shape1, spawn_list[1], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
        }
        //z shape
        if (room_choice == 1)
        {
            //print("z");
            Vector3 offset = new Vector3(2, -1, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset = new Vector2(4, -1);
            new_room2(offset, shape6, spawn_list[6], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
        }
        //long shape
        if (room_choice == 2)
        {
            //print("long");
            Vector3 offset = new Vector3(2, 0, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset = new Vector2(4, 0);
            new_room2(offset, shape3, spawn_list[3], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
        }
        //t shape
        if (room_choice == 3)
        {
            //print("t");
            Vector3 offset = new Vector3(2, 0, 0) + rooms[rooms.Count - 1].transform.position;
            Vector2 small_offset;
            int spawn_point = UnityEngine.Random.Range(0, 2);
            if (spawn_point == 0)
            {
                small_offset = new Vector2(4, 0);
            }
            else
            {
                small_offset = new Vector2(2, -2);
            }
            new_room2(offset, shape4, spawn_list[4], rooms[rooms.Count - 1].transform.position.x + small_offset.x, rooms[rooms.Count - 1].transform.position.y + small_offset.y);
        }
    }

    public void new_room2(Vector3 offset, List<string> shape_points,GameObject shape,float x_position, float y_position)
    {
        int count = 0;
        foreach (var item1 in room_points)
        {
            foreach (var item2 in shape_points)
            {
                var split1 = Convert.ToInt32(item2.Split(',')[0]);
                var split2 = Convert.ToInt32(item2.Split(',')[1]);

                float x_pos = split1 + offset.x;
                float y_pos = split2 + offset.y;
                if (item1 == $"{x_pos},{y_pos}") 
                {
                    count++;
                }
            }
        }
        if (count == 0)
        {
            GameObject new_shape = Instantiate(shape, offset, Quaternion.identity);
            
            foreach (var item in shape_points)
            {
                int x_pos = Convert.ToInt32(item.Split(',')[0]);
                int y_pos = Convert.ToInt32(item.Split(',')[1]);
                GameObject point_name = Instantiate(point1, new Vector3(x_pos, y_pos, 0) + offset, Quaternion.identity);
                point_name.name = $"{shape.name} {x_pos},{y_pos}";
                room_points.Add($"{point_name.transform.position.x},{point_name.transform.position.y}");
            }
            rooms.Add(new_shape);
            spawn_small_room(x_position, y_position);
            
        }
        else
        {
            Debug.LogError($"couldnt spawn {shape.name}");
            int rand = UnityEngine.Random.Range(0, optiontest.Count - 1);
            //print(rand);
            //rand = 1;
            if (optiontest[rand] == "up")
            {
                Debug.LogWarning("try up " + total_count);
                spawn_up();
            }
            if (optiontest[rand] == "down")
            {
                Debug.LogWarning("try down " + total_count);
                spawn_down();
            }
            if (optiontest[rand] == "left")
            {
                Debug.LogWarning("try left " + total_count);
                spawn_left();
            }
            if (optiontest[rand] == "right")
            {
                Debug.LogWarning("try right " + total_count);
                spawn_right();
            }
            total_count++;
        }
    }


    public void spawn_small_room(float x_pos, float y_pos)
    {
        GameObject room1 = Instantiate(spawn_list[0], new Vector3(x_pos, y_pos, 0), Quaternion.identity);
        GameObject point_name = Instantiate(point1, room1.transform.position, Quaternion.identity);
        room1.name = $"small_room {x_pos},{y_pos}";
        point_name.name = $"room point";
        rooms.Add(room1);
        room_points.Add($"{x_pos},{y_pos}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
