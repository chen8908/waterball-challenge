namespace Youtube;

public class Video(Channel channel, string title, string description, int lenght)
{
    public Channel Channel { get; } = channel;
    public string Title { get; } = title;
    public string Description { get; } = description;
    public int Lenght { get; } = lenght;
}
