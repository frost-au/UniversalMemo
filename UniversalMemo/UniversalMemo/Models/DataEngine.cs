using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;


namespace UniversalMemo.Models
{
    public sealed class DataEngine
    {
        // Use interop to call the CreateFile function.
        // For more information about CreateFile,
        // see the unmanaged MSDN reference library.
        private static string DbName = "db.db";
        private static string Path = Xamarin.Essentials.FileSystem.AppDataDirectory + "/" + DbName;
        public static List<Folder> Folders { get; set; }
        public static List<Item> Items { get; set; }
        private static DataEngine Instance { get; set; }

        public DataEngine()
        {
            if (DataEngine.Instance == null)
            {
                DataEngine.Instance = this;
                DataEngine.Instance.CreateTestFolderData();
            }
        }

        public void CreateTestFolderData()
        {
            Folders = new List<Folder>
            {
                new Folder(Guid.NewGuid(), "Test Folder", DateTime.Now),
                new Folder(Guid.NewGuid(), "Test Folder2", DateTime.Now),
                new Folder(Guid.NewGuid(), "Test Folder3", DateTime.Now)
            };

            var db = new SQLiteConnection(Path);

            try
            {
                db.DeleteAll<Folder>();
            }
            catch {
                Console.WriteLine("Error with writing Folders");
            } finally
            {
                db.Close();
            }

            Items = new List<Item>
            {
                new Item(Guid.NewGuid(), Folders[0].BelongsTo, "Item of Joy", "A Working item brings much joy", "This is awesome!", DateTime.Now),
                new Item(Guid.NewGuid(), Folders[1].BelongsTo, "Item of Sadness", "A Working item brings much Sadness", "This is crap!", DateTime.Now),
                new Item(Guid.NewGuid(), Folders[2].BelongsTo, "Item of Average", "A Working item brings much average", "This is average!", DateTime.Now),
                new Item(Guid.NewGuid(), Folders[2].BelongsTo, "Item of justice", "A Working item brings much justice", "This is justice!", DateTime.Now),
                new Item(Guid.NewGuid(), Folders[0].BelongsTo, "Item of blackmagic", "A Working item brings much blackmagic", "This is blackmagic!", DateTime.Now),
                new Item(Guid.NewGuid(), Folders[2].BelongsTo, "Item of voodoo", "A Working item brings much voodoo", "This is voodoo!", DateTime.Now)
             };

            readData(typeof(Folder));
            readData(typeof(Item));
        }

        public void AddToDb(object NewTuple)
        {
            var db = new SQLiteConnection(Path);
            String TupleType = NewTuple.GetType().ToString();
            Console.WriteLine("Type passed is " + TupleType);

            //Adds the object to a table
            try
            {
                string Query = "";
                TableMapping mapping;
                List<Folder> FolderResult;
                List<Item> ItemResult;
                switch (TupleType)
                {
                    case "UniversalMemo.Models.Folder":
                        db.CreateTable<Folder>();
                        mapping = db.GetMapping<Folder>();
                        Query = String.Format("select * from {0};", mapping.TableName);
                        FolderResult = db.Query<Folder>(Query);
                        
                        break;

                    case "UniversalMemo.Models.Item":
                        db.CreateTable<Item>();
                        mapping = db.GetMapping<Item>();
                        Query = String.Format("select * from {0};", mapping.TableName);
                        ItemResult = db.Query<Item>(Query);
                        
                        break;
                }
                db.Insert(NewTuple);
                mapping = db.GetMapping<Folder>();
                Query = String.Format("SELECT * FROM {0};", mapping.TableName);
                var result = db.Query<Folder>(Query);
                Console.WriteLine("results are: " + result.Count());
            }
            catch
            {
                Console.WriteLine("Did not write table or insert something Type: " + NewTuple.GetType().ToString());
            }
            finally
            {
                db.Close();
            }
        }

        public static List<Item> GetItemByFolderID(Guid Key)
        {
            var db = new SQLiteConnection(Path);
            TableMapping Mapping = db.GetMapping<Item>();
            String Query = String.Format("SELECT * FROM {0} WHERE BelongsTo ={1}", Mapping.TableName, Key.ToString());
            List<Item> Results = db.Query<Item>(Query);

            return Results;
        }

        public static Item GetItemByID(Guid Key)
        {
            var db = new SQLiteConnection(Path);
            TableMapping Mapping = db.GetMapping<Item>();
            String Query = String.Format("SELECT * FROM {0} WHERE key ={1}", Mapping.TableName, Key.ToString());
            Item Results = db.Query<Item>(Query)[0];

            return Results;
        }

        public static Folder GetFolderByID(Guid Key)
        {
            var db = new SQLiteConnection(Path);
            TableMapping Mapping = db.GetMapping<Folder>();
            String Query = String.Format("SELECT * FROM {0} WHERE key ={1}", Mapping.TableName, Key.ToString());
            Folder Results = db.Query<Folder>(Query)[0];

            return Results;
        }

        public static List<Folder> getFolders()
        {
            var db = new SQLiteConnection(Path);
            TableMapping Mapping = db.GetMapping<Folder>();
            String Query = String.Format("SELECT * FROM {0}", Mapping.TableName);
            List<Folder> Results = db.Query<Folder>(Query);
            Folders = Results;
            return Results;
        }

        public static List<Item> getAllItems()
        {
            var db = new SQLiteConnection(Path);
            TableMapping mapping = db.GetMapping<Item>();
            String Query = String.Format("select * from {0};", mapping.TableName);
            var Results = db.Query<Item>(Query);
            Items = Results as List<Item>;
            return Results;
        }
        public void readData(Type Readtype)
        {
            var db = new SQLiteConnection(Path); 
            try
            {
                TableMapping mapping;
                String Query;
                switch (Readtype.ToString())
                {
                    case "UniversalMemo.Models.Folder":
                        db.CreateTable<Folder>();
                        mapping = db.GetMapping<Folder>();
                        Query = String.Format("select * from {0};", mapping.TableName);
                        Folders = db.Query<Folder>(Query);
                        Console.WriteLine("Restored Items from DB");
                        break;

                    case "UniversalMemo.Models.Item":
                        db.CreateTable<Item>();
                        mapping = db.GetMapping<Item>();
                        Query = String.Format("select * from {0};", mapping.TableName);
                        Items = db.Query<Item>(Query);
                        Console.WriteLine("Restored Items from DB");
                        break;
                }
            }
            catch{}finally
            {
                db.Close();
            }
        }

    }
}