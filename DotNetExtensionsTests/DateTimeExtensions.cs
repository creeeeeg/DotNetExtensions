using System;
using NUnit.Framework;

[TestFixture]
public class DateTimeExtensions
{
    private double time;
    private DateTime Now
        , Near1
        , Near2
        , Seconds_Ago
        , Seconds_Later
        , Minutes_Ago
        , Minutes_Later
        , Hours_Ago
        , Hours_Later;

    private Boolean yFlair
        , nFlair;

    private string OutOfRangeDateFormat
        , YesterdayDateFormat
        , TomorrowDateFormat
        , prefix
        , suffix;

    [SetUp]
    protected void Setup()
    {
        time = 3;
        Now = DateTime.Now;
        Near1 = DateTime.Now.AddTicks(-99);
        Near2 = DateTime.Now.AddTicks(99);
        Seconds_Ago = DateTime.Now.AddSeconds(-time);
        Seconds_Later = DateTime.Now.AddSeconds(time);
        Minutes_Ago = DateTime.Now.AddMinutes(-time);
        Minutes_Later = DateTime.Now.AddMinutes(time);
        Hours_Ago = DateTime.Now.AddHours(-time);
        Hours_Later = DateTime.Now.AddHours(time);
        yFlair = true;
        nFlair = false;
        OutOfRangeDateFormat = "MM/dd/yyyy HH:mm tt";
        YesterdayDateFormat = "HH:mm tt";
        TomorrowDateFormat = "HH:mm tt";
        prefix = "in ";
        suffix = " ago";
    }

    [Test]
    public void TestNow()
    {
        Console.Write(Seconds_Ago);
        var result = Near1.ToShort();
        Assert.AreEqual(result, "now");
    }
    [Test]
    public void SecondsAgo()
    {
        var result = Seconds_Ago.ToShort();
        Assert.AreEqual(result, time + "s" + suffix);
    }
    [Test]
    public void SecondsLater()
    {
        var result = Seconds_Later.ToShort();
        Assert.AreEqual(result, prefix + time + "s");
    }
    [Test]
    public void MinutesAgo()
    {
        var result = Minutes_Ago.ToShort();
        Assert.AreEqual(result, time + "m" + suffix);
    }
    [Test]
    public void MinutesLater()
    {
        var result = Minutes_Later.ToShort();
        Assert.AreEqual(result, prefix + time + "m");
    }
    [Test]
    public void HoursAgo()
    {
        var result = Hours_Ago.ToShort();
        Assert.AreEqual(result, time + "h" + suffix);
    }
    [Test]
    public void HoursLater()
    {
        var result = Hours_Later.ToShort();
        Assert.AreEqual(result, prefix + time + "h");
    }
}