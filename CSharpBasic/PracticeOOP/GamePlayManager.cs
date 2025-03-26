using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    class GamePlayManager
    {
        private Map _map;

        public void PlayGame()
        {
            InitializeLevel();
            GameWorkflow();
        }

        private void InitializeLevel()
        {
            CreateMap();
            SpawnNPCs();
            SpawnPlayer();
        }

        private void CreateMap()
        {
            _map = Map.CreateDefault(20, 20);
            _map.Display();
        }

        private void SpawnNPCs()
        {
            MapTile mapTile; // 지역 변수 -> 따라서 SpawnNPCs() 함수가 끝나면 stack에서 사라짐
            GameObject spawnedObject; // 지역 변수

            // new 키워드 배열 만들면 Heap에 저장 -> Heap 에 있는 것이 우리가 보는 실제 맵

            // 촌장님 소환
            if (_map.TryGetEmptyRandomMapTile(out mapTile)) // out : 변수 참조 키워드
            {
                spawnedObject = new TownNPC_VillageChief("마을 이장", int.MaxValue); 
                // spawnedObject는 주소를 저장하기 위한 곳 / new TownNPC는 힙에 저장됨. 이것의 주소가 spawned..에 저장
                // mapTile.GameObject = spawnedObject -> 이건 안 됨. 왜냐하면 값만 복사해서 stack에 저장되기 때문

                _map.TrySetGameObject(mapTile.Coord.X, mapTile.Coord.Y, spawnedObject);
            }
        }

        private void SpawnPlayer()
        {

        }

        // gameworkflow : 작업 흐름
        private void GameWorkflow() 
        {
            return;

            while(IsGameOver() == false &&
                  IsGameClear() == false)
            {

            }
        }

        private bool IsGameOver()
        {
            // TODO : 플레이어 체력이 0 이하인지
            return false;
        }

        private bool IsGameClear()
        {
            // TODO : 소환된 적이 더이상 남아있지 않은지
            return false;
        }

    }
}
