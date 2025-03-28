using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    class GamePlayManager
    {
        private Map _map;
        private PC _player;
        private Coord _playerCoord; // <= 플레이어 좌표 저장해놓고 활용해도 됨

        public void PlayGame()
        {
            InitializeLevel();
            GameWorkflow();
        }

        private void InitializeLevel()
        {
            CreateMap();
            SpawnGameObjects();
        }

        private void CreateMap()
        {
            _map = Map.CreateDefault(20, 20); // 맵을 기본 값으로 생성
            // 현재 데이터대로 화면에 출력
        }

        private void SpawnGameObjects()
        {
            MapTile mapTile; // 지역 변수 -> 따라서 SpawnNPCs() 함수가 끝나면 stack에서 사라짐
            GameObject spawnedObject; // 지역 변수
            Coord[] coords = _map.GetShuffledEmptyCoords();
            int coordIndex = 0; // 순차적으로 빈 타일을 검색하기 위한 인덱스 (iteration)

            // 이장님 소환 및 배치
            spawnedObject = new TownNPC_VillageChief("마을 이장", int.MaxValue);
            mapTile = _map.GetTile(coords[coordIndex]);
            mapTile.GameObject = spawnedObject;
            _map.SetTile(mapTile);
            coordIndex++;


            // 슬라임 10마리 생성
            for (int i = 0; i < 10; i++)
            {
                spawnedObject = new Slime("슬라임", 50);
                mapTile = _map.GetTile(coords[coordIndex]);
                mapTile.GameObject = spawnedObject;
                _map.SetTile(mapTile);
                coordIndex++;
            }

            // 버섯 5마리 생성
            for (int i = 0; i < 5; i++)
            {
                spawnedObject = new Mushroom("버섯", 100, 5);
                mapTile = _map.GetTile(coords[coordIndex]);
                mapTile.GameObject = spawnedObject;
                _map.SetTile(mapTile);

                coordIndex++;
            }

            // 플레이어 캐릭터 생성 (전사)
            spawnedObject = _player = new Warrior("스타전사", 200, 20);
            mapTile = _map.GetTile(coords[coordIndex]);
            mapTile.GameObject = spawnedObject;
            _map.SetTile(mapTile);
            _playerCoord = mapTile.Coord;
            coordIndex++;
        }

        // gameworkflow : 작업 흐름
        private void GameWorkflow() 
        {
            while(IsGameOver() == false &&
                  IsGameClear() == false)
            {
                Console.Clear();
                _map.Display();
                HandleInput();
            }
        }

        private bool IsGameOver()
        {
            return _player.Hp <= 0;
        }

        private bool IsGameClear()
        {
            // TODO : 소환된 적이 더이상 남아있지 않은지
            return false;
        }

        private void HandleInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;

            // TODO -> 방향키로 플레이어 이동
            // (경계를 벗어나거나, 타일 위에 다른 GameObject가 있으면 이동 불가)

            int playerX = _playerCoord.X;
            int playerY = _playerCoord.Y;
            
            
            // 플레이어 이동
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    playerY -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    playerY += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    playerX -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    playerX += 1;
                    break;
                default:
                    break;
            }
                 

            // 이동 후 플레이어 좌표 값
            Coord nextCoord = new Coord(playerX, playerY);


            // 이동 가능한지 확인
            if (_map.IsValid(nextCoord) && _map.IsEmpty(nextCoord))
            {
                // 1. 현재 위치 비우기
                MapTile currentTile = _map.GetTile(_playerCoord);
                currentTile.GameObject = null;
                _map.SetTile(currentTile);

                // 2. 새로운 위치에 플레이어 배치
                MapTile nextTile = _map.GetTile(nextCoord);
                nextTile.GameObject = _player;
                _map.SetTile(nextTile);

                // 3. 플레이어 좌표 갱신
                _playerCoord = nextCoord;
            }
            else
                return;

            // 강사님의 방향키 코드
            // Coord direction = default;
            // 
            // switch (key)
            // {
            //     case ConsoleKey.UpArrow:
            //         direction = Coord.Up;
            //         break;
            //     case ConsoleKey.DownArrow:
            //         direction = Coord.Down;
            //         break;
            //     case ConsoleKey.LeftArrow:
            //         direction = Coord.Left;
            //         break;
            //     case ConsoleKey.RightArrow:
            //         direction = Coord.Right;
            //         break;
            //     default:
            //         break;
            // }
            // 
            // Coord targetCoord = _playerCoord + direction;
            // 
            // if (_map.IsValid(targetCoord) &&
            //     _map.IsEmpty(targetCoord))
            // {
            //     MapTile origin = _map.GetTile(_playerCoord);
            //     origin.GameObject = null;
            //     _map.SetTile(origin);
            // 
            //     MapTile target = _map.GetTile(targetCoord);
            //     target.GameObject = _player;
            //     _map.SetTile(target);
            // 
            //     _playerCoord = targetCoord;
            // }
        }
    }
}
