using Youtube;
using Youtube.Common.Constants;
using Youtube.SubscribeNotifiedBehaviors;

// init
var waterBall = new ChannelSubscriber("水球");
var fireBall = new ChannelSubscriber("火球");
var pewDiePie = new Channel("PewDiePie");
var waterballsa = new Channel("水球軟體學院");
var likeBehavior = new LikeBehavior();
var unsubscribeBehavior = new UnsubscribeBehavior();

// behavior register
waterBall.Register(likeBehavior);
fireBall.Register(unsubscribeBehavior);

// subscriber subcribe channel
waterBall.Subcribe(pewDiePie);
waterBall.Subcribe(waterballsa);
fireBall.Subcribe(pewDiePie);
fireBall.Subcribe(waterballsa);

// channels upload video
waterballsa.Upload(new Video(waterballsa, "C1M1S2", "這個世界正是物件導向的呢！", 4 * AppConstants.Minute));
pewDiePie.Upload(new Video(pewDiePie, "Hello guys", "Clickbait", 30));
waterballsa.Upload(new Video(waterballsa, "C1M1S3", "物件 vs. 類別", 1 * AppConstants.Minute));
pewDiePie.Upload(new Video(pewDiePie, "Minecraft", "Let's play Minecraft", 30 * AppConstants.Minute));
