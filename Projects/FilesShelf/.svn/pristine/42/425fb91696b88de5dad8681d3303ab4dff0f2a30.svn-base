using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesShelf.SQLite;
using System.Data;

namespace FilesShelf.Models.Database
{
    public class DbTask:FilesShelfDbObject
    {
        public static void Insert(string taskString, SQLiteDatabase db)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("taskString", SQLiteDatabase.EscapeSpecialChars(taskString));
                data.Add("taskStatus", "0");
                db.Insert("Tasks", data);
            }
            catch (Exception fail)
            {
                throw new FSSQLiteException("An error occurred when trying to insert a new task.");
            }
        }

        public static void SetToFailed(string id, SQLiteDatabase db)
        {
            ChangeState(id, 2, db);
        }

        private static void ChangeState(string id, int stateCode, SQLiteDatabase db)
        {
            try
            {
                int res = db.ExecuteNonQuery(String.Format("UPDATE Tasks SET taskStatus={1} WHERE id={0}", id, stateCode));
            }
            catch (Exception fail)
            {
                throw new FSSQLiteException("An error occurred when trying to update a task.");
            }
        }

        public static void SetInProgress(string id, SQLiteDatabase db)
        {
            ChangeState(id, 1, db);
        }

        public static void SetToCompleted(string id, SQLiteDatabase db)
        {
            ChangeState(id, 3, db);
        }

        public static Task[] SelectAllTasks(SQLiteDatabase db)
        {
            try
            {
                List<Task> tasks = new List<Task>();
                DataTable resultSet = db.GetDataTable("SELECT * FROM 'Tasks' WHERE taskStatus>=0 ORDER BY taskStatus DESC");
                foreach (DataRow row in resultSet.Rows)
                {
                    Task tsk = new Task();
                    tsk.PathName = row["taskString"].ToString();
                    tsk.ID = row["id"].ToString();
                    tsk.ISBN = row["ISBN"].ToString();
                    string taskStatus = row["taskStatus"].ToString();
                    switch (int.Parse(taskStatus))
                    {
                        case 1:
                            tsk.CurrentState = State.InProgress;
                            break;
                        case 2:
                            tsk.CurrentState = State.Failed;
                            break;
                        case 3:
                            tsk.CurrentState = State.Completed;
                            break;
                        default:
                            tsk.CurrentState = State.Waiting;
                            break;
                    }
                    tasks.Add(tsk);
                }
                return tasks.ToArray();
            }
            catch (Exception fail)
            {
                throw new FSSQLiteException("An error occurred when trying to select a task.");
            }
        }

        public static void DeleteUnusedTasks(SQLiteDatabase db)
        {
            try
            {
                db.Delete("Tasks", "taskStatus=3");
            }
            catch (Exception fail)
            {
                throw new FSSQLiteException("An error occurred when trying to delete a task.");
            }
        }        

        public static void RefreshTasks(SQLiteDatabase db)
        {
            try
            {
                //UPDATE Tasks SET taskStatus=1 WHERE id=(SELECT id FROM Tasks WHERE taskStatus=0 LIMIT 1)
                db.ExecuteNonQuery("UPDATE Tasks SET taskStatus='3' WHERE id IN (SELECT id FROM Tasks WHERE taskStatus=-7)");
            }
            catch (Exception fail)
            {
                throw new FSSQLiteException("An error occurred when trying to update a task.");
            }
        }

        public static void SetNewItemInProgress(SQLiteDatabase db)
        {
            try
            {
                //UPDATE Tasks SET taskStatus=1 WHERE id=(SELECT id FROM Tasks WHERE taskStatus=0 LIMIT 1)
                db.ExecuteNonQuery("UPDATE Tasks SET taskStatus='1' WHERE id=(SELECT id FROM Tasks WHERE taskStatus=0 LIMIT 1)");
            }
            catch (Exception fail)
            {
                throw new FSSQLiteException("An error occurred when trying to update a task.");
            }
        }



        public static void SetToJustAdded(string id, SQLiteDatabase db)
        {
            ChangeState(id, -7, db);
        }

        public static void UpdateISBN(string id, string ISBN, SQLiteDatabase db)
        {
            try
            {
                //UPDATE Tasks SET taskStatus=1 WHERE id=(SELECT id FROM Tasks WHERE taskStatus=0 LIMIT 1)
                db.ExecuteNonQuery(String.Format("UPDATE Tasks SET taskStatus='0', ISBN='{1}' WHERE id={0}", id, SQLiteDatabase.EscapeSpecialChars(ISBN)));
            }
            catch (Exception fail)
            {
                throw new FSSQLiteException("An error occurred when trying to update a task.");
            }
        }
    }
}
