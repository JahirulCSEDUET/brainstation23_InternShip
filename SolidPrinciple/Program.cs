using SolidPrinciple.Following;

var alerts = new List<INotification>
{
    new EmailNotification
    {
        EmailAddress="jahirulcseduet@gmail.com",
        Subject="System alert",
        Message ="Server is down!"
    },
    new SmsNotification
    {
        PhoneNumber ="+8801626467279",
        Message ="Server is down!"
    },
    new PushNotification
    {
        DeviceToken="jdsxchsnls",
        Message="Server is down!"
    }
};
foreach(var alert in alerts)
{
    alert.send();
}