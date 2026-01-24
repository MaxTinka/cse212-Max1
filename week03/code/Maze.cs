public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        var currentPos = (_currX, _currY);
        if (!_mazeMap.ContainsKey(currentPos) || !_mazeMap[currentPos][0])
            throw new InvalidOperationException("Can't go that way!");
        
        var newPos = (_currX - 1, _currY);
        if (!_mazeMap.ContainsKey(newPos))
            throw new InvalidOperationException("Can't go that way!");
        
        _currX--;
    }

    public void MoveRight()
    {
        var currentPos = (_currX, _currY);
        if (!_mazeMap.ContainsKey(currentPos) || !_mazeMap[currentPos][1])
            throw new InvalidOperationException("Can't go that way!");
        
        var newPos = (_currX + 1, _currY);
        if (!_mazeMap.ContainsKey(newPos))
            throw new InvalidOperationException("Can't go that way!");
        
        _currX++;
    }

    public void MoveUp()
    {
        var currentPos = (_currX, _currY);
        if (!_mazeMap.ContainsKey(currentPos) || !_mazeMap[currentPos][2])
            throw new InvalidOperationException("Can't go that way!");
        
        var newPos = (_currX, _currY - 1);
        if (!_mazeMap.ContainsKey(newPos))
            throw new InvalidOperationException("Can't go that way!");
        
        _currY--;
    }

    public void MoveDown()
    {
        var currentPos = (_currX, _currY);
        if (!_mazeMap.ContainsKey(currentPos) || !_mazeMap[currentPos][3])
            throw new InvalidOperationException("Can't go that way!");
        
        var newPos = (_currX, _currY + 1);
        if (!_mazeMap.ContainsKey(newPos))
            throw new InvalidOperationException("Can't go that way!");
        
        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
