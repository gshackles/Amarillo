using System;
using System.Reflection;
using Android.App;
using Android.NUnitLite.UI;
using Android.OS;

namespace Amarillo.IntegrationTests.Droid
{
    [Activity(Label = "Amarillo.IntegrationTests.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class TestRunnerActivity : RunnerActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Add(Assembly.GetExecutingAssembly());

            base.OnCreate(bundle);
        }
    }
}

