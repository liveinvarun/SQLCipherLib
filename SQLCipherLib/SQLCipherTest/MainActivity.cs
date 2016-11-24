using Android.App;
using Android.Widget;
using Android.OS;

using Java.IO;
using Net.Sqlcipher.Database;

namespace SQLCipherTest
{
    [Activity(Label = "SQLCipherTest", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            SQLiteDatabase.LoadLibs(this);

            File databaseFile = GetDatabasePath("sample.db3");
            databaseFile.Mkdirs();
            databaseFile.Delete();
            SQLiteDatabase database = SQLiteDatabase.OpenOrCreateDatabase(databaseFile, "sample123", null);
            database.ExecSQL("create table test(id, name, age, postcode)");
            database.ExecSQL("insert into test(id,name,  age, postcode) values(?,?,?,?)",
                             new Java.Lang.Object[]{
                                                     1,"John",32,789012
                                                                        });
            database.Close();

            // ("Completed the database creation");
        }
    }
}

