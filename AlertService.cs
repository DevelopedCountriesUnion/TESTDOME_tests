//  	Difficulty: Easy
//  	Duration: 10min
//Refactor the AlertService and AlertDAO classes:
//1. Create a new interface, named IAlertDAO, that contains the same methods as AlertDAO.
//2. AlertDAO should implement the IAlertDAO interface.
//3. AlertService should have a constructor that accepts IAlertDAO.
//4. The RaiseAlert and GetAlertTime methods should use the object passed through the constructor.

	// Beginning codes 
using System.Collections.Generic;
using System;

public class AlertService	
{
    private readonly AlertDAO storage = new AlertDAO();
	
    public Guid RaiseAlert()
    {
        return this.storage.AddAlert(DateTime.Now);
    }
	
    public DateTime GetAlertTime(Guid id)
    {
        return this.storage.GetAlert(id);
    }	
}
	
public class AlertDAO
{
    private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();
	
    public Guid AddAlert(DateTime time)
    {
        Guid id = Guid.NewGuid();
        this.alerts.Add(id, time);
        return id;
    }
	
    public DateTime GetAlert(Guid id)
    {
        return this.alerts[id];
    }	
}

===============================================================================

	//Solution codes 3/3 passed
using System.Collections.Generic;
using System;

public class AlertService	
{
	//3. AlertService should have a constructor that accepts IAlertDAO.
    private readonly IAlertDAO storage;    //transfer parameter "storage" to IAlertDAO
	
    public AlertService(IAlertDAO alert)	// Then Create a class constructor with a parameter
    {
        storage = alert;
    }
	

    
    public Guid RaiseAlert()
    {
        
        return this.storage.AddAlert(DateTime.Now);
    }
	
    public DateTime GetAlertTime(Guid id)
    {
        return this.storage.GetAlert(id);
    }	
}

public class AlertDAO : IAlertDAO  //2. AlertDAO should implement the IAlertDAO interface.
{
    private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();
	
    public Guid AddAlert(DateTime time)  //method here
    {
        Guid id = Guid.NewGuid();
        this.alerts.Add(id, time);
        return id;
    }
	
    public DateTime GetAlert(Guid id)  //method here
    {
        return this.alerts[id];
    }	
}

//1. Create a new interface, named IAlertDAO, 
public interface IAlertDAO
{
	// that contains the same methods as AlertDAO.
    Guid AddAlert(DateTime time);
    DateTime GetAlert(Guid id);
}

    




