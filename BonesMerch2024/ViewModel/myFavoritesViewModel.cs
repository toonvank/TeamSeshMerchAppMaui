using BonesAlbumInfoApp.Model;
using BonesAlbumInfoApp.PassObjects;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonesAlbumInfoApp.ViewModel
{
    public partial class myFavoritesViewModel /*: INotifyPropertyChanged*/
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        //private ObservableCollection<rssChannelItem> likedMerch1;
        //public ObservableCollection<rssChannelItem> likedMerch
        //{
        //    get => likedMerch1; set
        //    {
        //        likedMerch1 = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(likedMerch)));
        //    }
        //}
        //IFirebaseConfig fcon = new FireSharp.Config.FirebaseConfig()
        //{
        //    AuthSecret = "O1itSeLoiYkjfMjzk3iv9q4wK99k70VkJ0COQPMZ",
        //    BasePath = "https://bonesinfoapp-default-rtdb.europe-west1.firebasedatabase.app/"
        //};
        ////IFirebaseClient client;
        //IFirebaseClient client;
        //string UID = Preferences.Default.Get("userid", "Unknown");
        //public myFavoritesViewModel()
        //{
        //    if (UID != null)
        //    {
        //        client = new FireSharp.FirebaseClient(fcon);
        //        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey: "AIzaSyAjUEQRl2QC5-Zt0Skxk9-53rKHtw7dxkM"));
        //        var setter = client.Get($"Users/{UID}/Likes/");
        //        if (setter.Body != "null")
        //        {
        //            string userLikes = setter.Body.Substring(1, setter.Body.Length - 2);
        //            string[] userLikesArray = userLikes.Split(',');
        //            List<int> userLikesList = new List<int>();
        //            if (userLikesArray.Contains<string>("null"))
        //            {
        //                // put in array where not equal to "null" and then use that array
        //                foreach (string item in userLikesArray)
        //                {
        //                    if (item != "null")
        //                    {
        //                        userLikesList.Add(int.Parse(item));
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                foreach (string item in userLikesArray)
        //                {
        //                    userLikesList.Add(int.Parse(item));
        //                }
        //            }
        //            ObservableCollection<rssChannelItem> items = new ObservableCollection<rssChannelItem>();
        //            foreach (var item in userLikesList)
        //            {
        //                for (int i = 0; i < DataPass.loadedMerch.Count; i++)
        //                {
        //                    if (DataPass.loadedMerch[i].idField == item)
        //                    {
        //                        items.Add(DataPass.loadedMerch[i]);
        //                    }
        //                }
        //            }
        //            likedMerch = items;
        //        }
        //    }
        //}
        //[RelayCommand]
        //public async Task RefreshDelete()
        //{
        //    client = new FireSharp.FirebaseClient(fcon);
        //    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey: "AIzaSyAjUEQRl2QC5-Zt0Skxk9-53rKHtw7dxkM"));
        //    var setter = client.Get($"Users/{UID}/Likes/");
        //    if (setter.Body != "null")
        //    {
        //        string userLikes = setter.Body.Substring(1, setter.Body.Length - 2);
        //        string[] userLikesArray = userLikes.Split(',');
        //        List<int> userLikesList = new List<int>();
        //        if (userLikesArray.Contains<string>("null"))
        //        {
        //            // put in array where not equal to "null" and then use that array
        //            foreach (string item in userLikesArray)
        //            {
        //                if (item != "null")
        //                {
        //                    userLikesList.Add(int.Parse(item));
        //                }
        //            }
        //        }
        //        else
        //        {
        //            foreach (string item in userLikesArray)
        //            {
        //                userLikesList.Add(int.Parse(item));
        //            }
        //        }
        //        ObservableCollection<rssChannelItem> items = new ObservableCollection<rssChannelItem>();
        //        foreach (var item in userLikesList)
        //        {
        //            for (int i = 0; i < DataPass.loadedMerch.Count; i++)
        //            {
        //                if (DataPass.loadedMerch[i].idField == item)
        //                {
        //                    items.Add(DataPass.loadedMerch[i]);
        //                }
        //            }
        //        }
        //        likedMerch.Clear();
        //        foreach (var item in items)
        //        {
        //            likedMerch.Add(item);
        //        }
        //    }
        //    else
        //    {
        //        likedMerch.Clear();
        //    }
        //}
    }
}
