namespace Youtube;

public class ChannelSubscriber(string name)
{
    public string Name { get; } = name;
    public List<Channel> SubcribedChannels { get; private set; } = [];
    public List<ISubscribeNotifiedBehavior> NotifiedBehaviors { get; private set; } = [];

    public void Subcribe(Channel channel)
    {
        SubcribedChannels.Add(channel);
        channel.BeSubcribed(this);
        Console.WriteLine($"{Name} 訂閱了 {channel.Name}。");
    }
    public void Unsubcribe(Channel channel)
    {
        var channels =  SubcribedChannels.ToList();
        channels.Remove(channel);
        SubcribedChannels = channels;
        channel.BeUnsubcribed(this);
        Console.WriteLine($"{Name} 解除訂閱了 {channel.Name}。");
    }
    public void BeNotified(Video video)
    {
        foreach (var behavior in NotifiedBehaviors)
            behavior.Action(this, video);
    }
    public void Register(ISubscribeNotifiedBehavior subscribeNotifiedBehavior)
    {
        NotifiedBehaviors.Add(subscribeNotifiedBehavior);
    }
}
