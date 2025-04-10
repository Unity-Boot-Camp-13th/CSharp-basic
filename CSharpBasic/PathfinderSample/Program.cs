namespace PathfinderSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = SpawnMap();
            map.Display();
        }

        static Map SpawnMap()
        {
            // 기본 길은 grass로, 플레이어가 지나가는 길은 dirt로 표현
            Map map = Map.CreateDefault(30, 20);
            Coord[] shuffledEmptyCoords = map.GetShuffledEmptyCoords();
            int i = 0;

            // 갈 수 없는 길 생성 (물)
            while (i < 100)
            {
                map.SetTile(new MapTile(shuffledEmptyCoords[i], FloorType.Water));
                i++;
            }

            // 갈 수 없는 길 생성 (돌)
            while (i < 150)
            {
                map.SetTile(new MapTile(shuffledEmptyCoords[i], FloorType.Stone));
                i++;
            }

            // 플레이어 생성
            map.SetTile(new MapTile(shuffledEmptyCoords[i], FloorType.Grass, '♀'));
            i++;

            // 목표 생성
            map.SetTile(new MapTile(shuffledEmptyCoords[i], FloorType.Grass, '☆'));
            i++;

            return map;
        }
    }
}
