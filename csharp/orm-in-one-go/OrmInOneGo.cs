using System;

public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        this.database.BeginTransaction();

        try 
        { 
            this.database.Write(data);
            this.database.EndTransaction();

        }
        catch(Exception e)
        {
            this.database.Dispose();
            throw e;
        }
    }

    public bool WriteSafely(string data)
    {
        try
        {
            this.Write(data);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
