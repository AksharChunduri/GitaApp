using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Firestore;
using GeetaAssessments.Models;

namespace GeetaAssessments.Droid.ServiceListeners
{
    public class OnCompleteListener: Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<AuthenticatedUser> _tcs;

        public OnCompleteListener(TaskCompletionSource<AuthenticatedUser> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var result = task.Result;
                if( result is DocumentSnapshot doc)
                {
                    var user = new AuthenticatedUser();
                    user.ID = doc.Id;
                    Object map = doc.Get("Roles");
                    //user.Roles = (List<String>)doc.Get("Roles");
                    user.Location = doc.GetString("Location");
                    _tcs.TrySetResult(user);
                }
            }
            _tcs.TrySetResult(default(AuthenticatedUser));
        }
    }
}
