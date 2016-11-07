namespace DayCare.Db
{
    public class ApplicationDbContextMessage
    {
        public static string VALID = "The {0} data is not valid!";
        public static string INVALID = "The {0} data is invalid!";
        public static string EXISTS = "The {0} {1} exists!";
        public static string NOTEXISTS = "The {0} {1} doesn't exists anymore!";
        public static string CREATEOK = "Created the {0} {1} in the database!";
        public static string CREATENOK = "Could not creat the {0} {1} in the database!";
        public static string EDITOK = "Updated the {0} {1} in the database!";
        public static string EDITNOK = "Could not update the {0} {1} in the database!";
        public static string DELETEOK = "Deleted the {0} {1} in the database!";
        public static string DELETENOK = "Could not delete the {0} {1} in the database!";
        public static string SOFTDELETEOK = "Soft-deleted the {0} {1} in the database!";
        public static string SOFTDELETENOK = "Could not soft-delete the {0} {1} in the database!";
        public static string SOFTUNDELETEOK = "Soft-undeleted the {0} {1} in the database!";
        public static string SOFTUNDELETENOK = "Could not soft-undelete the {0} {1} in the database!";
        public static string ENABLETWOFACTOROK = "Enabled Two Factor for the {0} {1} in the database!";
        public static string ENABLETWOFACTORNOK = "Could not enable Two Factor for the {0} {1} in the database!";
        public static string DISABLETWOFACTOROK = "Disabled Two Factor for the {0} {1} in the database!";
        public static string DISABLETWOFACTORNOK = "Could not disable Two Factor for the {0} {1} in the database!";
    }
}