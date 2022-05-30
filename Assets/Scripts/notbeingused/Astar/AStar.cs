using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public static class AStar
{
    private static Dictionary<Point, Node> nodes;

    private static void CreateNodes()
    {
        nodes = new Dictionary<Point, Node>();

       // foreach (TileScript tile in LevelManager.Instance.Tiles.Values)
       // {
       //     nodes.Add(tile.GridPosition, new Node(tile));
       // }
    }

    public static Stack<Node> GetPath(Point start, Point goal)
    {
        if (nodes == null)
        {
            CreateNodes();
        }

        //Creates an open list to be used with the A* algorithm
        HashSet<Node> openList = new HashSet<Node>();

        //Creates an closed list to be used with the A* algorithm
        HashSet<Node> closedList = new HashSet<Node>();

        //1,2,3

        Stack<Node> finalPath = new Stack<Node>();
  


        Node currentNode = nodes[start];
        
        //1. Adds the start node to the OpenList
        openList.Add(currentNode);

        while(openList.Count > 0)//Step10
        {
        //2. Runs through all neighbors
            // for (int x=-1; x<=1; x++)
            // {
            //     for(int y=-1; y <=1; y++)
            //     {
            //         Point neighborPos = new Point(currentNode.GridPosition.X - x,currentNode.GridPosition.Y - y);
                    
            //         if(LevelManager.Instance.InBounds(neighborPos) && LevelManager.Instance.Tiles[neighborPos].WalkAble && neighborPos != currentNode.GridPosition)
            //         {
            //             int gCost = 0;

            //             if(Math.Abs(x-y) == 1)
            //             {
            //                 gCost = 10;
            //             }
            //             else
            //             {
            //                 if(!ConnectedDiagonally(currentNode, nodes[neighborPos]))
            //                 {
            //                     continue;
            //                 }
            //                 gCost = 14;
            //             }

            //             //3.add neighbors to the open list
            //             Node neighbor = nodes[neighborPos];

            //             if(openList.Contains(neighbor))
            //             {
            //                 if(currentNode.G + gCost < neighbor.G) //Step 9.4
            //                 {
            //                     neighbor.CalcValues(currentNode,nodes[goal],gCost);
            //                 }
            //             }
            //             else if(!closedList.Contains(neighbor))//step 9.1
            //             {
            //                 openList.Add(neighbor); //step 9.2
            //                 neighbor.CalcValues(currentNode,nodes[goal],gCost);//step9.3
            //             }
                       
            //         }
                    
            //     }
            // }
            
            //5. and 8. Moves the current node from the open list to the closed list
            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if (openList.Count >0) //step 7
            {
                //Sorts the list by F value, and selects the first on the list
                currentNode = openList.OrderBy(n => n.F).First();
            }

            if(currentNode == nodes[goal])
            {
                while(currentNode.GridPosition !=start)
                {
                finalPath.Push(currentNode);
                currentNode = currentNode.Parent;
                }
                return finalPath;;
            }
        }

        return null;
        
        //THIS IS FOR DEBUGING REMOVE LATER!!!
        //GameObject.Find("AStarDebugger").GetComponent<AStarDebug>().DebugPath(openList, closedList,finalPath);
    

    }

    //private static bool ConnectedDiagonally(Node currentNode, Node neighbor)
    //{
    //     Point direction = neighbor.GridPosition - currentNode.GridPosition;

    //     Point first = new Point(currentNode.GridPosition.X + direction.X, currentNode.GridPosition.Y);

    //     Point second = new Point(currentNode.GridPosition.X, currentNode.GridPosition.Y +direction.Y);

    //     if(LevelManager.Instance.InBounds(first) && !LevelManager.Instance.Tiles[first].WalkAble)
    //     {
    //         return false;
    //     }

    //     if(LevelManager.Instance.InBounds(second) && !LevelManager.Instance.Tiles[second].WalkAble)
    //     {
    //         return false;
    //     }

    //     return true;
    // }

}






