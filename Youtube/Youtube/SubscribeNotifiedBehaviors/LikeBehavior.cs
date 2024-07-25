using Youtube.Common.Constants;

namespace Youtube.SubscribeNotifiedBehaviors;

public class LikeBehavior : ISubscribeNotifiedBehavior
{
    public void Action(ChannelSubscriber subscriber, Video video)
    {
        if (video.Lenght >= 3 * AppConstants.Minute)
            Console.WriteLine($@"{subscriber.Name} 對影片 ""{video.Title}"" 按讚。");
    }
}
