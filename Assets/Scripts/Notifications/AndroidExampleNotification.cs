using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class AndroidExampleNotification : MonoBehaviour
{
    /*
     * Bildirim kanalları, farklı türdeki bildirimleri gruplamak veya ayırmak için kullanılır. 
     */
    [SerializeField] private int notificationId; // Bildirimlerin kimliğini tutacak olan değişken.
    [SerializeField] private string channelIdExample; //  Bildirim kanalının örnek kimliğini tutacak değişken.
    [SerializeField] private string channelName;

    [SerializeField] private string _title = "Where Have You Been!";
    [SerializeField] private string _text = "Come back and play, WE MISS YOU";
    [SerializeField] private string _smallIcon = "default";
    [SerializeField] private string _largeIcon = "default";

#if UNITY_ANDROID 
    public void NotificationExample(DateTime timeToFire)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = channelIdExample,
            Name = channelName,
            Description = "This is just an example",
            Importance = Importance.Default
        };
        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel); // // Bildirim kanalını kayde
        AndroidNotification notification = new AndroidNotification()
        {
            Title = _title,
            Text = _text,
            SmallIcon = _smallIcon,
            LargeIcon = _largeIcon,
            FireTime = timeToFire

        };
        //AndroidNotificationCenter.SendNotification(notification, channelIdExample);
        AndroidNotificationCenter.SendNotificationWithExplicitID(notification,channelIdExample,notificationId); // Oluşturulan bildirim belirtilen kanala ve kimliğe gönderiliyor.
        
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus == false)
        {
            DateTime whenToFire = DateTime.Now.AddDays(1); // 1 gün sonra gönderim için tarih belirle
            NotificationExample(whenToFire); // Bildirim örneğini çağır
        }
        else
        {
            AndroidNotificationCenter.CancelScheduledNotification(notificationId);  // Zamanlanmış bildirimi iptal et
        }
    }
    #endif
}
