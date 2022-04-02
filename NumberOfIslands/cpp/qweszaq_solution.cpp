class Solution {
public:
    
    int numIslands(vector<vector<char>>& grid) {
        
        int answer=0, x, y, checked[grid.size()][grid[0].size()];
        queue <pair<int, int>> island;
        pair<int, int> tmp;
        
        for(int i=0; i<grid.size(); i++)
            for(int j=0; j<grid[i].size(); j++)
                checked[i][j]=0;
        
        for(int i=0; i<grid.size(); i++)
        {
            for(int j=0; j<grid[i].size(); j++)
            {
                if(grid[i][j]=='1') 
                {
                   
                    island.push(make_pair(i,j));
                    checked[i][j]=1;
                    
                    while(!island.empty())
                    {
                        tmp=island.front();
                        x=tmp.first;
                        y=tmp.second;
                        island.pop();
                        grid[x][y]='3';
                        
                        if(x>0 && grid[x-1][y]=='1' && checked[x-1][y]==0) {island.push(make_pair( x-1,y)); checked[x-1][y]=1;}
                        if(y>0 && grid[x][y-1]=='1' && checked[x][y-1]==0) {island.push(make_pair(x,y-1 )); checked[x][y-1]=1; }
                        if(x+1<grid.size() && grid[x+1][y]=='1' && checked[x+1][y]==0) { island.push(make_pair( x+1,y )); checked[x+1][y]=1; } 
                        if(y+1<grid[x].size() && grid[x][y+1]=='1' && checked[x][y+1]==0 ) {island.push(make_pair(x,y+1 )); checked[x][y+1]=1;}
                        
                    }
                    
                    answer++;
                }
            }
        }
        
        return answer;
    }
};
