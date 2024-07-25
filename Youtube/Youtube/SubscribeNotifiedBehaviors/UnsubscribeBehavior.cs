using Youtube.Common.Constants;

namespace Youtube.SubscribeNotifiedBehaviors;

public class UnsubscribeBehavior : ISubscribeNotifiedBehavior
{
    public void Action(ChannelSubscriber subscriber, Video video)
    {
        if (video.Lenght <= 1 * AppConstants.Minute)
        {
            var channel = video.Channel;
            subscriber.Unsubcribe(channel);
        }
    }
}
