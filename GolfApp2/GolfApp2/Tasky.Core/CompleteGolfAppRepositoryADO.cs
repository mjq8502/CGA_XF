using System;
using System.Collections.Generic;
using System.IO;

namespace DataObjects
{
    public class CompleteGolfAppRepositoryADO
    {
        CompleteGolfAppDatabase db = null;
        protected static string dbLocation;
        protected static CompleteGolfAppRepositoryADO me;

        static CompleteGolfAppRepositoryADO()
        {
            me = new CompleteGolfAppRepositoryADO();
        }

        protected CompleteGolfAppRepositoryADO()
        {
            // set the db location
            dbLocation = DatabaseFilePath;

            // instantiate the database	
            db = new CompleteGolfAppDatabase(dbLocation);
        }

        public static string DatabaseFilePath
        {
            get
            {
                var sqliteFilename = "CompleteGolfAppDatabase.db3";
#if NETFX_CORE
				var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else

#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
				var path = sqliteFilename;
#else

#if __ANDROID__
                // Just use whatever directory SpecialFolder.Personal returns
                string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
#endif
                var path = Path.Combine(libraryPath, sqliteFilename);
#endif

#endif
                return path;
            }
        }

        public static Tee GetTee(int id)
        {
            return me.db.GetTee(id);
        }

        public static IEnumerable<Tee> GetTees()
        {
            return me.db.GetTees();
        }

        public static int SaveTee(Tee item)
        {
            return me.db.SaveTee(item);
        }

        public static int DeleteTee(int id)
        {
            return me.db.DeleteTee(id);
        }

        public static Course GetCourse(int id)
        {
            return me.db.GetCourse(id);
        }

        public static Course GetCourse(string newCourseName)
        {
            return me.db.GetCourse(newCourseName);
        }

        public static IEnumerable<Course> GetCourses()
        {
            return me.db.GetCourses();
        }

        public static int SaveCourse(Course item)
        {
            return me.db.SaveCourse(item);
        }

        public static int DeleteCourse(int id)
        {
            return me.db.DeleteCourse(id);
        }


        public static CourseTee GetCourseTee(int id)
        {
            return me.db.GetCourseTee(id);
        }

        public static IEnumerable<CourseTee> GetCourseTees(int courseID)
        {
            return me.db.GetCourseTees(courseID);
        }

        public static IEnumerable<CourseTee> GetAllCourseTees()
        {
            return me.db.GetAllCourseTees();
        }

        public static int SaveCourseTee(CourseTee item)
        {
            return me.db.SaveCourseTee(item);
        }

        public static int DeleteCourseTee(int id)
        {
            return me.db.DeleteCourseTee(id);
        }

        public static IEnumerable<CourseTeeHoleData> GetCourseHoleData(int courseID)
        {
            return me.db.GetCourseHoleData(courseID);
        }

        public static int CreateCourseHolesForTee(int courseTeeID, int numberOfHoles)
        {
            return me.db.CreateCourseHolesForTee(courseTeeID, numberOfHoles);
        }

        public static int UpdateCourseTeeHole(int courseTeeID, int holeNumber, int yards)
        {
            return me.db.UpdateCourseTeeHole(courseTeeID, holeNumber, yards);
        }

        public static int SaveCourseHolePar(int courseID, int holeNumber, int par)
        {
            return me.db.SaveCourseHolePar(courseID, holeNumber, par);
        }

        public static IEnumerable<CourseHoleParData> GetCourseHoleParData(int courseID)
        {
            return me.db.GetCourseHoleParData(courseID);
        }

    }
}

