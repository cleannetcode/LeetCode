// Author: Trufanov Roman
// Github: pingvin1308

public class Solution {
   
    public int NumIslands(char[][] grid) {
        var lands = GetLands(grid);

        var queue = new Queue<(int, int)>();
        var visitedLands = new HashSet<(int, int)>();
        var numIslands = 0;

        for (var i = 0; i < grid.Length; i++) {
            for (var j = 0; j < grid[i].Length; j++) {
                if (lands[i][j] != 1) continue;

                queue.Enqueue((i, j));
                numIslands++;

                while (queue.Count > 0) {
                    var (y, x) = queue.Dequeue();
                    var land = lands[y][x];

                    if (!visitedLands.Add((y, x))) {
                        continue;
                    }

                    if (y-1 >= 0 && lands[y-1][x] != 0 && !visitedLands.Contains((y-1, x))) {
                        lands[y-1][x] = land+1;
                        queue.Enqueue((y-1, x));
                    }

                    if (y+1 < grid.Length && lands[y+1][x] != 0 && !visitedLands.Contains((y+1, x))) {
                        lands[y+1][x] = land+1;
                        queue.Enqueue((y+1, x));
                    }

                    if (x-1 >= 0 && lands[y][x-1] != 0 && !visitedLands.Contains((y, x-1))) {
                        lands[y][x-1] = land+1;;
                        queue.Enqueue((y, x-1));
                    }

                    if (x+1 < grid[y].Length && lands[y][x+1] != 0 && !visitedLands.Contains((y, x+1)))                     {
                        lands[y][x+1] = land+1;
                        queue.Enqueue((y, x+1));
                    }
                }
            }
        }
        
        return numIslands;
    }
    
    private int[][] GetLands(char[][] grid) {
        var lands = new int[grid.Length][];
        
        for (var i = 0; i < grid.Length; i++) {
            lands[i] = new int[grid[i].Length];
            
            for (var j = 0; j < grid[i].Length; j++) {
                lands[i][j] = int.Parse(grid[i][j].ToString());
            }
        }
        
        return lands;
    }
}
