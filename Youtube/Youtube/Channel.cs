namespace Youtube;

public class Channel(string name)
{
    public string Name { get; } = name;
    public List<ChannelSubscriber> Subscribers { get; set; } = [];
    public List<Video> Videos { get; private set; } = [];
    public void BeSubcribed(ChannelSubscriber subscriber)
    {
        Subscribers.Add(subscriber);
    }
    public void BeUnsubcribed(ChannelSubscriber subscriber)
    {
        var subcribers = Subscribers.ToList();
        subcribers.Remove(subscriber);
        Subscribers = subcribers;
    }
    public void Upload(Video video)
    {
        Videos.Add(video);
        Console.WriteLine($@"頻道 {Name} 上架了一則新影片 ""{video.Title}""。");
        Notify(video);

    }
    private void Notify(Video video)
    {
        foreach(var subcriber in Subscribers)
            subcriber.BeNotified(video);
    }
}
