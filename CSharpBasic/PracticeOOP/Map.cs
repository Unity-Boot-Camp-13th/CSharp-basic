using PracticeOOP.Utilities;

namespace PracticeOOP
{
    class Map
    {
        public Map(int width, int height)
        {
            _tiles = new MapTile[height, width];
        }

        public MapTile this[int y, int x]
        {
            get
            {
                return _tiles[y, x];
            }
            set
            {
                _tiles[y, x] = value;
            }
        }

        // 위랑 아래 중 사용하기 더 편한 것을 사용 
        public MapTile this[Coord coord]
        {
            get
            {
                return _tiles[coord.Y, coord.X];
            }
            set
            {
                _tiles[coord.Y, coord.X] = value;
            }
        }


        MapTile[,] _tiles; // map을 여러 개로 만들 거라서 static을 붙일 수 없음


        public static Map CreateDefault(int width, int height)
        {
            Map map = new Map(width, height);

            for (int i = 0; i < map._tiles.GetLength(0); i++)
            {
                for (int j = 0; j < map._tiles.GetLength(1); j++)
                {
                    map._tiles[i, j] = new MapTile(coord: new Coord(j, i),
                                               floorType: FloorType.Grass,
                                               gameObject: null);
                }
            }

            return map;
        }

        public void SetTile(MapTile mapTile)
        {
            Coord coord = mapTile.Coord;
            _tiles[coord.Y, coord.X] = mapTile;
        }

        public MapTile GetTile(Coord coord)
        {
            return _tiles[coord.Y, coord.X];
        }

        // public bool TryGetEmptyRandomMapTile(out MapTile mapTile)
        // {
        //     Random random = new Random();
        //     int randomY = random.Next(_tiles.GetLength(0)); // y축 좌표 반환
        //     int randomX = random.Next(_tiles.GetLength(1)); // x축 좌표 반환
        // 
        //     // 타일 비어있음
        //     if (_tiles[randomY, randomX].GameObject == null)
        //     {
        //         mapTile = _tiles[randomY, randomX];
        //         return true;
        //     }
        // 
        //     // mapTile = default; // default는 초기화를 0으로 반환하겠다는 이야기.
        //     mapTile = MapTile.Invalid;
        //     return false;
        // }

        public bool IsEmpty(int x, int y)
        {
            return _tiles[y, x].GameObject == null;
        }

        public bool IsEmpty(Coord coord)
        {
            return _tiles[coord.Y, coord.X].GameObject == null;
        }

        /// <summary>
        /// x, y 좌표가 맵의 경계 내에 존재하는 유효한 좌표인지 확인
        /// </summary>
        /// <returns> ture : 유효함, false : 유효하지 않음 </returns>
        public bool IsValid(int x, int y)
        {
            // x나 y가 2차원 배열 인덱스 범위를 벗어날 때
            if (x < 0 || x >= _tiles.GetLength(1) ||
                y < 0 || y >= _tiles.GetLength(0))
            {
                return false;
            }
            return true;
        }

        public bool IsValid(Coord coord)
        {
            if (coord.X < 0 || coord.X >= _tiles.GetLength(1) ||
                coord.Y < 0 || coord.Y >= _tiles.GetLength(0))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 비어 있는 타일의 좌표들을 랜덤하게 섞은 배열을 가져옴
        /// </summary>
        public Coord[] GetShuffledEmptyCoords()
        {
            Coord[] buffer = new Coord[_tiles.Length];
            int bufferIndex = 0; // 0부터 차곡차곡 넣어야해서 0으로 초기화

            for (int i = 0; i < _tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _tiles.GetLength(1); j++)
                {
                    if (IsEmpty(j, i))
                    {
                        buffer[bufferIndex] = _tiles[i, j].Coord;
                        bufferIndex++;
                    }
                }
            }

            Coord[] emptyCoords = new Coord[bufferIndex];
            Array.Copy(buffer, 0, emptyCoords, 0, bufferIndex); // 3번째 오버라이드 이용

            // 위의 Array.Copy와 같은 기능을 하는 밑의 for루프
            // for (int i = 0; i < bufferIndex; i++)
            // {
            //     emptyCoords[i] = buffer[i];
            // }

            Random random = new Random();
            random.Shuffle(emptyCoords);
            return emptyCoords;
        }

        public void Display()
        {
            for (int i = 0; i < _tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _tiles.GetLength(1); j++)
                {
                    switch (_tiles[i, j].FloorType)
                    {
                        case FloorType.None:
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case FloorType.Grass:
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case FloorType.Stone:
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;
                        case FloorType.Water:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            break;
                        default:
                            break;
                    }

                    if (_tiles[i,j].GameObject == null)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        // TODO : Gameobject의 문자 출력
                        GameObject gameObject = _tiles[i, j].GameObject;
                        Console.ForegroundColor = gameObject.SymbolColor;
                        Console.Write($"{gameObject.Symbol}");
                    }
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }

    }
}
