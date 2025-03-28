using System;
using System.Collections.Generic;
using System.Linq;
namespace DelegateSample
{
    class Subscriber
    {
        public Subscriber(string nickname)
        {
            Nickname = nickname;
        }

        public string Nickname {get; set; }

        public void Notification(Youtuber youtuber, Content content)
        {
            Console.WriteLine($"{Nickname} 에게 알림! {youtuber.Nickname} 이(가) {content.Title} 게시함.");
        }
    }
}
