using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSample
{
    class Box<T, K> // type , key, value 약자로 T, K , V 가장 많이 사용
    {
        public T Item1 { get; set; }
        public K Item2 { get; set; }

        public void PrintItems()
        {
            // typeof 키워드 : 이 타입의 메타데이터 정보를 포함하는 객체를 반환받는 키워드
            Console.WriteLine($"{typeof(T)} 아이템 {(Item1 == null ? "없음" : "있음")}, {typeof(K)} 아이템 {(Item2 == null ? "없음" : "있음")}");
        }


        public void Dummy<Tkey, TValue>()
        {

        }
    }
}
