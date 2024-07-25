namespace Youtube;

public interface ISubscribeNotifiedBehavior
{
    void Action(ChannelSubscriber subscriber, Video video);
}
