using System.Text;
using System.Threading.Tasks;

namespace PathfinderSample
{
    class Pathfinder
    {
        public Pathfinder(Map map)
        {
            _map = map;
            _visits = new bool[_map.Height, _map.Width];
        }

        Map _map;
        bool[,] _visits;

        // DFS : Depth Fist Search 깊이 우선 탐색
        public bool TryFindPathDFS(Coord start, Coord end, out IEnumerable<Coord> pathResult)
        {
            bool found = false;
            pathResult = default;
            List<(Coord prev, Coord next)> pairs = new List<(Coord prev, Coord next)>(_map.Height * _map.Width / 2);
            Stack<Coord> stack = new Stack<Coord>(_map.Height * _map.Width / 2);
            stack.Push(start);
            _visits[start.Y, start.X] = true;
            pairs.Add((Coord.Invalid, start));

            // 탐색방향
            Coord[] directions = new Coord[] {Coord.Up, Coord.Right, Coord.Down, Coord.Left};

            while (stack.Count > 0)
            {
                Coord current = stack.Pop();

                // 경로 찾음
                if (current == end)
                {
                    found = true;
                    break;
                }

                // 각 방향 순회
                foreach (Coord direction in directions)
                {
                    Coord next = current + direction;
                    MapTile nextTile = _map.GetTile(next);

                    // 이미 방문했다면 이쪽 가면 안 됨
                    if (_visits[next.Y, next.X])
                        continue;

                    // 못 걷는 곳이면 이쪽 가면 안 됨
                    if (_map.IsWalkable(next) == false)
                        continue;
                    
                    stack.Push(next);
                    _visits[next.Y, next.X] = true;
                    pairs.Add((current, next));
                }
            }

            if (found)
            {
                List<Coord> path = new List<Coord>();
                int index = pairs.FindLastIndex(pair => pair.next == end);
                path.Add(end);

                // 현재 역추적중인 쌍이 시작점으로부터 출발하는거라면 순회중지
                while (index > 0 && // 0번 인덱스는 start임
                       pairs[index].prev != start) 
                {
                    path.Add(pairs[index].prev);
                    // 현재 추적쌍의 출발점을 도착점으로 가지는 가장 마지막 좌표 찾음
                    index = pairs.FindLastIndex(pair => pair.next == pairs[index].prev);
                }

                path.Add(start);
                path.Reverse();
                pathResult = path;
            }

            return found;
        }
    }
}
