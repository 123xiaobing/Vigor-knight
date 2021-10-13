using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomGenerator : MonoBehaviour
{
    public enum Direction { up,down,left,right };
    public Direction direction;

    [Header("房间信息")]
    public GameObject roomPrefab;
    public int roomNumber;
    public Color startColor, endColor;//开始和结尾房间的颜色
    public GameObject endRoom;

    [Header("位置控制")]
    public Transform generaterPoint;
    public float xOffset;//x方向位移
    public float yOffset;//y方向位移
    public LayerMask RoomLayer;

    public int maxStep;
    public List<Room> rooms = new List<Room>();//链表用来保存新生成的房间

    List<GameObject> farRooms = new List<GameObject>();
    List<GameObject> lessFarRooms = new List<GameObject>();
    List<GameObject> oneWayRooms = new List<GameObject>();

    public WallType walltype;



    void Start()
    {
        for (int i = 0; i < roomNumber; i++)
        {
            rooms.Add(Instantiate(roomPrefab, generaterPoint.position, Quaternion.identity).GetComponent<Room>());

            //改变point位置
            ChangePointPosition();
        }

        rooms[0].GetComponent<SpriteRenderer>().color = startColor;

        endRoom = rooms[0].gameObject;


        //找到最后房间
        foreach(var room in rooms)
        {

            SetupRoom(room, room.transform.position);

        }
        FindEndRoom();
        endRoom.GetComponent<SpriteRenderer>().color = endColor;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePointPosition()
    {
        do
        {
            direction = (Direction)Random.Range(0, 4);//运用枚举随机生成

            switch (direction)
            {
                case Direction.up:
                    generaterPoint.position += new Vector3(0, yOffset, 0);
                    break;
                case Direction.down:
                    generaterPoint.position += new Vector3(0, -yOffset, 0);
                    break;
                case Direction.left:
                    generaterPoint.position += new Vector3(-xOffset, 0, 0);
                    break;
                case Direction.right:
                    generaterPoint.position += new Vector3(xOffset, 0, 0);
                    break;
            }
        } while (Physics2D.OverlapCircle(generaterPoint.position,0.2f,RoomLayer));
    }

    public void SetupRoom(Room newRoom,Vector3 roomPosition)
    {
        newRoom.roomUp = Physics2D.OverlapCircle(roomPosition + new Vector3(0, yOffset, 0), 0.1f, RoomLayer);
        newRoom.roomDown = Physics2D.OverlapCircle(roomPosition + new Vector3(0, -yOffset, 0), 0.1f, RoomLayer);
        newRoom.roomLeft = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0, 0), 0.1f, RoomLayer);
        newRoom.roomRight = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0, 0), 0.1f, RoomLayer);
                
        newRoom.UpdateRoom(xOffset,yOffset);
        
        
        switch(newRoom.doorNum)
        {
            case 1:
                if(newRoom.roomUp)
                    Instantiate(walltype.singleU,roomPosition,Quaternion.identity);
                if(newRoom.roomDown)
                    Instantiate(walltype.singleD,roomPosition,Quaternion.identity);
                if(newRoom.roomLeft)
                    Instantiate(walltype.singleL,roomPosition,Quaternion.identity);
                if(newRoom.roomRight)
                    Instantiate(walltype.singleR,roomPosition,Quaternion.identity);
                break;
            case 2:
                if(newRoom.roomLeft&&newRoom.roomUp)
                    Instantiate(walltype.doubleUL,roomPosition,Quaternion.identity);
                if(newRoom.roomUp&&newRoom.roomRight)
                    Instantiate(walltype.doubleUR,roomPosition,Quaternion.identity);
                if(newRoom.roomRight&&newRoom.roomDown)
                    Instantiate(walltype.doubleRD,roomPosition,Quaternion.identity);
                if(newRoom.roomDown&&newRoom.roomLeft)
                    Instantiate(walltype.doubleLD,roomPosition,Quaternion.identity);
                if(newRoom.roomUp&&newRoom.roomDown)
                    Instantiate(walltype.doubleUD,roomPosition,Quaternion.identity);
                if(newRoom.roomLeft&&newRoom.roomRight)
                    Instantiate(walltype.doubleLR,roomPosition,Quaternion.identity);
                break;
            case 3:
                if(newRoom.roomLeft&&newRoom.roomUp&&newRoom.roomRight)
                    Instantiate(walltype.tripleLUR,roomPosition,Quaternion.identity);
                if(newRoom.roomUp&&newRoom.roomRight&&newRoom.roomDown)
                    Instantiate(walltype.tripleUDR,roomPosition,Quaternion.identity);
                if(newRoom.roomRight&&newRoom.roomDown&&newRoom.roomLeft)
                    Instantiate(walltype.tripleLDR,roomPosition,Quaternion.identity);
                if(newRoom.roomDown&&newRoom.roomLeft&&newRoom.roomUp)
                    Instantiate(walltype.tripleUDL,roomPosition,Quaternion.identity);
                break;
            case 4:
                if(newRoom.roomDown&&newRoom.roomLeft&&newRoom.roomUp&&newRoom.roomRight)
                Instantiate(walltype.fourDoors,roomPosition,Quaternion.identity);
                break;    
        }
    }

    public void FindEndRoom()
    {
        for (int  i = 0;  i < rooms.Count;  i++)
        {
            if (rooms[i].stepToStart > maxStep)
                maxStep = rooms[i].stepToStart;
        }

        //获得房间的最大值和次大值
        foreach (var room in rooms)
        {
            if (room.stepToStart == maxStep)
                farRooms.Add(room.gameObject);
            if (room.stepToStart == maxStep - 1)
                lessFarRooms.Add(room.gameObject);
        }

        for (int i = 0; i < farRooms.Count; i++)
        {
            if (farRooms[i].GetComponent<Room>().doorNum == 1)
                oneWayRooms.Add(farRooms[i]);
        }

        for (int i = 0; i < lessFarRooms.Count; i++)
        {
            if (lessFarRooms[i].GetComponent<Room>().doorNum == 1)
                oneWayRooms.Add(lessFarRooms[i]);
        }

        if(oneWayRooms.Count!=0)
        {
            endRoom = oneWayRooms[Random.Range(0, oneWayRooms.Count)];
        }
        else
        {
            endRoom = farRooms[Random.Range(0, farRooms.Count)];
        }
    }
}

[System.Serializable]
public class WallType
{
    public GameObject singleL,singleR,singleU,singleD,
                      doubleUL,doubleUR,doubleUD,doubleLR,doubleLD,doubleRD,
                      tripleLUR,tripleLDR,tripleUDL,tripleUDR,
                      fourDoors;


}
