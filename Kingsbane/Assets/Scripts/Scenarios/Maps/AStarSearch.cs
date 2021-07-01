using System;
using System.Collections.Generic;
using UnityEngine;
using CategoryEnums;

//These links were used as reference for the AStar Search Algorithms
// https://www.redblobgames.com/pathfinding/a-star/introduction.html
// https://www.redblobgames.com/pathfinding/a-star/implementation.html#csharp

public class PriorityQueue<T>
{
    private List<Tuple<T, int>> elements = new List<Tuple<T, int>>();

    public int Count
    {
        get { return elements.Count; }
    }

    public void Enqueue(T item, int priority)
    {
        elements.Add(Tuple.Create(item, priority));
    }

    public T Dequeue()
    {
        int bestIndex = 0;

        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].Item2 < elements[bestIndex].Item2)
            {
                bestIndex = i;
            }
        }

        T bestItem = elements[bestIndex].Item1;
        elements.RemoveAt(bestIndex);
        return bestItem;
    }
}


public class AStarSearch
{
    public Dictionary<Cell, Cell> cameFrom
        = new Dictionary<Cell, Cell>();
    public Dictionary<Cell, int> costSoFar
        = new Dictionary<Cell, int>();

    static public int Heuristic(Cell a, Cell b)
    {
        return Math.Abs((int)a.gridIndex.x - (int)b.gridIndex.x) + Math.Abs((int)a.gridIndex.y - (int)b.gridIndex.y);
    }

    public AStarSearch(Cell start, Cell goal, Unit unit = null)
    {
        var frontier = new PriorityQueue<Cell>();
        frontier.Enqueue(start, 0);

        cameFrom[start] = start;
        costSoFar[start] = 0;

        while (frontier.Count > 0)
        {
            var current = frontier.Dequeue();

            if (current.Equals(goal))
            {
                break;
            }

            foreach (var adjCell in current.adjCells)
            {
                var moveCost = CalculateMoveCost(adjCell, unit);

                if (moveCost == null)
                    continue;

                int newCost = costSoFar[current] + moveCost.Value;
                if (!costSoFar.ContainsKey(adjCell)
                    || newCost < costSoFar[adjCell])
                {
                    costSoFar[adjCell] = newCost;
                    int priority = newCost + Heuristic(adjCell, goal);
                    frontier.Enqueue(adjCell, priority);
                    cameFrom[adjCell] = current;
                }
            }
        }
    }

    public int? CalculateMoveCost(Cell nextCell, Unit unit)
    {
        if (!unit.CheckOccupancy(nextCell, ignoreFriendlyUnits: false))
            return null;

        return unit.HasKeyword(Keywords.Ethereal) ||
            unit.HasKeyword(Keywords.Stalker) ||
            unit.HasStatusEffect(Unit.StatusEffects.Airborne) ||
            nextCell.terrainType != TerrainTypes.Difficult ? 1 : 2;
    }

    public bool CheckMoveCost(int moveCost, Cell cell)
    {
        return costSoFar[cell] <= moveCost;
    }
}
