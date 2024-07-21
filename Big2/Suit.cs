using System.ComponentModel;

namespace Big2;

public enum Suit
{
    /// <summary>
    /// 梅花
    /// </summary>
    [Description("♣")]
    Club,
    /// <summary>
    /// 菱形
    /// </summary>
    [Description("♦")]
    Rhombus, 
    /// <summary>
    /// 愛心
    /// </summary>
    [Description("♥")]
    Heart, 
    /// <summary>
    /// 黑桃
    /// </summary>
    [Description("♠")]
    Spade
}
