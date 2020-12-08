using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Firestore;
using GeetaAssessments.Droid.ServiceListeners;
using GeetaAssessments.Models;
using GeetaAssessments.Services;
using Java.Util;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Linq;

[assembly: Dependency(typeof(GeetaAssessments.Droid.Services.FirestoreService))]
namespace GeetaAssessments.Droid.Services
{
    public class FirestoreService:Java.Lang.Object, IFirestore, IOnCompleteListener
    {
        private static Firebase.FirebaseApp app;
        public bool HasLocations { get; set; }
        public List<Locations> AllLocations { get; set; }

        public static FirebaseFirestore Instance
        {
            get
            {
                return FirebaseFirestore.GetInstance(app);
            }
        }

        public FirestoreService()
        {
            if(AllLocations == null)
                AllLocations = new List<Locations>();
        }

        public static string AppName { get; } = "GeetaAssessments.Android";

        public static void Init(Android.Content.Context context)
        {
            var baseOptions = Firebase.FirebaseOptions.FromResource(context);
            var options = new Firebase.FirebaseOptions.Builder(baseOptions).SetProjectId(baseOptions.StorageBucket.Split('.')[0]).Build();
            app = Firebase.FirebaseApp.InitializeApp(context, options, AppName);
            
        }

        public async Task<List<Locations>> GetLocations()
        {
            HasLocations = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("Locations");
            var document = collection.Get().AddOnCompleteListener(this);
    
            for(int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (HasLocations)
                    break;
            }
            return AllLocations;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;


                foreach (var doc in documents.Documents)
                {
                    Locations loc = new Locations();
                    loc.Centers = new List<string>();

                    loc.Location = (string)doc.Get("Location");
                    var centersDoc = doc.Get("Centers");
                    var centersList = new Android.Runtime.JavaList((System.Collections.IEnumerable)centersDoc);

                    var list = centersList.ToArray();
                  
                    for(int i = 0; i < list.Length; i++)
                    {
                        var o = (Java.Lang.Object)list[i].ToString();

                        loc.Centers.Add((string)o);
                    }     

                    AllLocations.Add(loc);
                }
                HasLocations = true;
            }
            else
            {
                AllLocations.Clear();
            }
        }

    }
}
