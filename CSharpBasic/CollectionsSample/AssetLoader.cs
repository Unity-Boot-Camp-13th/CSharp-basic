/*
 * 이건 그냥 IDisposable 이해용 샘플이니까 내부구현 디테일은 공부하지 마삼
 */

using System.Runtime.InteropServices;

namespace CollectionsSample
{
    /// <summary>
    /// IDisposable : 자원을 명시적으로 해제하기 위한 인터페이스
    /// </summary>
    class AssetLoader : IDisposable
    {
        IntPtr _pAsset; // 메모리 주소를 저장할 포인터 (관리되지 않는 메모리 위치)
        bool _disposed; // 한 번 해제했는지 여부를 추적
        const int KB = 1_024; // 1024 바이트

        /// <summary>
        /// 1KB 크기의 메모리를 직접 할당(관리되지 않는 힙)
        /// 이 메모리는 GC가 알아서 해제해주지 않으므로, 나중에 직접 FreeHGlobal()로 해줘야함
        /// </summary>
        public void Load()
        {
            _pAsset = Marshal.AllocHGlobal(1 *  KB); // 임의로 관리되지 않는 힙메모리에 1KB 할당
        }

        /// <summary>
        /// 외부에서 
        /// </summary>
        public void Dispose()
        {
            Dispose(_disposed);
            GC.SuppressFinalize(this); // 이 객체 소멸자 호출하지 말라고 하는 것 (소멸자 함수 호출 오버헤드를 없애기 위해서)
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                return;

            if (_pAsset != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_pAsset); // 직접 할당한 메모리 해제
                _pAsset = IntPtr.Zero;        // 이중 해제 방지
            }

            _disposed = true;
        }
    }
}
